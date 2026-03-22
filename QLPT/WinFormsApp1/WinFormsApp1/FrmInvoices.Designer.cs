namespace ThieunuQLPT
{
    partial class FrmInvoices
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            dd = new Label();
            label2 = new Label();
            dgvPhieuThu = new DataGridView();
            invoiceItemBindingSource = new BindingSource(components);
            invoiceBindingSource = new BindingSource(components);
            Add = new Button();
            Detele = new Button();
            txtInvoice = new TextBox();
            MonthYear = new Label();
            address = new Label();
            txtHouseName = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            sua = new Button();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            amountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)invoiceItemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)invoiceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.GradientActiveCaption;
            label1.Font = new Font("Times New Roman", 15F);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(265, 48);
            label1.Name = "label1";
            label1.Size = new Size(266, 50);
            label1.TabIndex = 0;
            label1.Text = "HÓA ĐƠN TIỀN PHÒNG";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // dd
            // 
            dd.AutoSize = true;
            dd.Font = new Font("Segoe UI", 15F);
            dd.Location = new Point(12, 33);
            dd.Name = "dd";
            dd.Size = new Size(185, 28);
            dd.TabIndex = 2;
            dd.Text = "Phòng Trọ Thiếu Nữ";
            dd.Click += dd_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(163, 28);
            label2.TabIndex = 2;
            label2.Text = "Đại Học Sư Phạm";
            label2.Click += dd_Click;
            // 
            // dgvPhieuThu
            // 
            dgvPhieuThu.AllowUserToDeleteRows = false;
            dgvPhieuThu.AutoGenerateColumns = false;
            dgvPhieuThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuThu.BackgroundColor = Color.White;
            dgvPhieuThu.BorderStyle = BorderStyle.None;
            dgvPhieuThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuThu.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, amountDataGridViewTextBoxColumn, TotalAmount });
            dgvPhieuThu.DataSource = invoiceItemBindingSource;
            dgvPhieuThu.GridColor = Color.Black;
            dgvPhieuThu.Location = new Point(89, 135);
            dgvPhieuThu.Name = "dgvPhieuThu";
            dgvPhieuThu.RowHeadersVisible = false;
            dgvPhieuThu.Size = new Size(624, 287);
            dgvPhieuThu.TabIndex = 3;
            dgvPhieuThu.CellContentClick += dataGridView1_CellContentClick;
            // 
            // invoiceItemBindingSource
            // 
            invoiceItemBindingSource.DataSource = typeof(Models.Invoices.InvoiceItem);
            // 
            // invoiceBindingSource
            // 
            invoiceBindingSource.DataSource = typeof(Models.Invoices.Invoice);
            // 
            // Add
            // 
            Add.BackColor = Color.DeepSkyBlue;
            Add.Location = new Point(46, 428);
            Add.Name = "Add";
            Add.Size = new Size(75, 23);
            Add.TabIndex = 4;
            Add.Text = "Thêm";
            Add.UseVisualStyleBackColor = false;
            Add.Click += Add_Click;
            // 
            // Detele
            // 
            Detele.BackColor = Color.DeepSkyBlue;
            Detele.Location = new Point(163, 428);
            Detele.Name = "Detele";
            Detele.Size = new Size(75, 23);
            Detele.TabIndex = 5;
            Detele.Text = "Xoas";
            Detele.UseVisualStyleBackColor = false;
            Detele.Click += Detele_Click;
            // 
            // txtInvoice
            // 
            txtInvoice.Location = new Point(181, 106);
            txtInvoice.Name = "txtInvoice";
            txtInvoice.Size = new Size(100, 23);
            txtInvoice.TabIndex = 6;
            txtInvoice.Text = "3/2026";
            txtInvoice.TextChanged += textBox1_TextChanged_1;
            // 
            // MonthYear
            // 
            MonthYear.AutoSize = true;
            MonthYear.Location = new Point(127, 109);
            MonthYear.Name = "MonthYear";
            MonthYear.Size = new Size(48, 15);
            MonthYear.TabIndex = 7;
            MonthYear.Text = "THÁNG";
            MonthYear.Click += MonthYear_Click;
            // 
            // address
            // 
            address.AutoSize = true;
            address.Location = new Point(296, 109);
            address.Name = "address";
            address.Size = new Size(49, 15);
            address.TabIndex = 7;
            address.Text = "PHÒNG";
            address.Click += MonthYear_Click;
            // 
            // txtHouseName
            // 
            txtHouseName.Location = new Point(344, 105);
            txtHouseName.Name = "txtHouseName";
            txtHouseName.Size = new Size(100, 23);
            txtHouseName.TabIndex = 6;
            txtHouseName.Text = "A101";
            txtHouseName.TextChanged += textBox1_TextChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(637, 20);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 7;
            label3.Text = "SỐ";
            label3.Click += MonthYear_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(661, 17);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 6;
            textBox3.Text = "12345";
            textBox3.TextChanged += textBox1_TextChanged_1;
            // 
            // sua
            // 
            sua.BackColor = Color.DeepSkyBlue;
            sua.Location = new Point(265, 428);
            sua.Name = "sua";
            sua.Size = new Size(75, 23);
            sua.TabIndex = 5;
            sua.Text = "Sửa";
            sua.UseVisualStyleBackColor = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            nameDataGridViewTextBoxColumn.HeaderText = "Chi phi";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            typeDataGridViewTextBoxColumn.HeaderText = "Loai chi phi";
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            amountDataGridViewTextBoxColumn.DataPropertyName = "amount";
            amountDataGridViewTextBoxColumn.HeaderText = "Tong so";
            amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // TotalAmount
            // 
            TotalAmount.DataPropertyName = "TotalAmount";
            TotalAmount.HeaderText = "Thanh tien";
            TotalAmount.Name = "TotalAmount";
            // 
            // FrmInvoices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(815, 475);
            Controls.Add(address);
            Controls.Add(label3);
            Controls.Add(MonthYear);
            Controls.Add(txtHouseName);
            Controls.Add(textBox3);
            Controls.Add(txtInvoice);
            Controls.Add(sua);
            Controls.Add(Detele);
            Controls.Add(Add);
            Controls.Add(label2);
            Controls.Add(dd);
            Controls.Add(dgvPhieuThu);
            Controls.Add(label1);
            Name = "FrmInvoices";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form Invoices";
            Load += FrmInvoices_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPhieuThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)invoiceItemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)invoiceBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label dd;
        private Label label2;
        private DataGridView dgvPhieuThu;
        private Button Add;
        private Button Detele;
        private TextBox txtInvoice;
        private Label MonthYear;
        private Label address;
        private TextBox txtHouseName;
        private TextBox textBox3;
        internal Label label3;
        private Button sua;
        private BindingSource invoiceBindingSource;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private BindingSource invoiceItemBindingSource;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn TotalAmount;
    }
}