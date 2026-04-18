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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)dgvCommonfund).BeginInit();
            SuspendLayout();
            // 
            // btnDone
            // 
            btnDone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDone.BackColor = Color.DarkOrange;
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDone.Location = new Point(767, 345);
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
            btnDelete.Location = new Point(767, 267);
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
            btnAdd.Location = new Point(767, 194);
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
            lblFundhave.Name = "lblFundhave";
            lblFundhave.Size = new Size(226, 54);
            lblFundhave.TabIndex = 21;
            lblFundhave.Text = "Quỹ chung";
            // 
            // dgvCommonfund
            // 
            dgvCommonfund.AllowUserToAddRows = false;
            dgvCommonfund.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvCommonfund.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvCommonfund.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCommonfund.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCommonfund.BackgroundColor = Color.LightGray;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvCommonfund.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvCommonfund.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCommonfund.Columns.AddRange(new DataGridViewColumn[] { colNamemem, colMoney, colTime, colStatus });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgvCommonfund.DefaultCellStyle = dataGridViewCellStyle10;
            dgvCommonfund.Location = new Point(44, 122);
            dgvCommonfund.Name = "dgvCommonfund";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Control;
            dataGridViewCellStyle11.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dgvCommonfund.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dgvCommonfund.RowHeadersWidth = 62;
            dataGridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvCommonfund.RowsDefaultCellStyle = dataGridViewCellStyle12;
            dgvCommonfund.RowTemplate.Height = 100;
            dgvCommonfund.Size = new Size(699, 328);
            dgvCommonfund.TabIndex = 20;
            // 
            // colNamemem
            // 
            colNamemem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            colNamemem.DefaultCellStyle = dataGridViewCellStyle9;
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
            btnExpenses.Name = "btnExpenses";
            btnExpenses.Size = new Size(128, 52);
            btnExpenses.TabIndex = 26;
            btnExpenses.Text = "Chi tiêu";
            btnExpenses.UseVisualStyleBackColor = false;
            btnExpenses.Click += btnExpenses_Click;
            // 
            // frmCommonfund
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnExpenses);
            Controls.Add(btnDone);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnSubmit);
            Controls.Add(lblFundhave);
            Controls.Add(dgvCommonfund);
            Name = "frmCommonfund";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quỹ chung";
            WindowState = FormWindowState.Maximized;
            Load += frmCommonfund_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCommonfund).EndInit();
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
    }
}