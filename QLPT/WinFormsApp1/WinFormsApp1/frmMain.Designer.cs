namespace WinFormsApp1
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            btnAccount = new Button();
            btnRoom = new Button();
            btnBill = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(664, 81);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ PHÒNG TRỌ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(btnAccount);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(938, 111);
            panel1.TabIndex = 1;
            // 
            // btnAccount
            // 
            btnAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccount.BackColor = Color.Green;
            btnAccount.FlatStyle = FlatStyle.Flat;
            btnAccount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAccount.ForeColor = Color.Black;
            btnAccount.Location = new Point(703, 25);
            btnAccount.Name = "btnAccount";
            btnAccount.Size = new Size(211, 65);
            btnAccount.TabIndex = 1;
            btnAccount.Text = "Đăng nhập";
            btnAccount.UseVisualStyleBackColor = false;
            btnAccount.Click += btnAccount_Click;
            // 
            // btnRoom
            // 
            btnRoom.BackColor = Color.FromArgb(255, 128, 0);
            btnRoom.FlatStyle = FlatStyle.Flat;
            btnRoom.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRoom.Location = new Point(36, 133);
            btnRoom.Name = "btnRoom";
            btnRoom.Size = new Size(147, 111);
            btnRoom.TabIndex = 2;
            btnRoom.Text = "Phòng";
            btnRoom.UseVisualStyleBackColor = false;
            btnRoom.Click += btnRoom_Click;
            // 
            // btnBill
            // 
            btnBill.BackColor = Color.FromArgb(255, 128, 0);
            btnBill.FlatStyle = FlatStyle.Flat;
            btnBill.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBill.Location = new Point(232, 133);
            btnBill.Name = "btnBill";
            btnBill.Size = new Size(140, 111);
            btnBill.TabIndex = 3;
            btnBill.Text = "Hóa đơn";
            btnBill.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnRoom);
            Controls.Add(btnBill);
            Controls.Add(panel1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phòng trọ";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnAccount;
        private Button btnRoom;
        private Button btnBill;
    }
}
