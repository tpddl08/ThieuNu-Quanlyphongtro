namespace ThieunuQLPT
{
    partial class frmNotedetail
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
            lblAuthor = new Label();
            lblDate = new Label();
            lblPinstatus = new Label();
            rtbContent = new RichTextBox();
            btnTogglepin = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(27, 95);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(157, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Tên bảng tin";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAuthor.Location = new Point(27, 26);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(93, 32);
            lblAuthor.TabIndex = 6;
            lblAuthor.Text = "Tác giả";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDate.Location = new Point(362, 26);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(74, 32);
            lblDate.TabIndex = 7;
            lblDate.Text = "Ngày";
            // 
            // lblPinstatus
            // 
            lblPinstatus.AutoSize = true;
            lblPinstatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPinstatus.Location = new Point(716, 26);
            lblPinstatus.Name = "lblPinstatus";
            lblPinstatus.Size = new Size(74, 32);
            lblPinstatus.TabIndex = 8;
            lblPinstatus.Text = "Ghim";
            // 
            // rtbContent
            // 
            rtbContent.BorderStyle = BorderStyle.FixedSingle;
            rtbContent.Font = new Font("Segoe UI", 10F);
            rtbContent.Location = new Point(27, 149);
            rtbContent.Name = "rtbContent";
            rtbContent.ReadOnly = true;
            rtbContent.Size = new Size(705, 264);
            rtbContent.TabIndex = 9;
            rtbContent.Text = "";
            // 
            // btnTogglepin
            // 
            btnTogglepin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTogglepin.BackColor = Color.DarkOrange;
            btnTogglepin.FlatStyle = FlatStyle.Flat;
            btnTogglepin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTogglepin.Location = new Point(765, 149);
            btnTogglepin.Name = "btnTogglepin";
            btnTogglepin.Size = new Size(112, 46);
            btnTogglepin.TabIndex = 10;
            btnTogglepin.Text = "Ghim";
            btnTogglepin.UseVisualStyleBackColor = false;
            btnTogglepin.Click += btnTogglepin_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.DarkOrange;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDelete.Location = new Point(765, 237);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 46);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.DarkOrange;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.Location = new Point(765, 321);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(112, 46);
            btnClose.TabIndex = 12;
            btnClose.Text = "Thoát";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // frmNotedetail
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnTogglepin);
            Controls.Add(rtbContent);
            Controls.Add(lblPinstatus);
            Controls.Add(lblDate);
            Controls.Add(lblAuthor);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Name = "frmNotedetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết bảng tin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblAuthor;
        private Label lblDate;
        private Label lblPinstatus;
        private RichTextBox rtbContent;
        private Button btnTogglepin;
        private Button btnDelete;
        private Button btnClose;
    }
}