namespace ThieunuQLPT
{
    partial class frmListExpense
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvExpenses = new DataGridView();
            date = new DataGridViewTextBoxColumn();
            title = new DataGridViewTextBoxColumn();
            amount = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            lblFundhave = new Label();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            // 
            // dgvExpenses
            // 
            dgvExpenses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Columns.AddRange(new DataGridViewColumn[] { date, title, amount, name });
            dgvExpenses.Location = new Point(30, 147);
            dgvExpenses.Margin = new Padding(4);
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.RowHeadersWidth = 51;
            dgvExpenses.Size = new Size(873, 312);
            dgvExpenses.TabIndex = 0;
            // 
            // date
            // 
            date.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            date.HeaderText = "Ngày";
            date.MinimumWidth = 6;
            date.Name = "date";
            // 
            // title
            // 
            title.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            title.HeaderText = "Nội dung";
            title.MinimumWidth = 6;
            title.Name = "title";
            title.ReadOnly = true;
            // 
            // amount
            // 
            amount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            amount.HeaderText = "Số tiền";
            amount.MinimumWidth = 6;
            amount.Name = "amount";
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.HeaderText = "Tên người chi";
            name.MinimumWidth = 6;
            name.Name = "name";
            // 
            // lblFundhave
            // 
            lblFundhave.AutoSize = true;
            lblFundhave.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFundhave.Location = new Point(30, 54);
            lblFundhave.Name = "lblFundhave";
            lblFundhave.Size = new Size(366, 54);
            lblFundhave.TabIndex = 1;
            lblFundhave.Text = "Danh sách chi tiêu";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.DarkOrange;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(740, 54);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(163, 54);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm chi tiêu";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // frmListExpense
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnAdd);
            Controls.Add(lblFundhave);
            Controls.Add(dgvExpenses);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmListExpense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách chi tiêu";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvExpenses;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn amount;
        private DataGridViewTextBoxColumn name;
        private Label lblFundhave;
        private Button btnAdd;
    }
}