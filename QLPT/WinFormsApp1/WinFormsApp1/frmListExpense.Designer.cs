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
            dgvExpenses = new DataGridView();
            date = new DataGridViewTextBoxColumn();
            title = new DataGridViewTextBoxColumn();
            amount = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).BeginInit();
            SuspendLayout();
            // 
            // dgvExpenses
            // 
            dgvExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpenses.Columns.AddRange(new DataGridViewColumn[] { date, title, amount, name });
            dgvExpenses.Location = new Point(19, 82);
            dgvExpenses.Name = "dgvExpenses";
            dgvExpenses.RowHeadersWidth = 51;
            dgvExpenses.Size = new Size(630, 359);
            dgvExpenses.TabIndex = 0;
            // 
            // date
            // 
            date.HeaderText = "Ngày";
            date.MinimumWidth = 6;
            date.Name = "date";
            date.Width = 125;
            // 
            // title
            // 
            title.HeaderText = "Nội dung";
            title.MinimumWidth = 6;
            title.Name = "title";
            title.ReadOnly = true;
            title.Width = 125;
            // 
            // amount
            // 
            amount.HeaderText = "Số tiền";
            amount.MinimumWidth = 6;
            amount.Name = "amount";
            amount.Width = 125;
            // 
            // name
            // 
            name.HeaderText = "Tên";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.Width = 125;
            // 
            // frmListExpense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvExpenses);
            Name = "frmListExpense";
            Text = "frmListExpense";
            ((System.ComponentModel.ISupportInitialize)dgvExpenses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvExpenses;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn amount;
        private DataGridViewTextBoxColumn name;
    }
}