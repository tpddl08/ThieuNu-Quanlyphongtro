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
            label4 = new Label();
            label2 = new Label();
            txtNumbermember = new TextBox();
            txtNameroom = new TextBox();
            txtService = new TextBox();
            txtWatter = new TextBox();
            txtElectric = new TextBox();
            label5 = new Label();
            label6 = new Label();
            lb7 = new Label();
            btnSubmit = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(96, 0);
            label1.Name = "label1";
            label1.Size = new Size(369, 96);
            label1.TabIndex = 6;
            label1.Text = "TẠO PHÒNG";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(txtService);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtNumbermember);
            panel1.Controls.Add(txtNameroom);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(96, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size(369, 284);
            panel1.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(14, 92);
            label4.Name = "label4";
            label4.Size = new Size(224, 45);
            label4.TabIndex = 10;
            label4.Text = "Số thành viên";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(14, 16);
            label2.Name = "label2";
            label2.Size = new Size(179, 45);
            label2.TabIndex = 8;
            label2.Text = "Tên phòng";
            // 
            // txtNumbermember
            // 
            txtNumbermember.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNumbermember.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumbermember.Location = new Point(244, 92);
            txtNumbermember.Name = "txtNumbermember";
            txtNumbermember.Size = new Size(107, 50);
            txtNumbermember.TabIndex = 7;
            // 
            // txtNameroom
            // 
            txtNameroom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNameroom.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNameroom.Location = new Point(219, 16);
            txtNameroom.Name = "txtNameroom";
            txtNameroom.Size = new Size(132, 50);
            txtNameroom.TabIndex = 5;
            // 
            // txtService
            // 
            txtService.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtService.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtService.Location = new Point(209, 170);
            txtService.Name = "txtService";
            txtService.Size = new Size(142, 50);
            txtService.TabIndex = 16;
            // 
            // txtWatter
            // 
            txtWatter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtWatter.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtWatter.Location = new Point(201, 92);
            txtWatter.Name = "txtWatter";
            txtWatter.Size = new Size(142, 50);
            txtWatter.TabIndex = 15;
            // 
            // txtElectric
            // 
            txtElectric.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtElectric.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtElectric.Location = new Point(201, 16);
            txtElectric.Name = "txtElectric";
            txtElectric.Size = new Size(142, 50);
            txtElectric.TabIndex = 14;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(14, 170);
            label5.Name = "label5";
            label5.Size = new Size(161, 45);
            label5.TabIndex = 13;
            label5.Text = "Phí nhà ở";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(14, 95);
            label6.Name = "label6";
            label6.Size = new Size(168, 45);
            label6.TabIndex = 12;
            label6.Text = "Tiền nước";
            // 
            // lb7
            // 
            lb7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lb7.AutoSize = true;
            lb7.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lb7.ForeColor = Color.Black;
            lb7.Location = new Point(14, 16);
            lb7.Name = "lb7";
            lb7.Size = new Size(158, 45);
            lb7.TabIndex = 11;
            lb7.Text = "Tiền điện";
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSubmit.BackColor = Color.ForestGreen;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = SystemColors.ActiveCaptionText;
            btnSubmit.Location = new Point(233, 176);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(110, 44);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Tạo";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 2, 1);
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(938, 484);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(87, 90);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientActiveCaption;
            panel3.Controls.Add(lb7);
            panel3.Controls.Add(txtWatter);
            panel3.Controls.Add(btnSubmit);
            panel3.Controls.Add(txtElectric);
            panel3.Controls.Add(label6);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(471, 99);
            panel3.Name = "panel3";
            panel3.Size = new Size(369, 284);
            panel3.TabIndex = 7;
            // 
            // frmCreateroom
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(tableLayoutPanel1);
            Name = "frmCreateroom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo phòng";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private Label label6;
        private Label lb7;
        private TextBox txtService;
        private TextBox txtWatter;
        private TextBox txtElectric;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
    }
}