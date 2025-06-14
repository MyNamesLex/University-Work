namespace TaskB
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
            this.ISBNTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.DisplayButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ISBNTextBox
            // 
            this.ISBNTextBox.Location = new System.Drawing.Point(103, 78);
            this.ISBNTextBox.Name = "ISBNTextBox";
            this.ISBNTextBox.Size = new System.Drawing.Size(185, 20);
            this.ISBNTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ISBN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Author";
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(103, 201);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(185, 20);
            this.AuthorTextBox.TabIndex = 4;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(103, 139);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(185, 20);
            this.NameTextBox.TabIndex = 5;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(53, 297);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(149, 23);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "AddButton";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(558, 297);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(149, 23);
            this.SortButton.TabIndex = 8;
            this.SortButton.Text = "SortButton";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // DisplayButton
            // 
            this.DisplayButton.Location = new System.Drawing.Point(392, 297);
            this.DisplayButton.Name = "DisplayButton";
            this.DisplayButton.Size = new System.Drawing.Size(149, 23);
            this.DisplayButton.TabIndex = 9;
            this.DisplayButton.Text = "DisplayButton";
            this.DisplayButton.UseVisualStyleBackColor = true;
            this.DisplayButton.Click += new System.EventHandler(this.DisplayButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(227, 297);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(149, 23);
            this.RemoveButton.TabIndex = 10;
            this.RemoveButton.Text = "RemoveButton";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.DisplayButton);
            this.Controls.Add(this.SortButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.AuthorTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ISBNTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ISBNTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Button DisplayButton;
        private System.Windows.Forms.Button RemoveButton;
    }
}

