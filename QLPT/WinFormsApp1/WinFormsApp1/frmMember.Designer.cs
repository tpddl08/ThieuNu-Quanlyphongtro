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
            label1 = new Label();
            btnSubmit = new Button();
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
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(47, 59);
            label1.Name = "label1";
            label1.Size = new Size(506, 54);
            label1.TabIndex = 7;
            label1.Text = "THÔNG TIN THÀNH VIÊN";
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.None;
            btnSubmit.BackColor = Color.ForestGreen;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(782, 146);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 46);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Lưu";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // frmMember
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(btnSubmit);
            Controls.Add(label1);
            Controls.Add(dgvMember);
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
        private Label label1;
        private Button btnSubmit;
    }
}