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
            lblNoti = new Label();
            btnSubmit = new Button();
            btnCreateroom = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            colName = new DataGridViewTextBoxColumn();
            colNumberphone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMember).BeginInit();
            SuspendLayout();
            // 
            // dgvMember
            // 
            dgvMember.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMember.BackgroundColor = Color.LightGray;
            dgvMember.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMember.Columns.AddRange(new DataGridViewColumn[] { colName, colNumberphone, colEmail, colEdit });
            dgvMember.Location = new Point(47, 146);
            dgvMember.Name = "dgvMember";
            dgvMember.RowHeadersWidth = 62;
            dgvMember.Size = new Size(699, 298);
            dgvMember.TabIndex = 0;
            // 
            // lblNoti
            // 
            lblNoti.AutoSize = true;
            lblNoti.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoti.Location = new Point(47, 35);
            lblNoti.Name = "lblNoti";
            lblNoti.Size = new Size(205, 54);
            lblNoti.TabIndex = 7;
            lblNoti.Text = "Thông tin";
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            btnCreateroom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCreateroom.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateroom.Location = new Point(298, 188);
            btnCreateroom.Name = "btnCreateroom";
            btnCreateroom.Size = new Size(369, 137);
            btnCreateroom.TabIndex = 10;
            btnCreateroom.Text = "Tạo phòng";
            btnCreateroom.UseVisualStyleBackColor = true;
            btnCreateroom.Visible = false;
            btnCreateroom.Click += btnCreateroom_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.HeaderText = "Tên";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            // 
            // colNumberphone
            // 
            colNumberphone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNumberphone.HeaderText = "Số điện thoại";
            colNumberphone.MinimumWidth = 8;
            colNumberphone.Name = "colNumberphone";
            // 
            // colEmail
            // 
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 8;
            colEmail.Name = "colEmail";
            // 
            // colEdit
            // 
            colEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colEdit.HeaderText = "Sửa";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.Width = 48;
            // 
            // frmMember
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnSubmit);
            Controls.Add(lblNoti);
            Controls.Add(dgvMember);
            Controls.Add(btnCreateroom);
            Name = "frmMember";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách thành viên";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvMember).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMember;
        private Label lblNoti;
        private Button btnSubmit;
        private Button btnCreateroom;
        private Button btnAdd;
        private Button btnDelete;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colNumberphone;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewButtonColumn colEdit;
    }
}