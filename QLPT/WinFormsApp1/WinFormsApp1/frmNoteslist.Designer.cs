namespace ThieunuQLPT
{
    partial class frmNoteslist
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
            pnlHeader = new Panel();
            btnCreatenote = new Button();
            lblTitle = new Label();
            pnlContent = new Panel();
            flpNotelist = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Navy;
            pnlHeader.Controls.Add(btnCreatenote);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(938, 76);
            pnlHeader.TabIndex = 0;
            // 
            // btnCreatenote
            // 
            btnCreatenote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreatenote.BackColor = Color.ForestGreen;
            btnCreatenote.FlatStyle = FlatStyle.Flat;
            btnCreatenote.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreatenote.ForeColor = SystemColors.ActiveCaptionText;
            btnCreatenote.Location = new Point(678, 14);
            btnCreatenote.Name = "btnCreatenote";
            btnCreatenote.Size = new Size(239, 49);
            btnCreatenote.TabIndex = 1;
            btnCreatenote.Text = "Tạo bảng tin mới";
            btnCreatenote.UseVisualStyleBackColor = false;
            btnCreatenote.Click += btnCreatenote_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(146, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Bảng tin";
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContent.Controls.Add(flpNotelist);
            pnlContent.Location = new Point(177, 82);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(594, 401);
            pnlContent.TabIndex = 1;
            // 
            // flpNotelist
            // 
            flpNotelist.AutoScroll = true;
            flpNotelist.Dock = DockStyle.Fill;
            flpNotelist.FlowDirection = FlowDirection.TopDown;
            flpNotelist.Location = new Point(0, 0);
            flpNotelist.Name = "flpNotelist";
            flpNotelist.Size = new Size(594, 401);
            flpNotelist.TabIndex = 0;
            flpNotelist.WrapContents = false;
            // 
            // frmNoteslist
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(pnlHeader);
            Controls.Add(pnlContent);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmNoteslist";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bảng tin";
            WindowState = FormWindowState.Maximized;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnCreatenote;
        private Label lblTitle;
        private Panel pnlContent;
        private FlowLayoutPanel flpNotelist;
    }
}