namespace AutoFillForm
{
    partial class EnterNotes
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnabandan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 55);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(394, 55);
            this.textBox1.TabIndex = 0;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(413, 26);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 1;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnabandan
            // 
            this.btnabandan.Location = new System.Drawing.Point(191, 162);
            this.btnabandan.Name = "btnabandan";
            this.btnabandan.Size = new System.Drawing.Size(75, 23);
            this.btnabandan.TabIndex = 2;
            this.btnabandan.Text = "Abandon";
            this.btnabandan.UseVisualStyleBackColor = true;
            // 
            // EnterNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 197);
            this.Controls.Add(this.btnabandan);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.textBox1);
            this.Name = "EnterNotes";
            this.Text = "EnterNotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnabandan;
    }
}