namespace AutoFillForm
{
    partial class SubPopUrl
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
            this.txturl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.lblname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblsitenme = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(111, 138);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(123, 20);
            this.txturl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter URL      :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(111, 183);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 23);
            this.btnsubmit.TabIndex = 2;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(30, 27);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(77, 13);
            this.lblname.TabIndex = 3;
            this.lblname.Text = "Name            : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // lblsitenme
            // 
            this.lblsitenme.AutoSize = true;
            this.lblsitenme.Location = new System.Drawing.Point(30, 67);
            this.lblsitenme.Name = "lblsitenme";
            this.lblsitenme.Size = new System.Drawing.Size(74, 13);
            this.lblsitenme.TabIndex = 5;
            this.lblsitenme.Text = "SiteName     : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "CarID           :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Later";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SubPopUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblsitenme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txturl);
            this.Name = "SubPopUrl";
            this.Text = "SubPopUrl";
            this.Load += new System.EventHandler(this.SubPopUrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblsitenme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}