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
            label1 = new Label();
            label2 = new Label();
            tlpContent = new TableLayoutPanel();
            lblTotal = new Label();
            lblServiceRate = new Label();
            lblWaterRate = new Label();
            lblRent = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label10 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            lblConsume = new Label();
            lblNewNums = new Label();
            label12 = new Label();
            label4 = new Label();
            label13 = new Label();
            lblOldNums = new Label();
            lblElectricRate = new Label();
            label7 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblRoom = new Label();
            lblMonthYear = new Label();
            label8 = new Label();
            label9 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label11 = new Label();
            lblMembers = new Label();
            btnEdit = new Button();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            tlpContent.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 360F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Location = new Point(6, 114);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(711, 34);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(342, 32);
            label1.TabIndex = 1;
            label1.Text = "Chi phí";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(353, 1);
            label2.Name = "label2";
            label2.Size = new Size(353, 32);
            label2.TabIndex = 2;
            label2.Text = "Thành tiền";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpContent
            // 
            tlpContent.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpContent.ColumnCount = 2;
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.6947479F));
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 361F));
            tlpContent.Controls.Add(lblTotal, 1, 4);
            tlpContent.Controls.Add(lblServiceRate, 1, 2);
            tlpContent.Controls.Add(lblWaterRate, 1, 1);
            tlpContent.Controls.Add(lblRent, 1, 0);
            tlpContent.Controls.Add(label3, 0, 0);
            tlpContent.Controls.Add(label5, 0, 1);
            tlpContent.Controls.Add(label6, 0, 2);
            tlpContent.Controls.Add(label10, 0, 4);
            tlpContent.Controls.Add(tableLayoutPanel4, 0, 3);
            tlpContent.Controls.Add(lblElectricRate, 1, 3);
            tlpContent.Location = new Point(6, 149);
            tlpContent.Margin = new Padding(3, 2, 3, 2);
            tlpContent.Name = "tlpContent";
            tlpContent.RowCount = 5;
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 26.4550266F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            tlpContent.Size = new Size(711, 188);
            tlpContent.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(352, 165);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(343, 22);
            lblTotal.TabIndex = 11;
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblServiceRate
            // 
            lblServiceRate.Location = new Point(352, 55);
            lblServiceRate.Name = "lblServiceRate";
            lblServiceRate.Size = new Size(355, 32);
            lblServiceRate.TabIndex = 9;
            lblServiceRate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWaterRate
            // 
            lblWaterRate.Location = new Point(352, 26);
            lblWaterRate.Name = "lblWaterRate";
            lblWaterRate.Size = new Size(355, 26);
            lblWaterRate.TabIndex = 8;
            lblWaterRate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRent
            // 
            lblRent.Location = new Point(352, 1);
            lblRent.Name = "lblRent";
            lblRent.Size = new Size(355, 24);
            lblRent.TabIndex = 7;
            lblRent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(4, 1);
            label3.Name = "label3";
            label3.Size = new Size(341, 24);
            label3.TabIndex = 2;
            label3.Text = "GIÁ PHÒNG";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(4, 26);
            label5.Name = "label5";
            label5.Size = new Size(341, 28);
            label5.TabIndex = 4;
            label5.Text = "NƯỚC (100.000đ/người)";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(4, 55);
            label6.Name = "label6";
            label6.Size = new Size(341, 32);
            label6.TabIndex = 5;
            label6.Text = "DỊCH VỤ";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(4, 165);
            label10.Name = "label10";
            label10.Size = new Size(341, 22);
            label10.TabIndex = 6;
            label10.Text = "Tổng";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.3617F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.638298F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 136F));
            tableLayoutPanel4.Controls.Add(lblConsume, 0, 1);
            tableLayoutPanel4.Controls.Add(lblNewNums, 2, 0);
            tableLayoutPanel4.Controls.Add(label12, 1, 0);
            tableLayoutPanel4.Controls.Add(label4, 0, 0);
            tableLayoutPanel4.Controls.Add(label13, 1, 1);
            tableLayoutPanel4.Controls.Add(lblOldNums, 2, 1);
            tableLayoutPanel4.Location = new Point(4, 92);
            tableLayoutPanel4.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(341, 70);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // lblConsume
            // 
            lblConsume.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConsume.Location = new Point(4, 35);
            lblConsume.Name = "lblConsume";
            lblConsume.Size = new Size(133, 32);
            lblConsume.TabIndex = 17;
            lblConsume.Text = "Tiêu thụ:";
            lblConsume.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNewNums
            // 
            lblNewNums.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNewNums.Location = new Point(206, 1);
            lblNewNums.Name = "lblNewNums";
            lblNewNums.Size = new Size(130, 32);
            lblNewNums.TabIndex = 15;
            lblNewNums.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(144, 1);
            label12.Name = "label12";
            label12.Size = new Size(55, 32);
            label12.TabIndex = 13;
            label12.Text = "Số mới";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(4, 1);
            label4.Name = "label4";
            label4.Size = new Size(133, 32);
            label4.TabIndex = 12;
            label4.Text = "ĐIỆN";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.Location = new Point(144, 35);
            label13.Name = "label13";
            label13.Size = new Size(55, 32);
            label13.TabIndex = 14;
            label13.Text = "Số cũ";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOldNums
            // 
            lblOldNums.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOldNums.Location = new Point(206, 35);
            lblOldNums.Name = "lblOldNums";
            lblOldNums.Size = new Size(130, 32);
            lblOldNums.TabIndex = 16;
            lblOldNums.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblElectricRate
            // 
            lblElectricRate.Location = new Point(352, 90);
            lblElectricRate.Name = "lblElectricRate";
            lblElectricRate.Size = new Size(355, 74);
            lblElectricRate.TabIndex = 12;
            lblElectricRate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Location = new Point(259, 83);
            label7.Name = "label7";
            label7.Size = new Size(199, 28);
            label7.TabIndex = 5;
            label7.Text = "PHIẾU TÍNH TIỀN PHÒNG";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(lblRoom, 1, 1);
            tableLayoutPanel2.Controls.Add(lblMonthYear, 1, 0);
            tableLayoutPanel2.Controls.Add(label8, 0, 0);
            tableLayoutPanel2.Controls.Add(label9, 0, 1);
            tableLayoutPanel2.Location = new Point(6, 64);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(212, 48);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // lblRoom
            // 
            lblRoom.Location = new Point(109, 24);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(99, 21);
            lblRoom.TabIndex = 10;
            lblRoom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMonthYear
            // 
            lblMonthYear.Location = new Point(109, 1);
            lblMonthYear.Name = "lblMonthYear";
            lblMonthYear.Size = new Size(99, 21);
            lblMonthYear.TabIndex = 9;
            lblMonthYear.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(4, 1);
            label8.Name = "label8";
            label8.Size = new Size(98, 22);
            label8.TabIndex = 7;
            label8.Text = "Tháng";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(4, 24);
            label9.Name = "label9";
            label9.Size = new Size(98, 22);
            label9.TabIndex = 8;
            label9.Text = "Phòng";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(label11, 0, 0);
            tableLayoutPanel3.Controls.Add(lblMembers, 1, 0);
            tableLayoutPanel3.Location = new Point(480, 83);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel3.Size = new Size(221, 22);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(4, 1);
            label11.Name = "label11";
            label11.Size = new Size(103, 20);
            label11.TabIndex = 7;
            label11.Text = "Thành viên";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMembers
            // 
            lblMembers.Location = new Point(114, 1);
            lblMembers.Name = "lblMembers";
            lblMembers.Size = new Size(103, 20);
            lblMembers.TabIndex = 8;
            lblMembers.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(630, 9);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(82, 22);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // button1
            // 
            button1.Location = new Point(549, 9);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Chia bill";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmBill
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 340);
            Controls.Add(button1);
            Controls.Add(btnEdit);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(label7);
            Controls.Add(tlpContent);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button button1;
    }
}