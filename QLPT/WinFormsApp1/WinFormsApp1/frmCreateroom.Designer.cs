namespace ThieunuQLPT
{
    partial class frmCreateroom
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
            label1 = new Label();
            panel1 = new Panel();
            txtPriceRent = new TextBox();
            label3 = new Label();
            btnSubmit = new Button();
            txtService = new TextBox();
            label4 = new Label();
            label2 = new Label();
            txtNumbermember = new TextBox();
            txtNameroom = new TextBox();
            label5 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(80, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(621, 80);
            label1.TabIndex = 6;
            label1.Text = "TẠO PHÒNG";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(txtPriceRent);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(txtService);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtNumbermember);
            panel1.Controls.Add(txtNameroom);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(80, 82);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(621, 237);
            panel1.TabIndex = 5;
            // 
            // txtPriceRent
            // 
            txtPriceRent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPriceRent.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPriceRent.Location = new Point(203, 104);
            txtPriceRent.Margin = new Padding(2, 2, 2, 2);
            txtPriceRent.Name = "txtPriceRent";
            txtPriceRent.Size = new Size(403, 43);
            txtPriceRent.TabIndex = 18;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(12, 151);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(157, 37);
            label3.TabIndex = 17;
            label3.Text = "Phí dịch vụ";
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSubmit.BackColor = Color.ForestGreen;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = SystemColors.ActiveCaptionText;
            btnSubmit.Location = new Point(396, 198);
            btnSubmit.Margin = new Padding(2, 2, 2, 2);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(210, 37);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Tạo";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtService
            // 
            txtService.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtService.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtService.Location = new Point(174, 151);
            txtService.Margin = new Padding(2, 2, 2, 2);
            txtService.Name = "txtService";
            txtService.Size = new Size(433, 43);
            txtService.TabIndex = 16;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(12, 58);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(191, 37);
            label4.TabIndex = 10;
            label4.Text = "Số thành viên";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(12, 13);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(152, 37);
            label2.TabIndex = 8;
            label2.Text = "Tên phòng";
            // 
            // txtNumbermember
            // 
            txtNumbermember.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNumbermember.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumbermember.Location = new Point(203, 60);
            txtNumbermember.Margin = new Padding(2, 2, 2, 2);
            txtNumbermember.Name = "txtNumbermember";
            txtNumbermember.Size = new Size(403, 43);
            txtNumbermember.TabIndex = 7;
            // 
            // txtNameroom
            // 
            txtNameroom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNameroom.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNameroom.Location = new Point(182, 13);
            txtNameroom.Margin = new Padding(2, 2, 2, 2);
            txtNameroom.Name = "txtNameroom";
            txtNameroom.Size = new Size(424, 43);
            txtNameroom.TabIndex = 5;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(12, 102);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(177, 37);
            label5.TabIndex = 13;
            label5.Text = "Phí thuê nhà";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 2, 1);
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(782, 403);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Location = new Point(2, 2);
            panel2.Margin = new Padding(2, 2, 2, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(72, 75);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientActiveCaption;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(705, 82);
            panel3.Margin = new Padding(2, 2, 2, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1, 237);
            panel3.TabIndex = 7;
            // 
            // frmCreateroom
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(782, 403);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "frmCreateroom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo phòng";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label4;
        private Label label2;
        private TextBox txtNumbermember;
        private TextBox txtNameroom;
        private Button btnSubmit;
        private Label label5;
        private TextBox txtService;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox txtPriceRent;
        private Label label3;
    }
}