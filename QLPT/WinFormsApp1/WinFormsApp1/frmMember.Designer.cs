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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvMember = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colNumberphone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            lblNoti = new Label();
            btnSubmit = new Button();
            btnCreateroom = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMember).BeginInit();
            SuspendLayout();
            // 
            // dgvMember
            // 
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvMember.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvMember.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMember.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMember.BackgroundColor = Color.LightGray;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMember.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMember.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMember.Columns.AddRange(new DataGridViewColumn[] { colName, colNumberphone, colEmail, colEdit });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvMember.DefaultCellStyle = dataGridViewCellStyle4;
            dgvMember.Location = new Point(47, 125);
            dgvMember.Name = "dgvMember";
            dgvMember.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvMember.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvMember.RowHeadersWidth = 62;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvMember.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvMember.RowTemplate.Height = 100;
            dgvMember.Size = new Size(699, 328);
            dgvMember.TabIndex = 0;
            dgvMember.CellContentClick += dgvMember_CellContentClick;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            colName.DefaultCellStyle = dataGridViewCellStyle3;
            colName.HeaderText = "Tên";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colNumberphone
            // 
            colNumberphone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNumberphone.HeaderText = "Số điện thoại";
            colNumberphone.MinimumWidth = 8;
            colNumberphone.Name = "colNumberphone";
            colNumberphone.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 8;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colEdit
            // 
            colEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colEdit.HeaderText = "Sửa";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Width = 82;
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
            btnSubmit.Location = new Point(770, 125);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 46);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Lưu";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCreateroom
            // 
            btnCreateroom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCreateroom.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateroom.Location = new Point(309, 12);
            btnCreateroom.Name = "btnCreateroom";
            btnCreateroom.Size = new Size(391, 98);
            btnCreateroom.TabIndex = 10;
            btnCreateroom.Text = "Tạo phòng";
            btnCreateroom.UseVisualStyleBackColor = true;
            btnCreateroom.Click += btnCreateroom_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(770, 197);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 46);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(770, 287);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 46);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
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