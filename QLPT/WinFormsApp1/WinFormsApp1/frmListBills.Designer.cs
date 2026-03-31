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
            colStatus = new DataGridViewTextBoxColumn();
            colDateCreate = new DataGridViewTextBoxColumn();
            colDetail = new DataGridViewButtonColumn();
            btnAll = new Button();
            btnAdd = new Button();
            label1 = new Label();
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
            dgvListinvoices.Columns.AddRange(new DataGridViewColumn[] { colName, colTimeAt, colMoney, colStatus, colDateCreate, colDetail });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvListinvoices.DefaultCellStyle = dataGridViewCellStyle2;
            dgvListinvoices.Location = new Point(4, 101);
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
            dgvListinvoices.Size = new Size(742, 386);
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
            colMoney.HeaderText = "Số tiền";
            colMoney.MinimumWidth = 8;
            colMoney.Name = "colMoney";
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.HeaderText = "Trạng thái";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
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
            // btnAll
            // 
            btnAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAll.BackColor = Color.SteelBlue;
            btnAll.FlatStyle = FlatStyle.Flat;
            btnAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAll.Location = new Point(770, 181);
            btnAll.Margin = new Padding(4);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(154, 54);
            btnAll.TabIndex = 1;
            btnAll.Text = "Tất cả";
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnAll_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.Location = new Point(771, 101);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(154, 57);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 21);
            label1.Name = "label1";
            label1.Size = new Size(383, 54);
            label1.TabIndex = 3;
            label1.Text = "Danh sách hóa đơn";
            // 
            // frmListBills
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(btnAll);
            Controls.Add(dgvListinvoices);
            Margin = new Padding(4);
            Name = "frmListBills";
            Text = "Danh sách hóa đơn";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvListinvoices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvListinvoices;
        private Button btnAll;
        private Button btnAdd;
        private Label label1;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colTimeAt;
        private DataGridViewTextBoxColumn colMoney;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDateCreate;
        private DataGridViewButtonColumn colDetail;
    }
}