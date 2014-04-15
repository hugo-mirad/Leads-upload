namespace AutoFillForm
{
    partial class NotesPopup
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
            this.btnnotesave = new System.Windows.Forms.Button();
            this.btnnotesabandon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(32, 44);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 45);
            this.textBox1.TabIndex = 0;
            // 
            // btnnotesave
            // 
            this.btnnotesave.Location = new System.Drawing.Point(291, 12);
            this.btnnotesave.Name = "btnnotesave";
            this.btnnotesave.Size = new System.Drawing.Size(75, 23);
            this.btnnotesave.TabIndex = 1;
            this.btnnotesave.Text = "Save";
            this.btnnotesave.UseVisualStyleBackColor = true;
            // 
            // btnnotesabandon
            // 
            this.btnnotesabandon.Location = new System.Drawing.Point(141, 126);
            this.btnnotesabandon.Name = "btnnotesabandon";
            this.btnnotesabandon.Size = new System.Drawing.Size(75, 23);
            this.btnnotesabandon.TabIndex = 2;
            this.btnnotesabandon.Text = "Abandon";
            this.btnnotesabandon.UseVisualStyleBackColor = true;
            // 
            // NotesPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(378, 161);
            this.Controls.Add(this.btnnotesabandon);
            this.Controls.Add(this.btnnotesave);
            this.Controls.Add(this.textBox1);
            this.Name = "NotesPopup";
            this.Text = "NotesPopup";
            this.Load += new System.EventHandler(this.NotesPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnnotesave;
        private System.Windows.Forms.Button btnnotesabandon;
    }
}