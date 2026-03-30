namespace ThieunuQLPT
{
    partial class frmChores
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
            lblNoti = new Label();
            btnDelete = new Button();
            btnSubmit = new Button();
            btnAdd = new Button();
            dgvChores = new DataGridView();
            colNamework = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnDone = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvChores).BeginInit();
            SuspendLayout();
            // 
            // lblNoti
            // 
            lblNoti.AutoSize = true;
            lblNoti.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoti.Location = new Point(44, 36);
            lblNoti.Name = "lblNoti";
            lblNoti.Size = new Size(202, 54);
            lblNoti.TabIndex = 14;
            lblNoti.Text = "Trực nhật";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(767, 268);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 46);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSubmit.BackColor = Color.RoyalBlue;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(767, 123);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 46);
            btnSubmit.TabIndex = 15;
            btnSubmit.Text = "Lưu";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.ForestGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(767, 195);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 46);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Tạo";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvChores
            // 
            dgvChores.AllowUserToAddRows = false;
            dgvChores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvChores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvChores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvChores.BackgroundColor = Color.LightGray;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvChores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvChores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChores.Columns.AddRange(new DataGridViewColumn[] { colNamework, colName, colTime, colStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvChores.DefaultCellStyle = dataGridViewCellStyle4;
            dgvChores.Location = new Point(44, 123);
            dgvChores.Name = "dgvChores";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvChores.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvChores.RowHeadersWidth = 62;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvChores.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvChores.RowTemplate.Height = 100;
            dgvChores.Size = new Size(699, 328);
            dgvChores.TabIndex = 13;
            dgvChores.CellContentClick += dgvChores_CellContentClick;
            // 
            // colNamework
            // 
            colNamework.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            colNamework.DefaultCellStyle = dataGridViewCellStyle3;
            colNamework.HeaderText = "Tên công việc";
            colNamework.MinimumWidth = 8;
            colNamework.Name = "colNamework";
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.HeaderText = "Tên người làm";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            // 
            // colTime
            // 
            colTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTime.HeaderText = "Thời gian thực hiện";
            colTime.MinimumWidth = 8;
            colTime.Name = "colTime";
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.HeaderText = "Trạng thái";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            // 
            // btnDone
            // 
            btnDone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDone.BackColor = Color.ForestGreen;
            btnDone.FlatStyle = FlatStyle.Flat;
            btnDone.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDone.Location = new Point(767, 346);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(128, 46);
            btnDone.TabIndex = 19;
            btnDone.Text = "Xong";
            btnDone.UseVisualStyleBackColor = false;
            btnDone.Click += btnDone_Click;
            // 
            // frmChores
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(938, 484);
            Controls.Add(btnDone);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnSubmit);
            Controls.Add(lblNoti);
            Controls.Add(dgvChores);
            Name = "frmChores";
            Text = "Trực nhật";
            WindowState = FormWindowState.Maximized;
            Load += frmChores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNoti;
        private Button btnDelete;
        private Button btnSubmit;
        private Button btnAdd;
        private DataGridView dgvChores;
        private DataGridViewTextBoxColumn colNamework;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colStatus;
        private Button btnDone;
    }
}