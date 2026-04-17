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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnChores = new Button();
            btnExpenses = new Button();
            btnNote = new Button();
            btnAdd = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 10);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(557, 67);
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
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(938, 110);
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
            btnAccount.Margin = new Padding(2);
            btnAccount.Name = "btnAccount";
            btnAccount.Size = new Size(176, 54);
            btnAccount.TabIndex = 1;
            btnAccount.Text = "Đăng nhập";
            btnAccount.UseVisualStyleBackColor = false;
            btnAccount.Click += btnAccount_Click;
            // 
            // btnRoom
            // 
            btnRoom.BackColor = Color.FromArgb(255, 128, 0);
            btnRoom.Dock = DockStyle.Fill;
            btnRoom.FlatStyle = FlatStyle.Flat;
            btnRoom.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btnRoom.Location = new Point(39, 38);
            btnRoom.Margin = new Padding(2);
            btnRoom.Name = "btnRoom";
            btnRoom.Size = new Size(183, 124);
            btnRoom.TabIndex = 2;
            btnRoom.Text = "Phòng";
            btnRoom.UseVisualStyleBackColor = false;
            btnRoom.Click += btnRoom_Click;
            // 
            // btnBill
            // 
            btnBill.BackColor = Color.FromArgb(255, 128, 0);
            btnBill.Dock = DockStyle.Fill;
            btnBill.FlatStyle = FlatStyle.Flat;
            btnBill.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btnBill.Location = new Point(263, 38);
            btnBill.Margin = new Padding(2);
            btnBill.Name = "btnBill";
            btnBill.Size = new Size(183, 124);
            btnBill.TabIndex = 3;
            btnBill.Text = "Hóa đơn";
            btnBill.UseVisualStyleBackColor = false;
            btnBill.Click += btnBill_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel1.Controls.Add(btnBill, 3, 1);
            tableLayoutPanel1.Controls.Add(btnRoom, 1, 1);
            tableLayoutPanel1.Controls.Add(btnChores, 5, 1);
            tableLayoutPanel1.Controls.Add(btnExpenses, 7, 1);
            tableLayoutPanel1.Controls.Add(btnNote, 1, 3);
            tableLayoutPanel1.Location = new Point(0, 118);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(782, 305);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnChores
            // 
            btnChores.BackColor = Color.DarkOrange;
            btnChores.Dock = DockStyle.Fill;
            btnChores.FlatStyle = FlatStyle.Flat;
            btnChores.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChores.Location = new Point(487, 38);
            btnChores.Margin = new Padding(2);
            btnChores.Name = "btnChores";
            btnChores.Size = new Size(183, 124);
            btnChores.TabIndex = 4;
            btnChores.Text = "Trực nhật";
            btnChores.UseVisualStyleBackColor = false;
            btnChores.Click += btnChores_Click;
            // 
            // btnExpenses
            // 
            btnExpenses.BackColor = Color.FromArgb(255, 128, 0);
            btnExpenses.Dock = DockStyle.Fill;
            btnExpenses.FlatStyle = FlatStyle.Flat;
            btnExpenses.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btnExpenses.Location = new Point(711, 38);
            btnExpenses.Margin = new Padding(2);
            btnExpenses.Name = "btnExpenses";
            btnExpenses.Size = new Size(183, 124);
            btnExpenses.TabIndex = 5;
            btnExpenses.Text = "Tài chính";
            btnExpenses.UseVisualStyleBackColor = false;
            btnExpenses.Click += btnExpenses_Click;
            // 
            // btnNote
            // 
            btnNote.BackColor = Color.FromArgb(255, 128, 0);
            btnNote.Dock = DockStyle.Fill;
            btnNote.FlatStyle = FlatStyle.Flat;
            btnNote.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btnNote.Location = new Point(39, 202);
            btnNote.Margin = new Padding(2);
            btnNote.Name = "btnNote";
            btnNote.Size = new Size(183, 124);
            btnNote.TabIndex = 6;
            btnNote.Text = "Bảng tin";
            btnNote.UseVisualStyleBackColor = false;
            btnNote.Click += btnNote_Click;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(595, 139);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 24);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(782, 403);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phòng trọ";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnAccount;
        private Button btnRoom;
        private Button btnBill;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnChores;
        private Button btnExpenses;
        private Button btnNote;
        private Button btnAdd;
    }
}
