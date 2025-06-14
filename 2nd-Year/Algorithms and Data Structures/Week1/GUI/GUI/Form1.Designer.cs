namespace GUI
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
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RedCheckBox = new System.Windows.Forms.CheckBox();
            this.ColourCheckBox_Checked = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(312, 96);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(100, 23);
            this.messageTextBox.TabIndex = 0;
            this.messageTextBox.TextChanged += new System.EventHandler(this.messageTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RedCheckBox
            // 
            this.RedCheckBox.AutoSize = true;
            this.RedCheckBox.Location = new System.Drawing.Point(490, 226);
            this.RedCheckBox.Name = "RedCheckBox";
            this.RedCheckBox.Size = new System.Drawing.Size(46, 19);
            this.RedCheckBox.TabIndex = 4;
            this.RedCheckBox.Text = "Red";
            this.RedCheckBox.UseVisualStyleBackColor = true;
            this.RedCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ColourCheckBox_Checked
            // 
            this.ColourCheckBox_Checked.AutoSize = true;
            this.ColourCheckBox_Checked.Location = new System.Drawing.Point(312, 226);
            this.ColourCheckBox_Checked.Name = "ColourCheckBox_Checked";
            this.ColourCheckBox_Checked.Size = new System.Drawing.Size(62, 19);
            this.ColourCheckBox_Checked.TabIndex = 3;
            this.ColourCheckBox_Checked.Text = "Colour";
            this.ColourCheckBox_Checked.UseVisualStyleBackColor = true;
            this.ColourCheckBox_Checked.CheckedChanged += new System.EventHandler(this.ColourCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RedCheckBox);
            this.Controls.Add(this.ColourCheckBox_Checked);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox RedCheckBox;
        private System.Windows.Forms.CheckBox ColourCheckBox_Checked;
    }
}

