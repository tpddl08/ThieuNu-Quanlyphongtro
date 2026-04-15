namespace ThieunuQLPT
{
    partial class frmEditBill
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
            btnInsert = new Button();
            btnDelete = new Button();
            btnLuu = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            txtMaxMembers = new TextBox();
            label11 = new Label();
            label1 = new Label();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblElectricRate = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            txtOldNums = new TextBox();
            txtNewNums = new TextBox();
            lblConsume = new Label();
            label12 = new Label();
            label4 = new Label();
            label13 = new Label();
            label10 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            lblWaterRate = new Label();
            lblTotal = new Label();
            txtRent = new TextBox();
            txtServiceRate = new TextBox();
            tlpContent = new TableLayoutPanel();
            txtMonth = new TextBox();
            label9 = new Label();
            label8 = new Label();
            txtRoom = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label7 = new Label();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tlpContent.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnInsert.BackColor = Color.DarkOrange;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInsert.Location = new Point(575, 27);
            btnInsert.Margin = new Padding(4);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(106, 36);
            btnInsert.TabIndex = 13;
            btnInsert.Text = "Thêm";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.DarkOrange;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.Location = new Point(699, 27);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(106, 36);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuu.BackColor = Color.DarkOrange;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.Location = new Point(825, 27);
            btnLuu.Margin = new Padding(4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(106, 36);
            btnLuu.TabIndex = 15;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(txtMaxMembers, 1, 0);
            tableLayoutPanel3.Controls.Add(label11, 0, 0);
            tableLayoutPanel3.Location = new Point(642, 104);
            tableLayoutPanel3.Margin = new Padding(4);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel3.Size = new Size(289, 38);
            tableLayoutPanel3.TabIndex = 12;
            // 
            // txtMaxMembers
            // 
            txtMaxMembers.BorderStyle = BorderStyle.FixedSingle;
            txtMaxMembers.Dock = DockStyle.Fill;
            txtMaxMembers.Font = new Font("Segoe UI", 10F);
            txtMaxMembers.Location = new Point(149, 5);
            txtMaxMembers.Margin = new Padding(4);
            txtMaxMembers.Name = "txtMaxMembers";
            txtMaxMembers.Size = new Size(135, 34);
            txtMaxMembers.TabIndex = 16;
            // 
            // label11
            // 
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label11.Location = new Point(5, 1);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(135, 36);
            label11.TabIndex = 7;
            label11.Text = "Thành viên";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(469, 1);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(456, 36);
            label1.TabIndex = 1;
            label1.Text = "Chi phí";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(5, 1);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(455, 36);
            label2.TabIndex = 2;
            label2.Text = "Thành tiền";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Location = new Point(1, 150);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(930, 38);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // lblElectricRate
            // 
            lblElectricRate.Dock = DockStyle.Fill;
            lblElectricRate.Font = new Font("Segoe UI", 10F);
            lblElectricRate.Location = new Point(469, 133);
            lblElectricRate.Margin = new Padding(4, 0, 4, 0);
            lblElectricRate.Name = "lblElectricRate";
            lblElectricRate.Size = new Size(456, 116);
            lblElectricRate.TabIndex = 12;
            lblElectricRate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel4.Controls.Add(txtOldNums, 2, 1);
            tableLayoutPanel4.Controls.Add(txtNewNums, 2, 0);
            tableLayoutPanel4.Controls.Add(lblConsume, 0, 1);
            tableLayoutPanel4.Controls.Add(label12, 1, 0);
            tableLayoutPanel4.Controls.Add(label4, 0, 0);
            tableLayoutPanel4.Controls.Add(label13, 1, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(5, 137);
            tableLayoutPanel4.Margin = new Padding(4);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(455, 108);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // txtOldNums
            // 
            txtOldNums.BorderStyle = BorderStyle.FixedSingle;
            txtOldNums.Dock = DockStyle.Fill;
            txtOldNums.Font = new Font("Segoe UI", 10F);
            txtOldNums.Location = new Point(277, 58);
            txtOldNums.Margin = new Padding(4);
            txtOldNums.Name = "txtOldNums";
            txtOldNums.Size = new Size(173, 34);
            txtOldNums.TabIndex = 19;
            // 
            // txtNewNums
            // 
            txtNewNums.BorderStyle = BorderStyle.FixedSingle;
            txtNewNums.Dock = DockStyle.Fill;
            txtNewNums.Font = new Font("Segoe UI", 10F);
            txtNewNums.Location = new Point(277, 5);
            txtNewNums.Margin = new Padding(4);
            txtNewNums.Name = "txtNewNums";
            txtNewNums.Size = new Size(173, 34);
            txtNewNums.TabIndex = 18;
            // 
            // lblConsume
            // 
            lblConsume.Dock = DockStyle.Fill;
            lblConsume.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConsume.Location = new Point(5, 54);
            lblConsume.Margin = new Padding(4, 0, 4, 0);
            lblConsume.Name = "lblConsume";
            lblConsume.Size = new Size(127, 53);
            lblConsume.TabIndex = 17;
            lblConsume.Text = "Tiêu thụ:";
            lblConsume.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label12.Location = new Point(141, 1);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(127, 52);
            label12.TabIndex = 13;
            label12.Text = "Số mới";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(5, 1);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(127, 52);
            label4.TabIndex = 12;
            label4.Text = "ĐIỆN";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label13.Location = new Point(141, 54);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(127, 53);
            label13.TabIndex = 14;
            label13.Text = "Số cũ";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.Location = new Point(5, 250);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(455, 45);
            label10.TabIndex = 6;
            label10.Text = "Tổng";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(5, 89);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(455, 43);
            label6.TabIndex = 5;
            label6.Text = "DỊCH VỤ";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(5, 45);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(455, 43);
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
            label3.Size = new Size(455, 43);
            label3.TabIndex = 2;
            label3.Text = "GIÁ PHÒNG";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWaterRate
            // 
            lblWaterRate.Dock = DockStyle.Fill;
            lblWaterRate.Font = new Font("Segoe UI", 10F);
            lblWaterRate.Location = new Point(469, 45);
            lblWaterRate.Margin = new Padding(4, 0, 4, 0);
            lblWaterRate.Name = "lblWaterRate";
            lblWaterRate.Size = new Size(456, 43);
            lblWaterRate.TabIndex = 8;
            lblWaterRate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Font = new Font("Segoe UI", 10F);
            lblTotal.Location = new Point(469, 250);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(456, 45);
            lblTotal.TabIndex = 11;
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRent
            // 
            txtRent.BorderStyle = BorderStyle.FixedSingle;
            txtRent.Dock = DockStyle.Fill;
            txtRent.Font = new Font("Segoe UI", 10F);
            txtRent.Location = new Point(469, 5);
            txtRent.Margin = new Padding(4);
            txtRent.Name = "txtRent";
            txtRent.Size = new Size(456, 34);
            txtRent.TabIndex = 13;
            // 
            // txtServiceRate
            // 
            txtServiceRate.BorderStyle = BorderStyle.FixedSingle;
            txtServiceRate.Dock = DockStyle.Fill;
            txtServiceRate.Font = new Font("Segoe UI", 10F);
            txtServiceRate.Location = new Point(469, 93);
            txtServiceRate.Margin = new Padding(4);
            txtServiceRate.Name = "txtServiceRate";
            txtServiceRate.Size = new Size(456, 34);
            txtServiceRate.TabIndex = 14;
            // 
            // tlpContent
            // 
            tlpContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlpContent.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpContent.ColumnCount = 2;
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpContent.Controls.Add(txtServiceRate, 1, 2);
            tlpContent.Controls.Add(txtRent, 1, 0);
            tlpContent.Controls.Add(lblTotal, 1, 4);
            tlpContent.Controls.Add(lblWaterRate, 1, 1);
            tlpContent.Controls.Add(label3, 0, 0);
            tlpContent.Controls.Add(label5, 0, 1);
            tlpContent.Controls.Add(label6, 0, 2);
            tlpContent.Controls.Add(label10, 0, 4);
            tlpContent.Controls.Add(tableLayoutPanel4, 0, 3);
            tlpContent.Controls.Add(lblElectricRate, 1, 3);
            tlpContent.Font = new Font("Segoe UI", 10F);
            tlpContent.Location = new Point(1, 191);
            tlpContent.Margin = new Padding(4);
            tlpContent.Name = "tlpContent";
            tlpContent.RowCount = 5;
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tlpContent.Size = new Size(930, 296);
            tlpContent.TabIndex = 9;
            // 
            // txtMonth
            // 
            txtMonth.BorderStyle = BorderStyle.FixedSingle;
            txtMonth.Dock = DockStyle.Fill;
            txtMonth.Font = new Font("Segoe UI", 10F);
            txtMonth.Location = new Point(112, 5);
            txtMonth.Margin = new Padding(4);
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(99, 34);
            txtMonth.TabIndex = 9;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.Location = new Point(5, 40);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(98, 39);
            label9.TabIndex = 8;
            label9.Text = "Phòng";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(5, 1);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(98, 38);
            label8.TabIndex = 7;
            label8.Text = "Tháng";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRoom
            // 
            txtRoom.BorderStyle = BorderStyle.FixedSingle;
            txtRoom.Dock = DockStyle.Fill;
            txtRoom.Font = new Font("Segoe UI", 10F);
            txtRoom.Location = new Point(112, 44);
            txtRoom.Margin = new Padding(4);
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(99, 34);
            txtRoom.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(txtRoom, 1, 1);
            tableLayoutPanel2.Controls.Add(label8, 0, 0);
            tableLayoutPanel2.Controls.Add(label9, 0, 1);
            tableLayoutPanel2.Controls.Add(txtMonth, 1, 0);
            tableLayoutPanel2.Location = new Point(1, 67);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(216, 80);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(1, 9);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(541, 46);
            label7.TabIndex = 10;
            label7.Text = "PHIẾU TÍNH TIỀN PHÒNG";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmEditBill
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnLuu);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(label7);
            Controls.Add(tlpContent);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            Margin = new Padding(4);
            Name = "frmEditBill";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chỉnh sửa";
            Load += frmEditBill_Load;
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tlpContent.ResumeLayout(false);
            tlpContent.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnInsert;
        private Button btnDelete;
        private Button btnLuu;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox txtMaxMembers;
        private Label label11;
        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblElectricRate;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox txtOldNums;
        private TextBox txtNewNums;
        private Label lblConsume;
        private Label label12;
        private Label label4;
        private Label label13;
        private Label label10;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label lblWaterRate;
        private Label lblTotal;
        private TextBox txtRent;
        private TextBox txtServiceRate;
        private TableLayoutPanel tlpContent;
        private TextBox txtMonth;
        private Label label9;
        private Label label8;
        private TextBox txtRoom;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label7;
    }
}