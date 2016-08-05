namespace PrimesCalculator
{
    partial class PrimesCounterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.startTextBox = new System.Windows.Forms.TextBox();
            this.endTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.primesCalculatorLabel = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.sumOfPrimesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startTextBox
            // 
            this.startTextBox.Location = new System.Drawing.Point(74, 41);
            this.startTextBox.Name = "startTextBox";
            this.startTextBox.Size = new System.Drawing.Size(100, 20);
            this.startTextBox.TabIndex = 0;
            // 
            // endTextBox
            // 
            this.endTextBox.Location = new System.Drawing.Point(74, 77);
            this.endTextBox.Name = "endTextBox";
            this.endTextBox.Size = new System.Drawing.Size(100, 20);
            this.endTextBox.TabIndex = 1;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(74, 117);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(100, 20);
            this.outputTextBox.TabIndex = 2;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(74, 174);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(100, 23);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(74, 214);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cancelButton.Size = new System.Drawing.Size(100, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // primesCalculatorLabel
            // 
            this.primesCalculatorLabel.AutoSize = true;
            this.primesCalculatorLabel.Location = new System.Drawing.Point(71, 9);
            this.primesCalculatorLabel.Name = "primesCalculatorLabel";
            this.primesCalculatorLabel.Size = new System.Drawing.Size(78, 13);
            this.primesCalculatorLabel.TabIndex = 9;
            this.primesCalculatorLabel.Text = "Primes Counter";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Location = new System.Drawing.Point(26, 80);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(29, 13);
            this.endLabel.TabIndex = 5;
            this.endLabel.Text = "End:";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Location = new System.Drawing.Point(27, 44);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(32, 13);
            this.startLabel.TabIndex = 6;
            this.startLabel.Text = "Start:";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(26, 120);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(42, 13);
            this.outputLabel.TabIndex = 8;
            this.outputLabel.Text = "Output:";
            // 
            // sumOfPrimesLabel
            // 
            this.sumOfPrimesLabel.AutoSize = true;
            this.sumOfPrimesLabel.Location = new System.Drawing.Point(71, 149);
            this.sumOfPrimesLabel.Name = "sumOfPrimesLabel";
            this.sumOfPrimesLabel.Size = new System.Drawing.Size(114, 13);
            this.sumOfPrimesLabel.TabIndex = 10;
            this.sumOfPrimesLabel.Text = "Sum on prime numbers";
            // 
            // PrimesCounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 261);
            this.Controls.Add(this.sumOfPrimesLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.primesCalculatorLabel);
            this.Controls.Add(this.startTextBox);
            this.Controls.Add(this.endTextBox);
            this.Controls.Add(this.calculateButton);
            this.Name = "PrimesCounterForm";
            this.Text = "Primes Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.TextBox endTextBox;
        private System.Windows.Forms.TextBox startTextBox;
        private System.Windows.Forms.Label primesCalculatorLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label sumOfPrimesLabel;
    }
}

