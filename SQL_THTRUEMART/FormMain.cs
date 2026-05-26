using System;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormMain : Form
    {
        private string _username;
        private Form _activeChild = null;
        private Panel _activeSubMenu = null;

        private readonly string _connectionString =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        // Màu sắc cho hover sidebar
        private readonly Color _colItem = Color.FromArgb(11, 37, 78);
        private readonly Color _colHover = Color.FromArgb(22, 68, 135);
        private readonly Color _colActive = Color.FromArgb(56, 139, 253);
        private readonly Color _colMod = Color.FromArgb(18, 58, 118);
        private readonly Color _colModOpen = Color.FromArgb(9, 30, 65);
        private Button _activeItemBtn = null;

        // Constructor không tham số — cho Designer và các nơi gọi không truyền username
        public FormMain() : this("Admin") { }

        public FormMain(string username)
        {
            InitializeComponent();
            _username = username;
            SetLabels();
            SetHoverEffects();
            CloseAllSubMenus();
            ShowHomeDashboard();
        }

        // Constructor phụ (tương thích cũ)
        public FormMain(string connectionString, string username)
            : this(username) { }

        // ================================================================
        // KHỞI TẠO
        // ================================================================
        private void SetLabels()
        {
            lblAppName.Text = "TH TRUEMART";
            lblAppSub.Text = "H\u1ec7 th\u1ed1ng qu\u1ea3n l\u00fd b\u00e1n h\u00e0ng";
            lblUserName.Text = _username;

            // Tiêu đề module (tiếng Việt dùng Unicode escape)
            btnModule1.Text = "1.  QU\u1ea2N TR\u1eca H\u1ec6 TH\u1ed0NG";
            btnModule2.Text = "2.  QU\u1ea2N L\u00dd KHO, SP";
            btnModule3.Text = "3.  B\u00c1N H\u00c0NG, GIAO D\u1ecaCH";
            btnModule4.Text = "4.  B\u00c1O C\u00c1O, QU\u1ea2N L\u00dd";
            btnModule5.Text = "5.  TI\u1ec6N \u00cdCH, TR\u1ea2 H\u00c0NG";

            // Item buttons
            btnF2.Text = "  F2.  Danh s\u00e1ch Nh\u00e2n vi\u00ean";
            btnF3.Text = "  F3.  Qu\u1ea3n l\u00fd Ph\u00e2n Quy\u1ec1n";
            btnF4.Text = "  F4.  Danh s\u00e1ch S\u1ea3n ph\u1ea9m";
            btnF5.Text = "  F5.  B\u00e1o c\u00e1o T\u1ed3n Kho";
            btnF6.Text = "  F6.  L\u1eadp Phi\u1ebfu Nh\u1eadp";
            btnF7.Text = "  F7.  L\u1eadp Phi\u1ebfu Xu\u1ea5t";
            btnF8.Text = "  F8.  L\u1eadp H\u00f3a \u0111\u01a1n";
            btnF9.Text = "  F9.  Chi ti\u1ebft HD & B\u00e1o c\u00e1o";
            btnF10.Text = "  F10. Qu\u1ea3n l\u00fd Th\u1ebb Th\u00e0nh Vi\u00ean";
            btnF11.Text = "  F11. Qu\u1ea3n l\u00fd \u0110\u01a1n h\u00e0ng Online";
            btnF12.Text = "  F12. B\u00e1o c\u00e1o Doanh s\u1ed1 NV";
            btnF13.Text = "  F13. Qu\u1ea3n l\u00fd Gi\u00e1, Khuy\u1ebfn m\u00e3i";
            btnF14.Text = "  F14. Tra c\u1ee9u SP S\u1eafp H\u1ebft H\u1ea1n";
            btnF15.Text = "  F15. L\u1eadp Phi\u1ebfu Tr\u1ea3 H\u00e0ng";

            btnLogout.Text = "\u2192 Tho\u00e1t";
            this.Text = "H\u1ec6 TH\u1ed0NG QU\u1ea2N L\u00dd TH TRUE MART";
        }

        private void SetHoverEffects()
        {
            // Module buttons
            foreach (var b in new[] { btnModule1, btnModule2, btnModule3, btnModule4, btnModule5 })
            {
                var btn = b;
                btn.MouseEnter += (s, e) => { if (!IsModuleOpen(btn)) btn.BackColor = _colHover; };
                btn.MouseLeave += (s, e) => { if (!IsModuleOpen(btn)) btn.BackColor = _colMod; };
            }

            // Item buttons
            foreach (var b in new[] { btnF2, btnF3, btnF4, btnF5, btnF6, btnF7,
                                       btnF8, btnF9, btnF10, btnF11, btnF12, btnF13,
                                       btnF14, btnF15 })
            {
                var btn = b;
                btn.MouseEnter += (s, e) => { if (btn != _activeItemBtn) btn.BackColor = _colHover; };
                btn.MouseLeave += (s, e) => { if (btn != _activeItemBtn) btn.BackColor = _colItem; };
            }

            // Logout
            btnLogout.MouseEnter += (s, e) => btnLogout.ForeColor = Color.FromArgb(255, 90, 90);
            btnLogout.MouseLeave += (s, e) => btnLogout.ForeColor = Color.FromArgb(160, 180, 210);
        }

        private bool IsModuleOpen(Button btn)
        {
            if (btn == btnModule1) return PanelSubmenu1.Visible;
            if (btn == btnModule2) return PanelSubmenu2.Visible;
            if (btn == btnModule3) return PanelSubmenu3.Visible;
            if (btn == btnModule4) return PanelSubmenu4.Visible;
            if (btn == btnModule5) return PanelSubmenu5.Visible;
            return false;
        }

        // ================================================================
        // TRANG CHỦ
        // ================================================================
        private void ShowHomeDashboard()
        {
            lblCurrentFormTitle.Text = "TRANG CH\u1ee6";
            lblMenuPath.Text = "TH TrueMart \u00b7 Ch\u00e0o m\u1eebng, " + _username;

            if (_activeChild != null) { _activeChild.Close(); _activeChild = null; }
            PanelDesktop.Controls.Clear();

            // Dashboard đơn giản
            var pnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 247, 251),
                Padding = new Padding(40)
            };

            var lbl = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(13, 43, 90),
                Text = "Ch\u00e0o m\u1eebng, " + _username + "!",
                Location = new Point(40, 50)
            };

            var sub = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(120, 130, 150),
                Text = "H\u00e3y ch\u1ecdn ch\u1ee9c n\u0103ng t\u1eeb menu b\u00ean tr\u00e1i \u0111\u1ec3 b\u1eaft \u0111\u1ea7u.",
                Location = new Point(42, 100)
            };

            // 5 shortcut cards
            string[] titles = {
                "Qu\u1ea3n tr\u1ecb h\u1ec7 th\u1ed1ng",
                "Qu\u1ea3n l\u00fd kho, SP",
                "B\u00e1n h\u00e0ng",
                "B\u00e1o c\u00e1o",
                "Ti\u1ec7n \u00edch"
            };
            string[] subs = { "F2 \u2013 F3", "F4 \u2013 F7", "F8 \u2013 F11", "F12 \u2013 F13", "F14 \u2013 F15" };
            Color[] colors = {
                Color.FromArgb(13, 43, 90),
                Color.FromArgb(13, 100, 60),
                Color.FromArgb(160, 80, 0),
                Color.FromArgb(80, 40, 140),
                Color.FromArgb(180, 50, 50)
            };

            int cardX = 42, cardY = 150;
            for (int i = 0; i < 5; i++)
            {
                var card = new Panel
                {
                    BackColor = Color.White,
                    Size = new Size(190, 90),
                    Location = new Point(cardX + i * 210, cardY)
                };
                var t = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = colors[i],
                    Text = titles[i],
                    Location = new Point(14, 18)
                };
                var s = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = Color.FromArgb(130, 140, 155),
                    Text = subs[i],
                    Location = new Point(16, 44)
                };
                card.Controls.Add(t); card.Controls.Add(s);
                pnl.Controls.Add(card);
            }

            pnl.Controls.Add(lbl);
            pnl.Controls.Add(sub);
            PanelDesktop.Controls.Add(pnl);
        }

        // ================================================================
        // MENU LOGIC
        // ================================================================
        private void CloseAllSubMenus()
        {
            PanelSubmenu1.Visible = false;
            PanelSubmenu2.Visible = false;
            PanelSubmenu3.Visible = false;
            PanelSubmenu4.Visible = false;
            PanelSubmenu5.Visible = false;

            // Reset màu module buttons
            foreach (var b in new[] { btnModule1, btnModule2, btnModule3, btnModule4, btnModule5 })
                b.BackColor = _colMod;
        }

        private void ShowSubMenu(Panel subMenu, Button moduleBtn)
        {
            bool wasOpen = subMenu.Visible;
            CloseAllSubMenus();
            if (!wasOpen)
            {
                subMenu.Visible = true;
                moduleBtn.BackColor = _colModOpen;
                _activeSubMenu = subMenu;
            }
            else
            {
                _activeSubMenu = null;
            }
        }

        private void OpenChildForm(Form childForm, string title, string path, Button itemBtn = null)
        {
            if (_activeChild != null) { _activeChild.Close(); _activeChild = null; }

            // Reset màu item cũ
            if (_activeItemBtn != null) { _activeItemBtn.BackColor = _colItem; _activeItemBtn = null; }
            if (itemBtn != null) { itemBtn.BackColor = _colActive; _activeItemBtn = itemBtn; }

            _activeChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            PanelDesktop.Controls.Clear();
            PanelDesktop.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();

            // Ẩn header của form con để tránh bị trùng với header FormMain
            // Áp dụng cho tất cả form: tìm control tên pnlHeader và ẩn đi
            HideChildHeader(childForm);

            lblCurrentFormTitle.Text = title;
            lblMenuPath.Text = "TH TrueMart \u00b7 " + path;

            CloseAllSubMenus();
            _activeSubMenu = null;
        }

        /// <summary>
        /// Ẩn panel header của form con (tên pnlHeader hoặc panel đầu tiên Dock=Top có chiều cao nhỏ)
        /// để FormMain là header duy nhất hiển thị.
        /// </summary>
        private void HideChildHeader(Form child)
        {
            // Ưu tiên: tìm chính xác theo tên phổ biến
            string[] headerNames = { "pnlHeader", "PanelHeader", "panelHeader",
                                     "pnlTop", "pnlTitle", "panelTitle" };
            foreach (string name in headerNames)
            {
                var ctrl = child.Controls[name];
                if (ctrl != null) { ctrl.Visible = false; return; }
            }

            // Fallback: ẩn Panel đầu tiên Dock=Top có Height <= 80
            // (là header kiểu navy ở đầu form con)
            foreach (System.Windows.Forms.Control ctrl in child.Controls)
            {
                if (ctrl is System.Windows.Forms.Panel p
                    && p.Dock == DockStyle.Top
                    && p.Height <= 80
                    && p.BackColor == System.Drawing.Color.FromArgb(13, 43, 90))
                {
                    p.Visible = false;
                    return;
                }
            }
        }

        // ================================================================
        // MODULE BUTTONS
        // ================================================================
        private void btnModule1_Click(object sender, EventArgs e) => ShowSubMenu(PanelSubmenu1, btnModule1);
        private void btnModule2_Click(object sender, EventArgs e) => ShowSubMenu(PanelSubmenu2, btnModule2);
        private void btnModule3_Click(object sender, EventArgs e) => ShowSubMenu(PanelSubmenu3, btnModule3);
        private void btnModule4_Click(object sender, EventArgs e) => ShowSubMenu(PanelSubmenu4, btnModule4);
        private void btnModule5_Click(object sender, EventArgs e) => ShowSubMenu(PanelSubmenu5, btnModule5);

        // ================================================================
        // FUNCTION BUTTONS
        // ================================================================

        // ── Module 1 ──
        private void btnF2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanVien(_connectionString), "DANH S\u00c1CH NH\u00c2N VI\u00caN",
                "Qu\u1ea3n tr\u1ecb h\u1ec7 th\u1ed1ng \u00bb Nh\u00e2n vi\u00ean", btnF2);
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPhanQuyen(), "QU\u1ea2N L\u00dd PH\u00c2N QUY\u1ec0N",
                "Qu\u1ea3n tr\u1ecb h\u1ec7 th\u1ed1ng \u00bb Ph\u00e2n quy\u1ec1n", btnF3);
        }

        // ── Module 2 ──
        private void btnF4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSanPham(), "DANH S\u00c1CH S\u1ea2N PH\u1ea8M",
                "Qu\u1ea3n l\u00fd kho \u00bb S\u1ea3n ph\u1ea9m", btnF4);
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTonKho(), "B\u00c1O C\u00c1O T\u1ed2N KHO",
                "Qu\u1ea3n l\u00fd kho \u00bb T\u1ed3n kho", btnF5);
        }

        private void btnF6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPhieuNhap(), "L\u1eacP PHI\u1ebeU NH\u1eacP",
        "Qu\u1ea3n l\u00fd kho \u00bb Phi\u1ebfu nh\u1eadp", btnF6);
        }

        private void btnF7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPhieuXuat(), "L\u1eacP PHI\u1ebeU XU\u1ea4T",
        "TH TrueMart \u00b7 Qu\u1ea3n l\u00fd kho \u00bb Phi\u1ebfu xu\u1ea5t", btnF7);
        }

        // ── Module 3 ──
        private void btnF8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormLapHoaDon(), "L\u1eacP H\u00d3A \u0110\u01a0N ",
                "B\u00e1n h\u00e0ng \u00bb H\u00f3a \u0111\u01a1n", btnF8);
        }

        private void btnF9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormChiTiet_HD(), "CHI TI\u1ebeT H\u00d3A \u0110\u01a0N & B\u00c1O C\u00c1O",
                "B\u00e1n h\u00e0ng \u00bb Chi ti\u1ebft HD", btnF9);
        }

        private void btnF10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTheThanhVien(), "QU\u1ea2N L\u00dd TH\u1ebe TH\u00c0NH VI\u00caN",
                "B\u00e1n h\u00e0ng \u00bb Th\u1ebb th\u00e0nh vi\u00ean", btnF10);
        }

        private void btnF11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDonHang(), "QU\u1ea2N L\u00dd \u0110\u01a0N H\u00c0NG ONLINE",
                "B\u00e1n h\u00e0ng \u00bb \u0110\u01a1n h\u00e0ng online", btnF11);
        }

        // ── Module 4 ──
        private void btnF12_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBaoCaoDoanhSo(), "B\u00c1O C\u00c1O DOANH S\u1ed0 NH\u00c2N VI\u00caN",
                "B\u00e1o c\u00e1o \u00bb Doanh s\u1ed1 NV", btnF12);
        }

        private void btnF13_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQuanLyGiaKM(), "QU\u1ea2N L\u00dd GI\u00c1 B\u00c1N & KHUY\u1ebeN M\u00c3I",
                "Qu\u1ea3n l\u00fd \u00bb Gi\u00e1 & KM", btnF13);
        }

        // ── Module 5 ──
        private void btnF14_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSPHetHan(), "TRA C\u1ee8U S\u1ea2N PH\u1ea8M S\u1eaeP H\u1ebeT H\u1ea0N",
                 "Ti\u1ec7n \u00edch \u00bb s\u1ea3n ph\u1ea9m h\u1ebft h\u1ea1n", btnF14);
        }

        private void btnF15_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPhieuTraHang(), "L\u1eacP PHI\u1ebeU TR\u1ea2 H\u00c0NG",
                "Ti\u1ec7n \u00edch \u00bb Tr\u1ea3 h\u00e0ng", btnF15);
        }

        // ================================================================
        // ĐĂNG XUẤT
        // ================================================================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "B\u1ea1n c\u00f3 ch\u1eafc ch\u1eafn mu\u1ed1n \u0111\u0103ng xu\u1ea5t?",
                "X\u00e1c nh\u1eadn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                var loginForm = new DangNhap();
                loginForm.Show();
                this.Dispose();
            }
        }
    }

    // Lớp phụ giữ lại tương thích
    public class ColorTag
    {
        public Color Color { get; set; }
        public ColorTag(Color color) { Color = color; }
    }
}