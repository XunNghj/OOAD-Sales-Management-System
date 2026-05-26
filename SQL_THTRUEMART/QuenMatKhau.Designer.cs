namespace SQL_THTRUEMART
{
    partial class QuenMatKhau
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMainLayout = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlFormContainer = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblFormDesc = new System.Windows.Forms.Label();
            this.lblEmailLabel = new System.Windows.Forms.Label();
            this.pnlEmailBg = new System.Windows.Forms.Panel();
            this.lblEmailIcon = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlBackLink = new System.Windows.Forms.Panel();
            this.lblBackIcon = new System.Windows.Forms.Label();
            this.lblBackText = new System.Windows.Forms.Label();
            this.pnlHelpCard = new System.Windows.Forms.Panel();
            this.lblHelpIcon = new System.Windows.Forms.Label();
            this.lblHelpTitle = new System.Windows.Forms.Label();
            this.lblHelpDesc = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.lblEditorialTitle = new System.Windows.Forms.Label();
            this.lblEditorialDesc = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.pbEditorialImage = new System.Windows.Forms.PictureBox();
            this.pnlMainLayout.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFormContainer.SuspendLayout();
            this.pnlEmailBg.SuspendLayout();
            this.pnlBackLink.SuspendLayout();
            this.pnlHelpCard.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditorialImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainLayout
            // 
            this.pnlMainLayout.Controls.Add(this.pnlRight);
            this.pnlMainLayout.Controls.Add(this.pnlLeft);
            this.pnlMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainLayout.Location = new System.Drawing.Point(0, 0);
            this.pnlMainLayout.Name = "pnlMainLayout";
            this.pnlMainLayout.Size = new System.Drawing.Size(1440, 900);
            this.pnlMainLayout.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.pnlRight.Controls.Add(this.pnlFormContainer);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(650, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(790, 900);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlFormContainer
            // 
            this.pnlFormContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormContainer.Controls.Add(this.lblFormTitle);
            this.pnlFormContainer.Controls.Add(this.lblFormDesc);
            this.pnlFormContainer.Controls.Add(this.lblEmailLabel);
            this.pnlFormContainer.Controls.Add(this.pnlEmailBg);
            this.pnlFormContainer.Controls.Add(this.btnSubmit);
            this.pnlFormContainer.Controls.Add(this.pnlBackLink);
            this.pnlFormContainer.Controls.Add(this.pnlHelpCard);
            this.pnlFormContainer.Location = new System.Drawing.Point(155, 100);
            this.pnlFormContainer.Name = "pnlFormContainer";
            this.pnlFormContainer.Size = new System.Drawing.Size(503, 700);
            this.pnlFormContainer.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lblFormTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(444, 72);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Quên mật khẩu?";
            // 
            // lblFormDesc
            // 
            this.lblFormDesc.AutoSize = true;
            this.lblFormDesc.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(71)))), ((int)(((byte)(81)))));
            this.lblFormDesc.Location = new System.Drawing.Point(0, 88);
            this.lblFormDesc.Name = "lblFormDesc";
            this.lblFormDesc.Size = new System.Drawing.Size(453, 23);
            this.lblFormDesc.TabIndex = 1;
            this.lblFormDesc.Text = "Nhập email của bạn để nhận liên kết khôi phục mật khẩu.";
            // 
            // lblEmailLabel
            // 
            this.lblEmailLabel.AutoSize = true;
            this.lblEmailLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblEmailLabel.Location = new System.Drawing.Point(0, 130);
            this.lblEmailLabel.Name = "lblEmailLabel";
            this.lblEmailLabel.Size = new System.Drawing.Size(115, 20);
            this.lblEmailLabel.TabIndex = 2;
            this.lblEmailLabel.Text = "ĐỊA CHỈ EMAIL";
            // 
            // pnlEmailBg
            // 
            this.pnlEmailBg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.pnlEmailBg.Controls.Add(this.lblEmailIcon);
            this.pnlEmailBg.Controls.Add(this.txtEmail);
            this.pnlEmailBg.Location = new System.Drawing.Point(0, 160);
            this.pnlEmailBg.Name = "pnlEmailBg";
            this.pnlEmailBg.Size = new System.Drawing.Size(500, 60);
            this.pnlEmailBg.TabIndex = 3;
            // 
            // lblEmailIcon
            // 
            this.lblEmailIcon.AutoSize = true;
            this.lblEmailIcon.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblEmailIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(119)))), ((int)(((byte)(130)))));
            this.lblEmailIcon.Location = new System.Drawing.Point(5, 15);
            this.lblEmailIcon.Name = "lblEmailIcon";
            this.lblEmailIcon.Size = new System.Drawing.Size(47, 32);
            this.lblEmailIcon.TabIndex = 0;
            this.lblEmailIcon.Text = "✉";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(232)))), ((int)(((byte)(239)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.txtEmail.Location = new System.Drawing.Point(68, 17);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(426, 27);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Text = "example@thmilk.vn";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(115)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(0, 250);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(500, 60);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Gửi liên kết khôi phục";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // pnlBackLink
            // 
            this.pnlBackLink.Controls.Add(this.lblBackIcon);
            this.pnlBackLink.Controls.Add(this.lblBackText);
            this.pnlBackLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlBackLink.Location = new System.Drawing.Point(0, 340);
            this.pnlBackLink.Name = "pnlBackLink";
            this.pnlBackLink.Size = new System.Drawing.Size(250, 30);
            this.pnlBackLink.TabIndex = 5;
            // 
            // lblBackIcon
            // 
            this.lblBackIcon.AutoSize = true;
            this.lblBackIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBackIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(115)))));
            this.lblBackIcon.Location = new System.Drawing.Point(0, 3);
            this.lblBackIcon.Name = "lblBackIcon";
            this.lblBackIcon.Size = new System.Drawing.Size(29, 28);
            this.lblBackIcon.TabIndex = 0;
            this.lblBackIcon.Text = "←";
            // 
            // lblBackText
            // 
            this.lblBackText.AutoSize = true;
            this.lblBackText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBackText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(115)))));
            this.lblBackText.Location = new System.Drawing.Point(30, 4);
            this.lblBackText.Name = "lblBackText";
            this.lblBackText.Size = new System.Drawing.Size(186, 25);
            this.lblBackText.TabIndex = 1;
            this.lblBackText.Text = "Quay lại Đăng nhập";
            // 
            // pnlHelpCard
            // 
            this.pnlHelpCard.BackColor = System.Drawing.Color.White;
            this.pnlHelpCard.Controls.Add(this.lblHelpIcon);
            this.pnlHelpCard.Controls.Add(this.lblHelpTitle);
            this.pnlHelpCard.Controls.Add(this.lblHelpDesc);
            this.pnlHelpCard.Location = new System.Drawing.Point(0, 420);
            this.pnlHelpCard.Name = "pnlHelpCard";
            this.pnlHelpCard.Size = new System.Drawing.Size(500, 120);
            this.pnlHelpCard.TabIndex = 6;
            // 
            // lblHelpIcon
            // 
            this.lblHelpIcon.AutoSize = true;
            this.lblHelpIcon.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblHelpIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.lblHelpIcon.Location = new System.Drawing.Point(5, 45);
            this.lblHelpIcon.Name = "lblHelpIcon";
            this.lblHelpIcon.Size = new System.Drawing.Size(0, 37);
            this.lblHelpIcon.TabIndex = 0;
            // 
            // lblHelpTitle
            // 
            this.lblHelpTitle.AutoSize = true;
            this.lblHelpTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHelpTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(33)))));
            this.lblHelpTitle.Location = new System.Drawing.Point(188, 12);
            this.lblHelpTitle.Name = "lblHelpTitle";
            this.lblHelpTitle.Size = new System.Drawing.Size(114, 25);
            this.lblHelpTitle.TabIndex = 1;
            this.lblHelpTitle.Text = "Cần hỗ trợ?";
            // 
            // lblHelpDesc
            // 
            this.lblHelpDesc.AutoSize = true;
            this.lblHelpDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHelpDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(71)))), ((int)(((byte)(81)))));
            this.lblHelpDesc.Location = new System.Drawing.Point(1, 36);
            this.lblHelpDesc.Name = "lblHelpDesc";
            this.lblHelpDesc.Size = new System.Drawing.Size(441, 46);
            this.lblHelpDesc.TabIndex = 2;
            this.lblHelpDesc.Text = "Nếu bạn không nhận được email trong 5 phút, vui lòng\r\nkiểm tra hộp thư rác hoặc l" +
    "iên hệ  hotline: 1800 54 54 40";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(156)))));
            this.pnlLeft.Controls.Add(this.lblBrandName);
            this.pnlLeft.Controls.Add(this.lblEditorialTitle);
            this.pnlLeft.Controls.Add(this.lblEditorialDesc);
            this.pnlLeft.Controls.Add(this.lblCopyright);
            this.pnlLeft.Controls.Add(this.pbEditorialImage);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(650, 900);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblBrandName
            // 
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBrandName.ForeColor = System.Drawing.Color.White;
            this.lblBrandName.Location = new System.Drawing.Point(60, 60);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(224, 46);
            this.lblBrandName.TabIndex = 0;
            this.lblBrandName.Text = "TH TrueMart";
            // 
            // lblEditorialTitle
            // 
            this.lblEditorialTitle.AutoSize = true;
            this.lblEditorialTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblEditorialTitle.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold);
            this.lblEditorialTitle.ForeColor = System.Drawing.Color.White;
            this.lblEditorialTitle.Location = new System.Drawing.Point(50, 320);
            this.lblEditorialTitle.Name = "lblEditorialTitle";
            this.lblEditorialTitle.Size = new System.Drawing.Size(489, 212);
            this.lblEditorialTitle.TabIndex = 1;
            this.lblEditorialTitle.Text = "The Pristine\nHarvest.";
            // 
            // lblEditorialDesc
            // 
            this.lblEditorialDesc.AutoSize = true;
            this.lblEditorialDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblEditorialDesc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEditorialDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblEditorialDesc.Location = new System.Drawing.Point(63, 532);
            this.lblEditorialDesc.Name = "lblEditorialDesc";
            this.lblEditorialDesc.Size = new System.Drawing.Size(417, 56);
            this.lblEditorialDesc.TabIndex = 2;
            this.lblEditorialDesc.Text = "Mang đến nguồn dinh dưỡng tươi sạch, \r\ntinh khiết nhất từ những cánh đồng xanh ng" +
    "át.";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblCopyright.Location = new System.Drawing.Point(60, 820);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(315, 23);
            this.lblCopyright.TabIndex = 3;
            this.lblCopyright.Text = "© 2024 TH TrueMart. All rights reserved.";
            // 
            // pbEditorialImage
            // 
            this.pbEditorialImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbEditorialImage.Location = new System.Drawing.Point(0, 0);
            this.pbEditorialImage.Name = "pbEditorialImage";
            this.pbEditorialImage.Size = new System.Drawing.Size(650, 900);
            this.pbEditorialImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEditorialImage.TabIndex = 0;
            this.pbEditorialImage.TabStop = false;
            // 
            // QuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1440, 900);
            this.Controls.Add(this.pnlMainLayout);
            this.Name = "QuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TH TrueMart | Quên Mật Khẩu";
            this.pnlMainLayout.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlFormContainer.ResumeLayout(false);
            this.pnlFormContainer.PerformLayout();
            this.pnlEmailBg.ResumeLayout(false);
            this.pnlEmailBg.PerformLayout();
            this.pnlBackLink.ResumeLayout(false);
            this.pnlBackLink.PerformLayout();
            this.pnlHelpCard.ResumeLayout(false);
            this.pnlHelpCard.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditorialImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo biến UI
        private System.Windows.Forms.Panel pnlMainLayout;

        // Left Side
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox pbEditorialImage;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.Label lblEditorialTitle;
        private System.Windows.Forms.Label lblEditorialDesc;
        private System.Windows.Forms.Label lblCopyright;

        // Right Side
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlFormContainer;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblFormDesc;

        private System.Windows.Forms.Label lblEmailLabel;
        private System.Windows.Forms.Panel pnlEmailBg;
        private System.Windows.Forms.Label lblEmailIcon;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Button btnSubmit;

        private System.Windows.Forms.Panel pnlBackLink;
        private System.Windows.Forms.Label lblBackIcon;
        private System.Windows.Forms.Label lblBackText;

        private System.Windows.Forms.Panel pnlHelpCard;
        private System.Windows.Forms.Label lblHelpIcon;
        private System.Windows.Forms.Label lblHelpTitle;
        private System.Windows.Forms.Label lblHelpDesc;
    }
}