namespace ThieunuQLPT
{
    partial class frmDetail
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
            dgvSplitBill = new DataGridView();
            colUsername = new DataGridViewTextBoxColumn();
            colNumabsent = new DataGridViewTextBoxColumn();
            colIspaid = new DataGridViewTextBoxColumn();
            colElectric = new DataGridViewTextBoxColumn();
            colWater = new DataGridViewTextBoxColumn();
            colRent = new DataGridViewTextBoxColumn();
            colService = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnPaid = new Button();
            btnSubmit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSplitBill).BeginInit();
            SuspendLayout();
            // 
            // dgvSplitBill
            // 
            dgvSplitBill.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSplitBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSplitBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSplitBill.Columns.AddRange(new DataGridViewColumn[] { colUsername, colNumabsent, colIspaid, colElectric, colWater, colRent, colService });
            dgvSplitBill.Location = new Point(22, 142);
            dgvSplitBill.Margin = new Padding(4, 5, 4, 5);
            dgvSplitBill.Name = "dgvSplitBill";
            dgvSplitBill.RowHeadersWidth = 62;
            dgvSplitBill.Size = new Size(716, 328);
            dgvSplitBill.TabIndex = 0;
            dgvSplitBill.CellContentClick += dgvSplitBill_CellEndEdit;
            // 
            // colUsername
            // 
            colUsername.HeaderText = "Tên người ở";
            colUsername.MinimumWidth = 8;
            colUsername.Name = "colUsername";
            // 
            // colNumabsent
            // 
            colNumabsent.HeaderText = "Số ngày vắng";
            colNumabsent.MinimumWidth = 8;
            colNumabsent.Name = "colNumabsent";
            // 
            // colIspaid
            // 
            colIspaid.HeaderText = "Thanh toán";
            colIspaid.MinimumWidth = 8;
            colIspaid.Name = "colIspaid";
            // 
            // colElectric
            // 
            colElectric.HeaderText = "Tiền điện";
            colElectric.MinimumWidth = 8;
            colElectric.Name = "colElectric";
            // 
            // colWater
            // 
            colWater.HeaderText = "Tiền nước";
            colWater.MinimumWidth = 8;
            colWater.Name = "colWater";
            // 
            // colRent
            // 
            colRent.HeaderText = "Tiền thuê";
            colRent.MinimumWidth = 8;
            colRent.Name = "colRent";
            // 
            // colService
            // 
            colService.HeaderText = "Tiền dịch vụ";
            colService.MinimumWidth = 8;
            colService.Name = "colService";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 55);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(716, 54);
            label1.TabIndex = 1;
            label1.Text = "HÓA ĐƠN THEO TỪNG THÀNH VIÊN";
            // 
            // btnPaid
            // 
            btnPaid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPaid.BackColor = Color.ForestGreen;
            btnPaid.FlatStyle = FlatStyle.Flat;
            btnPaid.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPaid.Location = new Point(774, 214);
            btnPaid.Name = "btnPaid";
            btnPaid.Size = new Size(128, 94);
            btnPaid.TabIndex = 14;
            btnPaid.Text = "Đã thanh toán";
            btnPaid.UseVisualStyleBackColor = false;
            btnPaid.Click += btnPaid_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSubmit.BackColor = Color.RoyalBlue;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(774, 142);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 46);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "Lưu";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // frmDetail
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnPaid);
            Controls.Add(btnSubmit);
            Controls.Add(label1);
            Controls.Add(dgvSplitBill);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết hóa đơn theo thành viên";
            ((System.ComponentModel.ISupportInitialize)dgvSplitBill).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSplitBill;
        private Label label1;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colNumabsent;
        private DataGridViewTextBoxColumn colIspaid;
        private DataGridViewTextBoxColumn colElectric;
        private DataGridViewTextBoxColumn colWater;
        private DataGridViewTextBoxColumn colRent;
        private DataGridViewTextBoxColumn colService;
        private Button btnPaid;
        private Button btnSubmit;
    }
}