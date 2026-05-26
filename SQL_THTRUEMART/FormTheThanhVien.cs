using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormTheThanhVien : Form
    {
        private readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        private string _currentMaKH = "";

        public FormTheThanhVien()
        {
            InitializeComponent();
            SetLabels();
            SetHoverEffects();
        }

        // ================================================================
        // LABELS + HOVER
        // ================================================================
        private void SetLabels()
        {
            lblTitle.Text = "QU\u1ea2N L\u00dd TH\u1eba TH\u00c0NH VI\u00caN";
            lblSubtitle.Text = "TH True Mart \u00b7 KHACHHANG \u00b7 THETHANHVIEN \u00b7 LOAIKH \u00b7 HOADON";
            lblStat1Lbl.Text = "TH\u00c0NH VI\u00caN";
            lblStat2Lbl.Text = "T\u1ed4NG \u0110I\u1ec2M T\u00cdCH L\u0168Y";
            lblStat3Lbl.Text = "KH CH\u01afA C\u00d3 TH\u1eba";
            lblLeftTitle.Text = "Danh s\u00e1ch kh\u00e1ch h\u00e0ng";
            lblCardTitle.Text = "Th\u00f4ng tin th\u1eba th\u00e0nh vi\u00ean";
            lblMaKH.Text = "M\u00e3 KH";
            lblTenKH.Text = "H\u1ecd t\u00ean";
            lblSDT.Text = "S\u0110T";
            lblDiaChi.Text = "\u0110\u1ecba ch\u1ec9";
            lblLoaiKH.Text = "H\u1ea1ng th\u00e0nh vi\u00ean";
            lblMaTTV.Text = "M\u00e3 TTV";
            lblNgayCap.Text = "Ng\u00e0y c\u1ea5p";
            lblDiemHT.Text = "\u0110I\u1ec2M HI\u1ec6N T\u1ea0I";
            lblDiemTitle.Text = "C\u1eadp nh\u1eadt \u0111i\u1ec3m t\u00edch l\u0169y  (1 \u0111i\u1ec3m / 10,000 \u0111)";
            lblTongTienGD.Text = "T\u1ed5ng ti\u1ec1n GD (\u0111) *";
            lblDiemSeThem.Text = "\u0110i\u1ec3m s\u1ebd th\u00eam";
            lblNote.Text = "* 1 \u0111i\u1ec3m t\u00edch l\u0169y = 10,000 VND chi ti\u00eau. C\u1eadp nh\u1eadt s\u1ebd t\u1ef1 \u0111\u1ed9ng n\u00e2ng h\u1ea1ng n\u1ebfu \u0111\u1ee7 \u0111i\u1ec1u ki\u1ec7n.";
            btnCapNhatDiem.Text = "\u2714 C\u1eadp nh\u1eadt \u0111i\u1ec3m";
            btnSearchKH.Text = "T\u00ecm";
            lblHDTitle.Text = "L\u1ecbch s\u1eed h\u00f3a \u0111\u01a1n c\u1ee7a kh\u00e1ch h\u00e0ng";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 KHACHHANG \u00b7 THETHANHVIEN \u00b7 LOAIKH \u00b7 HOADON";
        }

        private void SetHoverEffects()
        {
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnCapNhatDiem, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnSearchKH, Color.FromArgb(80, 160, 255), Color.FromArgb(56, 139, 253));
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormTheThanhVien_Load(object sender, EventArgs e)
        {
            LoadComboLoaiKH();
            LoadKhachHang();
            UpdateStats();
            ClearCard();
        }

        private void LoadComboLoaiKH()
        {
            cmbLoaiKHFilter.Items.Clear();
            cmbLoaiKHFilter.Items.Add("-- T\u1ea5t c\u1ea3 h\u1ea1ng --");
            var dt = Query("SELECT TEN_LOAIKH FROM LOAIKH ORDER BY TEN_LOAIKH");
            if (dt != null) foreach (DataRow row in dt.Rows) cmbLoaiKHFilter.Items.Add(row["TEN_LOAIKH"].ToString());
            cmbLoaiKHFilter.Items.Add("-- Ch\u01b0a c\u00f3 th\u1eba --");
            cmbLoaiKHFilter.SelectedIndex = 0;
        }

        // ================================================================
        // LOAD DANH SÁCH KH
        // ================================================================
        private void LoadKhachHang(string keyword = "", string loaiFilter = "")
        {
            string sql = @"
                SELECT KH.MA_KH, KH.TEN_KH, KH.SDT_KH,
                       LKH.TEN_LOAIKH,
                       ISNULL(TTV.SOTHE, N'') AS SOTHE,
                       ISNULL(TTV.DIEM_HT, 0)  AS DIEM_HT
                FROM KHACHHANG KH
                JOIN LOAIKH        LKH ON KH.MA_LOAIKH = LKH.MA_LOAIKH
                LEFT JOIN THETHANHVIEN TTV ON KH.MA_KH = TTV.MA_KH
                WHERE (@kw = '' OR KH.TEN_KH LIKE @kw OR KH.SDT_KH LIKE @kw OR KH.MA_KH LIKE @kw)
                  AND (@loai = '' OR LKH.TEN_LOAIKH = @loai
                       OR (@loai = N'-- Ch\u01b0a c\u00f3 th\u1eba --' AND TTV.SOTHE IS NULL))
                ORDER BY KH.MA_KH";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(keyword) ? "" : "%" + keyword.Trim() + "%";
                    cmd.Parameters.Add("@loai", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(loaiFilter) ? "" : loaiFilter;

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvKhachHang.AutoGenerateColumns = true;
                    dgvKhachHang.DataSource = dt;

                    void Col(string n, string h, bool vis = true,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvKhachHang.Columns.Contains(n)) return;
                        dgvKhachHang.Columns[n].HeaderText = h; dgvKhachHang.Columns[n].Visible = vis;
                        dgvKhachHang.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("MA_KH", "M\u00e3 KH", true, DataGridViewContentAlignment.MiddleCenter);
                    Col("TEN_KH", "Kh\u00e1ch h\u00e0ng");
                    Col("SDT_KH", "S\u0110T", true, DataGridViewContentAlignment.MiddleCenter);
                    Col("TEN_LOAIKH", "H\u1ea1ng");
                    Col("SOTHE", "TTV", true, DataGridViewContentAlignment.MiddleCenter);
                    Col("DIEM_HT", "\u0110i\u1ec3m", true, DataGridViewContentAlignment.MiddleRight);
                    if (dgvKhachHang.Columns.Contains("DIEM_HT"))
                        dgvKhachHang.Columns["DIEM_HT"].DefaultCellStyle.Format = "#,##0";

                    // Tô màu theo hạng
                    foreach (DataGridViewRow row in dgvKhachHang.Rows)
                    {
                        string maTTV = row.Cells["SOTHE"].Value?.ToString() ?? "";
                        string loai = row.Cells["TEN_LOAIKH"].Value?.ToString() ?? "";
                        if (string.IsNullOrEmpty(maTTV))
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(150, 150, 150);
                        else if (loai.Contains("Vip") || loai.Contains("VIP") || loai.Contains("Kim"))
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(160, 80, 0);
                        else
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(13, 43, 90);
                    }
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i danh s\u00e1ch KH", ex); }
            }
        }

        // ================================================================
        // CLICK HÀNG → LOAD THÔNG TIN THẺ
        // ================================================================
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvKhachHang.Rows[e.RowIndex];
            if (row.Cells["MA_KH"].Value == null) return;
            _currentMaKH = row.Cells["MA_KH"].Value.ToString();
            LoadCardInfo(_currentMaKH);
        }

        private void LoadCardInfo(string maKH)
        {
            string sql = @"
                SELECT KH.MA_KH, KH.TEN_KH, KH.SDT_KH,
                       ISNULL(KH.DIACHI_KH, N'') AS DIACHI_KH,
                       LKH.TEN_LOAIKH,
                       ISNULL(TTV.SOTHE,   N'') AS SOTHE,
                       ISNULL(TTV.NGAYCAP, GETDATE()) AS NGAYCAP,
                       ISNULL(TTV.DIEM_HT, 0)    AS DIEM_HT
                FROM KHACHHANG KH
                JOIN LOAIKH        LKH ON KH.MA_LOAIKH = LKH.MA_LOAIKH
                LEFT JOIN THETHANHVIEN TTV ON KH.MA_KH = TTV.MA_KH
                WHERE KH.MA_KH = @M";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = maKH;
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.Read()) return;
                        txtMaKH.Text = rdr["MA_KH"].ToString();
                        txtTenKH.Text = rdr["TEN_KH"].ToString();
                        txtSDT.Text = rdr["SDT_KH"].ToString();
                        txtDiaChi.Text = rdr["DIACHI_KH"].ToString();

                        string loai = rdr["TEN_LOAIKH"].ToString();
                        txtLoaiKH.Text = loai;
                        txtLoaiKH.BackColor = loai.Contains("Vip") || loai.Contains("VIP") || loai.Contains("Kim")
                            ? Color.FromArgb(255, 240, 200)
                            : Color.FromArgb(220, 232, 248);

                        string maTTV = rdr["SOTHE"].ToString();
                        txtMaTTV.Text = string.IsNullOrEmpty(maTTV) ? "Ch\u01b0a c\u00f3 th\u1eba" : maTTV;
                        txtNgayCap.Text = maTTV.Length > 0
                            ? Convert.ToDateTime(rdr["NGAYCAP"]).ToString("dd/MM/yyyy")
                            : "--";

                        int diem = Convert.ToInt32(rdr["DIEM_HT"]);
                        txtDiemHienTai.Text = diem.ToString("#,##0");
                        txtDiemHienTai.ForeColor = diem > 0 ? Color.FromArgb(13, 100, 60) : Color.FromArgb(100, 110, 125);
                    }

                    btnCapNhatDiem.Enabled = true;
                    txtTongTienGiaoDich.Text = "";
                    txtDiemSeThem.Text = "";
                    lblHDTitle.Text = "L\u1ecbch s\u1eed h\u00f3a \u0111\u01a1n \u2014 " + txtTenKH.Text;

                    LoadHoaDonHistory(maKH);
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i th\u00f4ng tin th\u1eba", ex); }
            }
        }

        private void LoadHoaDonHistory(string maKH)
        {
            string sql = @"
                SELECT HD.MA_HD, HD.NGAYLAPHD,
                       HD.TONGCONGTHANHTIEN,
                       ISNULL(HD.HINHTHUCLANHD, N'') AS HTTT,
                       ISNULL(LHD.TENLOAI_HD, N'')   AS LOAI_HD
                FROM HOADON HD
                LEFT JOIN LOAI_HD LHD ON HD.MA_LOAIHD = LHD.MA_LOAIHD
                WHERE HD.MA_KH = @M
                ORDER BY HD.NGAYLAPHD DESC";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = maKH;
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvHoaDon.AutoGenerateColumns = true;
                    dgvHoaDon.DataSource = dt;

                    void Col(string n, string h, string fmt = null,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvHoaDon.Columns.Contains(n)) return;
                        dgvHoaDon.Columns[n].HeaderText = h;
                        if (fmt != null) dgvHoaDon.Columns[n].DefaultCellStyle.Format = fmt;
                        dgvHoaDon.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("MA_HD", "M\u00e3 H\u0110", null, DataGridViewContentAlignment.MiddleCenter);
                    Col("NGAYLAPHD", "Ng\u00e0y", "dd/MM/yy", DataGridViewContentAlignment.MiddleCenter);
                    Col("TONGCONGTHANHTIEN", "Th\u00e0nh ti\u1ec1n", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("HTTT", "HTTT");
                    Col("LOAI_HD", "Lo\u1ea1i H\u0110");
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i l\u1ecbch s\u1eed HD", ex); }
            }
        }

        // ================================================================
        // TÌM KIẾM
        // ================================================================
        private void btnSearchKH_Click(object sender, EventArgs e)
            => LoadKhachHang(txtSearchSDT.Text, GetLoaiFilter());

        private void txtSearchSDT_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) btnSearchKH_Click(sender, e); }

        private void cmbLoaiKHFilter_SelectedIndexChanged(object sender, EventArgs e)
            => LoadKhachHang(txtSearchSDT.Text, GetLoaiFilter());

        private string GetLoaiFilter()
        {
            if (cmbLoaiKHFilter.SelectedIndex <= 0) return "";
            string sel = cmbLoaiKHFilter.SelectedItem.ToString();
            return sel.StartsWith("--") ? sel : sel;
        }

        // ================================================================
        // TÍNH ĐIỂM LIVE
        // ================================================================
        private void txtTongTienGiaoDich_TextChanged(object sender, EventArgs e)
        {
            string raw = txtTongTienGiaoDich.Text.Replace(",", "").Replace(".", "");
            if (decimal.TryParse(raw, out decimal tien) && tien > 0)
            {
                int diem = (int)(tien / 10000);
                txtDiemSeThem.Text = "+" + diem.ToString("#,##0");
            }
            else
                txtDiemSeThem.Text = "";
        }

        // ================================================================
        // CẬP NHẬT ĐIỂM
        // ================================================================
        private void btnCapNhatDiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMaKH)) { Warn("Ch\u1ecdn kh\u00e1ch h\u00e0ng tr\u01b0\u1edbc."); return; }

            string raw = txtTongTienGiaoDich.Text.Replace(",", "").Replace(".", "");
            if (!decimal.TryParse(raw, out decimal tongTien) || tongTien <= 0)
            { Warn("Nh\u1eadp t\u1ed5ng ti\u1ec1n giao d\u1ecbch h\u1ee3p l\u1ec7 (> 0)."); txtTongTienGiaoDich.Focus(); return; }

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    // Thử SP trước
                    bool hasSP = false;
                    using (var chk = new SqlCommand("SELECT COUNT(*) FROM sys.objects WHERE type='P' AND name='sp_CapNhat_DiemTichLuy'", con))
                        hasSP = Convert.ToInt32(chk.ExecuteScalar()) > 0;

                    if (hasSP)
                    {
                        using (var cmd = new SqlCommand("sp_CapNhat_DiemTichLuy", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaKH", _currentMaKH);
                            cmd.Parameters.AddWithValue("@TongTienGiaoDich", tongTien);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Tự tính và UPDATE / INSERT THETHANHVIEN
                        int diemThem = (int)(tongTien / 10000);

                        // Kiểm tra đã có thẻ chưa
                        var chkTTV = new SqlCommand("SELECT COUNT(*) FROM THETHANHVIEN WHERE MA_KH=@K", con);
                        chkTTV.Parameters.Add("@K", SqlDbType.Char, 10).Value = _currentMaKH;
                        bool coThe = Convert.ToInt32(chkTTV.ExecuteScalar()) > 0;

                        if (coThe)
                        {
                            var upd = new SqlCommand("UPDATE THETHANHVIEN SET DIEM_HT = DIEM_HT + @D WHERE MA_KH=@K", con);
                            upd.Parameters.Add("@D", SqlDbType.Int).Value = diemThem;
                            upd.Parameters.Add("@K", SqlDbType.Char, 10).Value = _currentMaKH;
                            upd.ExecuteNonQuery();
                        }
                        else
                        {
                            // Tạo thẻ mới
                            string maTTV = "TTV" + _currentMaKH.Replace("KH", "");
                            var ins = new SqlCommand(@"
                                INSERT INTO THETHANHVIEN (SOTHE, MA_KH, DIEM_HT, NGAYCAP)
                                VALUES (@TTV, @K, @D, GETDATE())", con);
                            ins.Parameters.Add("@TTV", SqlDbType.Char, 10).Value = maTTV;
                            ins.Parameters.Add("@K", SqlDbType.Char, 10).Value = _currentMaKH;
                            ins.Parameters.Add("@D", SqlDbType.Int).Value = diemThem;
                            ins.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("C\u1eadp nh\u1eadt \u0111i\u1ec3m t\u00edch l\u0169y th\u00e0nh c\u00f4ng!",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtTongTienGiaoDich.Text = ""; txtDiemSeThem.Text = "";
                    LoadCardInfo(_currentMaKH);
                    LoadKhachHang(txtSearchSDT.Text, GetLoaiFilter());
                    UpdateStats();
                }
                catch (SqlException ex) { ShowErr("c\u1eadp nh\u1eadt \u0111i\u1ec3m", ex); }
            }
        }

        // ================================================================
        // STATS
        // ================================================================
        private void UpdateStats()
        {
            string sql = @"
                SELECT
                    COUNT(DISTINCT TTV.MA_KH)                       AS SoTV,
                    ISNULL(SUM(TTV.DIEM_HT), 0)                     AS TongDiem,
                    (SELECT COUNT(*) FROM KHACHHANG KH2
                     LEFT JOIN THETHANHVIEN TTV2 ON KH2.MA_KH=TTV2.MA_KH
                     WHERE TTV2.SOTHE IS NULL)                     AS ChuaCoThe
                FROM THETHANHVIEN TTV";

            var dt = Query(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblStat1Val.Text = dt.Rows[0]["SoTV"].ToString();
                lblStat2Val.Text = Convert.ToInt32(dt.Rows[0]["TongDiem"]).ToString("#,##0");
                lblStat3Val.Text = dt.Rows[0]["ChuaCoThe"].ToString();
            }
        }

        // ================================================================
        // CLEAR CARD
        // ================================================================
        private void ClearCard()
        {
            txtMaKH.Text = ""; txtTenKH.Text = ""; txtSDT.Text = ""; txtDiaChi.Text = "";
            txtLoaiKH.Text = ""; txtMaTTV.Text = ""; txtNgayCap.Text = "";
            txtDiemHienTai.Text = "0"; txtTongTienGiaoDich.Text = ""; txtDiemSeThem.Text = "";
            btnCapNhatDiem.Enabled = false;
            dgvHoaDon.DataSource = null;
            lblHDTitle.Text = "L\u1ecbch s\u1eed h\u00f3a \u0111\u01a1n c\u1ee7a kh\u00e1ch h\u00e0ng";
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private DataTable Query(string sql)
        {
            using (var con = new SqlConnection(_conn))
            {
                try { con.Open(); var dt = new DataTable(); new SqlDataAdapter(sql, con).Fill(dt); return dt; }
                catch (SqlException ex) { ShowErr("query", ex); return null; }
            }
        }

        private void ShowErr(string ctx, SqlException ex)
            => MessageBox.Show("L\u1ed7i " + ctx + ":\n" + ex.Message, "L\u1ed7i SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void Warn(string msg)
            => MessageBox.Show(msg, "Th\u00f4ng b\u00e1o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}