using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormPhieuXuat : Form
    {
        private readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        private DataTable _dtChiTiet;
        private DataTable _dtSanPham;
        private string _viewingMaPX = "";
        private bool _isEditingNew = false;
        private bool _isEditingExist = false;

        public FormPhieuXuat()
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
            lblTitle.Text = "L\u1eacP PHI\u1ebcU XU\u1ea4T KHO";
            lblSubtitle.Text = "TH True Mart \u00b7 Xu\u1ea5t h\u00e0ng";
            lblLeftTitle.Text = "L\u1ecbch s\u1eed phi\u1ebfu xu\u1ea5t";
            btnSearchPX.Text = "T\u00ecm";
            btnLapMoiPX.Text = "+ L\u1eadp phi\u1ebfu m\u1edbi";
            btnSuaPX.Text = "\u270e S\u1eeda phi\u1ebfu";
            btnXoaPX.Text = "\u00d7 X\u00f3a phi\u1ebfu";
            lblInfoTitle.Text = "Th\u00f4ng tin phi\u1ebfu xu\u1ea5t";
            lblMaPX.Text = "M\u00e3 phi\u1ebfu *";
            lblNgayXuat.Text = "Ng\u00e0y xu\u1ea5t";
            lblKhoXuat.Text = "Kho xu\u1ea5t *";
            lblNV.Text = "Nh\u00e2n vi\u00ean *";
            lblDiaDiemGH.Text = "\u0110\u1ecba \u0111i\u1ec3m giao h\u00e0ng *";
            lblLyDo.Text = "L\u00fd do xu\u1ea5t";
            lblGhiChu.Text = "Ghi ch\u00fa";
            lblGridTitle.Text = "Chi ti\u1ebft s\u1ea3n ph\u1ea9m xu\u1ea5t";
            lblGridHint.Text = "Ch\u1ecdn SP \u2192 nh\u1eadp s\u1ed1 l\u01b0\u1ee3ng \u2192 \u0111\u01a1n gi\u00e1 t\u1ef1 \u0111\u1ed9ng \u2192 c\u1ed9t T\u1ed3n kho c\u1ea3nh b\u00e1o \u0111\u1ecf n\u1ebfu xu\u1ea5t qu\u00e1";
            btnAddRow.Text = "+ Th\u00eam d\u00f2ng";
            btnDelRow.Text = "\u2212 X\u00f3a d\u00f2ng";
            lblTongGiaLabel.Text = "T\u1ed5ng tr\u1ecb gi\u00e1 xu\u1ea5t (\u0111):";
            btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu xu\u1ea5t";
            btnCancel.Text = "\u00d7 H\u1ee7y b\u1ecf";
            lblHintSave.Text = "";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 PHIEUXUAT \u00b7 CT_PHIEUXUAT \u00b7 TONKHO";
        }

        private void SetHoverEffects()
        {
            var colNav = Color.FromArgb(13, 43, 90);
            var colNavH = Color.FromArgb(25, 65, 120);
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnSave, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnLapMoiPX, colNavH, colNav);
            H(btnAddRow, colNavH, colNav);
            H(btnSuaPX, Color.FromArgb(210, 145, 10), Color.FromArgb(180, 120, 0));
            H(btnXoaPX, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnDelRow, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnSearchPX, Color.FromArgb(80, 160, 255), Color.FromArgb(56, 139, 253));
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormPhieuXuat_Load(object sender, EventArgs e)
        {
            LoadComboKho();
            LoadComboNV();
            LoadSanPhamData();
            BuildChiTietGrid();
            LoadHistory();
            SetReadonlyRight(true);
        }

        private void LoadComboKho()
        {
            var dt = Query("SELECT MA_KHO, TEN_KHO + ' [' + MA_KHO + ']' AS HT FROM KHO ORDER BY TEN_KHO");
            if (dt == null) return;
            cboKhoXuat.DataSource = dt; cboKhoXuat.DisplayMember = "HT"; cboKhoXuat.ValueMember = "MA_KHO"; cboKhoXuat.SelectedIndex = -1;
        }

        private void LoadComboNV()
        {
            var dt = Query("SELECT MANV, TENNV + ' [' + MANV + ']' AS HT FROM NHANVIEN WHERE TRANGTHAI_NV=N'\u0110ang l\u00e0m vi\u1ec7c' ORDER BY TENNV");
            if (dt == null) return;
            cboNhanVien.DataSource = dt; cboNhanVien.DisplayMember = "HT"; cboNhanVien.ValueMember = "MANV"; cboNhanVien.SelectedIndex = -1;
        }

        private void LoadSanPhamData()
        {
            _dtSanPham = Query("SELECT MASP, TENSP + ' [' + MASP + ']' AS HT FROM SANPHAM ORDER BY TENSP");
        }

        // ================================================================
        // BUILD GRID — có thêm cột TonKho (readonly, cảnh báo đỏ)
        // ================================================================
        private void BuildChiTietGrid()
        {
            _dtChiTiet = new DataTable();
            _dtChiTiet.Columns.Add("MASP", typeof(string));
            _dtChiTiet.Columns.Add("TENSP", typeof(string));
            _dtChiTiet.Columns.Add("SOLUONGXUAT", typeof(int));
            _dtChiTiet.Columns.Add("DONGIA_PX", typeof(decimal));
            _dtChiTiet.Columns.Add("THANHTIEN_PX", typeof(decimal));
            _dtChiTiet.Columns.Add("TON_KHO", typeof(decimal)); // chỉ hiển thị

            dgvChiTietPX.Columns.Clear();

            var colSP = new DataGridViewComboBoxColumn
            {
                Name = "colMaSP",
                HeaderText = "S\u1ea3n ph\u1ea9m *",
                DataPropertyName = "MASP",
                Width = 240,
                FlatStyle = FlatStyle.Flat,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            };
            if (_dtSanPham != null) { colSP.DataSource = _dtSanPham; colSP.DisplayMember = "HT"; colSP.ValueMember = "MASP"; }
            dgvChiTietPX.Columns.Add(colSP);

            dgvChiTietPX.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSL", HeaderText = "S\u1ed1 l\u01b0\u1ee3ng *", DataPropertyName = "SOLUONGXUAT", Width = 100, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "#,##0" } });
            dgvChiTietPX.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDG", HeaderText = "\u0110\u01a1n gi\u00e1 (\u0111) *", DataPropertyName = "DONGIA_PX", Width = 130, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#,##0" } });
            dgvChiTietPX.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTT", HeaderText = "Th\u00e0nh ti\u1ec1n (\u0111)", DataPropertyName = "THANHTIEN_PX", Width = 140, ReadOnly = true, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#,##0", BackColor = Color.FromArgb(255, 248, 240), ForeColor = Color.FromArgb(140, 50, 20) } });

            // Cột tồn kho — màu xanh nếu ok, đỏ nếu vượt
            dgvChiTietPX.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTon",
                HeaderText = "T\u1ed3n kho",
                DataPropertyName = "TON_KHO",
                Width = 100,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#,##0", BackColor = Color.FromArgb(240, 255, 245), ForeColor = Color.FromArgb(13, 100, 60) }
            });

            dgvChiTietPX.DataSource = _dtChiTiet;
            dgvChiTietPX.DataError += (s, ev) => ev.Cancel = true;
            dgvChiTietPX.CellFormatting += DgvChiTietPX_CellFormatting;
        }

        // Tô đỏ ô Tồn kho khi SL xuất > tồn
        private void DgvChiTietPX_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _dtChiTiet.Rows.Count) return;
            if (dgvChiTietPX.Columns[e.ColumnIndex].Name != "colTon") return;
            var row = _dtChiTiet.Rows[e.RowIndex];
            if (row["TON_KHO"] == DBNull.Value || row["SOLUONGXUAT"] == DBNull.Value) return;
            decimal ton = Convert.ToDecimal(row["TON_KHO"]);
            int sl = Convert.ToInt32(row["SOLUONGXUAT"]);
            if (sl > ton)
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 220, 220);
                e.CellStyle.ForeColor = Color.FromArgb(180, 0, 0);
            }
            else
            {
                e.CellStyle.BackColor = Color.FromArgb(240, 255, 245);
                e.CellStyle.ForeColor = Color.FromArgb(13, 100, 60);
            }
        }

        // ================================================================
        // LOAD LỊCH SỬ
        // ================================================================
        private void LoadHistory(string keyword = "")
        {
            string sql = @"
                SELECT PX.MA_PX, PX.NGAYXUAT, KH.TEN_KHO, NV.TENNV,
                       PX.TRIGIA_PX, PX.DIADIEMGH,
                       (SELECT COUNT(*) FROM CT_PHIEUXUAT C WHERE C.MA_PX=PX.MA_PX) AS SoDong
                FROM PHIEUXUAT PX
                JOIN KHO      KH ON PX.MA_KHO=KH.MA_KHO
                JOIN NHANVIEN NV ON PX.MANV=NV.MANV
                WHERE @kw='' OR PX.MA_PX LIKE @kw OR KH.TEN_KHO LIKE @kw OR NV.TENNV LIKE @kw
                ORDER BY PX.NGAYXUAT DESC";

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
                    Col("MA_PX", "M\u00e3 phi\u1ebfu");
                    Col("NGAYXUAT", "Ng\u00e0y", "dd/MM/yy", DataGridViewContentAlignment.MiddleCenter);
                    Col("TEN_KHO", "Kho");
                    Col("TENNV", "Nh\u00e2n vi\u00ean");
                    Col("TRIGIA_PX", "Tr\u1ecb gi\u00e1", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("DIADIEMGH", "Giao \u0111i");
                    Col("SoDong", "D\u00f2ng", null, DataGridViewContentAlignment.MiddleCenter);
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
            if (row.Cells["MA_PX"].Value == null) return;

            _viewingMaPX = row.Cells["MA_PX"].Value.ToString();
            _isEditingNew = false; _isEditingExist = false;
            LoadPhieuXuatDetail(_viewingMaPX);
            SetReadonlyRight(true);
            lblInfoTitle.Text = "Xem phi\u1ebfu: " + _viewingMaPX + "  (ch\u1ebf \u0111\u1ed9 xem)";
            lblInfoTitle.ForeColor = Color.FromArgb(100, 60, 20);
        }

        private void LoadPhieuXuatDetail(string maPX)
        {
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmdH = new SqlCommand("SELECT * FROM PHIEUXUAT WHERE MA_PX=@M", con);
                    cmdH.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPX;
                    using (var rdr = cmdH.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            txtMaPX.Text = maPX;
                            dtpNgayXuat.Value = Convert.ToDateTime(rdr["NGAYXUAT"]);
                            SetCombo(cboKhoXuat, rdr["MA_KHO"]?.ToString() ?? "");
                            SetCombo(cboNhanVien, rdr["MANV"]?.ToString() ?? "");
                            txtDiaDiemGH.Text = rdr["DIADIEMGH"]?.ToString() ?? "";
                            txtLyDo.Text = rdr["LYDOXUAT"]?.ToString() ?? "";
                            txtGhiChu.Text = rdr["GHICHU_PX"]?.ToString() ?? "";
                        }
                    }

                    string sqlD = @"
                        SELECT CT.MASP, SP.TENSP, CT.SOLUONGXUAT, CT.DONGIA_PX, CT.THANHTIEN_PX
                        FROM CT_PHIEUXUAT CT JOIN SANPHAM SP ON CT.MASP=SP.MASP
                        WHERE CT.MA_PX=@M";
                    var cmdD = new SqlCommand(sqlD, con);
                    cmdD.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPX;
                    var dt = new DataTable();
                    new SqlDataAdapter(cmdD).Fill(dt);

                    dgvChiTietPX.DataSource = null; dgvChiTietPX.Columns.Clear();
                    dgvChiTietPX.AutoGenerateColumns = true; dgvChiTietPX.DataSource = dt;
                    void Col(string n, string h, string fmt = null,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvChiTietPX.Columns.Contains(n)) return;
                        dgvChiTietPX.Columns[n].HeaderText = h;
                        if (fmt != null) dgvChiTietPX.Columns[n].DefaultCellStyle.Format = fmt;
                        dgvChiTietPX.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("MASP", "M\u00e3 SP", null, DataGridViewContentAlignment.MiddleCenter);
                    Col("TENSP", "T\u00ean s\u1ea3n ph\u1ea9m");
                    Col("SOLUONGXUAT", "S\u1ed1 l\u01b0\u1ee3ng", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("DONGIA_PX", "\u0110\u01a1n gi\u00e1", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("THANHTIEN_PX", "Th\u00e0nh ti\u1ec1n", "#,##0", DataGridViewContentAlignment.MiddleRight);

                    decimal tong = 0;
                    foreach (DataRow r in dt.Rows)
                        if (r["THANHTIEN_PX"] != DBNull.Value) tong += Convert.ToDecimal(r["THANHTIEN_PX"]);
                    txtTongGia.Text = tong.ToString("#,##0");
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i chi ti\u1ebft phi\u1ebfu", ex); }
            }
        }

        // ================================================================
        // LẬP PHIẾU MỚI
        // ================================================================
        private void btnLapMoiPX_Click(object sender, EventArgs e)
        {
            _isEditingNew = true; _isEditingExist = false; _viewingMaPX = "";
            txtMaPX.Text = GenerateMaPX();
            dtpNgayXuat.Value = DateTime.Today;
            cboKhoXuat.SelectedIndex = -1; cboNhanVien.SelectedIndex = -1;
            txtDiaDiemGH.Text = ""; txtLyDo.Text = ""; txtGhiChu.Text = "";
            dgvChiTietPX.DataSource = null; dgvChiTietPX.Columns.Clear(); BuildChiTietGrid();
            txtTongGia.Text = "0";
            SetReadonlyRight(false);
            lblInfoTitle.Text = "L\u1eadp phi\u1ebfu m\u1edbi: " + txtMaPX.Text;
            lblInfoTitle.ForeColor = Color.FromArgb(13, 43, 90);
            btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu xu\u1ea5t";
            cboKhoXuat.Focus();
        }

        private string GenerateMaPX()
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(MA_PX,3,LEN(MA_PX)) AS INT)),0)+1 FROM PHIEUXUAT WHERE ISNUMERIC(SUBSTRING(MA_PX,3,LEN(MA_PX)))=1";
            using (var con = new SqlConnection(_conn))
            {
                try { con.Open(); return "PX" + Convert.ToInt32(new SqlCommand(sql, con).ExecuteScalar()).ToString("D3"); }
                catch { return "PX" + DateTime.Now.ToString("mmss"); }
            }
        }

        // ================================================================
        // SỬA PHIẾU
        // ================================================================
        private void btnSuaPX_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_viewingMaPX)) { Warn("Ch\u1ecdn phi\u1ebfu c\u1ea7n s\u1eeda t\u1eeb danh s\u00e1ch b\u00ean tr\u00e1i."); return; }

            _isEditingNew = false; _isEditingExist = true;

            // Load chi tiết vào editable grid
            dgvChiTietPX.DataSource = null; dgvChiTietPX.Columns.Clear(); BuildChiTietGrid();

            string sql = @"SELECT CT.MASP, SP.TENSP, CT.SOLUONGXUAT, CT.DONGIA_PX, CT.THANHTIEN_PX
                           FROM CT_PHIEUXUAT CT JOIN SANPHAM SP ON CT.MASP=SP.MASP WHERE CT.MA_PX=@M";
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = _viewingMaPX;
                    using (var rdr = cmd.ExecuteReader())
                        while (rdr.Read())
                        {
                            decimal ton = GetTonKho(rdr["MASP"].ToString(), cboKhoXuat.SelectedValue?.ToString() ?? "");
                            _dtChiTiet.Rows.Add(rdr["MASP"], rdr["TENSP"],
                                Convert.ToInt32(rdr["SOLUONGXUAT"]),
                                Convert.ToDecimal(rdr["DONGIA_PX"]),
                                Convert.ToDecimal(rdr["THANHTIEN_PX"]),
                                ton);
                        }
                    RecalcTotal();
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i chi ti\u1ebft \u0111\u1ec3 s\u1eeda", ex); return; }
            }

            SetReadonlyRight(false);
            lblInfoTitle.Text = "\u270e  \u0110ang s\u1eeda phi\u1ebfu: " + _viewingMaPX;
            lblInfoTitle.ForeColor = Color.FromArgb(160, 80, 0);
            btnSave.Text = "\u2714 C\u1eadp nh\u1eadt phi\u1ebfu";
        }

        // ================================================================
        // THÊM / XÓA DÒNG
        // ================================================================
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (!_isEditingNew && !_isEditingExist) { Warn("Ch\u1ecdn L\u1eadp phi\u1ebfu m\u1edbi ho\u1eb7c S\u1eeda phi\u1ebfu tr\u01b0\u1edbc."); return; }
            _dtChiTiet.Rows.Add("", "", 1, 0m, 0m, 0m);
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (!_isEditingNew && !_isEditingExist) return;
            if (dgvChiTietPX.CurrentRow == null) return;
            int idx = dgvChiTietPX.CurrentRow.Index;
            if (idx >= 0 && idx < _dtChiTiet.Rows.Count) { _dtChiTiet.Rows.RemoveAt(idx); RecalcTotal(); }
        }

        // Chọn SP → tự điền giá bán + tồn kho
        private void dgvChiTietPX_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((!_isEditingNew && !_isEditingExist) || e.RowIndex < 0) return;
            var col = dgvChiTietPX.Columns[e.ColumnIndex];

            if (col.Name == "colMaSP")
            {
                string maSP = dgvChiTietPX.Rows[e.RowIndex].Cells["colMaSP"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(maSP)) return;

                if (_dtSanPham != null)
                {
                    var rows = _dtSanPham.Select($"MASP='{maSP}'");
                    if (rows.Length > 0) _dtChiTiet.Rows[e.RowIndex]["TENSP"] = rows[0]["HT"].ToString();
                }

                // Giá bán mới nhất
                using (var con = new SqlConnection(_conn))
                {
                    try
                    {
                        con.Open();
                        var cmd = new SqlCommand("SELECT TOP 1 GIABAN FROM BIENDONGGIA WHERE MASP=@S ORDER BY NGAYCAPNHAT_BDG DESC", con);
                        cmd.Parameters.Add("@S", SqlDbType.Char, 10).Value = maSP;
                        var val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            decimal gia = Convert.ToDecimal(val);
                            _dtChiTiet.Rows[e.RowIndex]["DONGIA_PX"] = gia;
                            _dtChiTiet.Rows[e.RowIndex]["THANHTIEN_PX"] = 1 * gia;
                        }
                    }
                    catch { }
                }

                // Tồn kho
                string maKho = cboKhoXuat.SelectedValue?.ToString() ?? "";
                _dtChiTiet.Rows[e.RowIndex]["TON_KHO"] = GetTonKho(maSP, maKho);
            }

            if (col.Name == "colSL" || col.Name == "colDG")
            {
                var row = _dtChiTiet.Rows[e.RowIndex];
                int sl = row["SOLUONGXUAT"] == DBNull.Value ? 0 : Convert.ToInt32(row["SOLUONGXUAT"]);
                decimal dg = row["DONGIA_PX"] == DBNull.Value ? 0 : Convert.ToDecimal(row["DONGIA_PX"]);
                row["THANHTIEN_PX"] = sl * dg;
            }

            RecalcTotal();
        }

        private decimal GetTonKho(string maSP, string maKho)
        {
            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(maKho)) return 0;
            string sql = "SELECT ISNULL(TONCK, 0) FROM TONKHO WHERE MASP=@S AND MA_KHO=@K";
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@S", SqlDbType.Char, 10).Value = maSP;
                    cmd.Parameters.Add("@K", SqlDbType.Char, 10).Value = maKho;
                    var val = cmd.ExecuteScalar();
                    return val == null || val == DBNull.Value ? 0 : Convert.ToDecimal(val);
                }
                catch { return 0; }
            }
        }

        private void RecalcTotal()
        {
            decimal tong = 0;
            foreach (DataRow r in _dtChiTiet.Rows)
                if (r["THANHTIEN_PX"] != DBNull.Value) tong += Convert.ToDecimal(r["THANHTIEN_PX"]);
            txtTongGia.Text = tong.ToString("#,##0");
        }

        // ================================================================
        // LƯU PHIẾU XUẤT
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_isEditingNew && !_isEditingExist) { Warn("Ch\u1ecdn L\u1eadp phi\u1ebfu m\u1edbi ho\u1eb7c S\u1eeda phi\u1ebfu tr\u01b0\u1edbc."); return; }

            dgvChiTietPX.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvChiTietPX.EndEdit();

            string maPX = txtMaPX.Text.Trim();
            string maKho = cboKhoXuat.SelectedValue?.ToString();
            string maNV = cboNhanVien.SelectedValue?.ToString();
            string diaDiem = txtDiaDiemGH.Text.Trim();

            if (string.IsNullOrEmpty(maKho)) { Warn("Ch\u1ecdn kho xu\u1ea5t."); cboKhoXuat.Focus(); return; }
            if (string.IsNullOrEmpty(maNV)) { Warn("Ch\u1ecdn nh\u00e2n vi\u00ean."); cboNhanVien.Focus(); return; }
            if (string.IsNullOrEmpty(diaDiem)) { Warn("Nh\u1eadp \u0111\u1ecba \u0111i\u1ec3m giao h\u00e0ng."); txtDiaDiemGH.Focus(); return; }
            if (_dtChiTiet.Rows.Count == 0) { Warn("Th\u00eam \u00edt nh\u1ea5t 1 s\u1ea3n ph\u1ea9m."); return; }

            // Validate + kiểm tra tồn kho
            for (int i = 0; i < _dtChiTiet.Rows.Count; i++)
            {
                var row = _dtChiTiet.Rows[i];
                if (row["MASP"]?.ToString() == "" || row["MASP"] == DBNull.Value) { Warn($"D\u00f2ng {i + 1}: Ch\u01b0a ch\u1ecdn SP."); return; }
                int sl = row["SOLUONGXUAT"] == DBNull.Value ? 0 : Convert.ToInt32(row["SOLUONGXUAT"]);
                if (sl <= 0) { Warn($"D\u00f2ng {i + 1}: S\u1ed1 l\u01b0\u1ee3ng ph\u1ea3i > 0."); return; }
                decimal ton = row["TON_KHO"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TON_KHO"]);
                if (sl > ton)
                {
                    if (MessageBox.Show(
                        $"D\u00f2ng {i + 1}: Xu\u1ea5t {sl} nh\u01b0ng t\u1ed3n kho ch\u1ec9 c\u00f2n {ton}.\nV\u1eabn ti\u1ebfp t\u1ee5c l\u01b0u?",
                        "C\u1ea3nh b\u00e1o t\u1ed3n kho", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        != DialogResult.Yes) return;
                }
            }

            decimal triGia = decimal.Parse(txtTongGia.Text.Replace(",", "").Replace(".", ""));
            string lyDo = txtLyDo.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();

            using (var con = new SqlConnection(_conn))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open(); tran = con.BeginTransaction();

                    SqlCommand cmdPX;
                    if (_isEditingNew)
                    {
                        cmdPX = new SqlCommand(@"
                            INSERT INTO PHIEUXUAT (MA_PX, NGAYXUAT, LYDOXUAT, TRIGIA_PX, DIADIEMGH, GHICHU_PX, MA_KHO, MANV)
                            VALUES (@M,@N,@LD,@TG,@DD,@GC,@KH,@NV)", con, tran);
                    }
                    else
                    {
                        var del = new SqlCommand("DELETE FROM CT_PHIEUXUAT WHERE MA_PX=@M", con, tran);
                        del.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPX;
                        del.ExecuteNonQuery();
                        cmdPX = new SqlCommand(@"
                            UPDATE PHIEUXUAT SET
                              NGAYXUAT=@N, LYDOXUAT=@LD, TRIGIA_PX=@TG,
                              DIADIEMGH=@DD, GHICHU_PX=@GC, MA_KHO=@KH, MANV=@NV
                            WHERE MA_PX=@M", con, tran);
                    }

                    cmdPX.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPX;
                    cmdPX.Parameters.Add("@N", SqlDbType.Date).Value = dtpNgayXuat.Value.Date;
                    cmdPX.Parameters.Add("@LD", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(lyDo) ? (object)DBNull.Value : lyDo;
                    cmdPX.Parameters.Add("@TG", SqlDbType.Decimal).Value = triGia;
                    cmdPX.Parameters.Add("@DD", SqlDbType.NVarChar, 100).Value = diaDiem;
                    cmdPX.Parameters.Add("@GC", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu;
                    cmdPX.Parameters.Add("@KH", SqlDbType.Char, 10).Value = maKho;
                    cmdPX.Parameters.Add("@NV", SqlDbType.Char, 10).Value = maNV;
                    ((SqlParameter)cmdPX.Parameters["@TG"]).Precision = 18; ((SqlParameter)cmdPX.Parameters["@TG"]).Scale = 2;
                    cmdPX.ExecuteNonQuery();

                    foreach (DataRow row in _dtChiTiet.Rows)
                    {
                        var cmdCT = new SqlCommand(@"
                            INSERT INTO CT_PHIEUXUAT (MA_PX,MASP,SOLUONGXUAT,DONGIA_PX,THANHTIEN_PX)
                            VALUES (@M,@SP,@SL,@DG,@TT)", con, tran);
                        cmdCT.Parameters.Add("@M", SqlDbType.Char, 10).Value = maPX;
                        cmdCT.Parameters.Add("@SP", SqlDbType.Char, 10).Value = row["MASP"].ToString();
                        cmdCT.Parameters.Add("@SL", SqlDbType.Int).Value = Convert.ToInt32(row["SOLUONGXUAT"]);
                        cmdCT.Parameters.Add("@DG", SqlDbType.Decimal).Value = Convert.ToDecimal(row["DONGIA_PX"]);
                        cmdCT.Parameters.Add("@TT", SqlDbType.Decimal).Value = Convert.ToDecimal(row["THANHTIEN_PX"]);
                        foreach (string p in new[] { "@DG", "@TT" })
                        { ((SqlParameter)cmdCT.Parameters[p]).Precision = 18; ((SqlParameter)cmdCT.Parameters[p]).Scale = 2; }
                        cmdCT.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show((_isEditingNew ? "L\u01b0u" : "C\u1eadp nh\u1eadt") + " phi\u1ebfu xu\u1ea5t [" + maPX + "] th\u00e0nh c\u00f4ng!",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _isEditingNew = false; _isEditingExist = false;
                    btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu xu\u1ea5t";
                    SetReadonlyRight(true);
                    LoadHistory();
                    lblInfoTitle.Text = "Ph\u00f4i \u0111\u00e3 l\u01b0u. Ch\u1ecdn phi\u1ebfu b\u00ean tr\u00e1i \u0111\u1ec3 xem l\u1ea1i.";
                    lblInfoTitle.ForeColor = Color.FromArgb(100, 60, 20);
                }
                catch (SqlException ex) { tran?.Rollback(); ShowErr("l\u01b0u phi\u1ebfu xu\u1ea5t", ex); }
                catch (Exception ex2) { tran?.Rollback(); MessageBox.Show(ex2.Message, "L\u1ed7i", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // ================================================================
        // XÓA PHIẾU
        // ================================================================
        private void btnXoaPX_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_viewingMaPX)) { Warn("Ch\u1ecdn phi\u1ebfu c\u1ea7n x\u00f3a t\u1eeb danh s\u00e1ch b\u00ean tr\u00e1i."); return; }

            if (MessageBox.Show("X\u00f3a phi\u1ebfu xu\u1ea5t [" + _viewingMaPX + "] v\u00e0 to\u00e0n b\u1ed9 chi ti\u1ebft?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            using (var con = new SqlConnection(_conn))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open(); tran = con.BeginTransaction();
                    var c1 = new SqlCommand("DELETE FROM CT_PHIEUXUAT WHERE MA_PX=@M", con, tran);
                    c1.Parameters.Add("@M", SqlDbType.Char, 10).Value = _viewingMaPX;
                    c1.ExecuteNonQuery();
                    var c2 = new SqlCommand("DELETE FROM PHIEUXUAT WHERE MA_PX=@M", con, tran);
                    c2.Parameters.Add("@M", SqlDbType.Char, 10).Value = _viewingMaPX;
                    c2.ExecuteNonQuery();
                    tran.Commit();
                    MessageBox.Show("X\u00f3a th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _viewingMaPX = ""; ClearRight(); LoadHistory();
                }
                catch (SqlException ex) { tran?.Rollback(); ShowErr("x\u00f3a phi\u1ebfu", ex); }
            }
        }

        // ================================================================
        // TÌM KIẾM
        // ================================================================
        private void btnSearchPX_Click(object sender, EventArgs e) => LoadHistory(txtSearchPX.Text);
        private void txtSearchPX_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) btnSearchPX_Click(sender, e); }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _isEditingNew = false; _isEditingExist = false; _viewingMaPX = "";
            btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu xu\u1ea5t";
            ClearRight(); SetReadonlyRight(true);
            lblInfoTitle.Text = "Th\u00f4ng tin phi\u1ebfu xu\u1ea5t";
            lblInfoTitle.ForeColor = Color.FromArgb(13, 43, 90);
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private void SetReadonlyRight(bool ro)
        {
            txtMaPX.ReadOnly = true;
            dtpNgayXuat.Enabled = !ro;
            cboKhoXuat.Enabled = !ro; cboNhanVien.Enabled = !ro;
            txtDiaDiemGH.ReadOnly = ro; txtLyDo.ReadOnly = ro; txtGhiChu.ReadOnly = ro;
            dgvChiTietPX.ReadOnly = ro;
            btnAddRow.Enabled = !ro; btnDelRow.Enabled = !ro;
            btnSave.Enabled = !ro;
            btnSuaPX.Enabled = ro && !string.IsNullOrEmpty(_viewingMaPX);
            btnXoaPX.Enabled = ro && !string.IsNullOrEmpty(_viewingMaPX);
        }

        private void ClearRight()
        {
            txtMaPX.Text = ""; txtDiaDiemGH.Text = ""; txtLyDo.Text = ""; txtGhiChu.Text = ""; txtTongGia.Text = "0";
            cboKhoXuat.SelectedIndex = -1; cboNhanVien.SelectedIndex = -1;
            dgvChiTietPX.DataSource = null; dgvChiTietPX.Columns.Clear();
        }

        private void SetCombo(ComboBox cmb, string val)
        {
            if (cmb.DataSource is DataTable dt)
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (dt.Rows[i][cmb.ValueMember].ToString() == val) { cmb.SelectedIndex = i; return; }
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