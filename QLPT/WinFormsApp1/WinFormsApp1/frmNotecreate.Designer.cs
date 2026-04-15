namespace ThieunuQLPT
{
    partial class frmNotecreate
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
            lblTitle = new Label();
            lblName = new Label();
            lblContent = new Label();
            lblError = new Label();
            txtTitle = new TextBox();
            rtbContent = new RichTextBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(31, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(250, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TẠO BẢNG TIN";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.Location = new Point(43, 86);
            lblName.Name = "lblName";
            lblName.Size = new Size(98, 32);
            lblName.TabIndex = 1;
            lblName.Text = "Tiêu đề";
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblContent.Location = new Point(47, 160);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(122, 32);
            lblContent.TabIndex = 2;
            lblContent.Text = "Nội dung";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblError.Location = new Point(47, 326);
            lblError.Name = "lblError";
            lblError.Size = new Size(48, 32);
            lblError.TabIndex = 3;
            lblError.Text = "Lỗi";
            // 
            // txtTitle
            // 
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Font = new Font("Segoe UI", 10F);
            txtTitle.Location = new Point(206, 86);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(429, 34);
            txtTitle.TabIndex = 4;
            // 
            // rtbContent
            // 
            rtbContent.BorderStyle = BorderStyle.FixedSingle;
            rtbContent.Font = new Font("Segoe UI", 10F);
            rtbContent.Location = new Point(206, 160);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(594, 100);
            rtbContent.TabIndex = 5;
            rtbContent.Text = "";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DarkOrange;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmit.Location = new Point(599, 383);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(201, 49);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Đăng bảng tin";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkOrange;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.Location = new Point(448, 383);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 49);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmNotecreate
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(rtbContent);
            Controls.Add(txtTitle);
            Controls.Add(lblError);
            Controls.Add(lblContent);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Name = "frmNotecreate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo bảng tin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblName;
        private Label lblContent;
        private Label lblError;
        private TextBox txtTitle;
        private RichTextBox rtbContent;
        private Button btnSubmit;
        private Button btnCancel;
    }
}