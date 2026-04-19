namespace ThieunuQLPT
{
    partial class frmCommonfund
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommonfund));
            btnDone = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            btnSubmit = new Button();
            lblFundhave = new Label();
            dgvCommonfund = new DataGridView();
            colNamemem = new DataGridViewTextBoxColumn();
            colMoney = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnExpenses = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvCommonfund).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnDone
            // 
            btnDone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDone.BackColor = Color.DarkOrange;
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDone.Location = new Point(767, 308);
            btnDone.Margin = new Padding(2);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(128, 46);
            btnDone.TabIndex = 25;
            btnDone.Text = "Đã đóng";
            btnDone.UseVisualStyleBackColor = false;
            btnDone.Click += btnDone_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.DarkOrange;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(767, 246);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 46);
            btnDelete.TabIndex = 24;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.DarkOrange;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(767, 184);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 46);
            btnAdd.TabIndex = 23;
            btnAdd.Text = "Tạo";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSubmit.BackColor = Color.DarkOrange;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(767, 122);
            btnSubmit.Margin = new Padding(2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 46);
            btnSubmit.TabIndex = 22;
            btnSubmit.Text = "Lưu";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblFundhave
            // 
            lblFundhave.AutoSize = true;
            lblFundhave.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFundhave.Location = new Point(44, 35);
            lblFundhave.Margin = new Padding(2, 0, 2, 0);
            lblFundhave.Name = "lblFundhave";
            lblFundhave.Size = new Size(226, 54);
            lblFundhave.TabIndex = 21;
            lblFundhave.Text = "Quỹ chung";
            // 
            // dgvCommonfund
            // 
            dgvCommonfund.AllowUserToAddRows = false;
            dgvCommonfund.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvCommonfund.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCommonfund.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCommonfund.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCommonfund.BackgroundColor = Color.LightGray;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCommonfund.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCommonfund.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCommonfund.Columns.AddRange(new DataGridViewColumn[] { colNamemem, colMoney, colTime, colStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvCommonfund.DefaultCellStyle = dataGridViewCellStyle4;
            dgvCommonfund.Location = new Point(44, 122);
            dgvCommonfund.Margin = new Padding(2);
            dgvCommonfund.Name = "dgvCommonfund";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvCommonfund.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvCommonfund.RowHeadersWidth = 62;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvCommonfund.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvCommonfund.RowTemplate.Height = 100;
            dgvCommonfund.Size = new Size(698, 328);
            dgvCommonfund.TabIndex = 20;
            // 
            // colNamemem
            // 
            colNamemem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            colNamemem.DefaultCellStyle = dataGridViewCellStyle3;
            colNamemem.HeaderText = "Tên thành viên";
            colNamemem.MinimumWidth = 8;
            colNamemem.Name = "colNamemem";
            // 
            // colMoney
            // 
            colMoney.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMoney.HeaderText = "Số tiền";
            colMoney.MinimumWidth = 8;
            colMoney.Name = "colMoney";
            // 
            // colTime
            // 
            colTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTime.HeaderText = "Hạn đóng";
            colTime.MinimumWidth = 8;
            colTime.Name = "colTime";
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.HeaderText = "Trạng thái";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            // 
            // btnExpenses
            // 
            btnExpenses.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExpenses.BackColor = Color.DarkOrange;
            btnExpenses.FlatStyle = FlatStyle.Flat;
            btnExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExpenses.Location = new Point(767, 44);
            btnExpenses.Margin = new Padding(2);
            btnExpenses.Name = "btnExpenses";
            btnExpenses.Size = new Size(128, 52);
            btnExpenses.TabIndex = 26;
            btnExpenses.Text = "Chi tiêu";
            btnExpenses.UseVisualStyleBackColor = false;
            btnExpenses.Click += btnExpenses_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(767, 360);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 27;
            pictureBox1.TabStop = false;
            // 
            // frmCommonfund
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(pictureBox1);
            Controls.Add(btnExpenses);
            Controls.Add(btnDone);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnSubmit);
            Controls.Add(lblFundhave);
            Controls.Add(dgvCommonfund);
            Margin = new Padding(2);
            Name = "frmCommonfund";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quỹ chung";
            WindowState = FormWindowState.Maximized;
            Load += frmCommonfund_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCommonfund).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDone;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnSubmit;
        private Label lblFundhave;
        private DataGridView dgvCommonfund;
        private DataGridViewTextBoxColumn colNamemem;
        private DataGridViewTextBoxColumn colMoney;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colStatus;
        private Button btnExpenses;
        private PictureBox pictureBox1;
    }
}