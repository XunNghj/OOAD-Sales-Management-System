using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class QuenMatKhau : Form
    {
        // Khai báo bảng màu tái sử dụng (Theo chuẩn Flat Design & Tailwind Config)
        private Color cPrimary = Color.FromArgb(0, 59, 115);
        private Color cPrimaryHover = Color.FromArgb(0, 82, 156);
        private Color cBgNormal = Color.FromArgb(231, 232, 239); // surface-container-high
        private Color cBgActive = Color.White;
        private Color cTextNormal = Color.FromArgb(25, 28, 33);
        private Color cTextMuted = Color.FromArgb(150, 150, 150);

        public QuenMatKhau()
        {
            InitializeComponent();

            // Bật chống giật khung hình khi Resize Form
            this.DoubleBuffered = true;

            // Thiết lập hiệu ứng Hover, Focus
            SetupUIEffects();

            // Đăng ký Event
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;

            // Xử lý hiệu ứng Gradient Overlay trên ảnh nền cột trái
            pbEditorialImage.Paint += PbEditorialImage_Paint;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblFormTitle; // Bỏ Focus mặc định ở Textbox
            this.WindowState = FormWindowState.Maximized; // Phóng to toàn màn hình

            // Load ảnh phong cảnh đồng cỏ chất lượng cao từ Internet
            LoadImageAsync(pbEditorialImage, "https://lh3.googleusercontent.com/aida-public/AB6AXuCwbDRmtRc8cJMOqHATY79qR61AbFo53Yxir_aSQe3g5oURPxQwWtl1uQgheiUWGX3Sh_SoVCvxhD81lPM6WzcQ7y8w7WHFEqzyDY7ofweviqEfhHaVOBQKXFhcTJpKeMjCHVWfmGypSV1zX7T3pzCc0F8g0Ef_bhoVPnKRPHqfc026_u201vOfV1Zb2SDKmbs8oiM56u8ufcvLt0U_aNJ3LJ9L9iw1rwrnaDj7mhJTVzxD5B-wshk9QmIzSIZ-vdM740RbNa_0utIj");

            // Chuyển quyền quản lý các Label chữ trắng sang PictureBox để nền trong suốt (Transparency)
            MakeLabelsTransparentOverImage();

            // Cập nhật Layout tự động
            MainForm_Resize(this, EventArgs.Empty);
        }

        #region XỬ LÝ CO DÃN BẤT ĐỐI XỨNG (ASYMMETRIC RESPONSIVE GRID)

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (pnlMainLayout == null || this.ClientSize.Width == 0 || this.WindowState == FormWindowState.Minimized) return;

            int fw = this.ClientSize.Width;
            int fh = this.ClientSize.Height;

            // 1. CHIA TỶ LỆ MÀN HÌNH (45% Trái, 55% Phải)
            int leftWidth = (int)(fw * 0.45);
            pnlLeft.Width = leftWidth;

            pnlRight.Width = fw - leftWidth;
            pnlRight.Left = leftWidth;

            // 2. CĂN GIỮA FORM QUÊN MẬT KHẨU (NẰM TRONG CỘT PHẢI)
            pnlFormContainer.Left = (pnlRight.Width - pnlFormContainer.Width) / 2;
            pnlFormContainer.Top = (pnlRight.Height - pnlFormContainer.Height) / 2;

            // Cập nhật lại vị trí các Label trắng trên ảnh khi Resize (do Parent là PictureBox)
            lblBrandName.Top = 60;
            lblEditorialTitle.Top = fh / 2 - 150; // Giữa màn hình
            lblEditorialDesc.Top = lblEditorialTitle.Bottom + 20;
            lblCopyright.Top = fh - 80; // Sát đáy
        }

        // Kỹ thuật giúp Label hiển thị trong suốt hoàn hảo trên PictureBox
        private void MakeLabelsTransparentOverImage()
        {
            Label[] labels = { lblBrandName, lblEditorialTitle, lblEditorialDesc, lblCopyright };
            foreach (var lbl in labels)
            {
                // Chuyển Parent từ Panel sang PictureBox
                Point pos = pbEditorialImage.PointToClient(lbl.Parent.PointToScreen(lbl.Location));
                lbl.Parent = pbEditorialImage;
                lbl.Location = pos;
            }
        }

        // Vẽ lớp sương mù (Gradient Overlay) màu xanh dương đen đè lên ảnh
        private void PbEditorialImage_Paint(object sender, PaintEventArgs e)
        {
            // Mô phỏng class .editorial-gradient từ CSS Tailwind
            using (LinearGradientBrush brush = new LinearGradientBrush(
                e.ClipRectangle,
                Color.FromArgb(180, 0, 59, 115), // Xanh đậm 180 alpha
                Color.FromArgb(140, 0, 82, 156), // Xanh nhạt 140 alpha
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }

        #endregion

        #region XỬ LÝ HIỆU ỨNG GIAO DIỆN (HOVER / FOCUS)

        private void SetupUIEffects()
        {
            // Focus Email Input (Hiệu ứng đổi màu viền/nền và Placeholder)
            txtEmail.GotFocus += (s, e) => {
                pnlEmailBg.BackColor = cBgActive;
                txtEmail.BackColor = cBgActive;
                if (txtEmail.Text == "example@thmilk.vn")
                {
                    txtEmail.Text = "";
                    txtEmail.ForeColor = cTextNormal;
                }
            };

            txtEmail.LostFocus += (s, e) => {
                pnlEmailBg.BackColor = cBgNormal;
                txtEmail.BackColor = cBgNormal;
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    txtEmail.Text = "example@thmilk.vn";
                    txtEmail.ForeColor = cTextMuted;
                }
            };

            // Nút "Gửi liên kết khôi phục" Hover
            btnSubmit.MouseEnter += (s, e) => btnSubmit.BackColor = cPrimaryHover;
            btnSubmit.MouseLeave += (s, e) => btnSubmit.BackColor = cPrimary;

            // Link "Quay lại Đăng nhập" Hover (Gạch chân)
            pnlBackLink.MouseEnter += (s, e) => {
                lblBackText.Font = new Font(lblBackText.Font, FontStyle.Underline | FontStyle.Bold);
                lblBackIcon.Left -= 3; // Hiệu ứng đẩy mũi tên sang trái
            };
            pnlBackLink.MouseLeave += (s, e) => {
                lblBackText.Font = new Font(lblBackText.Font, FontStyle.Bold);
                lblBackIcon.Left += 3;
            };

            lblBackText.MouseEnter += (s, e) => pnlBackLink.Focus();
            lblBackIcon.MouseEnter += (s, e) => pnlBackLink.Focus();

            // Hiệu ứng Hover nhạt cho Thẻ Cần hỗ trợ (Help Card)
            pnlHelpCard.MouseEnter += (s, e) => pnlHelpCard.BackColor = Color.FromArgb(239, 239, 248);
            pnlHelpCard.MouseLeave += (s, e) => pnlHelpCard.BackColor = Color.FromArgb(243, 243, 250);
        }

        private void LoadImageAsync(PictureBox pb, string url)
        {
            try
            {
                pb.LoadAsync(url);
            }
            catch
            {
                // Bỏ qua lỗi, form sẽ hiện màu xanh nền mặc định
            }
        }

        #endregion
    }
}