using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormDonHang : Form
    {
        private readonly string connectionString =
           @"Data Source=XUAN-NGHI\SQLEXPRESS;
              Initial Catalog=SQL_THTRUEMART;
              Integrated Security=True;
              TrustServerCertificate=True;";

        private string _editMode = "NONE";
        private string _currentMaDH = "";

        // Trang thai don hang (Unicode escape)
        private readonly string[] TRANG_THAI_DH = new[]
        {
            "Ch\u1edd x\u00e1c nh\u1eadn",
            "\u0110\u00e3 x\u00e1c nh\u1eadn",
            "\u0110ang chu\u1ea9n b\u1ecb",
            "\u0110ang giao",
            "\u0110\u00e3 giao",
            "Ho\u00e0n th\u00e0nh",
            "\u0110\u00e3 h\u1ee7y"
        };

        // --- Cột tuỳ chọn: có thể không tồn tại trong DB cũ ---
        private bool _hasDiaChi = false;
        private bool _hasTrangThai = false;
        private bool _hasGhiChu = false;
        private bool _hasTrangThaiSP = false;

        public FormDonHang()
        {
            InitializeComponent();
            SetLabels();
            SetComboBoxItems();
            SetHoverEffects();
        }

        // ================================================================
        // KHỞI TẠO
        // ================================================================
        private void SetLabels()
        {
            lblTitle.Text = "QU\u1ea2N L\u00dd \u0110\u01a0N H\u00c0NG";
            lblSubtitle.Text = "TH True Mart \u00b7 Th\u00eam / S\u1eeda / X\u00f3a \u0111\u01a1n h\u00e0ng";
            lblStat1Lbl.Text = "T\u1ed4NG \u0110\u01a0N H\u00c0NG";
            lblStat2Lbl.Text = "KH\u00c1CH H\u00c0NG";
            lblStat3Lbl.Text = "T\u1ed4NG TH\u00c0NH TI\u1ec0N (\u0111)";
            lblListTitle.Text = "Danh s\u00e1ch \u0111\u01a1n h\u00e0ng";
            lblListSub.Text = "Nh\u1ea5p m\u1ed9t h\u00e0ng \u0111\u1ec3 xem / s\u1eeda chi ti\u1ebft";
            btnReload.Text = "\u21ba T\u1ea3i l\u1ea1i";
            btnThemDH.Text = "+ Th\u00eam \u0110H";
            btnSuaDH.Text = "\u270e S\u1eeda \u0110H";
            btnXoaDH.Text = "\u00d7 X\u00f3a \u0110H";
            lblEditTitle.Text = "\u25bc  Th\u00f4ng tin \u0111\u01a1n h\u00e0ng";
            lblEditMaDH.Text = "M\u00e3 \u0111\u01a1n h\u00e0ng";
            lblEditMaKH.Text = "Kh\u00e1ch h\u00e0ng *";
            lblEditDiaChi.Text = "\u0110\u1ecba ch\u1ec9 giao h\u00e0ng";
            lblEditHinhThuc.Text = "H\u00ecnh th\u1ee9c TT *";
            lblEditTrangThai.Text = "Tr\u1ea1ng th\u00e1i";
            lblEditGhiChu.Text = "Ghi ch\u00fa";
            btnLuuDH.Text = "\u2714  L\u01b0u";
            btnHuyDH.Text = "\u00d7  H\u1ee7y";
            lblDetailTitle.Text = "Chi ti\u1ebft s\u1ea3n ph\u1ea9m trong \u0111\u01a1n";
            lblMaDHSel.Text = "\u0110H \u0111ang ch\u1ecdn:";
            lblAddSP.Text = "S\u1ea3n ph\u1ea9m";
            lblAddSoLuong.Text = "S\u1ed1 l\u01b0\u1ee3ng";
            lblAddDonGia.Text = "\u0110\u01a1n gi\u00e1";
            lblAddGiamGia.Text = "Gi\u1ea3m gi\u00e1 (%)";
            btnThemSP.Text = "+ Th\u00eam SP";
            btnXoaSP.Text = "\u00d7 X\u00f3a SP";
            lblTongTien.Text = "T\u1ed5ng th\u00e0nh ti\u1ec1n (\u0111)";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 DONHANG \u00b7 CT_DH";
        }

        private void SetComboBoxItems()
        {
            cmbEditHinhThuc.Items.Clear();
            cmbEditHinhThuc.Items.Add("Tr\u01b0\u1edbc");
            cmbEditHinhThuc.Items.Add("COD");

            cmbEditTrangThai.Items.Clear();
            foreach (var tt in TRANG_THAI_DH)
                cmbEditTrangThai.Items.Add(tt);
        }

        private void SetHoverEffects()
        {
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnThemDH, Color.FromArgb(25, 65, 120), Color.FromArgb(13, 43, 90));
            H(btnSuaDH, Color.FromArgb(210, 145, 10), Color.FromArgb(180, 120, 0));
            H(btnXoaDH, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnLuuDH, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnThemSP, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnXoaSP, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
        }

        // ================================================================
        // FORM LOAD – phát hiện cột thực tế trong DB
        // ================================================================
        private void FormDonHang_Load(object sender, EventArgs e)
        {
            DetectColumns();   // << quan trọng: kiểm tra cột trước
            LoadComboBoxKH();
            LoadComboBoxSP();
            LoadDonHangHeader();
            ClearEditForm();
            UpdateEditFormVisibility();
        }

        /// <summary>
        /// Kiểm tra các cột tuỳ chọn có tồn tại trong DB không.
        /// Nếu DB cũ thiếu cột thì vẫn chạy được, chỉ ẩn controls đó.
        /// </summary>
        private void DetectColumns()
        {
            string sql = @"
                SELECT COLUMN_NAME
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME IN ('DONHANG','SANPHAM')";

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);
                    var cols = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    foreach (DataRow r in dt.Rows)
                        cols.Add(r["COLUMN_NAME"].ToString());

                    _hasDiaChi = cols.Contains("DIACHI_GH");
                    _hasTrangThai = cols.Contains("TRANGTHAI_DH");
                    _hasGhiChu = cols.Contains("GHICHU_DH");
                    _hasTrangThaiSP = cols.Contains("TRANGTHAI_SP");
                }
                catch
                {
                    // Nếu không detect được → dùng chế độ an toàn (chỉ cột cơ bản)
                    _hasDiaChi = _hasTrangThai = _hasGhiChu = _hasTrangThaiSP = false;
                }
            }
        }

        /// <summary>Ẩn/hiện controls tuỳ theo cột có trong DB không.</summary>
        private void UpdateEditFormVisibility()
        {
            lblEditDiaChi.Visible = _hasDiaChi;
            txtEditDiaChi.Visible = _hasDiaChi;
            lblEditTrangThai.Visible = _hasTrangThai;
            cmbEditTrangThai.Visible = _hasTrangThai;
            lblEditGhiChu.Visible = _hasGhiChu;
            txtEditGhiChu.Visible = _hasGhiChu;
        }

        // ================================================================
        // LOAD COMBOBOXES
        // ================================================================
        private void LoadComboBoxKH()
        {
            string sql = "SELECT MA_KH, TEN_KH + ' (' + MA_KH + ')' AS HIENTHIKH FROM KHACHHANG ORDER BY TEN_KH";
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);
                    cmbEditMaKH.DataSource = dt;
                    cmbEditMaKH.DisplayMember = "HIENTHIKH";
                    cmbEditMaKH.ValueMember = "MA_KH";
                    cmbEditMaKH.SelectedIndex = -1;
                }
                catch (SqlException ex)
                { ShowSqlError("load kh\u00e1ch h\u00e0ng", ex); }
            }
        }

        private void LoadComboBoxSP()
        {
            // Nếu DB không có cột TRANGTHAI_SP → lấy tất cả SP
            string sql = _hasTrangThaiSP
                ? "SELECT MASP, TENSP + ' [' + MASP + ']' AS HIENTHI FROM SANPHAM WHERE TRANGTHAI_SP = @TS ORDER BY TENSP"
                : "SELECT MASP, TENSP + ' [' + MASP + ']' AS HIENTHI FROM SANPHAM ORDER BY TENSP";

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    if (_hasTrangThaiSP)
                        cmd.Parameters.Add("@TS", SqlDbType.NVarChar, 20).Value = "\u0110ang b\u00e1n";

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    cmbAddMaSP.DataSource = dt;
                    cmbAddMaSP.DisplayMember = "HIENTHI";
                    cmbAddMaSP.ValueMember = "MASP";
                    cmbAddMaSP.SelectedIndex = -1;
                }
                catch (SqlException ex)
                { ShowSqlError("load s\u1ea3n ph\u1ea9m", ex); }
            }
        }

        // ================================================================
        // A. DANH SÁCH ĐH – chỉ SELECT cột chắc chắn có
        // ================================================================
        private void LoadDonHangHeader()
        {
            // Xây dựng SELECT dựa theo cột thực tế phát hiện được
            var selectParts = new System.Text.StringBuilder();
            selectParts.Append("DH.MA_DH, DH.NGAYLAP_DH, KH.TEN_KH, DH.HINHTHUCTT_DH, DH.MA_KH");
            selectParts.Append(", ISNULL((SELECT SUM(SOLUONG_DH * DONGIA_DH * (1.0 - GIAMGIA_DH/100.0)) FROM CT_DH WHERE MA_DH=DH.MA_DH),0) AS THANHTIEN_DH");
            if (_hasDiaChi) selectParts.Append(", DH.DIACHI_GH");
            if (_hasTrangThai) selectParts.Append(", DH.TRANGTHAI_DH");
            if (_hasGhiChu) selectParts.Append(", DH.GHICHU_DH");

            string sql = $@"
                SELECT {selectParts}
                FROM DONHANG DH
                JOIN KHACHHANG KH ON DH.MA_KH = KH.MA_KH
                ORDER BY DH.NGAYLAP_DH DESC";

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);

                    dgvDonHangHeader.AutoGenerateColumns = true;
                    dgvDonHangHeader.DataSource = dt;

                    // Đặt tên cột
                    void Col(string name, string header,
                             string fmt = null,
                             DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft,
                             bool visible = true)
                    {
                        if (!dgvDonHangHeader.Columns.Contains(name)) return;
                        var c = dgvDonHangHeader.Columns[name];
                        c.HeaderText = header; c.Visible = visible;
                        if (fmt != null) c.DefaultCellStyle.Format = fmt;
                        c.DefaultCellStyle.Alignment = align;
                    }

                    Col("MA_DH", "M\u00e3 \u0110H");
                    Col("NGAYLAP_DH", "Ng\u00e0y l\u1eadp", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
                    Col("TEN_KH", "Kh\u00e1ch h\u00e0ng");
                    Col("HINHTHUCTT_DH", "H\u00ecnh th\u1ee9c TT", align: DataGridViewContentAlignment.MiddleCenter);
                    Col("THANHTIEN_DH", "Th\u00e0nh ti\u1ec1n (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("DIACHI_GH", "\u0110\u1ecba ch\u1ec9 giao");
                    Col("TRANGTHAI_DH", "Tr\u1ea1ng th\u00e1i");
                    Col("GHICHU_DH", "Ghi ch\u00fa");
                    Col("MA_KH", "", visible: false);

                    if (_hasTrangThai) ApplyStatusRowColor();
                    UpdateStatCards(dt);
                }
                catch (SqlException ex)
                { ShowSqlError("t\u1ea3i danh s\u00e1ch \u0111\u01a1n h\u00e0ng", ex); }
            }
        }

        private void ApplyStatusRowColor()
        {
            if (!dgvDonHangHeader.Columns.Contains("TRANGTHAI_DH")) return;
            foreach (DataGridViewRow row in dgvDonHangHeader.Rows)
            {
                string tt = row.Cells["TRANGTHAI_DH"].Value?.ToString() ?? "";
                if (tt == TRANG_THAI_DH[5]) row.DefaultCellStyle.BackColor = Color.FromArgb(232, 252, 240);
                else if (tt == TRANG_THAI_DH[6]) row.DefaultCellStyle.BackColor = Color.FromArgb(255, 242, 242);
                else if (tt == TRANG_THAI_DH[3]) row.DefaultCellStyle.BackColor = Color.FromArgb(255, 251, 228);
            }
        }

        // ================================================================
        // B. CLICK HÀNG → CHI TIẾT
        // ================================================================
        private void dgvDonHangHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvDonHangHeader.Rows[e.RowIndex];
            if (row.Cells["MA_DH"].Value == null) return;

            _currentMaDH = row.Cells["MA_DH"].Value.ToString();
            txtMaDH.Text = _currentMaDH;
            txtTongTien.Text = Convert.ToDecimal(row.Cells["THANHTIEN_DH"].Value).ToString("#,##0");
            LoadDonHangDetail(_currentMaDH);
        }

        private void LoadDonHangDetail(string maDH)
        {
            string sql = @"
                SELECT CT.MASP, SP.TENSP, CT.SOLUONG_DH, CT.DONGIA_DH, CT.GIAMGIA_DH,
                       CAST(CT.SOLUONG_DH * CT.DONGIA_DH * (1.0 - CT.GIAMGIA_DH/100.0) AS DECIMAL(15,2)) AS THANHTIEN
                FROM CT_DH CT
                JOIN SANPHAM SP ON CT.MASP = SP.MASP
                WHERE CT.MA_DH = @MaDH";

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@MaDH", SqlDbType.VarChar, 10).Value = maDH;
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvChiTietDH.AutoGenerateColumns = true;
                    dgvChiTietDH.DataSource = dt;

                    void Col(string name, string header, string fmt = null,
                             DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvChiTietDH.Columns.Contains(name)) return;
                        var c = dgvChiTietDH.Columns[name];
                        c.HeaderText = header;
                        if (fmt != null) c.DefaultCellStyle.Format = fmt;
                        c.DefaultCellStyle.Alignment = align;
                    }

                    Col("MASP", "M\u00e3 SP");
                    Col("TENSP", "T\u00ean s\u1ea3n ph\u1ea9m");
                    Col("SOLUONG_DH", "S\u1ed1 l\u01b0\u1ee3ng", align: DataGridViewContentAlignment.MiddleCenter);
                    Col("DONGIA_DH", "\u0110\u01a1n gi\u00e1 (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("GIAMGIA_DH", "Gi\u1ea3m (%)", align: DataGridViewContentAlignment.MiddleCenter);
                    Col("THANHTIEN", "Th\u00e0nh ti\u1ec1n (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                }
                catch (SqlException ex)
                { ShowSqlError("t\u1ea3i chi ti\u1ebft", ex); }
            }
        }

        // ================================================================
        // C. THÊM ĐH
        //    Điền form → Lưu mới INSERT (tránh lỗi NOT NULL DB)
        //    Sau khi Lưu thành công → _currentMaDH được set → thêm SP ngay
        // ================================================================
        private void btnThemDH_Click(object sender, EventArgs e)
        {
            ClearEditForm();          // reset form (đặt _editMode = NONE)
            _editMode = "ADD";        // ghi đè ngay sau ClearEditForm

            string newMaDH = GenerateMaDH();
            txtEditMaDH.Text = newMaDH;

            cmbEditHinhThuc.SelectedIndex = 1;  // COD
            cmbEditTrangThai.SelectedIndex = 0;  // Chờ xác nhận

            lblEditTitle.Text = "\u25bc  Th\u00eam \u0111\u01a1n h\u00e0ng m\u1edbi: " + newMaDH
                                     + "  \u2192 \u0111i\u1ec1n th\u00f4ng tin r\u1ed3i nh\u1ea5n L\u01b0u";
            lblEditTitle.ForeColor = Color.FromArgb(13, 100, 60);

            // Xóa chi tiết để tránh nhầm với đơn cũ
            dgvChiTietDH.DataSource = null;
            txtMaDH.Text = newMaDH + " (chua luu)";
            txtTongTien.Text = "-";
            _currentMaDH = "";

            cmbEditMaKH.Focus();
        }

        private string GenerateMaDH()
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(MA_DH,3,LEN(MA_DH)) AS INT)),0)+1 FROM DONHANG WHERE ISNUMERIC(SUBSTRING(MA_DH,3,LEN(MA_DH)))=1";
            using (var con = new SqlConnection(connectionString))
            {
                try { con.Open(); return "DH" + Convert.ToInt32(new SqlCommand(sql, con).ExecuteScalar()).ToString("D3"); }
                catch { return "DH" + DateTime.Now.ToString("mmss"); }
            }
        }

        // ================================================================
        // D. SỬA ĐH
        // ================================================================
        private void btnSuaDH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMaDH)) { Warn("Ch\u1ecdn \u0111\u01a1n h\u00e0ng c\u1ea7n s\u1eeda."); return; }

            _editMode = "EDIT";
            var row = dgvDonHangHeader.CurrentRow;
            txtEditMaDH.Text = _currentMaDH;

            // Chọn KH
            if (row.Cells["MA_KH"].Value != null)
            {
                string maKH = row.Cells["MA_KH"].Value.ToString();
                var dt = (DataTable)cmbEditMaKH.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (dt.Rows[i]["MA_KH"].ToString() == maKH) { cmbEditMaKH.SelectedIndex = i; break; }
            }

            // Hình thức TT
            string ht = row.Cells["HINHTHUCTT_DH"].Value?.ToString() ?? "";
            cmbEditHinhThuc.SelectedIndex = ht == "COD" ? 1 : 0;

            // Cột tuỳ chọn
            if (_hasDiaChi && dgvDonHangHeader.Columns.Contains("DIACHI_GH"))
                txtEditDiaChi.Text = row.Cells["DIACHI_GH"].Value?.ToString() ?? "";
            if (_hasGhiChu && dgvDonHangHeader.Columns.Contains("GHICHU_DH"))
                txtEditGhiChu.Text = row.Cells["GHICHU_DH"].Value?.ToString() ?? "";
            if (_hasTrangThai && dgvDonHangHeader.Columns.Contains("TRANGTHAI_DH"))
            {
                string tt = row.Cells["TRANGTHAI_DH"].Value?.ToString() ?? "";
                int idx = Array.IndexOf(TRANG_THAI_DH, tt);
                cmbEditTrangThai.SelectedIndex = idx >= 0 ? idx : 0;
            }

            lblEditTitle.Text = "\u25bc  \u0110ang s\u1eeda: " + _currentMaDH;
            lblEditTitle.ForeColor = Color.FromArgb(160, 80, 0);
        }

        // ================================================================
        // E. XÓA ĐH
        // ================================================================
        private void btnXoaDH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMaDH)) { Warn("Ch\u1ecdn \u0111\u01a1n h\u00e0ng c\u1ea7n x\u00f3a."); return; }

            if (MessageBox.Show("X\u00f3a \u0111\u01a1n h\u00e0ng [" + _currentMaDH + "] v\u00e0 to\u00e0n b\u1ed9 chi ti\u1ebft?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            using (var con = new SqlConnection(connectionString))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();

                    var c1 = new SqlCommand("DELETE FROM CT_DH WHERE MA_DH=@D", con, tran);
                    c1.Parameters.Add("@D", SqlDbType.VarChar, 10).Value = _currentMaDH;
                    c1.ExecuteNonQuery();

                    var c2 = new SqlCommand("DELETE FROM DONHANG WHERE MA_DH=@D", con, tran);
                    c2.Parameters.Add("@D", SqlDbType.VarChar, 10).Value = _currentMaDH;
                    c2.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("X\u00f3a th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _currentMaDH = ""; txtMaDH.Text = ""; txtTongTien.Text = "-";
                    dgvChiTietDH.DataSource = null;
                    ClearEditForm(); LoadDonHangHeader();
                }
                catch (SqlException ex)
                { tran?.Rollback(); ShowSqlError("x\u00f3a \u0111\u01a1n h\u00e0ng", ex); }
            }
        }

        // ================================================================
        // F. LƯU (INSERT / UPDATE) – chỉ SET cột tồn tại
        // ================================================================
        private void btnLuuDH_Click(object sender, EventArgs e)
        {
            if (_editMode == "NONE") { MessageBox.Show("Ch\u1ecdn Th\u00eam m\u1edbi ho\u1eb7c S\u1eeda tr\u01b0\u1edbc.", "Th\u00f4ng b\u00e1o", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (cmbEditMaKH.SelectedValue == null) { Warn("Ch\u1ecdn kh\u00e1ch h\u00e0ng."); return; }
            if (cmbEditHinhThuc.SelectedIndex < 0) { Warn("Ch\u1ecdn h\u00ecnh th\u1ee9c thanh to\u00e1n."); return; }

            string maDH = txtEditMaDH.Text.Trim();
            string maKH = cmbEditMaKH.SelectedValue.ToString();
            string hinhThuc = cmbEditHinhThuc.SelectedItem.ToString();
            string diaChi = _hasDiaChi ? txtEditDiaChi.Text.Trim() : "";
            string trangThai = _hasTrangThai && cmbEditTrangThai.SelectedIndex >= 0
                              ? cmbEditTrangThai.SelectedItem.ToString() : TRANG_THAI_DH[0];
            string ghiChu = _hasGhiChu ? txtEditGhiChu.Text.Trim() : "";

            // Bắt buộc địa chỉ nếu cột tồn tại
            if (_hasDiaChi && string.IsNullOrWhiteSpace(diaChi)) { Warn("Nh\u1eadp \u0111\u1ecba ch\u1ec9 giao h\u00e0ng."); return; }

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;

                    if (_editMode == "ADD")
                    {
                        // Xây dựng INSERT động
                        // THANHTIEN_DH = 0 tạm, MANV lấy NV đầu tiên đang làm việc
                        var cols = new System.Text.StringBuilder("MA_DH,NGAYLAP_DH,MA_KH,HINHTHUCTT_DH,THANHTIEN_DH,MANV");
                        var vals = new System.Text.StringBuilder(
                            "@MaDH,GETDATE(),@MaKH,@HT,0," +
                            "(SELECT TOP 1 MANV FROM NHANVIEN)");
                        if (_hasDiaChi) { cols.Append(",DIACHI_GH"); vals.Append(",@DC"); }
                        if (_hasTrangThai) { cols.Append(",TRANGTHAI_DH"); vals.Append(",@TT"); }
                        if (_hasGhiChu) { cols.Append(",GHICHU_DH"); vals.Append(",@GC"); }

                        cmd = new SqlCommand($"INSERT INTO DONHANG ({cols}) VALUES ({vals})", con);
                    }
                    else
                    {
                        // Xây dựng UPDATE động
                        var sets = new System.Text.StringBuilder("MA_KH=@MaKH,HINHTHUCTT_DH=@HT");
                        if (_hasDiaChi) sets.Append(",DIACHI_GH=@DC");
                        if (_hasTrangThai) sets.Append(",TRANGTHAI_DH=@TT");
                        if (_hasGhiChu) sets.Append(",GHICHU_DH=@GC");

                        cmd = new SqlCommand($"UPDATE DONHANG SET {sets} WHERE MA_DH=@MaDH", con);
                    }

                    cmd.Parameters.Add("@MaDH", SqlDbType.VarChar, 10).Value = maDH;
                    cmd.Parameters.Add("@MaKH", SqlDbType.VarChar, 10).Value = maKH;
                    cmd.Parameters.Add("@HT", SqlDbType.NVarChar, 20).Value = hinhThuc;
                    if (_hasDiaChi) cmd.Parameters.Add("@DC", SqlDbType.NVarChar, 300).Value = string.IsNullOrEmpty(diaChi) ? (object)DBNull.Value : diaChi;
                    if (_hasTrangThai) cmd.Parameters.Add("@TT", SqlDbType.NVarChar, 30).Value = trangThai;
                    if (_hasGhiChu) cmd.Parameters.Add("@GC", SqlDbType.NVarChar, 300).Value = string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show((_editMode == "ADD" ? "Th\u00eam" : "C\u1eadp nh\u1eadt") + " [" + maDH + "] th\u00e0nh c\u00f4ng!",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _currentMaDH = maDH;
                    LoadDonHangHeader(); LoadDonHangDetail(_currentMaDH);
                    txtMaDH.Text = _currentMaDH; ClearEditForm();
                }
                catch (SqlException ex)
                { ShowSqlError("l\u01b0u \u0111\u01a1n h\u00e0ng", ex); }
            }
        }

        private void btnHuyDH_Click(object sender, EventArgs e) => ClearEditForm();

        // ================================================================
        // G. THÊM SP VÀO CT_DH
        // ================================================================
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMaDH)) { Warn("Ch\u1ecdn \u0111\u01a1n h\u00e0ng tr\u01b0\u1edbc."); return; }
            if (cmbAddMaSP.SelectedValue == null) { Warn("Ch\u1ecdn s\u1ea3n ph\u1ea9m."); return; }
            if (!int.TryParse(txtAddSoLuong.Text, out int sl) || sl <= 0) { Warn("S\u1ed1 l\u01b0\u1ee3ng ph\u1ea3i > 0."); return; }
            if (!decimal.TryParse(txtAddDonGia.Text, out decimal dg) || dg < 0) { Warn("\u0110\u01a1n gi\u00e1 kh\u00f4ng h\u1ee3p l\u1ec7."); return; }
            if (!decimal.TryParse(txtAddGiamGia.Text, out decimal gg) || gg < 0 || gg > 100) { Warn("Gi\u1ea3m gi\u00e1 0-100."); return; }

            string maSP = cmbAddMaSP.SelectedValue.ToString();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var chk = new SqlCommand("SELECT COUNT(*) FROM CT_DH WHERE MA_DH=@D AND MASP=@S", con);
                    chk.Parameters.Add("@D", SqlDbType.VarChar, 10).Value = _currentMaDH;
                    chk.Parameters.Add("@S", SqlDbType.VarChar, 10).Value = maSP;
                    bool exists = Convert.ToInt32(chk.ExecuteScalar()) > 0;

                    string sql = exists
                        ? "UPDATE CT_DH SET SOLUONG_DH=@SL,DONGIA_DH=@DG,GIAMGIA_DH=@GG WHERE MA_DH=@D AND MASP=@S"
                        : "INSERT INTO CT_DH(MA_DH,MASP,SOLUONG_DH,DONGIA_DH,GIAMGIA_DH) VALUES(@D,@S,@SL,@DG,@GG)";

                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@D", SqlDbType.VarChar, 10).Value = _currentMaDH;
                    cmd.Parameters.Add("@S", SqlDbType.VarChar, 10).Value = maSP;
                    cmd.Parameters.Add("@SL", SqlDbType.Int).Value = sl;
                    cmd.Parameters.Add("@DG", SqlDbType.Decimal).Value = dg; ((SqlParameter)cmd.Parameters["@DG"]).Precision = 15; ((SqlParameter)cmd.Parameters["@DG"]).Scale = 2;
                    cmd.Parameters.Add("@GG", SqlDbType.Decimal).Value = gg; ((SqlParameter)cmd.Parameters["@GG"]).Precision = 5; ((SqlParameter)cmd.Parameters["@GG"]).Scale = 2;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(exists ? "C\u1eadp nh\u1eadt SP th\u00e0nh c\u00f4ng!" : "Th\u00eam SP th\u00e0nh c\u00f4ng!",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDonHangDetail(_currentMaDH); LoadDonHangHeader();
                    txtAddSoLuong.Text = "1"; txtAddDonGia.Text = "0"; txtAddGiamGia.Text = "0";
                    cmbAddMaSP.SelectedIndex = -1;
                }
                catch (SqlException ex)
                { ShowSqlError("th\u00eam s\u1ea3n ph\u1ea9m", ex); }
            }
        }

        // ================================================================
        // H. XÓA SP
        // ================================================================
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTietDH.CurrentRow == null) { Warn("Ch\u1ecdn s\u1ea3n ph\u1ea9m c\u1ea7n x\u00f3a."); return; }
            string maSP = dgvChiTietDH.CurrentRow.Cells["MASP"].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(maSP)) return;

            if (MessageBox.Show("X\u00f3a [" + maSP + "] kh\u1ecfi \u0111\u01a1n [" + _currentMaDH + "]?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("DELETE FROM CT_DH WHERE MA_DH=@D AND MASP=@S", con);
                    cmd.Parameters.Add("@D", SqlDbType.VarChar, 10).Value = _currentMaDH;
                    cmd.Parameters.Add("@S", SqlDbType.VarChar, 10).Value = maSP;
                    cmd.ExecuteNonQuery();
                    LoadDonHangDetail(_currentMaDH); LoadDonHangHeader();
                }
                catch (SqlException ex)
                { ShowSqlError("x\u00f3a s\u1ea3n ph\u1ea9m", ex); }
            }
        }

        // ================================================================
        // I. TẢI LẠI
        // ================================================================
        private void btnReload_Click(object sender, EventArgs e)
        {
            _currentMaDH = ""; dgvChiTietDH.DataSource = null;
            txtMaDH.Text = ""; txtTongTien.Text = "-";
            ClearEditForm(); LoadDonHangHeader();
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private void ClearEditForm()
        {
            _editMode = "NONE";
            txtEditMaDH.Text = ""; cmbEditMaKH.SelectedIndex = -1;
            txtEditDiaChi.Text = ""; cmbEditHinhThuc.SelectedIndex = -1;
            cmbEditTrangThai.SelectedIndex = -1; txtEditGhiChu.Text = "";
            lblEditTitle.Text = "\u25bc  Th\u00f4ng tin \u0111\u01a1n h\u00e0ng  (ch\u1ecdn Th\u00eam m\u1edbi ho\u1eb7c S\u1eeda)";
            lblEditTitle.ForeColor = Color.FromArgb(13, 43, 90);
        }

        private void UpdateStatCards(DataTable dt)
        {
            double tongTien = 0;
            var khSet = new HashSet<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (dt.Columns.Contains("TEN_KH") && row["TEN_KH"] != DBNull.Value)
                    khSet.Add(row["TEN_KH"].ToString());
                if (dt.Columns.Contains("THANHTIEN_DH") && row["THANHTIEN_DH"] != DBNull.Value)
                    tongTien += Convert.ToDouble(row["THANHTIEN_DH"]);
            }
            lblStat1Val.Text = dt.Rows.Count.ToString();
            lblStat2Val.Text = khSet.Count.ToString();
            lblStat3Val.Text = tongTien.ToString("#,##0");
            lblListSub.Text = "DONHANG \u27f6 KHACHHANG \u00b7 " + dt.Rows.Count + " \u0111\u01a1n";
        }

        private void ShowSqlError(string ctx, SqlException ex)
            => MessageBox.Show("L\u1ed7i " + ctx + ":\n" + ex.Message, "L\u1ed7i SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void Warn(string msg)
            => MessageBox.Show(msg, "Thi\u1ebfu th\u00f4ng tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}