using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormPhieuNhap : Form
    {
        private readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        // DataTable cho grid chi tiết (inline editable)
        private DataTable _dtChiTiet;
        // DataTable danh sách sản phẩm để tạo ComboBox column
        private DataTable _dtSanPham;
        // Phiếu đang chọn để xem (trái) vs phiếu đang lập (phải)
        private string _viewingSoPN = "";  // đang xem lịch sử
        private bool _isEditingNew = false; // đang lập mới
        private bool _isEditingExist = false; // đang sửa phiếu cũ

        public FormPhieuNhap()
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
            lblTitle.Text = "L\u1eacP PHI\u1ebcU NH\u1eacP H\u00c0NG";
            lblSubtitle.Text = "TH True Mart \u00b7 Kho h\u00e0ng";
            lblLeftTitle.Text = "L\u1ecbch s\u1eed phi\u1ebfu nh\u1eadp";
            btnSearchPN.Text = "T\u00ecm";
            btnLapMoiPN.Text = "+ L\u1eadp phi\u1ebfu m\u1edbi";
            btnSuaPN.Text = "\u270e S\u1eeda phi\u1ebfu";
            btnXoaPN.Text = "\u00d7 X\u00f3a phi\u1ebfu";
            btnXuatPN.Text = "\u21e9 Xu\u1ea5t PN"; // Nút xuất chứng từ
            lblInfoTitle.Text = "Th\u00f4ng tin phi\u1ebfu nh\u1eadp";
            lblSoPN.Text = "S\u1ed1 phi\u1ebfu *";
            lblNgayNhap.Text = "Ng\u00e0y nh\u1eadp";
            lblNCC.Text = "Nh\u00e0 cung c\u1ea5p *";
            lblNV.Text = "Nh\u00e2n vi\u00ean *";
            lblLyDo.Text = "L\u00fd do nh\u1eadp";
            lblGhiChu.Text = "Ghi ch\u00fa";
            lblGridTitle.Text = "Chi ti\u1ebft s\u1ea3n ph\u1ea9m nh\u1eadp";
            lblGridHint.Text = "Ch\u1ecdn SP t\u1eeb dropdown \u2192 nh\u1eadp s\u1ed1 l\u01b0\u1ee3ng & \u0111\u01a1n gi\u00e1 tr\u1ef1c ti\u1ebfp v\u00e0o \u00f4";
            btnAddRow.Text = "+ Th\u00eam d\u00f2ng";
            btnDelRow.Text = "\u2212 X\u00f3a d\u00f2ng";
            lblTongGiaLabel.Text = "T\u1ed5ng tr\u1ecb gi\u00e1 (\u0111):";
            btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu nh\u1eadp";
            btnCancel.Text = "\u00d7 H\u1ee7y b\u1ecf";
            lblLyDoNhap.Text = "";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 PHIEUNHAP \u00b7 CT_PHIEUNHAP \u00b7 SANPHAM";
        }

        private void SetHoverEffects()
        {
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnSave, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnSuaPN, Color.FromArgb(210, 145, 10), Color.FromArgb(180, 120, 0));
            H(btnLapMoiPN, Color.FromArgb(25, 65, 120), Color.FromArgb(13, 43, 90));
            H(btnXoaPN, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnAddRow, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnDelRow, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnSearchPN, Color.FromArgb(80, 160, 255), Color.FromArgb(56, 139, 253));
            H(btnXuatPN, Color.FromArgb(120, 80, 200), Color.FromArgb(100, 60, 180)); // Màu tím cho nút xuất
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadComboNCC();
            LoadComboNV();
            LoadSanPhamData();
            BuildChiTietGrid();
            LoadHistory();
            SetReadonlyRight(true); // Mặc định phải đang ở chế độ xem
        }

        // ================================================================
        // LOAD COMBOS
        // ================================================================
        private void LoadComboNCC()
        {
            var dt = Query("SELECT MA_NCC, TEN_NCC + ' [' + MA_NCC + ']' AS HIENTHI FROM NHACUNGCAP ORDER BY TEN_NCC");
            if (dt == null) return;
            cboNCC.DataSource = dt; cboNCC.DisplayMember = "HIENTHI"; cboNCC.ValueMember = "MA_NCC"; cboNCC.SelectedIndex = -1;
        }

        private void LoadComboNV()
        {
            var dt = Query("SELECT MANV, TENNV + ' [' + MANV + ']' AS HIENTHI FROM NHANVIEN WHERE TRANGTHAI_NV=N'\u0110ang l\u00e0m vi\u1ec7c' ORDER BY TENNV");
            if (dt == null) return;
            cboNhanVien.DataSource = dt; cboNhanVien.DisplayMember = "HIENTHI"; cboNhanVien.ValueMember = "MANV"; cboNhanVien.SelectedIndex = -1;
        }

        private void LoadSanPhamData()
        {
            _dtSanPham = Query("SELECT MASP, TENSP + ' [' + MASP + ']' AS HIENTHI FROM SANPHAM ORDER BY TENSP");
        }

        // ================================================================
        // BUILD CHI TIẾT GRID (inline editable với ComboBox column)
        // ================================================================
        private void BuildChiTietGrid()
        {
            _dtChiTiet = new DataTable();
            _dtChiTiet.Columns.Add("MASP", typeof(string));
            _dtChiTiet.Columns.Add("TENSP", typeof(string));
            _dtChiTiet.Columns.Add("SOLUONGNHAP", typeof(int));
            _dtChiTiet.Columns.Add("DONGIA_PN", typeof(decimal));
            _dtChiTiet.Columns.Add("THANHTIEN_PN", typeof(decimal));

            dgvChiTietPN.Columns.Clear();

            // Col 0: ComboBox chọn SP
            var colSP = new DataGridViewComboBoxColumn
            {
                Name = "colMaSP",
                HeaderText = "S\u1ea3n ph\u1ea9m *",
                DataPropertyName = "MASP",
                Width = 260,
                FlatStyle = FlatStyle.Flat,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            };
            if (_dtSanPham != null)
            {
                colSP.DataSource = _dtSanPham;
                colSP.DisplayMember = "HIENTHI";
                colSP.ValueMember = "MASP";
            }
            dgvChiTietPN.Columns.Add(colSP);

            // Col 1: Số lượng
            dgvChiTietPN.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSoLuong",
                HeaderText = "S\u1ed1 l\u01b0\u1ee3ng *",
                DataPropertyName = "SOLUONGNHAP",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "#,##0" }
            });

            // Col 2: Đơn giá
            dgvChiTietPN.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDonGia",
                HeaderText = "\u0110\u01a1n gi\u00e1 (\u0111) *",
                DataPropertyName = "DONGIA_PN",
                Width = 140,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#,##0" }
            });

            // Col 3: Thành tiền (readonly computed)
            dgvChiTietPN.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colThanhTien",
                HeaderText = "Th\u00e0nh ti\u1ec1n (\u0111)",
                DataPropertyName = "THANHTIEN_PN",
                Width = 150,
                ReadOnly = true,
                DefaultCellStyle = {
                    Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#,##0",
                    BackColor = Color.FromArgb(240, 248, 240), ForeColor = Color.FromArgb(13, 100, 60)
                }
            });

            dgvChiTietPN.DataSource = _dtChiTiet;
            dgvChiTietPN.DataError += (s, ev) => ev.Cancel = true; // bỏ qua lỗi ComboBox chưa chọn
        }

        // ================================================================
        // LOAD LỊCH SỬ PHIẾU NHẬP (trái)
        // ================================================================
        private void LoadHistory(string keyword = "")
        {
            string sql = @"
                SELECT PN.SO_PN, PN.NGAYNHAP, NCC.TEN_NCC, NV.TENNV,
                       PN.TRIGIA_PN,
                       (SELECT COUNT(*) FROM CT_PHIEUNHAP C WHERE C.SO_PN = PN.SO_PN) AS SoDong
                FROM PHIEUNHAP PN
                JOIN NHACUNGCAP NCC ON PN.MA_NCC = NCC.MA_NCC
                JOIN NHANVIEN   NV  ON PN.MANV   = NV.MANV
                WHERE @kw='' OR PN.SO_PN LIKE @kw OR NCC.TEN_NCC LIKE @kw OR NV.TENNV LIKE @kw
                ORDER BY PN.NGAYNHAP DESC";

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
                    Col("SO_PN", "S\u1ed1 phi\u1ebfu");
                    Col("NGAYNHAP", "Ng\u00e0y", "dd/MM/yy", DataGridViewContentAlignment.MiddleCenter);
                    Col("TEN_NCC", "NCC");
                    Col("TENNV", "Nh\u00e2n vi\u00ean");
                    Col("TRIGIA_PN", "Tr\u1ecb gi\u00e1", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("SoDong", "S\u1ed1 d\u00f2ng", null, DataGridViewContentAlignment.MiddleCenter);
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i l\u1ecbch s\u1eed", ex); }
            }
        }

        // ================================================================
        // CLICK LỊCH SỬ → XEM CHI TIẾT BÊN PHẢI (readonly)
        // ================================================================
        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvHistory.Rows[e.RowIndex];
            if (row.Cells["SO_PN"].Value == null) return;

            _viewingSoPN = row.Cells["SO_PN"].Value.ToString();
            _isEditingNew = false;
            LoadPhieuNhapDetail(_viewingSoPN);
            SetReadonlyRight(true);
            lblInfoTitle.Text = "Xem phi\u1ebfu: " + _viewingSoPN + "  (\u0111ang xem - kh\u00f4ng s\u1eeda \u0111\u01b0\u1ee3c)";
            lblInfoTitle.ForeColor = Color.FromArgb(80, 40, 140);
        }

        private void LoadPhieuNhapDetail(string soPN)
        {
            // Header
            string sqlH = "SELECT * FROM PHIEUNHAP WHERE SO_PN=@S";
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmdH = new SqlCommand(sqlH, con);
                    cmdH.Parameters.Add("@S", SqlDbType.Char, 10).Value = soPN;
                    using (var rdr = cmdH.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            txtSoPN.Text = soPN;
                            dtpNgayNhap.Value = Convert.ToDateTime(rdr["NGAYNHAP"]);
                            SetCombo(cboNCC, rdr["MA_NCC"]?.ToString() ?? "");
                            SetCombo(cboNhanVien, rdr["MANV"]?.ToString() ?? "");
                            txtLyDo.Text = rdr["LYDONHAP"]?.ToString() ?? "";
                            txtGhiChu.Text = rdr["GHICHU_PN"]?.ToString() ?? "";
                        }
                    }

                    // Detail
                    string sqlD = @"
                        SELECT CT.MASP, SP.TENSP, CT.SOLUONGNHAP, CT.DONGIA_PN, CT.THANHTIEN_PN
                        FROM CT_PHIEUNHAP CT JOIN SANPHAM SP ON CT.MASP = SP.MASP
                        WHERE CT.SO_PN=@S";
                    var cmdD = new SqlCommand(sqlD, con);
                    cmdD.Parameters.Add("@S", SqlDbType.Char, 10).Value = soPN;
                    var dt = new DataTable();
                    new SqlDataAdapter(cmdD).Fill(dt);

                    // Hiện dạng readonly đơn giản (không dùng _dtChiTiet editable)
                    dgvChiTietPN.DataSource = null;
                    dgvChiTietPN.Columns.Clear();
                    dgvChiTietPN.AutoGenerateColumns = true;
                    dgvChiTietPN.DataSource = dt;
                    void Col(string n, string h, string fmt = null,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvChiTietPN.Columns.Contains(n)) return;
                        dgvChiTietPN.Columns[n].HeaderText = h;
                        if (fmt != null) dgvChiTietPN.Columns[n].DefaultCellStyle.Format = fmt;
                        dgvChiTietPN.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("MASP", "M\u00e3 SP", null, DataGridViewContentAlignment.MiddleCenter);
                    Col("TENSP", "T\u00ean s\u1ea3n ph\u1ea9m");
                    Col("SOLUONGNHAP", "S\u1ed1 l\u01b0\u1ee3ng", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("DONGIA_PN", "\u0110\u01a1n gi\u00e1 (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("THANHTIEN_PN", "Th\u00e0nh ti\u1ec1n (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);

                    // Tổng
                    decimal tong = 0;
                    foreach (DataRow r in dt.Rows)
                        if (r["THANHTIEN_PN"] != DBNull.Value) tong += Convert.ToDecimal(r["THANHTIEN_PN"]);
                    txtTongGia.Text = tong.ToString("#,##0");
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i chi ti\u1ebft phi\u1ebfu", ex); }
            }
        }

        // ================================================================
        // LẬP PHIẾU MỚI
        // ================================================================
        private void btnLapMoiPN_Click(object sender, EventArgs e)
        {
            _isEditingNew = true;
            _viewingSoPN = "";
            txtSoPN.Text = GenerateSoPN();
            dtpNgayNhap.Value = DateTime.Today;
            cboNCC.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;
            txtLyDo.Text = ""; txtGhiChu.Text = "";

            // Reset grid về editable
            dgvChiTietPN.DataSource = null;
            dgvChiTietPN.Columns.Clear();
            BuildChiTietGrid();

            txtTongGia.Text = "0";
            SetReadonlyRight(false);
            lblInfoTitle.Text = "L\u1eadp phi\u1ebfu m\u1edbi: " + txtSoPN.Text;
            lblInfoTitle.ForeColor = Color.FromArgb(13, 100, 60);
            lblGridHint.Text = "Ch\u1ecdn SP t\u1eeb dropdown \u2192 nh\u1eadp s\u1ed1 l\u01b0\u1ee3ng & \u0111\u01a1n gi\u00e1 tr\u1ef1c ti\u1ebfp v\u00e0o \u00f4";
            cboNCC.Focus();
        }

        private string GenerateSoPN()
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(SO_PN,3,LEN(SO_PN)) AS INT)),0)+1 FROM PHIEUNHAP WHERE ISNUMERIC(SUBSTRING(SO_PN,3,LEN(SO_PN)))=1";
            using (var con = new SqlConnection(_conn))
            {
                try { con.Open(); return "PN" + Convert.ToInt32(new SqlCommand(sql, con).ExecuteScalar()).ToString("D3"); }
                catch { return "PN" + DateTime.Now.ToString("mmss"); }
            }
        }

        // ================================================================
        // THÊM / XÓA DÒNG TRONG GRID
        // ================================================================
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (!_isEditingNew && !_isEditingExist) { Warn("Ch\u1ecdn L\u1eadp phi\u1ebfu m\u1edbi ho\u1eb7c S\u1eeda phi\u1ebfu tr\u01b0\u1edbc."); return; }
            _dtChiTiet.Rows.Add("", "", 1, 0m, 0m);
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            if (!_isEditingNew && !_isEditingExist) return;
            if (dgvChiTietPN.CurrentRow == null) return;
            int idx = dgvChiTietPN.CurrentRow.Index;
            if (idx >= 0 && idx < _dtChiTiet.Rows.Count)
            {
                _dtChiTiet.Rows.RemoveAt(idx);
                RecalcTotal();
            }
        }

        // Khi user thay đổi SP trong ComboBox → tự điền giá từ BIENDONGGIA
        private void dgvChiTietPN_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((!_isEditingNew && !_isEditingExist) || e.RowIndex < 0) return;

            var col = dgvChiTietPN.Columns[e.ColumnIndex];
            if (col.Name == "colMaSP")
            {
                string maSP = dgvChiTietPN.Rows[e.RowIndex].Cells["colMaSP"].Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(maSP)) return;

                // Tên SP
                if (_dtSanPham != null)
                {
                    var rows = _dtSanPham.Select($"MASP='{maSP}'");
                    if (rows.Length > 0)
                        _dtChiTiet.Rows[e.RowIndex]["TENSP"] = rows[0]["HIENTHI"].ToString();
                }

                // Gợi ý giá từ BIENDONGGIA
                using (var con = new SqlConnection(_conn))
                {
                    try
                    {
                        con.Open();
                        var cmd = new SqlCommand(
                            "SELECT TOP 1 GIABAN FROM BIENDONGGIA WHERE MASP=@S ORDER BY NGAYCAPNHAT_BDG DESC", con);
                        cmd.Parameters.Add("@S", SqlDbType.Char, 10).Value = maSP;
                        var val = cmd.ExecuteScalar();
                        if (val != null && val != DBNull.Value)
                        {
                            decimal gia = Convert.ToDecimal(val);
                            _dtChiTiet.Rows[e.RowIndex]["DONGIA_PN"] = gia;
                            // Tính lại thành tiền với sl=1
                            int sl = 1;
                            if (_dtChiTiet.Rows[e.RowIndex]["SOLUONGNHAP"] != DBNull.Value)
                                sl = Convert.ToInt32(_dtChiTiet.Rows[e.RowIndex]["SOLUONGNHAP"]);
                            _dtChiTiet.Rows[e.RowIndex]["THANHTIEN_PN"] = sl * gia;
                        }
                    }
                    catch { }
                }
            }

            if (col.Name == "colSoLuong" || col.Name == "colDonGia")
            {
                var row = _dtChiTiet.Rows[e.RowIndex];
                int sl = row["SOLUONGNHAP"] == DBNull.Value ? 0 : Convert.ToInt32(row["SOLUONGNHAP"]);
                decimal dg = row["DONGIA_PN"] == DBNull.Value ? 0 : Convert.ToDecimal(row["DONGIA_PN"]);
                row["THANHTIEN_PN"] = sl * dg;
            }

            RecalcTotal();
        }

        private void RecalcTotal()
        {
            decimal tong = 0;
            foreach (DataRow row in _dtChiTiet.Rows)
                if (row["THANHTIEN_PN"] != DBNull.Value) tong += Convert.ToDecimal(row["THANHTIEN_PN"]);
            txtTongGia.Text = tong.ToString("#,##0");
        }

        // ================================================================
        // LƯU PHIẾU NHẬP
        // ================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_isEditingNew && !_isEditingExist) { Warn("Ch\u1ecdn L\u1eadp phi\u1ebfu m\u1edbi ho\u1eb7c S\u1eeda phi\u1ebfu tr\u01b0\u1edbc."); return; }

            // Commit edit đang dở
            dgvChiTietPN.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvChiTietPN.EndEdit();

            string soPN = txtSoPN.Text.Trim();
            string maNCC = cboNCC.SelectedValue?.ToString();
            string maNV = cboNhanVien.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(maNCC)) { Warn("Ch\u1ecdn nh\u00e0 cung c\u1ea5p."); cboNCC.Focus(); return; }
            if (string.IsNullOrEmpty(maNV)) { Warn("Ch\u1ecdn nh\u00e2n vi\u00ean."); cboNhanVien.Focus(); return; }
            if (_dtChiTiet.Rows.Count == 0) { Warn("Th\u00eam \u00edt nh\u1ea5t 1 s\u1ea3n ph\u1ea9m."); return; }

            // Validate dòng
            for (int i = 0; i < _dtChiTiet.Rows.Count; i++)
            {
                var row = _dtChiTiet.Rows[i];
                if (row["MASP"]?.ToString() == "" || row["MASP"] == DBNull.Value)
                { Warn($"D\u00f2ng {i + 1}: Ch\u01b0a ch\u1ecdn s\u1ea3n ph\u1ea9m."); return; }
                int sl = row["SOLUONGNHAP"] == DBNull.Value ? 0 : Convert.ToInt32(row["SOLUONGNHAP"]);
                if (sl <= 0) { Warn($"D\u00f2ng {i + 1}: S\u1ed1 l\u01b0\u1ee3ng ph\u1ea3i > 0."); return; }
                decimal dg = row["DONGIA_PN"] == DBNull.Value ? 0 : Convert.ToDecimal(row["DONGIA_PN"]);
                if (dg <= 0) { Warn($"D\u00f2ng {i + 1}: \u0110\u01a1n gi\u00e1 ph\u1ea3i > 0."); return; }
            }

            decimal triGia = decimal.Parse(txtTongGia.Text.Replace(",", "").Replace(".", ""));
            string lyDo = txtLyDo.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();

            using (var con = new SqlConnection(_conn))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();

                    // INSERT hoặc UPDATE PHIEUNHAP tùy chế độ
                    SqlCommand cmdPN;
                    if (_isEditingNew)
                    {
                        cmdPN = new SqlCommand(@"
                            INSERT INTO PHIEUNHAP (SO_PN, NGAYNHAP, LYDONHAP, TRIGIA_PN, GHICHU_PN, MA_NCC, MANV)
                            VALUES (@S, @N, @LD, @TG, @GC, @NCC, @NV)", con, tran);
                    }
                    else
                    {
                        // Xóa CT cũ trước khi insert lại
                        var delCT = new SqlCommand("DELETE FROM CT_PHIEUNHAP WHERE SO_PN=@S", con, tran);
                        delCT.Parameters.Add("@S", SqlDbType.Char, 10).Value = soPN;
                        delCT.ExecuteNonQuery();

                        cmdPN = new SqlCommand(@"
                            UPDATE PHIEUNHAP SET
                              NGAYNHAP=@N, LYDONHAP=@LD, TRIGIA_PN=@TG,
                              GHICHU_PN=@GC, MA_NCC=@NCC, MANV=@NV
                            WHERE SO_PN=@S", con, tran);
                    }
                    cmdPN.Parameters.Add("@S", SqlDbType.Char, 10).Value = soPN;
                    cmdPN.Parameters.Add("@N", SqlDbType.Date).Value = dtpNgayNhap.Value.Date;
                    cmdPN.Parameters.Add("@LD", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(lyDo) ? (object)DBNull.Value : lyDo;
                    cmdPN.Parameters.Add("@TG", SqlDbType.Decimal).Value = triGia;
                    cmdPN.Parameters.Add("@GC", SqlDbType.NVarChar, 100).Value = string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu;
                    cmdPN.Parameters.Add("@NCC", SqlDbType.Char, 10).Value = maNCC;
                    cmdPN.Parameters.Add("@NV", SqlDbType.Char, 10).Value = maNV;
                    ((SqlParameter)cmdPN.Parameters["@TG"]).Precision = 18;
                    ((SqlParameter)cmdPN.Parameters["@TG"]).Scale = 2;
                    cmdPN.ExecuteNonQuery();

                    // INSERT CT_PHIEUNHAP
                    foreach (DataRow row in _dtChiTiet.Rows)
                    {
                        var cmdCT = new SqlCommand(@"
                            INSERT INTO CT_PHIEUNHAP (SO_PN, MASP, SOLUONGNHAP, DONGIA_PN, THANHTIEN_PN)
                            VALUES (@S, @SP, @SL, @DG, @TT)", con, tran);
                        cmdCT.Parameters.Add("@S", SqlDbType.Char, 10).Value = soPN;
                        cmdCT.Parameters.Add("@SP", SqlDbType.Char, 10).Value = row["MASP"].ToString();
                        cmdCT.Parameters.Add("@SL", SqlDbType.Int).Value = Convert.ToInt32(row["SOLUONGNHAP"]);
                        cmdCT.Parameters.Add("@DG", SqlDbType.Decimal).Value = Convert.ToDecimal(row["DONGIA_PN"]);
                        cmdCT.Parameters.Add("@TT", SqlDbType.Decimal).Value = Convert.ToDecimal(row["THANHTIEN_PN"]);
                        foreach (string p in new[] { "@DG", "@TT" })
                        { ((SqlParameter)cmdCT.Parameters[p]).Precision = 18; ((SqlParameter)cmdCT.Parameters[p]).Scale = 2; }
                        cmdCT.ExecuteNonQuery();
                    }

                    tran.Commit();
                    MessageBox.Show((_isEditingNew ? "L\u01b0u" : "C\u1eadp nh\u1eadt") + " phi\u1ebfu nh\u1eadp [" + soPN + "] th\u00e0nh c\u00f4ng!",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _isEditingNew = false;
                    _isEditingExist = false;
                    btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu nh\u1eadp";
                    SetReadonlyRight(true);
                    LoadHistory();
                    lblInfoTitle.Text = "Ph\u00f4i \u0111\u00e3 l\u01b0u. Ch\u1ecdn phi\u1ebfu b\u00ean tr\u00e1i \u0111\u1ec3 xem l\u1ea1i.";
                    lblInfoTitle.ForeColor = Color.FromArgb(13, 43, 90);
                }
                catch (SqlException ex) { tran?.Rollback(); ShowErr("l\u01b0u phi\u1ebfu nh\u1eadp", ex); }
                catch (Exception ex2) { tran?.Rollback(); MessageBox.Show(ex2.Message, "L\u1ed7i", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }


        // ================================================================
        // SỬA PHIẾU NHẬP CŨ
        // ================================================================
        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_viewingSoPN)) { Warn("Ch\u1ecdn phi\u1ebfu c\u1ea7n s\u1eeda t\u1eeb l\u1ecbch s\u1eed b\u00ean tr\u00e1i."); return; }

            // Kiểm tra phiếu còn tồn tại
            _isEditingNew = false;
            _isEditingExist = true;

            // Load chi tiết vào grid editable
            dgvChiTietPN.DataSource = null;
            dgvChiTietPN.Columns.Clear();
            BuildChiTietGrid();

            string sql = @"
                SELECT CT.MASP, SP.TENSP, CT.SOLUONGNHAP, CT.DONGIA_PN, CT.THANHTIEN_PN
                FROM CT_PHIEUNHAP CT JOIN SANPHAM SP ON CT.MASP=SP.MASP
                WHERE CT.SO_PN=@S";
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@S", SqlDbType.Char, 10).Value = _viewingSoPN;
                    using (var rdr = cmd.ExecuteReader())
                        while (rdr.Read())
                            _dtChiTiet.Rows.Add(
                                rdr["MASP"].ToString(),
                                rdr["TENSP"].ToString(),
                                Convert.ToInt32(rdr["SOLUONGNHAP"]),
                                Convert.ToDecimal(rdr["DONGIA_PN"]),
                                Convert.ToDecimal(rdr["THANHTIEN_PN"]));
                    RecalcTotal();
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i chi ti\u1ebft \u0111\u1ec3 s\u1eeda", ex); return; }
            }

            SetReadonlyRight(false);
            txtSoPN.BackColor = System.Drawing.Color.FromArgb(235, 239, 246); // vẫn readonly
            lblInfoTitle.Text = "\u270e  Đang s\u1eeda phi\u1ebfu: " + _viewingSoPN;
            lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(160, 80, 0);
            btnSave.Text = "\u2714 C\u1eadp nh\u1eadt phi\u1ebfu";
        }

        // ================================================================
        // XÓA PHIẾU (từ lịch sử)
        // ================================================================
        private void btnXoaPN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_viewingSoPN)) { Warn("Ch\u1ecdn phi\u1ebfu c\u1ea7n x\u00f3a t\u1eeb l\u1ecbch s\u1eed b\u00ean tr\u00e1i."); return; }

            if (MessageBox.Show("X\u00f3a phi\u1ebfu nh\u1eadp [" + _viewingSoPN + "] v\u00e0 to\u00e0n b\u1ed9 chi ti\u1ebft?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            using (var con = new SqlConnection(_conn))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open(); tran = con.BeginTransaction();
                    var c1 = new SqlCommand("DELETE FROM CT_PHIEUNHAP WHERE SO_PN=@S", con, tran);
                    c1.Parameters.Add("@S", SqlDbType.Char, 10).Value = _viewingSoPN;
                    c1.ExecuteNonQuery();
                    var c2 = new SqlCommand("DELETE FROM PHIEUNHAP WHERE SO_PN=@S", con, tran);
                    c2.Parameters.Add("@S", SqlDbType.Char, 10).Value = _viewingSoPN;
                    c2.ExecuteNonQuery();
                    tran.Commit();
                    MessageBox.Show("X\u00f3a th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _viewingSoPN = ""; ClearRight(); LoadHistory();
                }
                catch (SqlException ex) { tran?.Rollback(); ShowErr("x\u00f3a phi\u1ebfu", ex); }
            }
        }

        // ================================================================
        // TÌM KIẾM LỊCH SỬ
        // ================================================================
        private void btnSearchPN_Click(object sender, EventArgs e) => LoadHistory(txtSearchPN.Text);
        private void txtSearchPN_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) btnSearchPN_Click(sender, e); }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _isEditingNew = false; _isEditingExist = false; _viewingSoPN = "";
            btnSave.Text = "\u2714 L\u01b0u phi\u1ebfu nh\u1eadp";
            ClearRight(); SetReadonlyRight(true);
            lblInfoTitle.Text = "Th\u00f4ng tin phi\u1ebfu nh\u1eadp";
            lblInfoTitle.ForeColor = Color.FromArgb(13, 43, 90);
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private void SetReadonlyRight(bool ro)
        {
            txtSoPN.ReadOnly = true; // luôn readonly
            dtpNgayNhap.Enabled = !ro;
            cboNCC.Enabled = !ro; cboNhanVien.Enabled = !ro;
            txtLyDo.ReadOnly = ro; txtGhiChu.ReadOnly = ro;
            dgvChiTietPN.ReadOnly = ro;
            btnAddRow.Enabled = !ro; btnDelRow.Enabled = !ro;
            btnSave.Enabled = !ro;
            btnXoaPN.Enabled = ro && !string.IsNullOrEmpty(_viewingSoPN);
            btnSuaPN.Enabled = ro && !string.IsNullOrEmpty(_viewingSoPN);
            btnXuatPN.Enabled = ro && !string.IsNullOrEmpty(_viewingSoPN); // Vô hiệu hóa nút xuất nếu chưa có phiếu
        }

        private void ClearRight()
        {
            txtSoPN.Text = ""; txtLyDo.Text = ""; txtGhiChu.Text = ""; txtTongGia.Text = "0";
            cboNCC.SelectedIndex = -1; cboNhanVien.SelectedIndex = -1;
            dgvChiTietPN.DataSource = null; dgvChiTietPN.Columns.Clear();
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

        private void btnXuatPN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_viewingSoPN))
            {
                MessageBox.Show("Vui l\u00f2ng ch\u1ecdn phi\u1ebfu tr\u01b0\u1edbc khi xu\u1ea5t ch\u1ee9ng t\u1eeb.", "Th\u00f4ng b\u00e1o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ChungTuExporter.ExportPhieuNhap(_viewingSoPN);
        }
    }
}