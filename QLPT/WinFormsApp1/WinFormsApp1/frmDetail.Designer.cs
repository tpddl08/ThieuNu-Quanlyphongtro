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
            components = new System.ComponentModel.Container();
            dgvSplitBill = new DataGridView();
            invoiceItemBindingSource = new BindingSource(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSplitBill).BeginInit();
            ((System.ComponentModel.ISupportInitialize)invoiceItemBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvSplitBill
            // 
            dgvSplitBill.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSplitBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSplitBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSplitBill.Location = new Point(1, 156);
            dgvSplitBill.Margin = new Padding(4, 5, 4, 5);
            dgvSplitBill.Name = "dgvSplitBill";
            dgvSplitBill.RowHeadersWidth = 62;
            dgvSplitBill.Size = new Size(936, 328);
            dgvSplitBill.TabIndex = 0;
            dgvSplitBill.CellContentClick += dataGridView1_CellContentClick;
            // 
            // invoiceItemBindingSource
            // 
            invoiceItemBindingSource.DataSource = typeof(Models.Invoices.InvoiceItem);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(274, 37);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(386, 54);
            label1.TabIndex = 1;
            label1.Text = "CHI TIẾT HÓA ĐƠN";
            // 
            // frmDetail
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(label1);
            Controls.Add(dgvSplitBill);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmDetail";
            Text = "FormDongTien";
            Load += FormDongTien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSplitBill).EndInit();
            ((System.ComponentModel.ISupportInitialize)invoiceItemBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSplitBill;
        private BindingSource invoiceItemBindingSource;
        private Label label1;
    }
}