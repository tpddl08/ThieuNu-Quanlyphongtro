namespace ThieunuQLPT
{
    partial class frmBill
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            label1 = new Label();
            btnEdit = new Button();
            tlpContent = new TableLayoutPanel();
            lblTotal = new Label();
            lblServiceRate = new Label();
            label6 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            lblNewNums = new Label();
            label12 = new Label();
            label13 = new Label();
            lblOldNums = new Label();
            label4 = new Label();
            lblConsume = new Label();
            lblElectricRate = new Label();
            lblWaterRate = new Label();
            label5 = new Label();
            label3 = new Label();
            lblRent = new Label();
            label10 = new Label();
            label7 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblRoom = new Label();
            label8 = new Label();
            label9 = new Label();
            lblMonthYear = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label11 = new Label();
            lblMembers = new Label();
            tableLayoutPanel1.SuspendLayout();
            tlpContent.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(2, 152);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(935, 32);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(472, 1);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(458, 30);
            label2.TabIndex = 2;
            label2.Text = "Thành tiền";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(5, 1);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(458, 30);
            label1.TabIndex = 1;
            label1.Text = "Chi phí";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.Location = new Point(760, 33);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(165, 46);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // tlpContent
            // 
            tlpContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlpContent.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpContent.ColumnCount = 2;
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpContent.Controls.Add(lblTotal, 1, 4);
            tlpContent.Controls.Add(lblServiceRate, 1, 2);
            tlpContent.Controls.Add(label6, 0, 2);
            tlpContent.Controls.Add(tableLayoutPanel4, 0, 3);
            tlpContent.Controls.Add(lblElectricRate, 1, 3);
            tlpContent.Controls.Add(lblWaterRate, 1, 1);
            tlpContent.Controls.Add(label5, 0, 1);
            tlpContent.Controls.Add(label3, 0, 0);
            tlpContent.Controls.Add(lblRent, 1, 0);
            tlpContent.Controls.Add(label10, 0, 4);
            tlpContent.Location = new Point(2, 187);
            tlpContent.Margin = new Padding(4);
            tlpContent.Name = "tlpContent";
            tlpContent.RowCount = 5;
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpContent.Size = new Size(935, 296);
            tlpContent.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Font = new Font("Segoe UI", 10F);
            lblTotal.Location = new Point(472, 266);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(458, 29);
            lblTotal.TabIndex = 11;
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblServiceRate
            // 
            lblServiceRate.Dock = DockStyle.Fill;
            lblServiceRate.Font = new Font("Segoe UI", 10F);
            lblServiceRate.Location = new Point(472, 61);
            lblServiceRate.Margin = new Padding(4, 0, 4, 0);
            lblServiceRate.Name = "lblServiceRate";
            lblServiceRate.Size = new Size(458, 29);
            lblServiceRate.TabIndex = 9;
            lblServiceRate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(5, 61);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(458, 29);
            label6.TabIndex = 5;
            label6.Text = "DỊCH VỤ";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.3617F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.638298F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 195F));
            tableLayoutPanel4.Controls.Add(lblNewNums, 2, 0);
            tableLayoutPanel4.Controls.Add(label12, 1, 0);
            tableLayoutPanel4.Controls.Add(label13, 1, 1);
            tableLayoutPanel4.Controls.Add(lblOldNums, 2, 1);
            tableLayoutPanel4.Controls.Add(label4, 0, 0);
            tableLayoutPanel4.Controls.Add(lblConsume, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(5, 95);
            tableLayoutPanel4.Margin = new Padding(4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(458, 166);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // lblNewNums
            // 
            lblNewNums.Dock = DockStyle.Fill;
            lblNewNums.Font = new Font("Segoe UI", 10F);
            lblNewNums.Location = new Point(265, 1);
            lblNewNums.Margin = new Padding(4, 0, 4, 0);
            lblNewNums.Name = "lblNewNums";
            lblNewNums.Size = new Size(188, 81);
            lblNewNums.TabIndex = 15;
            lblNewNums.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label12.Location = new Point(185, 1);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(71, 81);
            label12.TabIndex = 13;
            label12.Text = "Số mới";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label13.Location = new Point(185, 83);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(71, 82);
            label13.TabIndex = 14;
            label13.Text = "Số cũ";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOldNums
            // 
            lblOldNums.Dock = DockStyle.Fill;
            lblOldNums.Font = new Font("Segoe UI", 10F);
            lblOldNums.Location = new Point(265, 83);
            lblOldNums.Margin = new Padding(4, 0, 4, 0);
            lblOldNums.Name = "lblOldNums";
            lblOldNums.Size = new Size(188, 82);
            lblOldNums.TabIndex = 16;
            lblOldNums.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(5, 1);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(171, 81);
            label4.TabIndex = 12;
            label4.Text = "ĐIỆN";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblConsume
            // 
            lblConsume.Dock = DockStyle.Fill;
            lblConsume.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConsume.Location = new Point(5, 83);
            lblConsume.Margin = new Padding(4, 0, 4, 0);
            lblConsume.Name = "lblConsume";
            lblConsume.Size = new Size(171, 82);
            lblConsume.TabIndex = 17;
            lblConsume.Text = "Tiêu thụ:";
            lblConsume.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblElectricRate
            // 
            lblElectricRate.Dock = DockStyle.Fill;
            lblElectricRate.Font = new Font("Segoe UI", 10F);
            lblElectricRate.Location = new Point(472, 91);
            lblElectricRate.Margin = new Padding(4, 0, 4, 0);
            lblElectricRate.Name = "lblElectricRate";
            lblElectricRate.Size = new Size(458, 174);
            lblElectricRate.TabIndex = 12;
            lblElectricRate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWaterRate
            // 
            lblWaterRate.Dock = DockStyle.Fill;
            lblWaterRate.Font = new Font("Segoe UI", 10F);
            lblWaterRate.Location = new Point(472, 31);
            lblWaterRate.Margin = new Padding(4, 0, 4, 0);
            lblWaterRate.Name = "lblWaterRate";
            lblWaterRate.Size = new Size(458, 29);
            lblWaterRate.TabIndex = 8;
            lblWaterRate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(5, 31);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(458, 29);
            label5.TabIndex = 4;
            label5.Text = "NƯỚC (100.000đ/người)";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(5, 1);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(458, 29);
            label3.TabIndex = 2;
            label3.Text = "GIÁ PHÒNG";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRent
            // 
            lblRent.Dock = DockStyle.Fill;
            lblRent.Font = new Font("Segoe UI", 10F);
            lblRent.Location = new Point(472, 1);
            lblRent.Margin = new Padding(4, 0, 4, 0);
            lblRent.Name = "lblRent";
            lblRent.Size = new Size(458, 29);
            lblRent.TabIndex = 7;
            lblRent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.Location = new Point(5, 266);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(458, 29);
            label10.TabIndex = 6;
            label10.Text = "Tổng";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(2, 9);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(531, 46);
            label7.TabIndex = 5;
            label7.Text = "PHIẾU TÍNH TIỀN PHÒNG";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(lblRoom, 1, 1);
            tableLayoutPanel2.Controls.Add(label8, 0, 0);
            tableLayoutPanel2.Controls.Add(label9, 0, 1);
            tableLayoutPanel2.Controls.Add(lblMonthYear, 1, 0);
            tableLayoutPanel2.Location = new Point(2, 71);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(302, 80);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // lblRoom
            // 
            lblRoom.Font = new Font("Segoe UI", 10F);
            lblRoom.Location = new Point(155, 40);
            lblRoom.Margin = new Padding(4, 0, 4, 0);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(142, 35);
            lblRoom.TabIndex = 10;
            lblRoom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(5, 1);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(141, 38);
            label8.TabIndex = 7;
            label8.Text = "Tháng";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.Location = new Point(5, 40);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(141, 38);
            label9.TabIndex = 8;
            label9.Text = "Phòng";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMonthYear
            // 
            lblMonthYear.Font = new Font("Segoe UI", 10F);
            lblMonthYear.Location = new Point(155, 1);
            lblMonthYear.Margin = new Padding(4, 0, 4, 0);
            lblMonthYear.Name = "lblMonthYear";
            lblMonthYear.Size = new Size(142, 35);
            lblMonthYear.TabIndex = 9;
            lblMonthYear.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(label11, 0, 0);
            tableLayoutPanel3.Controls.Add(lblMembers, 1, 0);
            tableLayoutPanel3.Location = new Point(610, 106);
            tableLayoutPanel3.Margin = new Padding(4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel3.Size = new Size(327, 38);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // label11
            // 
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.Location = new Point(5, 1);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(154, 36);
            label11.TabIndex = 7;
            label11.Text = "Thành viên";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMembers
            // 
            lblMembers.Font = new Font("Segoe UI", 10F);
            lblMembers.Location = new Point(168, 1);
            lblMembers.Margin = new Padding(4, 0, 4, 0);
            lblMembers.Name = "lblMembers";
            lblMembers.Size = new Size(149, 35);
            lblMembers.TabIndex = 8;
            lblMembers.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmBill
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(938, 484);
            Controls.Add(btnEdit);
            Controls.Add(label7);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tlpContent);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4);
            Name = "frmBill";
            Text = "Chi tiết hóa đơn";
            Load += frmBill_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tlpContent.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private TableLayoutPanel tlpContent;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label7;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label8;
        private Label label9;
        private Label lblTotal;
        private Label lblServiceRate;
        private Label lblWaterRate;
        private Label lblRent;
        private Label label10;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label11;
        private Label lblMembers;
        private Label lblRoom;
        private Label lblMonthYear;
        private TableLayoutPanel tableLayoutPanel4;
        private Label lblConsume;
        private Label lblNewNums;
        private Label label12;
        private Label label4;
        private Label label13;
        private Label lblOldNums;
        private Label lblElectricRate;
        private Button btnEdit;
    }
}