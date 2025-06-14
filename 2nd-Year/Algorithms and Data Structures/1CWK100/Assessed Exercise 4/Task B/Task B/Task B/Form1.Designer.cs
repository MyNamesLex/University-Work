namespace Task_B
{
    partial class Form1
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
            this.DisplayButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.EndTimeTextBox = new System.Windows.Forms.TextBox();
            this.StartTimeTextBox = new System.Windows.Forms.TextBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.startTime = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.endTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DisplayButton
            // 
            this.DisplayButton.Location = new System.Drawing.Point(188, 267);
            this.DisplayButton.Name = "DisplayButton";
            this.DisplayButton.Size = new System.Drawing.Size(82, 23);
            this.DisplayButton.TabIndex = 2;
            this.DisplayButton.Text = "DisplayButton";
            this.DisplayButton.UseVisualStyleBackColor = true;
            this.DisplayButton.Click += new System.EventHandler(this.DisplayButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(45, 267);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "AddButton";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EndTimeTextBox
            // 
            this.EndTimeTextBox.Location = new System.Drawing.Point(83, 198);
            this.EndTimeTextBox.Name = "EndTimeTextBox";
            this.EndTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.EndTimeTextBox.TabIndex = 4;
            // 
            // StartTimeTextBox
            // 
            this.StartTimeTextBox.Location = new System.Drawing.Point(83, 134);
            this.StartTimeTextBox.Name = "StartTimeTextBox";
            this.StartTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.StartTimeTextBox.TabIndex = 5;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(83, 69);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.IDTextBox.TabIndex = 6;
            // 
            // startTime
            // 
            this.startTime.AutoSize = true;
            this.startTime.Location = new System.Drawing.Point(252, 137);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(55, 13);
            this.startTime.TabIndex = 7;
            this.startTime.Text = "Start Time";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(252, 72);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(18, 13);
            this.ID.TabIndex = 8;
            this.ID.Text = "ID";
            // 
            // endTime
            // 
            this.endTime.AutoSize = true;
            this.endTime.Enabled = false;
            this.endTime.Location = new System.Drawing.Point(252, 201);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(52, 13);
            this.endTime.TabIndex = 9;
            this.endTime.Text = "End Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.StartTimeTextBox);
            this.Controls.Add(this.EndTimeTextBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DisplayButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DisplayButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox EndTimeTextBox;
        private System.Windows.Forms.TextBox StartTimeTextBox;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label startTime;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label endTime;
    }
}

