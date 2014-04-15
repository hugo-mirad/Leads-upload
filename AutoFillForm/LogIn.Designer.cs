namespace AutoFillForm
{
    partial class LogIn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblUname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.txtUname);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.lblPwd);
            this.panel1.Controls.Add(this.lblUname);
            this.panel1.Location = new System.Drawing.Point(439, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 169);
            this.panel1.TabIndex = 0;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(156, 66);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(159, 20);
            this.txtPwd.TabIndex = 4;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(156, 40);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(159, 20);
            this.txtUname.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(156, 108);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(74, 66);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(77, 13);
            this.lblPwd.TabIndex = 1;
            this.lblPwd.Text = "Password        ";
            // 
            // lblUname
            // 
            this.lblUname.AutoSize = true;
            this.lblUname.Location = new System.Drawing.Point(74, 43);
            this.lblUname.Name = "lblUname";
            this.lblUname.Size = new System.Drawing.Size(78, 13);
            this.lblUname.TabIndex = 0;
            this.lblUname.Text = "User Name      ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(450, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "WELCOME TO MULTISITE POSTING APPLICATION";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutoFillForm.Properties.Resources.logo2;
            this.pictureBox1.Location = new System.Drawing.Point(33, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 82);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1271, 746);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "LogIn";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPwd;
        public System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblUname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
      
    }
}