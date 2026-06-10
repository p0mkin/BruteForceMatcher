using System;
using System.Windows.Forms;

namespace BruteForceMatcher
{
    public partial class Form1 : Form
    {
        private string _targetHashToCrack;   // hashed password
        public Form1()
        {
            InitializeComponent();
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
        private void button4_Click(object sender, EventArgs e)   // RANDOM GEN PASSWORD 
        {
            int chosenLength = (int)numericUpDown1.Value;// Read length value
            
            string newPassword = PasswordManager.GenerateRandomPassword(chosenLength); // Generate
            
            textBox1.Text = newPassword; // Set to view
            
            _targetHashToCrack = HashValidator.GenerateHash(newPassword); // Hash and save to variable
            
            MessageBox.Show($"{chosenLength}-character password generated and hashed!", "Ready");
        }
        private void button2_Click(object sender, EventArgs e) // start
        {
        }

        private void button3_Click(object sender, EventArgs e) // stop
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // enter password
        {
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e) // result
        {
        }

        private void label1_Click(object sender, EventArgs e) // elapsed time
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}