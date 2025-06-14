namespace WebinarB_stacks
{
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SalaryTextBox = new System.Windows.Forms.TextBox();
            this.SpecialTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.JobIDTextBox = new System.Windows.Forms.TextBox();
            this.DescTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.NextJobButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SalaryTextBox
            // 
            this.SalaryTextBox.Location = new System.Drawing.Point(102, 151);
            this.SalaryTextBox.Name = "SalaryTextBox";
            this.SalaryTextBox.Size = new System.Drawing.Size(100, 23);
            this.SalaryTextBox.TabIndex = 1;
            // 
            // SpecialTextBox
            // 
            this.SpecialTextBox.Location = new System.Drawing.Point(102, 102);
            this.SpecialTextBox.Name = "SpecialTextBox";
            this.SpecialTextBox.Size = new System.Drawing.Size(100, 23);
            this.SpecialTextBox.TabIndex = 2;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(102, 59);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 23);
            this.NameTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Specialism";
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Salary";
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // JobIDTextBox
            // 
            this.JobIDTextBox.Location = new System.Drawing.Point(102, 247);
            this.JobIDTextBox.Name = "JobIDTextBox";
            this.JobIDTextBox.Size = new System.Drawing.Size(100, 23);
            this.JobIDTextBox.TabIndex = 1;
            // 
            // DescTextBox
            // 
            this.DescTextBox.Location = new System.Drawing.Point(102, 305);
            this.DescTextBox.Name = "DescTextBox";
            this.DescTextBox.Size = new System.Drawing.Size(100, 23);
            this.DescTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "JobID";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Desc";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NextJobButton
            // 
            this.NextJobButton.Location = new System.Drawing.Point(262, 290);
            this.NextJobButton.Name = "NextJobButton";
            this.NextJobButton.Size = new System.Drawing.Size(75, 23);
            this.NextJobButton.TabIndex = 5;
            this.NextJobButton.Text = "NextJob";
            this.NextJobButton.UseVisualStyleBackColor = true;
            this.NextJobButton.Click += new System.EventHandler(this.NextJobButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NextJobButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescTextBox);
            this.Controls.Add(this.JobIDTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.SpecialTextBox);
            this.Controls.Add(this.SalaryTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SalaryTextBox;
        private System.Windows.Forms.TextBox SpecialTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox JobIDTextBox;
        private System.Windows.Forms.TextBox xtB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.TextBox ox;
        private System.Windows.Forms.TextBox DescTextBox;
        private System.Windows.Forms.Button NextJobButton;
    }
}

