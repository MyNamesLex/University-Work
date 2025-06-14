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
            this.DirectEdgeNumberTwoTextBox = new System.Windows.Forms.TextBox();
            this.InsertNodeButton = new System.Windows.Forms.Button();
            this.DirectEdgeButton = new System.Windows.Forms.Button();
            this.CountButton = new System.Windows.Forms.Button();
            this.DirectEdge = new System.Windows.Forms.Label();
            this.InsertNode = new System.Windows.Forms.Label();
            this.InsertNodeTextBox = new System.Windows.Forms.TextBox();
            this.DirectEdgeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DirectEdgeNumberTwoTextBox
            // 
            this.DirectEdgeNumberTwoTextBox.Location = new System.Drawing.Point(336, 153);
            this.DirectEdgeNumberTwoTextBox.Name = "DirectEdgeNumberTwoTextBox";
            this.DirectEdgeNumberTwoTextBox.Size = new System.Drawing.Size(100, 20);
            this.DirectEdgeNumberTwoTextBox.TabIndex = 19;
            // 
            // InsertNodeButton
            // 
            this.InsertNodeButton.Location = new System.Drawing.Point(221, 334);
            this.InsertNodeButton.Name = "InsertNodeButton";
            this.InsertNodeButton.Size = new System.Drawing.Size(103, 23);
            this.InsertNodeButton.TabIndex = 18;
            this.InsertNodeButton.Text = "InsertAirportButton";
            this.InsertNodeButton.UseVisualStyleBackColor = true;
            this.InsertNodeButton.Click += new System.EventHandler(this.InsertNodeButton_Click_1);
            // 
            // DirectEdgeButton
            // 
            this.DirectEdgeButton.Location = new System.Drawing.Point(366, 334);
            this.DirectEdgeButton.Name = "DirectEdgeButton";
            this.DirectEdgeButton.Size = new System.Drawing.Size(119, 23);
            this.DirectEdgeButton.TabIndex = 17;
            this.DirectEdgeButton.Text = "AiportToAirportButton";
            this.DirectEdgeButton.UseVisualStyleBackColor = true;
            this.DirectEdgeButton.Click += new System.EventHandler(this.DirectEdgeButton_Click);
            // 
            // CountButton
            // 
            this.CountButton.Location = new System.Drawing.Point(504, 334);
            this.CountButton.Name = "CountButton";
            this.CountButton.Size = new System.Drawing.Size(75, 23);
            this.CountButton.TabIndex = 16;
            this.CountButton.Text = "CountButton";
            this.CountButton.UseVisualStyleBackColor = true;
            this.CountButton.Click += new System.EventHandler(this.CountButton_Click);
            // 
            // DirectEdge
            // 
            this.DirectEdge.AutoSize = true;
            this.DirectEdge.Location = new System.Drawing.Point(462, 156);
            this.DirectEdge.Name = "DirectEdge";
            this.DirectEdge.Size = new System.Drawing.Size(86, 13);
            this.DirectEdge.TabIndex = 14;
            this.DirectEdge.Text = "Airport To Airport";
            // 
            // InsertNode
            // 
            this.InsertNode.AutoSize = true;
            this.InsertNode.Location = new System.Drawing.Point(462, 96);
            this.InsertNode.Name = "InsertNode";
            this.InsertNode.Size = new System.Drawing.Size(37, 13);
            this.InsertNode.TabIndex = 13;
            this.InsertNode.Text = "Airport";
            // 
            // InsertNodeTextBox
            // 
            this.InsertNodeTextBox.Location = new System.Drawing.Point(230, 93);
            this.InsertNodeTextBox.Name = "InsertNodeTextBox";
            this.InsertNodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.InsertNodeTextBox.TabIndex = 12;
            // 
            // DirectEdgeTextBox
            // 
            this.DirectEdgeTextBox.Location = new System.Drawing.Point(230, 153);
            this.DirectEdgeTextBox.Name = "DirectEdgeTextBox";
            this.DirectEdgeTextBox.Size = new System.Drawing.Size(100, 20);
            this.DirectEdgeTextBox.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DirectEdgeNumberTwoTextBox);
            this.Controls.Add(this.InsertNodeButton);
            this.Controls.Add(this.DirectEdgeButton);
            this.Controls.Add(this.CountButton);
            this.Controls.Add(this.DirectEdge);
            this.Controls.Add(this.InsertNode);
            this.Controls.Add(this.InsertNodeTextBox);
            this.Controls.Add(this.DirectEdgeTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DirectEdgeNumberTwoTextBox;
        private System.Windows.Forms.Button InsertNodeButton;
        private System.Windows.Forms.Button DirectEdgeButton;
        private System.Windows.Forms.Button CountButton;
        private System.Windows.Forms.Label DirectEdge;
        private System.Windows.Forms.Label InsertNode;
        private System.Windows.Forms.TextBox InsertNodeTextBox;
        private System.Windows.Forms.TextBox DirectEdgeTextBox;
    }
}

