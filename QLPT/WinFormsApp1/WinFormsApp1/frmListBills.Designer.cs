namespace ThieunuQLPT
{
    partial class frmListBills
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvListinvoices = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colTimeAt = new DataGridViewTextBoxColumn();
            colMoney = new DataGridViewTextBoxColumn();
            colDateCreate = new DataGridViewTextBoxColumn();
            colDetail = new DataGridViewButtonColumn();
            btnEdit = new Button();
            label1 = new Label();
            btnReload = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvListinvoices).BeginInit();
            SuspendLayout();
            // 
            // dgvListinvoices
            // 
            dgvListinvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvListinvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvListinvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListinvoices.Columns.AddRange(new DataGridViewColumn[] { colName, colTimeAt, colMoney, colDateCreate, colDetail });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvListinvoices.DefaultCellStyle = dataGridViewCellStyle2;
            dgvListinvoices.Location = new Point(13, 101);
            dgvListinvoices.Margin = new Padding(4);
            dgvListinvoices.Name = "dgvListinvoices";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvListinvoices.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvListinvoices.RowHeadersWidth = 51;
            dgvListinvoices.Size = new Size(733, 386);
            dgvListinvoices.TabIndex = 0;
            dgvListinvoices.CellContentClick += dgvListinvoices_CellContentClick;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.HeaderText = "Tên phòng";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            // 
            // colTimeAt
            // 
            colTimeAt.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTimeAt.HeaderText = "Thời điểm";
            colTimeAt.MinimumWidth = 8;
            colTimeAt.Name = "colTimeAt";
            // 
            // colMoney
            // 
            colMoney.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMoney.HeaderText = "Tổng tiền";
            colMoney.MinimumWidth = 8;
            colMoney.Name = "colMoney";
            // 
            // colDateCreate
            // 
            colDateCreate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDateCreate.HeaderText = "Ngày tạo";
            colDateCreate.MinimumWidth = 8;
            colDateCreate.Name = "colDateCreate";
            // 
            // colDetail
            // 
            colDetail.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colDetail.HeaderText = "Chi tiết";
            colDetail.MinimumWidth = 8;
            colDetail.Name = "colDetail";
            colDetail.Width = 133;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.DarkOrange;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.Location = new Point(771, 101);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(154, 57);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(463, 54);
            label1.TabIndex = 3;
            label1.Text = "DANH SÁCH HÓA ĐƠN";
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReload.BackColor = Color.DarkOrange;
            btnReload.FlatStyle = FlatStyle.Flat;
            btnReload.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReload.Location = new Point(771, 193);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(155, 56);
            btnReload.TabIndex = 4;
            btnReload.Text = "Tải lại";
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;
            // 
            // frmListBills
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnReload);
            Controls.Add(label1);
            Controls.Add(btnEdit);
            Controls.Add(dgvListinvoices);
            Margin = new Padding(4);
            Name = "frmListBills";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách hóa đơn";
            WindowState = FormWindowState.Maximized;
            Click += frmListBills_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListinvoices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvListinvoices;
        private Button btnEdit;
        private Label label1;
        private Button btnReload;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colTimeAt;
        private DataGridViewTextBoxColumn colMoney;
        private DataGridViewTextBoxColumn colDateCreate;
        private DataGridViewButtonColumn colDetail;
    }
}