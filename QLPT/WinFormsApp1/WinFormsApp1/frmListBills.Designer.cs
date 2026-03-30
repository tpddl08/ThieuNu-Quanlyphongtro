namespace ThieunuQLPT
{
    partial class frmListBills
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
            dataGridView1 = new DataGridView();
            btnAll = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(4, 101);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(779, 386);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAll
            // 
            btnAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAll.Location = new Point(808, 144);
            btnAll.Margin = new Padding(4);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(118, 36);
            btnAll.TabIndex = 1;
            btnAll.Text = "Tất cả";
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += btnAll_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.Location = new Point(807, 101);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(118, 36);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // frmListBills
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(938, 484);
            Controls.Add(btnAdd);
            Controls.Add(btnAll);
            Controls.Add(dataGridView1);
            Margin = new Padding(4);
            Name = "frmListBills";
            Text = "Danh sách hóa đơn";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAll;
        private Button btnAdd;
    }
}