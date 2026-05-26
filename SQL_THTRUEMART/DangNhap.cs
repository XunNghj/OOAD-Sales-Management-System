using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class DangNhap : Form
    {
        // ── Kết nối CSDL ────────────────────────────────────────────────
        private readonly string connectionString =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;
              Initial Catalog=SQL_THTRUEMART;
              Integrated Security=True;
              TrustServerCertificate=True;";

        // ── Theo dõi tab đang chọn (0 = Khách hàng, 1 = Nhân viên) ─────
        private int _currentTab = 0;
        private bool _passIsPlaceholder = true; // Flag tránh lỗi so sánh khi PasswordChar bật

        // ── Bảng màu hệ thống (giữ nguyên) ─────────────────────────────
        private Color cPrimary = Color.FromArgb(0, 59, 115);
        private Color cTextNormal = Color.FromArgb(25, 28, 33);
        private Color cTextPlaceholder = Color.FromArgb(150, 150, 150);
        private Color cOutline = Color.FromArgb(114, 119, 130);
        private Color cBgNormal = Color.FromArgb(231, 232, 239);
        private Color cBgActive = Color.White;
        private Color cHoverSocial = Color.FromArgb(220, 220, 225);

        public DangNhap()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetupLogic();
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
            pbBackgroundLeft.Paint += PbBackgroundLeft_Paint;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblWelcome;
            this.WindowState = FormWindowState.Maximized;
            LoadImageAsync(pbBackgroundLeft,
                "https://lh3.googleusercontent.com/aida-public/AB6AXuAixp-hMXLcu_JjfQssx3kdrFDWOG7me90QIaQIsTVuawcVdNk34BcCS0E1PMa-6XSnwNRnpmBvjh94mBjhdOr6U_Xk0WIARiqvkx5p8C9VYAJ_rhksh-QO0kcA1AKxVBX2oOqeEBHVp8da5vPgA-o0dC5-x12sOzzt2s1xugbvNJXhvx0ZN4lyHfYIyhSq7tycq6yOy76Kp91goyDRLuEiHjqYF5uesghXlnI8LWZlceEnAuAlsWncwuQLeE6GUQSwL6KxJn81rpND");
            MainForm_Resize(this, EventArgs.Empty);
        }

        #region XỬ LÝ CO DÃN 50/50 VÀ CĂN GIỮA (RESPONSIVE)

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (pnlFooter == null || this.ClientSize.Width == 0) return;

            int fw = this.ClientSize.Width;
            int fh = this.ClientSize.Height;

            pnlFooter.Width = fw;
            pnlFooter.Top = fh - pnlFooter.Height;

            int splitHeight = fh - pnlFooter.Height;

            pnlLeft.Width = fw / 2;
            pnlLeft.Height = splitHeight;

            pnlRight.Width = fw - pnlLeft.Width;
            pnlRight.Left = pnlLeft.Right;
            pnlRight.Height = splitHeight;

            pnlLoginBox.Left = (pnlRight.Width - pnlLoginBox.Width) / 2;
            pnlLoginBox.Top = (pnlRight.Height - pnlLoginBox.Height) / 2;

            SetupTransparentLabels();

            int padding = 40;
            linkHelp.Left = pnlFooter.Width - padding - linkHelp.Width;
            linkTerms.Left = linkHelp.Left - 30 - linkTerms.Width;
            linkPrivacy.Left = linkTerms.Left - 30 - linkPrivacy.Width;
        }

        private void SetupTransparentLabels()
        {
            Label[] leftLabels = { lblLogoIcon, lblLogoText, lblHeroTitle, lblHeroDesc, lblCopyRightLeft };
            foreach (var lbl in leftLabels)
            {
                if (lbl.Parent != pbBackgroundLeft)
                {
                    Point pos = pbBackgroundLeft.PointToClient(lbl.Parent.PointToScreen(lbl.Location));
                    lbl.Parent = pbBackgroundLeft;
                    lbl.Location = pos;
                }
            }
            lblCopyRightLeft.Top = pnlLeft.Height - 80;
        }

        private void PbBackgroundLeft_Paint(object sender, PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(160, 0, 59, 115)))
                e.Graphics.FillRectangle(brush, e.ClipRectangle);
        }

        #endregion

        #region XỬ LÝ LOGIC UI (PLACEHOLDER, TAB, HOVER) — GIỮ NGUYÊN

        private void SetupLogic()
        {
            txtEmail.GotFocus += (s, e) => {
                pnlEmailBg.BackColor = cBgActive; txtEmail.BackColor = cBgActive;
                if (txtEmail.Text == "example@thmilk.vn") { txtEmail.Text = ""; txtEmail.ForeColor = cTextNormal; }
            };
            txtEmail.LostFocus += (s, e) => {
                pnlEmailBg.BackColor = cBgNormal; txtEmail.BackColor = cBgNormal;
                if (string.IsNullOrWhiteSpace(txtEmail.Text)) { txtEmail.Text = "example@thmilk.vn"; txtEmail.ForeColor = cTextPlaceholder; }
            };

            txtPass.GotFocus += (s, e) => {
                pnlPassBg.BackColor = cBgActive; txtPass.BackColor = cBgActive;
                if (_passIsPlaceholder)
                {
                    _passIsPlaceholder = false; // set false khi user focus vào
                    txtPass.Text = "";
                    txtPass.ForeColor = cTextNormal;
                }
                txtPass.SelectAll();
            };
            txtPass.LostFocus += (s, e) => {
                pnlPassBg.BackColor = cBgNormal; txtPass.BackColor = cBgNormal;
                if (string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    _passIsPlaceholder = true;
                    txtPass.Text = "••••••••";
                    txtPass.ForeColor = cTextPlaceholder;
                }
            };

            linkForgotPass.MouseEnter += (s, e) => linkForgotPass.Font = new Font(linkForgotPass.Font, FontStyle.Underline | FontStyle.Bold);
            linkForgotPass.MouseLeave += (s, e) => linkForgotPass.Font = new Font(linkForgotPass.Font, FontStyle.Bold);

            linkRegister.MouseEnter += (s, e) => linkRegister.Font = new Font(linkRegister.Font, FontStyle.Underline | FontStyle.Bold);
            linkRegister.MouseLeave += (s, e) => linkRegister.Font = new Font(linkRegister.Font, FontStyle.Bold);

            Label[] footerLinks = { linkPrivacy, linkTerms, linkHelp };
            foreach (var link in footerLinks)
            {
                link.MouseEnter += (s, e) => link.ForeColor = cPrimary;
                link.MouseLeave += (s, e) => link.ForeColor = cOutline;
            }

            btnGoogle.MouseEnter += (s, e) => btnGoogle.BackColor = cHoverSocial;
            btnGoogle.MouseLeave += (s, e) => btnGoogle.BackColor = cBgNormal;
            btnFacebook.MouseEnter += (s, e) => btnFacebook.BackColor = cHoverSocial;
            btnFacebook.MouseLeave += (s, e) => btnFacebook.BackColor = cBgNormal;

            lblTabCustomer.Click += (s, e) => SwitchTab(0);
            lblTabStaff.Click += (s, e) => SwitchTab(1);

            btnTogglePass.Click += (s, e) =>
                txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;

            txtPass.UseSystemPasswordChar = true;

            // Cho phép nhấn Enter để đăng nhập
            txtEmail.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) txtPass.Focus(); };
            txtPass.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnLogin_Click(s, e); };
        }

        private void SwitchTab(int index)
        {
            _currentTab = index;
            if (index == 0)
            {
                lblTabCustomer.ForeColor = cPrimary;
                lblTabStaff.ForeColor = cOutline;
                pnlTabActive.Left = lblTabCustomer.Left;
                lblEmailLabel.Text = "EMAIL / T\u00caN \u0110\u0102NG NH\u1eacP";
                lblEmailIcon.Text = "\U0001f464";
                txtEmail.Text = "example@thmilk.vn";
                txtEmail.ForeColor = cTextPlaceholder;
            }
            else
            {
                lblTabStaff.ForeColor = cPrimary;
                lblTabCustomer.ForeColor = cOutline;
                pnlTabActive.Left = lblTabStaff.Left;
                lblEmailLabel.Text = "M\u00c3 NH\u00c2N VI\u00caN";
                lblEmailIcon.Text = "\U0001faa6";
                txtEmail.Text = "EMP-0000";
                txtEmail.ForeColor = cTextPlaceholder;
            }
        }

        #endregion

        #region UTILS

        private void LoadImageAsync(PictureBox pb, string url)
        {
            try { pb.LoadAsync(url); } catch { }
        }

        /// <summary>Hash mật khẩu MD5 — giống hệt DangKy.</summary>
        private string HashMD5(string input)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        #endregion

        // ════════════════════════════════════════════════════════════════
        //  NÚT ĐĂNG NHẬP
        //
        //  Tab 0 (Khách hàng):
        //    Query TAIKHOAN WHERE TENTK = @input AND MK = @hash
        //    → Nếu MANV IS NULL → tài khoản KH → mở form KH
        //
        //  Tab 1 (Nhân viên):
        //    Query TAIKHOAN WHERE (TENTK = @input OR MANV = @input) AND MK = @hash
        //    → Nếu MANV IS NOT NULL → tài khoản NV → mở form chính
        // ════════════════════════════════════════════════════════════════
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ── 1. Lấy giá trị ──────────────────────────────────────────
            string inputTen = txtEmail.Text.Trim();
            string inputPass = txtPass.Text.Trim();

            // Bỏ qua nếu đang hiển thị placeholder
            string emailPlaceholder = _currentTab == 0 ? "example@thmilk.vn" : "EMP-0000";
            string passPlaceholder = "\u2022\u2022\u2022\u2022\u2022\u2022\u2022\u2022";

            if (inputTen == emailPlaceholder) inputTen = "";
            // Kiểm tra trực tiếp - không phụ thuộc flag tránh lỗi timing
            if (inputPass == "••••••••" || _passIsPlaceholder) inputPass = "";

            // ── 2. Validate cơ bản ───────────────────────────────────────
            if (string.IsNullOrEmpty(inputTen) || string.IsNullOrEmpty(inputPass))
            {
                MessageBox.Show("Vui l\u00f2ng nh\u1eadp t\u00ean \u0111\u0103ng nh\u1eadp v\u00e0 m\u1eadt kh\u1ea9u.",
                    "Thi\u1ebfu th\u00f4ng tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPass = inputPass; // So sánh mật khẩu gốc, không mã hóa

            // ── 3. Truy vấn CSDL ─────────────────────────────────────────
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd;
                    if (_currentTab == 0)
                    {
                        // Tab Khách hàng: đăng nhập bằng email (TENTK)
                        cmd = new SqlCommand(@"
                            SELECT TK.MATK, TK.TENTK, TK.MANV, TK.MA_KH,
                                   KH.TEN_KH, NV.TENNV
                            FROM TAIKHOAN TK
                            LEFT JOIN KHACHHANG KH ON TK.MA_KH = KH.MA_KH
                            LEFT JOIN NHANVIEN  NV ON TK.MANV  = NV.MANV
                            WHERE TK.TENTK = @Input AND TK.MK = @MK", con);
                    }
                    else
                    {
                        // Tab Nhân viên: đăng nhập bằng MANV hoặc email
                        cmd = new SqlCommand(@"
                            SELECT TK.MATK, TK.TENTK, TK.MANV, TK.MA_KH,
                                   KH.TEN_KH, NV.TENNV
                            FROM TAIKHOAN TK
                            LEFT JOIN KHACHHANG KH ON TK.MA_KH = KH.MA_KH
                            LEFT JOIN NHANVIEN  NV ON TK.MANV  = NV.MANV
                            WHERE (TK.TENTK = @Input OR TK.MANV = @Input)
                              AND TK.MK = @MK", con);
                    }

                    cmd.Parameters.Add("@Input", SqlDbType.NVarChar, 100).Value = inputTen;
                    cmd.Parameters.Add("@MK", SqlDbType.Char, 256).Value = hashedPass;

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.Read())
                        {
                            // Không tìm thấy → sai thông tin
                            MessageBox.Show(
                                "T\u00ean \u0111\u0103ng nh\u1eadp ho\u1eb7c m\u1eadt kh\u1ea9u kh\u00f4ng \u0111\u00fang.\nVui l\u00f2ng ki\u1ec3m tra l\u1ea1i.",
                                "\u0110\u0103ng nh\u1eadp th\u1ea5t b\u1ea1i",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPass.Text = passPlaceholder;
                            txtPass.ForeColor = cTextPlaceholder;
                            return;
                        }

                        string maTK = rdr["MATK"].ToString().Trim();
                        string manv = rdr["MANV"] == DBNull.Value ? null : rdr["MANV"].ToString().Trim();
                        string maKH = rdr["MA_KH"] == DBNull.Value ? null : rdr["MA_KH"].ToString().Trim();
                        string tenKH = rdr["TEN_KH"] == DBNull.Value ? "" : rdr["TEN_KH"].ToString().Trim();
                        string tenNV = rdr["TENNV"] == DBNull.Value ? "" : rdr["TENNV"].ToString().Trim();

                        rdr.Close();

                        // ── 4. Xác định loại tài khoản và mở form ──────
                        if (_currentTab == 1 && manv == null)
                        {
                            // Nhân viên tab nhưng tài khoản là KH → từ chối
                            MessageBox.Show(
                                "T\u00e0i kho\u1ea3n n\u00e0y kh\u00f4ng ph\u1ea3i nh\u00e2n vi\u00ean.\nVui l\u00f2ng ch\u1ecdn tab Kh\u00e1ch h\u00e0ng.",
                                "Sai lo\u1ea1i t\u00e0i kho\u1ea3n",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (_currentTab == 0 && manv != null)
                        {
                            // KH tab nhưng tài khoản là NV → từ chối
                            MessageBox.Show(
                                "T\u00e0i kho\u1ea3n n\u00e0y l\u00e0 nh\u00e2n vi\u00ean.\nVui l\u00f2ng ch\u1ecdn tab Nh\u00e2n vi\u00ean.",
                                "Sai lo\u1ea1i t\u00e0i kho\u1ea3n",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // ── 5. Đăng nhập thành công ─────────────────────
                        string tenHienThi = !string.IsNullOrEmpty(tenNV) ? tenNV
                                          : !string.IsNullOrEmpty(tenKH) ? tenKH
                                          : rdr["TENTK"].ToString();

                        // KH → MainForm | NV → FormMain
                        string tenHienThiFinal = !string.IsNullOrEmpty(tenNV) ? tenNV
                                               : !string.IsNullOrEmpty(tenKH) ? tenKH
                                               : inputTen;
                        if (manv != null)
                        {
                            // NHÂN VIÊN → FormMain
                            var formNV = new FormMain();
                            formNV.Text = "TH TrueMart — " + tenHienThiFinal + " [" + manv + "]";
                            formNV.Show();
                        }
                        else
                        {
                            // KHÁCH HÀNG → MainForm
                            var formKH = new MainForm();
                            formKH.Text = "TH TrueMart — " + tenHienThiFinal;
                            formKH.Show();
                        }

                        this.Hide();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("L\u1ed7i k\u1ebft n\u1ed1i CSDL:\n" + ex.Message,
                        "L\u1ed7i SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── EVENT HANDLERS CŨ (giữ nguyên) ──────────────────────────────
        private void linkRegister_Click(object sender, EventArgs e)
        {
            new DangKy().Show();
            this.Hide();
        }
    }
}