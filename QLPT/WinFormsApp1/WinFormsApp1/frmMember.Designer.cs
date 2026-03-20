namespace ThieunuQLPT
{
    partial class frmMember
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
            dgvMember = new DataGridView();
            lblNotification = new Label();
            btnSubmit = new Button();
            btnCreateroom = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMember).BeginInit();
            SuspendLayout();
            // 
            // dgvMember
            // 
            dgvMember.Anchor = AnchorStyles.None;
            dgvMember.BackgroundColor = Color.Navy;
            dgvMember.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMember.Location = new Point(47, 146);
            dgvMember.Name = "dgvMember";
            dgvMember.RowHeadersWidth = 62;
            dgvMember.Size = new Size(699, 298);
            dgvMember.TabIndex = 0;
            // 
            // lblNotification
            // 
            lblNotification.Anchor = AnchorStyles.None;
            lblNotification.AutoSize = true;
            lblNotification.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotification.Location = new Point(47, 35);
            lblNotification.Name = "lblNotification";
            lblNotification.Size = new Size(205, 54);
            lblNotification.TabIndex = 7;
            lblNotification.Text = "Thông tin";
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.None;
            btnSubmit.BackColor = Color.CornflowerBlue;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(782, 146);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 46);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Lưu";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // btnCreateroom
            // 
            btnCreateroom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateroom.Location = new Point(364, 231);
            btnCreateroom.Name = "btnCreateroom";
            btnCreateroom.Size = new Size(205, 48);
            btnCreateroom.TabIndex = 10;
            btnCreateroom.Text = "Tạo phòng";
            btnCreateroom.UseVisualStyleBackColor = true;
            btnCreateroom.Visible = false;
            btnCreateroom.Click += btnCreateroom_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(782, 218);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 46);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.None;
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(782, 295);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 46);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // frmMember
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnCreateroom);
            Controls.Add(btnSubmit);
            Controls.Add(lblNotification);
            Controls.Add(dgvMember);
            Name = "frmMember";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách thành viên";
            ((System.ComponentModel.ISupportInitialize)dgvMember).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMember;
        private Label lblNotification;
        private Button btnSubmit;
        private Button btnCreateroom;
        private Button btnAdd;
        private Button btnDelete;
    }
}