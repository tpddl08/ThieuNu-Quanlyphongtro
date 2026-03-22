namespace ThieunuQLPT
{
    partial class frmSignin
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
            label1 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            txtName = new TextBox();
            lblSDT = new Label();
            txtNumberphone = new TextBox();
            llbLogin = new LinkLabel();
            btnSubmit = new Button();
            label3 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(337, 9);
            label1.Name = "label1";
            label1.Size = new Size(303, 81);
            label1.TabIndex = 4;
            label1.Text = "ĐĂNG KÝ";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(lblSDT);
            panel1.Controls.Add(txtNumberphone);
            panel1.Controls.Add(llbLogin);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtEmail);
            panel1.Location = new Point(91, 103);
            panel1.Name = "panel1";
            panel1.Size = new Size(760, 354);
            panel1.TabIndex = 3;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(22, 22);
            label4.Name = "label4";
            label4.Size = new Size(72, 45);
            label4.TabIndex = 9;
            label4.Text = "Tên";
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 15F);
            txtName.Location = new Point(246, 22);
            txtName.Name = "txtName";
            txtName.Size = new Size(487, 47);
            txtName.TabIndex = 8;
            // 
            // lblSDT
            // 
            lblSDT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSDT.ForeColor = SystemColors.Control;
            lblSDT.Location = new Point(22, 122);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(218, 45);
            lblSDT.TabIndex = 7;
            lblSDT.Text = "Số điện thoại";
            // 
            // txtNumberphone
            // 
            txtNumberphone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNumberphone.BorderStyle = BorderStyle.FixedSingle;
            txtNumberphone.Font = new Font("Segoe UI", 15F);
            txtNumberphone.Location = new Point(246, 128);
            txtNumberphone.Name = "txtNumberphone";
            txtNumberphone.Size = new Size(487, 47);
            txtNumberphone.TabIndex = 6;
            // 
            // llbLogin
            // 
            llbLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            llbLogin.AutoSize = true;
            llbLogin.Font = new Font("Segoe UI", 12F);
            llbLogin.LinkColor = Color.Yellow;
            llbLogin.Location = new Point(40, 292);
            llbLogin.Name = "llbLogin";
            llbLogin.Size = new Size(132, 32);
            llbLogin.TabIndex = 5;
            llbLogin.TabStop = true;
            llbLogin.Text = "Đăng nhập";
            llbLogin.LinkClicked += llbLogin_LinkClicked;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSubmit.BackColor = Color.ForestGreen;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(234, 257);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(284, 46);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Đăng ký";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(22, 167);
            label3.Name = "label3";
            label3.Size = new Size(162, 45);
            label3.TabIndex = 3;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(22, 67);
            label2.Name = "label2";
            label2.Size = new Size(101, 45);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 15F);
            txtPassword.Location = new Point(246, 181);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(487, 47);
            txtPassword.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 15F);
            txtEmail.Location = new Point(246, 75);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(487, 47);
            txtEmail.TabIndex = 0;
            // 
            // frmSignin
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmSignin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản";
            Load += frmSignin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label lblSDT;
        private TextBox txtNumberphone;
        private LinkLabel llbLogin;
        private Button btnSubmit;
        private Label label3;
        private Label label2;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtName;
    }
}