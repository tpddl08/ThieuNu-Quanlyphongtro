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
            llbForget = new LinkLabel();
            llbSignin = new LinkLabel();
            btnSubmit = new Button();
            label3 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            txtUsername = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel1.BackColor = Color.Gold;
            panel1.Controls.Add(llbForget);
            panel1.Controls.Add(llbSignin);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(txtUsername);
            panel1.Location = new Point(172, 124);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 320);
            panel1.TabIndex = 0;
            // 
            // llbForget
            // 
            llbForget.AutoSize = true;
            llbForget.Font = new Font("Segoe UI", 12F);
            llbForget.Location = new Point(337, 210);
            llbForget.Name = "llbForget";
            llbForget.Size = new Size(191, 32);
            llbForget.TabIndex = 6;
            llbForget.TabStop = true;
            llbForget.Text = "Quên mật khẩu?";
            // 
            // llbSignin
            // 
            llbSignin.AutoSize = true;
            llbSignin.Font = new Font("Segoe UI", 12F);
            llbSignin.Location = new Point(369, 274);
            llbSignin.Name = "llbSignin";
            llbSignin.Size = new Size(159, 32);
            llbSignin.TabIndex = 5;
            llbSignin.TabStop = true;
            llbSignin.Text = "Tạo tài khoản";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.ForestGreen;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.Black;
            btnSubmit.Location = new Point(37, 196);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(208, 46);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Đăng nhập";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(37, 127);
            label3.Name = "label3";
            label3.Size = new Size(142, 41);
            label3.TabIndex = 3;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(37, 54);
            label2.Name = "label2";
            label2.Size = new Size(88, 41);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 15F);
            textBox1.Location = new Point(185, 121);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(343, 47);
            textBox1.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 15F);
            txtUsername.Location = new Point(185, 48);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(343, 47);
            txtUsername.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
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
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtUsername;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private LinkLabel llbForget;
        private LinkLabel llbSignin;
        private Button btnSubmit;
    }
}