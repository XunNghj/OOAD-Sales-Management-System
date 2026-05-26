using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class DangKy : Form
    {
        private readonly string connectionString =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;
              Initial Catalog=SQL_THTRUEMART;
              Integrated Security=True;
              TrustServerCertificate=True;";

        public DangKy()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetupLogic();
            this.Load   += MainForm_Load;
            this.Resize += MainForm_Resize;
        }

        // ════════════════════════════════════════════════════════════════
        //  FORM LOAD & RESIZE
        // ════════════════════════════════════════════════════════════════
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = lblTitle;
            this.WindowState   = FormWindowState.Maximized;

            LoadImageAsync(pbBackground,
                "https://lh3.googleusercontent.com/aida-public/AB6AXuDB_8oxFxIc33Ow-x5l8Y-wv6SOhAV_8gQB9AeIqw25g5_kYyllXE9oZtEZZj-RKuy9ZUSOBZCw_f_DKLOUGIEq7sjK6bYusfPtsLc6V70hPzquKNrZzyQ4A2g1781s0pMpNyiWLgIPPjj_ox8atorpHToTdMJ56NhHsSFn3nipvsYiXkv_NpO9jCva1CkvhuzyUvZ8XNzyXYYixJChZ309bLUyVgoEjN6PYyUqxfpT-zZISdxio4B5t8wx6nC4HuqbxjxgSUNnKwXr");
            LoadImageAsync(pbLeftImage,
                "https://lh3.googleusercontent.com/aida-public/AB6AXuAJYTLgLXdNsNNKRPVQm93oeX3KF35fR_x0Qk0YDP5qL6IOtD1b8eBjPCSdWr3oCHzDNZuiKdBxA_FaN4UyaY3EQZTWcjM0rX27tz7eiJOxaaeqLipAh5sHzPgOinl-cH16xFJoO0uRb7763SmjJ-x9P1yAkPlGonUP3uScouFA2eAw20D8DAwXqLyCgYrQj7h3nBn3J36iMM6SneuDsS-peabrU4IYXk1LYf-d_8wCvE8ig3JBfLrC6CM4-w8bFbotxDWEhNumS04S");

            MainForm_Resize(this, EventArgs.Empty);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (pnlMain == null || this.ClientSize.Width == 0) return;
            int fw = this.ClientSize.Width;
            int fh = this.ClientSize.Height;
            pnlMain.Left = (fw - pnlMain.Width)  / 2;
            pnlMain.Top  = (fh - pnlMain.Height) / 2;
            btnHelp.Left = fw - btnHelp.Width - 40;
            btnHelp.Top  = fh - btnHelp.Height - 40;
            btnHelp.BringToFront();
            pnlMain.BringToFront();
        }

        // ════════════════════════════════════════════════════════════════
        //  PLACEHOLDER & HOVER
        // ════════════════════════════════════════════════════════════════
        private void SetupLogic()
        {
            Color cTextActive      = Color.FromArgb(25, 28, 33);
            Color cTextPlaceholder = Color.FromArgb(150, 150, 150);
            Color cBgNormal        = Color.FromArgb(231, 232, 239);
            Color cBgActive        = Color.White;
            Color cHoverSocial     = Color.FromArgb(220, 220, 225);

            Action<TextBox, Panel, string> SetupInput = (txt, pnlBg, placeholder) =>
            {
                txt.GotFocus += (s, ev) => {
                    pnlBg.BackColor = cBgActive;
                    txt.BackColor   = cBgActive;
                    if (txt.Text == placeholder) { txt.Text = ""; txt.ForeColor = cTextActive; }
                };
                txt.LostFocus += (s, ev) => {
                    pnlBg.BackColor = cBgNormal;
                    txt.BackColor   = cBgNormal;
                    if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = placeholder; txt.ForeColor = cTextPlaceholder; }
                };
            };

            SetupInput(txtName,    pnlNameBg,    "John Doe");
            SetupInput(txtPhone,   pnlPhoneBg,   "+84 000 000 000");
            SetupInput(txtEmail,   pnlEmailBg,   "name@example.com");
            SetupInput(txtPass,    pnlPassBg,    "\u2022\u2022\u2022\u2022\u2022\u2022\u2022\u2022");
            SetupInput(txtConfirm, pnlConfirmBg, "\u2022\u2022\u2022\u2022\u2022\u2022\u2022\u2022");

            btnGoogle.MouseEnter   += (s, ev) => btnGoogle.BackColor   = cHoverSocial;
            btnGoogle.MouseLeave   += (s, ev) => btnGoogle.BackColor   = Color.FromArgb(243, 243, 250);
            btnFacebook.MouseEnter += (s, ev) => btnFacebook.BackColor = cHoverSocial;
            btnFacebook.MouseLeave += (s, ev) => btnFacebook.BackColor = Color.FromArgb(243, 243, 250);

            linkLogin.MouseEnter += (s, ev) => linkLogin.Font = new Font(linkLogin.Font, FontStyle.Underline | FontStyle.Bold);
            linkLogin.MouseLeave += (s, ev) => linkLogin.Font = new Font(linkLogin.Font, FontStyle.Bold);
        }

        // ════════════════════════════════════════════════════════════════
        //  TẢI ẢNH
        // ════════════════════════════════════════════════════════════════
        private void LoadImageAsync(PictureBox pb, string url)
        {
            try { pb.LoadAsync(url); } catch { }
        }

        // ════════════════════════════════════════════════════════════════
        //  NÚT ĐĂNG KÝ
        //
        //  Luồng ghi CSDL:
        //    Bước 1 (luôn luôn) → INSERT TAIKHOAN
        //    Bước 2a (không tick) → INSERT KHACHHANG, liên kết MA_KH
        //    Bước 2b (có tick)   → INSERT NHANVIEN,   liên kết MANV
        //
        //  Quan trọng: toàn bộ GenId() và Scalar() được gọi TRƯỚC
        //  BeginTransaction() để tránh lỗi "ExecuteScalar requires
        //  the command to have a transaction".
        // ════════════════════════════════════════════════════════════════
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // ── Bước 1: Lấy giá trị, loại placeholder ───────────────────
            string hoTen      = GetField(txtName,    "John Doe");
            string sdt        = GetField(txtPhone,   "+84 000 000 000");
            string email      = GetField(txtEmail,   "name@example.com");
            string matKhau    = GetField(txtPass,    "\u2022\u2022\u2022\u2022\u2022\u2022\u2022\u2022");
            string xacNhan    = GetField(txtConfirm, "\u2022\u2022\u2022\u2022\u2022\u2022\u2022\u2022");
            bool   laNhanVien = chkNhanVien.Checked;

            // ── Bước 2: Validate ─────────────────────────────────────────
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
            { Warn("Vui l\u00f2ng \u0111i\u1ec1n \u0111\u1ea7y \u0111\u1ee7 th\u00f4ng tin."); return; }

            if (matKhau != xacNhan)
            { Warn("M\u1eadt kh\u1ea9u x\u00e1c nh\u1eadn kh\u00f4ng kh\u1edbp."); return; }

            if (matKhau.Length < 6)
            { Warn("M\u1eadt kh\u1ea9u ph\u1ea3i c\u00f3 \u00edt nh\u1ea5t 6 k\u00fd t\u1ef1."); return; }

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // ── Bước 3: Kiểm tra email trùng trong TAIKHOAN ──────
                    if (Exists(con, "SELECT COUNT(*) FROM TAIKHOAN WHERE TENTK = @V", email))
                    { Warn("Email n\u00e0y \u0111\u00e3 c\u00f3 t\u00e0i kho\u1ea3n. Vui l\u00f2ng \u0111\u0103ng nh\u1eadp."); return; }

                    // ── Bước 4: Kiểm tra trùng trong bảng tương ứng ─────
                    if (laNhanVien)
                    {
                        if (Exists(con, "SELECT COUNT(*) FROM NHANVIEN WHERE EMAIL = @V", email))
                        { Warn("Email \u0111\u00e3 t\u1ed3n t\u1ea1i trong danh s\u00e1ch nh\u00e2n vi\u00ean."); return; }
                        if (Exists(con, "SELECT COUNT(*) FROM NHANVIEN WHERE SDT = @V", sdt))
                        { Warn("S\u1ed1 \u0111i\u1ec7n tho\u1ea1i \u0111\u00e3 t\u1ed3n t\u1ea1i trong danh s\u00e1ch nh\u00e2n vi\u00ean."); return; }
                    }
                    else
                    {
                        if (Exists(con, "SELECT COUNT(*) FROM KHACHHANG WHERE EMAIL_KH = @V", email))
                        { Warn("Email \u0111\u00e3 t\u1ed3n t\u1ea1i trong danh s\u00e1ch kh\u00e1ch h\u00e0ng."); return; }
                        if (Exists(con, "SELECT COUNT(*) FROM KHACHHANG WHERE SDT_KH = @V", sdt))
                        { Warn("S\u1ed1 \u0111i\u1ec7n tho\u1ea1i \u0111\u00e3 t\u1ed3n t\u1ea1i trong danh s\u00e1ch kh\u00e1ch h\u00e0ng."); return; }
                    }

                    // ── Bước 5: Sinh mã & đọc dữ liệu phụ ──────────────
                    //    *** PHẢI làm TRƯỚC BeginTransaction ***
                    //    Lý do: SqlCommand bên trong transaction bắt buộc
                    //    phải được truyền tran, còn GenId/Scalar dùng
                    //    SqlCommand không có tran → lỗi nếu đặt bên trong.
                    string hashedPw = matKhau; // Lưu mật khẩu gốc, không mã hóa

                    string maTK = GenId(con,
                        "SELECT ISNULL(MAX(CAST(SUBSTRING(MATK,3,LEN(MATK)) AS INT)),0)+1 " +
                        "FROM TAIKHOAN WHERE ISNUMERIC(SUBSTRING(MATK,3,LEN(MATK)))=1",
                        "TK");

                    // Khai báo biến cho cả 2 nhánh, gán giá trị theo từng trường hợp
                    string maNV = "", maCV = "", maPB = "";
                    string maKH = "", maLoaiKH = "";

                    if (laNhanVien)
                    {
                        maNV     = GenId(con,
                            "SELECT ISNULL(MAX(CAST(SUBSTRING(MANV,3,LEN(MANV)) AS INT)),0)+1 " +
                            "FROM NHANVIEN WHERE ISNUMERIC(SUBSTRING(MANV,3,LEN(MANV)))=1",
                            "NV");
                        maCV     = Scalar(con, "SELECT TOP 1 MACV FROM CHUCVU   ORDER BY MACV") ?? "CV001";
                        maPB     = Scalar(con, "SELECT TOP 1 MAPB FROM PHONGBAN ORDER BY MAPB") ?? "PB001";
                    }
                    else
                    {
                        maKH     = GenId(con,
                            "SELECT ISNULL(MAX(CAST(SUBSTRING(MA_KH,3,LEN(MA_KH)) AS INT)),0)+1 " +
                            "FROM KHACHHANG WHERE ISNUMERIC(SUBSTRING(MA_KH,3,LEN(MA_KH)))=1",
                            "KH");
                        // Lấy MA_LOAIKH từ dữ liệu thực trong KHACHHANG (tránh query bảng loại sai tên)
                        maLoaiKH = Scalar(con, "SELECT TOP 1 MA_LOAIKH FROM KHACHHANG WHERE MA_LOAIKH IS NOT NULL ORDER BY MA_LOAIKH") ?? "LKH001";
                    }

                    // ── Bước 6: Ghi CSDL bằng transaction ───────────────
                    //    Chỉ chứa INSERT, không có GenId/Scalar
                    using (var tran = con.BeginTransaction())
                    {
                        try
                        {
                            if (laNhanVien)
                            {
                                // Bảng 1 → NHANVIEN
                                var c1 = new SqlCommand(
                                    "INSERT INTO NHANVIEN (MANV,TENNV,SDT,EMAIL,MACV,MAPB,TRANGTHAI_NV) " +
                                    "VALUES (@MaNV,@Ten,@SDT,@Email,@MaCV,@MaPB,N'Ho\u1ea1t \u0111\u1ed9ng')",
                                    con, tran);
                                c1.Parameters.Add("@MaNV",  SqlDbType.Char, 10).Value      = maNV;
                                c1.Parameters.Add("@Ten",   SqlDbType.NVarChar, 100).Value = hoTen;
                                c1.Parameters.Add("@SDT",   SqlDbType.VarChar, 15).Value   = sdt;
                                c1.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value  = email;
                                c1.Parameters.Add("@MaCV",  SqlDbType.Char, 10).Value      = maCV;
                                c1.Parameters.Add("@MaPB",  SqlDbType.Char, 10).Value      = maPB;
                                c1.ExecuteNonQuery();

                                // Bảng 2 → TAIKHOAN (liên kết MANV)
                                var c2 = new SqlCommand(
                                    "INSERT INTO TAIKHOAN (MATK,TENTK,MANV,MK) " +
                                    "VALUES (@MaTK,@TenTK,@MaNV,@MK)",
                                    con, tran);
                                c2.Parameters.Add("@MaTK",  SqlDbType.Char, 10).Value     = maTK;
                                c2.Parameters.Add("@TenTK", SqlDbType.VarChar, 100).Value = email;
                                c2.Parameters.Add("@MaNV",  SqlDbType.Char, 10).Value     = maNV;
                                c2.Parameters.Add("@MK",    SqlDbType.Char, 256).Value    = hashedPw;
                                c2.ExecuteNonQuery();
                            }
                            else
                            {
                                // Bảng 1 → KHACHHANG
                                var c1 = new SqlCommand(
                                    "INSERT INTO KHACHHANG (MA_KH,TEN_KH,SDT_KH,EMAIL_KH,DIACHI_KH,MA_LOAIKH) " +
                                    "VALUES (@MaKH,@Ten,@SDT,@Email,@DiaChi,@MaLoai)",
                                    con, tran);
                                c1.Parameters.Add("@MaKH",   SqlDbType.Char, 10).Value      = maKH;
                                c1.Parameters.Add("@Ten",    SqlDbType.NVarChar, 100).Value  = hoTen;
                                c1.Parameters.Add("@SDT",    SqlDbType.VarChar, 15).Value   = sdt;
                                c1.Parameters.Add("@Email",  SqlDbType.VarChar, 100).Value  = email;
                                c1.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 200).Value = "Chưa cập nhật";
                                c1.Parameters.Add("@MaLoai", SqlDbType.Char, 10).Value      = maLoaiKH;
                                c1.ExecuteNonQuery();

                                // Bảng 2 → TAIKHOAN
                                // Tự động kiểm tra cột MA_KH tồn tại trước khi dùng
                                var chkCol = new SqlCommand(
                                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS " +
                                    "WHERE TABLE_NAME='TAIKHOAN' AND COLUMN_NAME='MA_KH'", con, tran);
                                bool hasMaKhCol = Convert.ToInt32(chkCol.ExecuteScalar()) > 0;

                                string tkSql = hasMaKhCol
                                    ? "INSERT INTO TAIKHOAN (MATK,TENTK,MA_KH,MK) VALUES (@MaTK,@TenTK,@MaKH,@MK)"
                                    : "INSERT INTO TAIKHOAN (MATK,TENTK,MK) VALUES (@MaTK,@TenTK,@MK)";

                                var c2 = new SqlCommand(tkSql, con, tran);
                                c2.Parameters.Add("@MaTK",  SqlDbType.Char, 10).Value     = maTK;
                                c2.Parameters.Add("@TenTK", SqlDbType.VarChar, 100).Value = email;
                                if (hasMaKhCol)
                                    c2.Parameters.Add("@MaKH", SqlDbType.Char, 10).Value  = maKH;
                                c2.Parameters.Add("@MK",    SqlDbType.Char, 256).Value    = hashedPw;
                                c2.ExecuteNonQuery();
                            }

                            tran.Commit();

                            string loai = laNhanVien ? "Nh\u00e2n vi\u00ean" : "Kh\u00e1ch h\u00e0ng";
                            MessageBox.Show(
                                $"\u0110\u0103ng k\u00fd th\u00e0nh c\u00f4ng! ({loai})\n\n" +
                                $"T\u00ean \u0111\u0103ng nh\u1eadp: {email}\n" +
                                "Vui l\u00f2ng \u0111\u0103ng nh\u1eadp \u0111\u1ec3 ti\u1ebfp t\u1ee5c.",
                                "Th\u00e0nh c\u00f4ng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            new DangNhap().Show();
                            this.Hide();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("L\u1ed7i \u0111\u0103ng k\u00fd:\n" + ex.Message,
                        "L\u1ed7i SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ════════════════════════════════════════════════════════════════
        //  HELPER METHODS
        // ════════════════════════════════════════════════════════════════

        /// <summary>Trả về "" nếu TextBox đang hiển thị placeholder.</summary>
        private string GetField(TextBox txt, string placeholder)
            => txt.Text.Trim() == placeholder.Trim() ? "" : txt.Text.Trim();

        /// <summary>Kiểm tra giá trị đã tồn tại trong DB chưa.</summary>
        private bool Exists(SqlConnection con, string sql, string value)
        {
            var cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@V", SqlDbType.NVarChar, 200).Value = value;
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        /// <summary>
        /// Sinh mã tự động dạng PREFIX + 3 chữ số (NV001, KH002...).
        /// Chỉ gọi khi KHÔNG có transaction đang mở trên connection.
        /// </summary>
        private string GenId(SqlConnection con, string sql, string prefix)
        {
            int next = Convert.ToInt32(new SqlCommand(sql, con).ExecuteScalar());
            return prefix + next.ToString("D3");
        }

        /// <summary>
        /// Lấy 1 giá trị scalar. Trả về null nếu không có kết quả.
        /// Chỉ gọi khi KHÔNG có transaction đang mở trên connection.
        /// </summary>
        private string Scalar(SqlConnection con, string sql)
        {
            var r = new SqlCommand(sql, con).ExecuteScalar();
            return (r == null || r == DBNull.Value) ? null : r.ToString().Trim();
        }

        /// <summary>Hash mật khẩu MD5 → chuỗi hex 32 ký tự.</summary>
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

        private void Warn(string msg)
            => MessageBox.Show(msg, "Th\u00f4ng b\u00e1o", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        // ════════════════════════════════════════════════════════════════
        //  EVENT HANDLERS CŨ (giữ nguyên)
        // ════════════════════════════════════════════════════════════════
        private void linkLogin_Click(object sender, EventArgs e)
        {
            new DangNhap().Show();
            this.Hide();
        }
    }
}