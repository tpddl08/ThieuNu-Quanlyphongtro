namespace ThieunuQLPT
{
    partial class frmLogin
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
            panel1 = new Panel();
            llbSignin = new LinkLabel();
            btnSubmit = new Button();
            label3 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            txtNumberphone = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(llbSignin);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtNumberphone);
            panel1.Location = new Point(82, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(772, 320);
            panel1.TabIndex = 0;
            // 
            // llbSignin
            // 
            llbSignin.AutoSize = true;
            llbSignin.BackColor = Color.Transparent;
            llbSignin.Font = new Font("Segoe UI", 12F);
            llbSignin.LinkColor = Color.FromArgb(255, 255, 128);
            llbSignin.Location = new Point(31, 263);
            llbSignin.Name = "llbSignin";
            llbSignin.Size = new Size(159, 32);
            llbSignin.TabIndex = 5;
            llbSignin.TabStop = true;
            llbSignin.Text = "Tạo tài khoản";
            llbSignin.LinkClicked += llbSignin_LinkClicked;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.ForestGreen;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.Black;
            btnSubmit.Location = new Point(282, 202);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(208, 46);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Đăng nhập";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(31, 123);
            label3.Name = "label3";
            label3.Size = new Size(162, 45);
            label3.TabIndex = 3;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(31, 50);
            label2.Name = "label2";
            label2.Size = new Size(218, 45);
            label2.TabIndex = 2;
            label2.Text = "Số điện thoại";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 15F);
            txtPassword.Location = new Point(270, 121);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(461, 47);
            txtPassword.TabIndex = 1;
            // 
            // txtNumberphone
            // 
            txtNumberphone.BorderStyle = BorderStyle.FixedSingle;
            txtNumberphone.Font = new Font("Segoe UI", 15F);
            txtNumberphone.Location = new Point(270, 48);
            txtNumberphone.Name = "txtNumberphone";
            txtNumberphone.Size = new Size(461, 47);
            txtNumberphone.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(270, 27);
            label1.Name = "label1";
            label1.Size = new Size(400, 81);
            label1.TabIndex = 1;
            label1.Text = "ĐĂNG NHẬP";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập tài khoản";
            Load += frmLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtNumberphone;
        private Label label1;
        private TextBox txtPassword;
        private Label label2;
        private Label label3;
        private LinkLabel llbSignin;
        private Button btnSubmit;
    }
}