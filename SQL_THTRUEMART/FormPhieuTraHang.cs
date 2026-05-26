using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormPhieuTraHang : Form
    {
        private readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        private DataTable _dtChiTiet;
        private DataTable _dtHoaDon;       // danh sách HĐ để chọn
        private string _viewingMaPTH = "";
        private bool _isEditingNew = false;
        private bool _isEditingExist = false;

        private readonly string[] TRANG_THAI = { "Ch\u1edd x\u1eed l\u00fd", "\u0110\u00e3 ho\u00e0n ti\u1ec1n", "Ch\u1edd ho\u00e0n ti\u1ec1n", "\u0110\u00e3 h\u1ee7y" };
        private readonly string[] PHUONG_THUC = { "Ti\u1ec1n m\u1eb7t", "Chuy\u1ec3n kho\u1ea3n", "Ho\u00e0n v\u00ed", "C\u1ea5n tr\u1eeb c\u00f4ng n\u1ee3" };

        public FormPhieuTraHang()
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
            lblTitle.Text = "L\u1eacP PHI\u1ebcU TR\u1ea2 H\u00c0NG";
            lblSubtitle.Text = "TH True Mart \u00b7 X\u1eed l\u00fd tr\u1ea3 h\u00e0ng";
            lblLeftTitle.Text = "L\u1ecbch s\u1eed phi\u1ebfu tr\u1ea3";
            btnSearchPTH.Text = "T\u00ecm";
            btnLapMoiPTH.Text = "+ L\u1eadp phi\u1ebfu m\u1edbi";
            btnSuaPTH.Text = "\u270e S\u1eeda phi\u1ebfu";
            btnXoaPTH.Text = "\u00d7 X\u00f3a phi\u1ebfu";
            lblInfoTitle.Text = "Th\u00f4ng tin phi\u1ebfu tr\u1ea3 h\u00e0ng";
            lblMaPTH.Text = "M\u00e3 phi\u1ebfu *";
            lblNgayTra.Text = "Ng\u00e0y tr\u1ea3";
            lblKH.Text = "Kh\u00e1ch h\u00e0ng *";
            lblNCC.Text = "Nh\u00e0 cung c\u1ea5p (n\u1ebfu tr\u1ea3 NCC)";
            lblNV.Text = "Nh\u00e2n vi\u00ean *";
            lblTrangThai.Text = "Tr\u1ea1ng th\u00e1i *";
            lblPhuongThuc.Text = "Ph\u01b0\u01a1ng th\u1ee9c ho\u00e0n ti\u1ec1n *";
            lblLyDoTra.Text = "L\u00fd do tr\u1ea3 *";
            lblGhiChu.Text = "Ghi ch\u00fa";
            lblGridTitle.Text = "Chi ti\u1ebft h\u00f3a \u0111\u01a1n tr\u1ea3 h\u00e0ng";
            lblGridHint.Text = "Ch\u1ecdn M\u00e3 H\u0110 g\u1ed1c \u2192 nh\u1eadp s\u1ed1 l\u01b0\u1ee3ng tr\u1ea3 \u2192 \u0111\u01a1n gi\u00e1 t\u1ef1 \u0111i\u1ec1n t\u1eeb HĐ g\u1ed1c";
            btnAddRow.Text = "+ Th\u00eam d\u00f2ng";
            btnDelRow.Text = "\u2212 X\u00f3a d\u00f2ng";
            lblTongHoanLabel.Text = "T\u1ed5ng ti\u1ec1n ho\u00e0n (\u0111):";
            btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu tr\u1ea3";
            btnCancel.Text = "\u00d7 H\u1ee7y b\u1ecf";
            lblHintSave.Text = "";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 PHIEUTRAHANG \u00b7 CT_PHIEUTRAHANG \u00b7 HOADON";
        }

        private void SetHoverEffects()
        {
            var colNav2 = Color.FromArgb(13, 43, 90);
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnLapMoiPTH, Color.FromArgb(25, 65, 120), colNav2);
            H(btnAddRow, Color.FromArgb(25, 65, 120), colNav2);
            H(btnSave, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnSuaPTH, Color.FromArgb(210, 145, 10), Color.FromArgb(180, 120, 0));
            H(btnXoaPTH, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnDelRow, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnSearchPTH, Color.FromArgb(80, 160, 255), Color.FromArgb(56, 139, 253));
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormPhieuTraHang_Load(object sender, EventArgs e)
        {
            LoadComboKH();
            LoadComboNCC();
            LoadComboNV();
            LoadComboStatic();
            LoadHoaDonData();
            BuildChiTietGrid();
            LoadHistory();
            SetReadonlyRight(true);
        }

        private void LoadComboKH()
        {
            var dt = Query("SELECT MA_KH, TEN_KH + ' [' + MA_KH + ']' AS HT FROM KHACHHANG ORDER BY TEN_KH");
            if (dt == null) return;
            cboKhachHang.DataSource = dt; cboKhachHang.DisplayMember = "HT"; cboKhachHang.ValueMember = "MA_KH"; cboKhachHang.SelectedIndex = -1;
        }

        private void LoadComboNCC()
        {
            var dt = Query("SELECT MA_NCC, TEN_NCC + ' [' + MA_NCC + ']' AS HT FROM NHACUNGCAP ORDER BY TEN_NCC");
            if (dt == null) return;
            // Thêm dòng trống đầu
            dt.Rows.InsertAt(dt.NewRow(), 0);
            dt.Rows[0]["MA_NCC"] = DBNull.Value; dt.Rows[0]["HT"] = "-- Kh\u00f4ng (tr\u1ea3 KH) --";
            cboNCC.DataSource = dt; cboNCC.DisplayMember = "HT"; cboNCC.ValueMember = "MA_NCC"; cboNCC.SelectedIndex = 0;
        }

        private void LoadComboNV()
        {
            var dt = Query("SELECT MANV, TENNV + ' [' + MANV + ']' AS HT FROM NHANVIEN WHERE TRANGTHAI_NV=N'\u0110ang l\u00e0m vi\u1ec7c' ORDER BY TENNV");
            if (dt == null) return;
            cboNhanVien.DataSource = dt; cboNhanVien.DisplayMember = "HT"; cboNhanVien.ValueMember = "MANV"; cboNhanVien.SelectedIndex = -1;
        }

        private void LoadComboStatic()
        {
            cboTrangThai.Items.Clear();
            foreach (var tt in TRANG_THAI) cboTrangThai.Items.Add(tt);
            cboTrangThai.SelectedIndex = 0;

            cboPhuongThuc.Items.Clear();
            foreach (var pt in PHUONG_THUC) cboPhuongThuc.Items.Add(pt);
            cboPhuongThuc.SelectedIndex = -1;
        }

        private void LoadHoaDonData()
        {
            // Danh sách HĐ để chọn trong ComboBox column
            _dtHoaDon = Query("SELECT MA_HD, MA_HD + ' - ' + CONVERT(VARCHAR,NGAYLAPHD,103) + ' (' + MA_KH + ')' AS HT FROM HOADON ORDER BY NGAYLAPHD DESC");
        }

        // ================================================================
        // BUILD GRID (ComboBox chọn MA_HD → tự điền đơn giá từ HĐ gốc)
        // ================================================================
        private void BuildChiTietGrid()
        {
            _dtChiTiet = new DataTable();
            _dtChiTiet.Columns.Add("MA_HD", typeof(string));
            _dtChiTiet.Columns.Add("SOLUONG_TRA", typeof(int));
            _dtChiTiet.Columns.Add("DONGIA_TRA", typeof(decimal));
            _dtChiTiet.Columns.Add("THANHTIEN_TRA", typeof(decimal));

            dgvChiTietTra.Columns.Clear();

            var colHD = new DataGridViewComboBoxColumn
            {
                Name = "colMaHD",
                HeaderText = "M\u00e3 H\u00f3a \u0111\u01a1n g\u1ed1c *",
                DataPropertyName = "MA_HD",
                Width = 220,
                FlatStyle = FlatStyle.Flat,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            };
            if (_dtHoaDon != null) { colHD.DataSource = _dtHoaDon; colHD.DisplayMember = "HT"; colHD.ValueMember = "MA_HD"; }
            dgvChiTietTra.Columns.Add(colHD);

            dgvChiTietTra.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSL", HeaderText = "S\u1ed1 l\u01b0\u1ee3ng tr\u1ea3 *", DataPropertyName = "SOLUONG_TRA", Width = 120, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "#,##0" } });
            dgvChiTietTra.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDG", HeaderText = "\u0110\u01a1n gi\u00e1 tr\u1ea3 (\u0111)", DataPropertyName = "DONGIA_TRA", Width = 130, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#,##0" } });
            dgvChiTietTra.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTT", HeaderText = "Th\u00e0nh ti\u1ec1n (\u0111)", DataPropertyName = "THANHTIEN_TRA", Width = 140, ReadOnly = true, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#,##0", BackColor = Color.FromArgb(248, 246, 255), ForeColor = Color.FromArgb(13, 43, 90) } });

            dgvChiTietTra.DataSource = _dtChiTiet;
            dgvChiTietTra.DataError += (s, ev) => ev.Cancel = true;
        }

        // ================================================================
        // LOAD LỊCH SỬ
        // ================================================================
        private void LoadHistory(string keyword = "")
        {
            string sql = @"
                SELECT PTH.MA_PTH, PTH.NGAYTRA, KH.TEN_KH,
                       NV.TENNV, PTH.TRANGTHAI_TRAHANG,
                       PTH.TONGTIENHOAN,
                       (SELECT COUNT(*) FROM CT_PHIEUTRAHANG C WHERE C.MA_PTH=PTH.MA_PTH) AS SoDong
                FROM PHIEUTRAHANG PTH
                JOIN KHACHHANG KH ON PTH.MA_KH=KH.MA_KH
                JOIN NHANVIEN  NV ON PTH.MANV=NV.MANV
                WHERE @kw='' OR PTH.MA_PTH LIKE @kw OR KH.TEN_KH LIKE @kw OR NV.TENNV LIKE @kw
                ORDER BY PTH.NGAYTRA DESC";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 100).Value =
                        string.IsNullOrWhiteSpace(keyword) ? "" : "%" + keyword.Trim() + "%";
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvHistory.AutoGenerateColumns = true;
                    dgvHistory.DataSource = dt;

                    void Col(string n, string h, string fmt = null,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvHistory.Columns.Contains(n)) return;
                        dgvHistory.Columns[n].HeaderText = h;
                        if (fmt != null) dgvHistory.Columns[n].DefaultCellStyle.Format = fmt;
                        dgvHistory.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("MA_PTH", "M\u00e3 phi\u1ebfu");
                    Col("NGAYTRA", "Ng\u00e0y", "dd/MM/yy", DataGridViewContentAlignment.MiddleCenter);
                    Col("TEN_KH", "Kh\u00e1ch h\u00e0ng");
                    Col("TENNV", "Nh\u00e2n vi\u00ean");
                    Col("TRANGTHAI_TRAHANG", "Tr\u1ea1ng th\u00e1i");
                    Col("TONGTIENHOAN", "Ti\u1ec1n ho\u00e0n", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("SoDong", "D\u00f2ng", null, DataGridViewContentAlignment.MiddleCenter);

                    // Tô màu trạng thái
                    foreach (DataGridViewRow row in dgvHistory.Rows)
                    {
                        string tt = row.Cells["TRANGTHAI_TRAHANG"].Value?.ToString() ?? "";
                        if (tt == TRANG_THAI[1])
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(13, 100, 60);
                        else if (tt == TRANG_THAI[3])
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 50, 50);
                    }
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i l\u1ecbch s\u1eed", ex); }
            }
        }

        // ================================================================
        // CLICK LỊCH SỬ → XEM
        // ================================================================
        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvHistory.Rows[e.RowIndex];
            if (row.Cells["MA_PTH"].Value == null) return;

            _viewingMaPTH = row.Cells["MA_PTH"].Value.ToString();
            _isEditingNew = false; _isEditingExist = false;
            LoadPhieuTraDetail(_viewingMaPTH);
            SetReadonlyRight(true);
            lblInfoTitle.Text = "Xem phi\u1ebfu: " + _viewingMaPTH + "  (ch\u1ebf \u0111\u1ed9 xem)";
            lblInfoTitle.ForeColor = Color.FromArgb(13, 43, 90);
        }

        private void LoadPhieuTraDetail(string maPTH)
        {
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmdH = new SqlCommand("SELECT * FROM PHIEUTRAHANG WHERE MA_PTH=@M", con);
                    cmdH.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPTH;
                    using (var rdr = cmdH.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            txtMaPTH.Text = maPTH;
                            dtpNgayTra.Value = Convert.ToDateTime(rdr["NGAYTRA"]);
                            SetCombo(cboKhachHang, rdr["MA_KH"]?.ToString() ?? "");
                            SetCombo(cboNhanVien, rdr["MANV"]?.ToString() ?? "");

                            string maNCC = rdr["MA_NCC"]?.ToString() ?? "";
                            if (!string.IsNullOrEmpty(maNCC)) SetCombo(cboNCC, maNCC);
                            else cboNCC.SelectedIndex = 0;

                            string tt = rdr["TRANGTHAI_TRAHANG"]?.ToString() ?? "";
                            int idx = Array.IndexOf(TRANG_THAI, tt);
                            cboTrangThai.SelectedIndex = idx >= 0 ? idx : 0;

                            string pt = rdr["PHUONGTHUCHOAN"]?.ToString() ?? "";
                            int idx2 = Array.IndexOf(PHUONG_THUC, pt);
                            cboPhuongThuc.SelectedIndex = idx2 >= 0 ? idx2 : -1;

                            txtLyDoTra.Text = rdr["LYDOTRA"]?.ToString() ?? "";
                            txtGhiChu.Text = rdr["GHICHU_TRAHANG"]?.ToString() ?? "";
                            txtTongHoan.Text = Convert.ToDecimal(rdr["TONGTIENHOAN"]).ToString("#,##0");
                        }
                    }

                    // Detail (readonly view)
                    string sqlD = @"
                        SELECT CT.MA_HD, CT.SOLUONG_TRA, CT.DONGIA_TRA, CT.THANHTIEN_TRA
                        FROM CT_PHIEUTRAHANG CT
                        WHERE CT.MA_PTH=@M";
                    var cmdD = new SqlCommand(sqlD, con);
                    cmdD.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPTH;
                    var dt = new DataTable();
                    new SqlDataAdapter(cmdD).Fill(dt);

                    dgvChiTietTra.DataSource = null; dgvChiTietTra.Columns.Clear();
                    dgvChiTietTra.AutoGenerateColumns = true; dgvChiTietTra.DataSource = dt;
                    void Col(string n, string h, string fmt = null,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvChiTietTra.Columns.Contains(n)) return;
                        dgvChiTietTra.Columns[n].HeaderText = h;
                        if (fmt != null) dgvChiTietTra.Columns[n].DefaultCellStyle.Format = fmt;
                        dgvChiTietTra.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("MA_HD", "M\u00e3 H\u00f3a \u0111\u01a1n g\u1ed1c", null, DataGridViewContentAlignment.MiddleCenter);
                    Col("SOLUONG_TRA", "S\u1ed1 l\u01b0\u1ee3ng tr\u1ea3", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("DONGIA_TRA", "\u0110\u01a1n gi\u00e1 tr\u1ea3", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("THANHTIEN_TRA", "Th\u00e0nh ti\u1ec1n", "#,##0", DataGridViewContentAlignment.MiddleRight);
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i chi ti\u1ebft phi\u1ebfu", ex); }
            }
        }

        // ================================================================
        // LẬP PHIẾU MỚI
        // ================================================================
        private void btnLapMoiPTH_Click(object sender, EventArgs e)
        {
            _isEditingNew = true; _isEditingExist = false; _viewingMaPTH = "";
            txtMaPTH.Text = GenerateMaPTH();
            dtpNgayTra.Value = DateTime.Today;
            cboKhachHang.SelectedIndex = -1; cboNCC.SelectedIndex = 0;
            cboNhanVien.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0; cboPhuongThuc.SelectedIndex = -1;
            txtLyDoTra.Text = ""; txtGhiChu.Text = "";
            dgvChiTietTra.DataSource = null; dgvChiTietTra.Columns.Clear(); BuildChiTietGrid();
            txtTongHoan.Text = "0";
            SetReadonlyRight(false);
            lblInfoTitle.Text = "L\u1eadp phi\u1ebfu m\u1edbi: " + txtMaPTH.Text;
            lblInfoTitle.ForeColor = Color.FromArgb(13, 43, 90);
            btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu tr\u1ea3";
            cboKhachHang.Focus();
        }

        private string GenerateMaPTH()
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(MA_PTH,4,LEN(MA_PTH)) AS INT)),0)+1 FROM PHIEUTRAHANG WHERE ISNUMERIC(SUBSTRING(MA_PTH,4,LEN(MA_PTH)))=1";
            using (var con = new SqlConnection(_conn))
            {
                try { con.Open(); return "PTH" + Convert.ToInt32(new SqlCommand(sql, con).ExecuteScalar()).ToString("D3"); }
                catch { return "PTH" + DateTime.Now.ToString("mmss"); }
            }
        }

        // ================================================================
        // SỬA PHIẾU
        // ================================================================
        private void btnSuaPTH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_viewingMaPTH)) { Warn("Ch\u1ecdn phi\u1ebfu c\u1ea7n s\u1eeda t\u1eeb danh s\u00e1ch b\u00ean tr\u00e1i."); return; }

            _isEditingNew = false; _isEditingExist = true;

            dgvChiTietTra.DataSource = null; dgvChiTietTra.Columns.Clear(); BuildChiTietGrid();

            string sql = "SELECT MA_HD, SOLUONG_TRA, DONGIA_TRA, THANHTIEN_TRA FROM CT_PHIEUTRAHANG WHERE MA_PTH=@M";
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = _viewingMaPTH;
                    using (var rdr = cmd.ExecuteReader())
                        while (rdr.Read())
                            _dtChiTiet.Rows.Add(rdr["MA_HD"], Convert.ToInt32(rdr["SOLUONG_TRA"]),
                                Convert.ToDecimal(rdr["DONGIA_TRA"]), Convert.ToDecimal(rdr["THANHTIEN_TRA"]));
                    RecalcTotal();
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i chi ti\u1ebft \u0111\u1ec3 s\u1eeda", ex); return; }
            }

            SetReadonlyRight(false);
            lblInfoTitle.Text = "\u270e  \u0110ang s\u1eeda phi\u1ebfu: " + _viewingMaPTH;
            lblInfoTitle.ForeColor = Color.FromArgb(160, 80, 0);
            btnSave.Text = "\u2714 C\u1eadp nh\u1eadt phi\u1ebfu";
        }

        // ================================================================
        // THÊM / XÓA DÒNG
        // ================================================================
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (!_isEditingNew && !_isEditingExist) { Warn("Ch\u1ecdn L\u1eadp phi\u1ebfu m\u1edbi ho\u1eb7c S\u1eeda phi\u1ebfu tr\u01b0\u1edbc."); return; }
            _dtChiTiet.Rows.Add("", 1, 0m, 0m);
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (!_isEditingNew && !_isEditingExist) return;
            if (dgvChiTietTra.CurrentRow == null) return;
            int idx = dgvChiTietTra.CurrentRow.Index;
            if (idx >= 0 && idx < _dtChiTiet.Rows.Count) { _dtChiTiet.Rows.RemoveAt(idx); RecalcTotal(); }
        }

        // Chọn HĐ gốc → tự điền đơn giá bán trung bình từ CT_HD
        private void dgvChiTietTra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((!_isEditingNew && !_isEditingExist) || e.RowIndex < 0) return;
            var col = dgvChiTietTra.Columns[e.ColumnIndex];

            if (col.Name == "colMaHD")
            {
                string maHD = dgvChiTietTra.Rows[e.RowIndex].Cells["colMaHD"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(maHD)) return;

                // Lấy tổng thành tiền của HĐ gốc làm gợi ý đơn giá
                using (var con = new SqlConnection(_conn))
                {
                    try
                    {
                        con.Open();
                        var cmd = new SqlCommand("SELECT ISNULL(TONGCONGTHANHTIEN,0) FROM HOADON WHERE MA_HD=@H", con);
                        cmd.Parameters.Add("@H", SqlDbType.Char, 10).Value = maHD;
                        var val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            decimal dg = Convert.ToDecimal(val);
                            _dtChiTiet.Rows[e.RowIndex]["DONGIA_TRA"] = dg;
                            _dtChiTiet.Rows[e.RowIndex]["THANHTIEN_TRA"] = 1 * dg;
                        }
                    }
                    catch { }
                }
            }

            if (col.Name == "colSL" || col.Name == "colDG")
            {
                var row = _dtChiTiet.Rows[e.RowIndex];
                int sl = row["SOLUONG_TRA"] == DBNull.Value ? 0 : Convert.ToInt32(row["SOLUONG_TRA"]);
                decimal dg = row["DONGIA_TRA"] == DBNull.Value ? 0 : Convert.ToDecimal(row["DONGIA_TRA"]);
                row["THANHTIEN_TRA"] = sl * dg;
            }

            RecalcTotal();
        }

        private void RecalcTotal()
        {
            decimal tong = 0;
            foreach (DataRow row in _dtChiTiet.Rows)
                if (row["THANHTIEN_TRA"] != DBNull.Value) tong += Convert.ToDecimal(row["THANHTIEN_TRA"]);
            txtTongHoan.Text = tong.ToString("#,##0");
        }

        // ================================================================
        // LƯU PHIẾU TRẢ
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_isEditingNew && !_isEditingExist) { Warn("Ch\u1ecdn L\u1eadp phi\u1ebfu m\u1edbi ho\u1eb7c S\u1eeda phi\u1ebfu tr\u01b0\u1edbc."); return; }

            dgvChiTietTra.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvChiTietTra.EndEdit();

            string maPTH = txtMaPTH.Text.Trim();
            string maKH = cboKhachHang.SelectedValue?.ToString();
            string maNV = cboNhanVien.SelectedValue?.ToString();
            string trangThai = cboTrangThai.SelectedItem?.ToString();
            string phuongThuc = cboPhuongThuc.SelectedItem?.ToString();
            string lyDo = txtLyDoTra.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();
            object maNCC = cboNCC.SelectedIndex <= 0 ? (object)DBNull.Value : cboNCC.SelectedValue;

            if (string.IsNullOrEmpty(maKH)) { Warn("Ch\u1ecdn kh\u00e1ch h\u00e0ng."); cboKhachHang.Focus(); return; }
            if (string.IsNullOrEmpty(maNV)) { Warn("Ch\u1ecdn nh\u00e2n vi\u00ean."); cboNhanVien.Focus(); return; }
            if (string.IsNullOrEmpty(phuongThuc)) { Warn("Ch\u1ecdn ph\u01b0\u01a1ng th\u1ee9c ho\u00e0n ti\u1ec1n."); cboPhuongThuc.Focus(); return; }
            if (string.IsNullOrEmpty(lyDo)) { Warn("Nh\u1eadp l\u00fd do tr\u1ea3."); txtLyDoTra.Focus(); return; }
            if (_dtChiTiet.Rows.Count == 0) { Warn("Th\u00eam \u00edt nh\u1ea5t 1 h\u00f3a \u0111\u01a1n tr\u1ea3."); return; }

            for (int i = 0; i < _dtChiTiet.Rows.Count; i++)
            {
                var row = _dtChiTiet.Rows[i];
                if (row["MA_HD"]?.ToString() == "" || row["MA_HD"] == DBNull.Value) { Warn($"D\u00f2ng {i + 1}: Ch\u01b0a ch\u1ecdn M\u00e3 HĐ."); return; }
                int sl = row["SOLUONG_TRA"] == DBNull.Value ? 0 : Convert.ToInt32(row["SOLUONG_TRA"]);
                if (sl <= 0) { Warn($"D\u00f2ng {i + 1}: S\u1ed1 l\u01b0\u1ee3ng tr\u1ea3 ph\u1ea3i > 0."); return; }
            }

            decimal tongHoan = decimal.Parse(txtTongHoan.Text.Replace(",", "").Replace(".", ""));

            using (var con = new SqlConnection(_conn))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open(); tran = con.BeginTransaction();

                    SqlCommand cmdPTH;
                    if (_isEditingNew)
                    {
                        cmdPTH = new SqlCommand(@"
                            INSERT INTO PHIEUTRAHANG
                              (MA_PTH,NGAYTRA,LYDOTRA,TONGTIENHOAN,TRANGTHAI_TRAHANG,
                               PHUONGTHUCHOAN,GHICHU_TRAHANG,MA_KH,MA_NCC,MANV)
                            VALUES (@M,@N,@LD,@TH,@TT,@PT,@GC,@KH,@NCC,@NV)", con, tran);
                    }
                    else
                    {
                        var del = new SqlCommand("DELETE FROM CT_PHIEUTRAHANG WHERE MA_PTH=@M", con, tran);
                        del.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPTH;
                        del.ExecuteNonQuery();
                        cmdPTH = new SqlCommand(@"
                            UPDATE PHIEUTRAHANG SET
                              NGAYTRA=@N,LYDOTRA=@LD,TONGTIENHOAN=@TH,
                              TRANGTHAI_TRAHANG=@TT,PHUONGTHUCHOAN=@PT,
                              GHICHU_TRAHANG=@GC,MA_KH=@KH,MA_NCC=@NCC,MANV=@NV
                            WHERE MA_PTH=@M", con, tran);
                    }

                    cmdPTH.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPTH;
                    cmdPTH.Parameters.Add("@N", SqlDbType.Date).Value = dtpNgayTra.Value.Date;
                    cmdPTH.Parameters.Add("@LD", SqlDbType.NVarChar, 255).Value = lyDo;
                    cmdPTH.Parameters.Add("@TH", SqlDbType.Decimal).Value = tongHoan;
                    cmdPTH.Parameters.Add("@TT", SqlDbType.NVarChar, 100).Value = trangThai;
                    cmdPTH.Parameters.Add("@PT", SqlDbType.NVarChar, 100).Value = phuongThuc;
                    cmdPTH.Parameters.Add("@GC", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu;
                    cmdPTH.Parameters.Add("@KH", SqlDbType.Char, 10).Value = maKH;
                    cmdPTH.Parameters.Add("@NCC", SqlDbType.Char, 10).Value = maNCC;
                    cmdPTH.Parameters.Add("@NV", SqlDbType.Char, 10).Value = maNV;
                    ((SqlParameter)cmdPTH.Parameters["@TH"]).Precision = 18; ((SqlParameter)cmdPTH.Parameters["@TH"]).Scale = 2;
                    cmdPTH.ExecuteNonQuery();

                    foreach (DataRow row in _dtChiTiet.Rows)
                    {
                        var cmdCT = new SqlCommand(@"
                            INSERT INTO CT_PHIEUTRAHANG (MA_PTH,MA_HD,SOLUONG_TRA,DONGIA_TRA,THANHTIEN_TRA)
                            VALUES (@M,@HD,@SL,@DG,@TT)", con, tran);
                        cmdCT.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPTH;
                        cmdCT.Parameters.Add("@HD", SqlDbType.Char, 10).Value = row["MA_HD"].ToString();
                        cmdCT.Parameters.Add("@SL", SqlDbType.Int).Value = Convert.ToInt32(row["SOLUONG_TRA"]);
                        cmdCT.Parameters.Add("@DG", SqlDbType.Decimal).Value = Convert.ToDecimal(row["DONGIA_TRA"]);
                        cmdCT.Parameters.Add("@TT", SqlDbType.Decimal).Value = Convert.ToDecimal(row["THANHTIEN_TRA"]);
                        foreach (string p in new[] { "@DG", "@TT" })
                        { ((SqlParameter)cmdCT.Parameters[p]).Precision = 18; ((SqlParameter)cmdCT.Parameters[p]).Scale = 2; }
                        cmdCT.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show((_isEditingNew ? "L\u01b0u" : "C\u1eadp nh\u1eadt") + " phi\u1ebfu tr\u1ea3 [" + maPTH + "] th\u00e0nh c\u00f4ng!",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _isEditingNew = false; _isEditingExist = false;
                    btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu tr\u1ea3";
                    SetReadonlyRight(true);
                    LoadHistory();
                    lblInfoTitle.Text = "Ph\u00f4i \u0111\u00e3 l\u01b0u. Ch\u1ecdn phi\u1ebfu b\u00ean tr\u00e1i \u0111\u1ec3 xem l\u1ea1i.";
                    lblInfoTitle.ForeColor = Color.FromArgb(13, 43, 90);
                }
                catch (SqlException ex) { tran?.Rollback(); ShowErr("l\u01b0u phi\u1ebfu tr\u1ea3", ex); }
                catch (Exception ex2) { tran?.Rollback(); MessageBox.Show(ex2.Message, "L\u1ed7i", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // ================================================================
        // XÓA PHIẾU
        // ================================================================
        private void btnXoaPTH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_viewingMaPTH)) { Warn("Ch\u1ecdn phi\u1ebfu c\u1ea7n x\u00f3a t\u1eeb danh s\u00e1ch b\u00ean tr\u00e1i."); return; }

            if (MessageBox.Show("X\u00f3a phi\u1ebfu tr\u1ea3 [" + _viewingMaPTH + "] v\u00e0 to\u00e0n b\u1ed9 chi ti\u1ebft?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            using (var con = new SqlConnection(_conn))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open(); tran = con.BeginTransaction();
                    var c1 = new SqlCommand("DELETE FROM CT_PHIEUTRAHANG WHERE MA_PTH=@M", con, tran);
                    c1.Parameters.Add("@M", SqlDbType.Char, 10).Value = _viewingMaPTH;
                    c1.ExecuteNonQuery();
                    var c2 = new SqlCommand("DELETE FROM PHIEUTRAHANG WHERE MA_PTH=@M", con, tran);
                    c2.Parameters.Add("@M", SqlDbType.Char, 10).Value = _viewingMaPTH;
                    c2.ExecuteNonQuery();
                    tran.Commit();
                    MessageBox.Show("X\u00f3a th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _viewingMaPTH = ""; ClearRight(); LoadHistory();
                }
                catch (SqlException ex) { tran?.Rollback(); ShowErr("x\u00f3a phi\u1ebfu", ex); }
            }
        }

        // ================================================================
        // TÌM KIẾM / HỦY
        // ================================================================
        private void btnSearchPTH_Click(object sender, EventArgs e) => LoadHistory(txtSearchPTH.Text);
        private void txtSearchPTH_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) btnSearchPTH_Click(sender, e); }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _isEditingNew = false; _isEditingExist = false; _viewingMaPTH = "";
            btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu tr\u1ea3";
            ClearRight(); SetReadonlyRight(true);
            lblInfoTitle.Text = "Th\u00f4ng tin phi\u1ebfu tr\u1ea3 h\u00e0ng";
            lblInfoTitle.ForeColor = Color.FromArgb(13, 43, 90);
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private void SetReadonlyRight(bool ro)
        {
            txtMaPTH.ReadOnly = true;
            dtpNgayTra.Enabled = !ro;
            cboKhachHang.Enabled = !ro; cboNCC.Enabled = !ro; cboNhanVien.Enabled = !ro;
            cboTrangThai.Enabled = !ro; cboPhuongThuc.Enabled = !ro;
            txtLyDoTra.ReadOnly = ro; txtGhiChu.ReadOnly = ro;
            dgvChiTietTra.ReadOnly = ro;
            btnAddRow.Enabled = !ro; btnDelRow.Enabled = !ro;
            btnSave.Enabled = !ro;
            btnSuaPTH.Enabled = ro && !string.IsNullOrEmpty(_viewingMaPTH);
            btnXoaPTH.Enabled = ro && !string.IsNullOrEmpty(_viewingMaPTH);
        }

        private void ClearRight()
        {
            txtMaPTH.Text = ""; txtLyDoTra.Text = ""; txtGhiChu.Text = ""; txtTongHoan.Text = "0";
            cboKhachHang.SelectedIndex = -1; cboNCC.SelectedIndex = 0;
            cboNhanVien.SelectedIndex = -1; cboTrangThai.SelectedIndex = 0; cboPhuongThuc.SelectedIndex = -1;
            dgvChiTietTra.DataSource = null; dgvChiTietTra.Columns.Clear();
        }

        private void SetCombo(ComboBox cmb, string val)
        {
            if (cmb.DataSource is DataTable dt)
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (dt.Rows[i][cmb.ValueMember]?.ToString() == val) { cmb.SelectedIndex = i; return; }
        }

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