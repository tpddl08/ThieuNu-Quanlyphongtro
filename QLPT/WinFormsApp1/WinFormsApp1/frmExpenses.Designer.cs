namespace ThieunuQLPT
{
    partial class frmExpenses
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
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            txtAmount = new TextBox();
            label3 = new Label();
            dtpDate = new DateTimePicker();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(178, 86);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 0;
            label1.Text = "Nội dung";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(277, 79);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(266, 27);
            txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 129);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 2;
            label2.Text = "Số tiền";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(293, 129);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(266, 27);
            txtAmount.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 238);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 4;
            label3.Text = "Ngày";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(111, 233);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(153, 27);
            dtpDate.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(528, 344);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 59);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // frmExpenses
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(dtpDate);
            Controls.Add(label3);
            Controls.Add(txtAmount);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "frmExpenses";
            Text = "frmExpenses";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtAmount;
        private Label label3;
        private DateTimePicker dtpDate;
        private Button btnAdd;
    }
}