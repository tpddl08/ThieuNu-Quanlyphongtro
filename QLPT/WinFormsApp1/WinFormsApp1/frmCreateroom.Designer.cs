namespace ThieunuQLPT
{
    partial class frmCreateroom
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
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtNumbermember = new TextBox();
            txtAddress = new TextBox();
            txtNameroom = new TextBox();
            btnSubmit = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(276, 9);
            label1.Name = "label1";
            label1.Size = new Size(392, 81);
            label1.TabIndex = 6;
            label1.Text = "TẠO PHÒNG";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtNumbermember);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(txtNameroom);
            panel1.Controls.Add(btnSubmit);
            panel1.Location = new Point(126, 102);
            panel1.Name = "panel1";
            panel1.Size = new Size(684, 354);
            panel1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(30, 178);
            label4.Name = "label4";
            label4.Size = new Size(224, 45);
            label4.TabIndex = 10;
            label4.Text = "Số thành viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(30, 100);
            label3.Name = "label3";
            label3.Size = new Size(122, 45);
            label3.TabIndex = 9;
            label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(30, 35);
            label2.Name = "label2";
            label2.Size = new Size(179, 45);
            label2.TabIndex = 8;
            label2.Text = "Tên phòng";
            // 
            // txtNumbermember
            // 
            txtNumbermember.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNumbermember.Location = new Point(262, 173);
            txtNumbermember.Name = "txtNumbermember";
            txtNumbermember.Size = new Size(376, 50);
            txtNumbermember.TabIndex = 7;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(262, 100);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(376, 50);
            txtAddress.TabIndex = 6;
            // 
            // txtNameroom
            // 
            txtNameroom.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNameroom.Location = new Point(262, 35);
            txtNameroom.Name = "txtNameroom";
            txtNameroom.Size = new Size(376, 50);
            txtNameroom.TabIndex = 5;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.ForestGreen;
            btnSubmit.FlatStyle = FlatStyle.Popup;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = SystemColors.ActiveCaptionText;
            btnSubmit.Location = new Point(235, 266);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(208, 46);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Tạo";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // frmCreateroom
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(938, 484);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "frmCreateroom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo phòng";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtNumbermember;
        private TextBox txtAddress;
        private TextBox txtNameroom;
        private Button btnSubmit;
    }
}