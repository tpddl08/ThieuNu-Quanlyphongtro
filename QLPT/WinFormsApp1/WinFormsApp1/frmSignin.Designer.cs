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
            llbLogin = new LinkLabel();
            btnSignin = new Button();
            label3 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            btnClose = new Button();
            lblSDT = new Label();
            txtnumberphone = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(244, 9);
            label1.Name = "label1";
            label1.Size = new Size(303, 81);
            label1.TabIndex = 4;
            label1.Text = "ĐĂNG KÝ";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(lblSDT);
            panel1.Controls.Add(txtnumberphone);
            panel1.Controls.Add(llbLogin);
            panel1.Controls.Add(btnSignin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtEmail);
            panel1.Location = new Point(110, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 320);
            panel1.TabIndex = 3;
            // 
            // llbLogin
            // 
            llbLogin.AutoSize = true;
            llbLogin.Font = new Font("Segoe UI", 12F);
            llbLogin.Location = new Point(27, 269);
            llbLogin.Name = "llbLogin";
            llbLogin.Size = new Size(132, 32);
            llbLogin.TabIndex = 5;
            llbLogin.TabStop = true;
            llbLogin.Text = "Đăng nhập";
            // 
            // btnSignin
            // 
            btnSignin.BackColor = Color.Green;
            btnSignin.FlatStyle = FlatStyle.Flat;
            btnSignin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignin.Location = new Point(191, 230);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(208, 46);
            btnSignin.TabIndex = 4;
            btnSignin.Text = "Đăng ký";
            btnSignin.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(27, 159);
            label3.Name = "label3";
            label3.Size = new Size(142, 41);
            label3.TabIndex = 3;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 27);
            label2.Name = "label2";
            label2.Size = new Size(88, 41);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 15F);
            txtPassword.Location = new Point(223, 159);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(305, 47);
            txtPassword.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 15F);
            txtEmail.Location = new Point(223, 25);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(305, 47);
            txtEmail.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(689, -1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 51);
            btnClose.TabIndex = 5;
            btnClose.Text = "Thoát";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSDT.Location = new Point(27, 94);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(193, 41);
            lblSDT.TabIndex = 7;
            lblSDT.Text = "Số điện thoại";
            // 
            // txtnumberphone
            // 
            txtnumberphone.BorderStyle = BorderStyle.FixedSingle;
            txtnumberphone.Font = new Font("Segoe UI", 15F);
            txtnumberphone.Location = new Point(223, 88);
            txtnumberphone.Name = "txtnumberphone";
            txtnumberphone.Size = new Size(305, 47);
            txtnumberphone.TabIndex = 6;
            // 
            // frmSignin
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmSignin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSignin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label lblSDT;
        private TextBox txtnumberphone;
        private LinkLabel llbLogin;
        private Button btnSignin;
        private Label label3;
        private Label label2;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Button btnClose;
    }
}