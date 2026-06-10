namespace BruteForceMatcher;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new System.Windows.Forms.Button();
        textBox1 = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        checkBox1 = new System.Windows.Forms.CheckBox();
        progressBar1 = new System.Windows.Forms.ProgressBar();
        label1 = new System.Windows.Forms.Label();
        numGenLenght = new System.Windows.Forms.NumericUpDown();
        button4 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)numGenLenght).BeginInit();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.Location = new System.Drawing.Point(432, 42);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(52, 27);
        button1.TabIndex = 0;
        button1.Text = "Set\r\n";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(38, 42);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(388, 27);
        textBox1.TabIndex = 1;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // button2
        // 
        button2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button2.Location = new System.Drawing.Point(569, 383);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(109, 42);
        button2.TabIndex = 2;
        button2.Text = "Start Attack";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Enabled = false;
        button3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button3.Location = new System.Drawing.Point(684, 383);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(109, 42);
        button3.TabIndex = 3;
        button3.Text = "Stop Attack";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // checkBox1
        // 
        checkBox1.Location = new System.Drawing.Point(569, 336);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new System.Drawing.Size(219, 41);
        checkBox1.TabIndex = 4;
        checkBox1.Text = "Use Multi-Threading";
        checkBox1.UseVisualStyleBackColor = true;
        checkBox1.CheckedChanged += checkBox1_CheckedChanged_2;
        // 
        // progressBar1
        // 
        progressBar1.ForeColor = System.Drawing.Color.LawnGreen;
        progressBar1.Location = new System.Drawing.Point(38, 383);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new System.Drawing.Size(525, 42);
        progressBar1.TabIndex = 5;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(38, 354);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(216, 23);
        label1.TabIndex = 6;
        label1.Text = "Elapsed Time:";
        label1.Click += label1_Click;
        // 
        // numGenLenght
        // 
        numGenLenght.Location = new System.Drawing.Point(389, 90);
        numGenLenght.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
        numGenLenght.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
        numGenLenght.Name = "numGenLenght";
        numGenLenght.Size = new System.Drawing.Size(37, 27);
        numGenLenght.TabIndex = 7;
        numGenLenght.Value = new decimal(new int[] { 4, 0, 0, 0 });
        numGenLenght.ValueChanged += numericUpDown1_ValueChanged;
        // 
        // button4
        // 
        button4.Location = new System.Drawing.Point(433, 90);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(50, 26);
        button4.TabIndex = 8;
        button4.Text = "Gene";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(button4);
        Controls.Add(numGenLenght);
        Controls.Add(label1);
        Controls.Add(progressBar1);
        Controls.Add(checkBox1);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)numGenLenght).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.NumericUpDown numGenLenght;
    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.ProgressBar progressBar1;

    private System.Windows.Forms.CheckBox checkBox1;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.Button button1;

    #endregion
}