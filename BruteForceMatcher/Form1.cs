using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BruteForceMatcher
{
    public partial class Form1 : Form
    {
        private string _targetHashToCrack;   // hashed password
        private CancellationTokenSource _cancellationTokenSource; 
        private Stopwatch _stopwatch; 
        
        private System.Windows.Forms.Timer _uiTimer; 
        private long _lastLiveUpdate = 0; 

        public Form1()
        {
            InitializeComponent();
            
            // ADDED: Setup Timer for live clock
            _uiTimer = new System.Windows.Forms.Timer();
            _uiTimer.Interval = 100; 
            _uiTimer.Tick += UiTimer_Tick;
        }
        
        private void UiTimer_Tick(object sender, EventArgs e)
        {
            if (_stopwatch != null && _stopwatch.IsRunning)
            {
                label1.Text = $"Elapsed Time: {_stopwatch.Elapsed:hh\\:mm\\:ss\\.ff}";
            }
        }

        private void button1_Click(object sender, EventArgs e)  // MANUALLY SET PASSWORD
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) 
            {
                MessageBox.Show("Enter password first.");
                return;
            }
            _targetHashToCrack = HashValidator.GenerateHash(textBox1.Text);   // Hash the password 
            MessageBox.Show("Password hashed.", "Ready");
        }
                                                            // Button 1 ir 4, Set ir Gen -> 2.a. 
        private void button4_Click(object sender, EventArgs e)   // RANDOM GEN PASSWORD 
        {
            int chosenLength = (int)numericUpDown1.Value;
            
            string newPassword = PasswordManager.GenerateRandomPassword(chosenLength); // Generate
            
            textBox1.Text = newPassword; // Set to view
            
            _targetHashToCrack = HashValidator.GenerateHash(newPassword); // Hash and save to variable
            
            MessageBox.Show($"{chosenLength}-character password generated and hashed!", "Ready");
        }

        private async void button2_Click(object sender, EventArgs e) // start
        {
            if (string.IsNullOrEmpty(_targetHashToCrack))
            {
                MessageBox.Show("Please set or generate a target password first!");
                return;
            }

            // 1. Lock the UI and start the Progress Bar animation
            button2.Enabled = false; 
            button3.Enabled = true;  
            label3.Text = "Attacking..."; 
            label1.Text = "Elapsed Time: 00:00:00";
            
            progressBar1.Style = ProgressBarStyle.Marquee; // Makes the bar slide side to side
            progressBar1.MarqueeAnimationSpeed = 30;

            _cancellationTokenSource = new CancellationTokenSource();
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            _uiTimer.Start(); 

            bool useMultiThreading = checkBox1.Checked;
            bool showLiveUpdates = checkBox3.Checked;

            var validator = new HashValidator(_targetHashToCrack);
            var engine = new BruteForceEngine(validator, showLiveUpdates, UpdateLiveGuessLabel);

            // 2. Run the engine in the background
            string result = await Task.Run(() => engine.RunAttack(useMultiThreading, _cancellationTokenSource.Token));

            
            _stopwatch.Stop();
            _uiTimer.Stop(); 
            
            progressBar1.Style = ProgressBarStyle.Blocks; 
            progressBar1.Value = 100; 
            
            button2.Enabled = true; 
            button3.Enabled = false; 

            // 3. Output the results
            if (_cancellationTokenSource.IsCancellationRequested)
            {
                label3.Text = "Attack Stopped manually.";
                progressBar1.Value = 0; 
            }
            else if (result != null)
            {
                label3.Text = $"Found! Password is '{result}'";
                label1.Text = $"Elapsed Time: {_stopwatch.Elapsed.TotalSeconds:F2} seconds";
            }
            else
            {
                label3.Text = "Not found.";
                progressBar1.Value = 0;
            }
        }
                                                        // button 2 ir 3, start ir stop. 2.b. 4.f.
        private void button3_Click(object sender, EventArgs e) // stop
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel(); 
                button3.Enabled = false; 
            }
        }
        
        // UI, prevent cross-thread crashes for Live Updates
        private void UpdateLiveGuessLabel(string currentGuess)
        {
            // ADDED: 100ms Throttle so the app doesn't freeze
            if (Environment.TickCount64 - _lastLiveUpdate > 100)
            {
                _lastLiveUpdate = Environment.TickCount64;
                
                // FIX: Pointed to label3 instad of label2
                if (label3.InvokeRequired)
                {
                    label3.BeginInvoke(new Action(() => label3.Text = currentGuess));
                }
                else
                {
                    label3.Text = currentGuess;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // enter password 2.a*
        {
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
        }
        
        private void label1_Click_1(object sender, EventArgs e)// elapsed time 2.d.
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) // 2.a*
        {
        }

        private void progressBar1_Click(object sender, EventArgs e) // 2.c 4.f 
        {
        }
        
        private void checkBox3_CheckedChanged(object sender, EventArgs e) // live updates
        {
        }
        
        private void label2_Click_1(object sender, EventArgs e) // current passw:
        {
        }

        private void label3_Click(object sender, EventArgs e) // result 2.e.
        {
        }
    }
}