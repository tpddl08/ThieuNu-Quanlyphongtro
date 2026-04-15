namespace ThieunuQLPT
{
    partial class ucNoteitemcard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlCard = new Panel();
            btnPin = new Button();
            btnDelete = new Button();
            lblDate = new Label();
            btnViewdatail = new Button();
            lblTitle = new Label();
            lblSummary = new Label();
            lblPinicon = new Label();
            lblAuthor = new Label();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.MediumAquamarine;
            pnlCard.Controls.Add(btnPin);
            pnlCard.Controls.Add(btnDelete);
            pnlCard.Controls.Add(lblDate);
            pnlCard.Controls.Add(btnViewdatail);
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblSummary);
            pnlCard.Controls.Add(lblPinicon);
            pnlCard.Controls.Add(lblAuthor);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Font = new Font("Segoe UI", 10F);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(960, 540);
            pnlCard.TabIndex = 0;
            // 
            // btnPin
            // 
            btnPin.BackColor = Color.DarkOrange;
            btnPin.FlatStyle = FlatStyle.Flat;
            btnPin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPin.Location = new Point(804, 452);
            btnPin.Name = "btnPin";
            btnPin.Size = new Size(115, 45);
            btnPin.TabIndex = 8;
            btnPin.Text = "Ghim";
            btnPin.UseVisualStyleBackColor = false;
            btnPin.Click += btnPin_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DarkOrange;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.Location = new Point(656, 452);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(115, 45);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDate.Location = new Point(56, 114);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(86, 38);
            lblDate.TabIndex = 2;
            lblDate.Text = "Ngày";
            // 
            // btnViewdatail
            // 
            btnViewdatail.BackColor = Color.DarkOrange;
            btnViewdatail.FlatStyle = FlatStyle.Flat;
            btnViewdatail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewdatail.Location = new Point(455, 452);
            btnViewdatail.Name = "btnViewdatail";
            btnViewdatail.Size = new Size(170, 45);
            btnViewdatail.TabIndex = 6;
            btnViewdatail.Text = "Xem chi tiết";
            btnViewdatail.UseVisualStyleBackColor = false;
            btnViewdatail.Click += btnViewdatail_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(56, 167);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(114, 38);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Tiêu đề";
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSummary.Location = new Point(56, 216);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(140, 38);
            lblSummary.TabIndex = 4;
            lblSummary.Text = "Nội dung";
            // 
            // lblPinicon
            // 
            lblPinicon.AutoSize = true;
            lblPinicon.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPinicon.Location = new Point(831, 46);
            lblPinicon.Name = "lblPinicon";
            lblPinicon.Size = new Size(88, 38);
            lblPinicon.TabIndex = 1;
            lblPinicon.Text = "Ghim";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAuthor.Location = new Point(56, 56);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(107, 38);
            lblAuthor.TabIndex = 5;
            lblAuthor.Text = "Tác giả";
            // 
            // ucNoteitemcard
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Khaki;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnlCard);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ucNoteitemcard";
            Size = new Size(960, 540);
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCard;
        private Label lblPinicon;
        private Label lblDate;
        private Label lblTitle;
        private Label lblSummary;
        private Label lblAuthor;
        private Button btnViewdatail;
        private Button btnDelete;
        private Button btnPin;
    }
}
