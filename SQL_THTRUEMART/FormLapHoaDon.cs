using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormLapHoaDon : Form
    {
        private readonly string connectionString =
           @"Data Source=XUAN-NGHI\SQLEXPRESS;
              Initial Catalog=SQL_THTRUEMART;
              Integrated Security=True;
              TrustServerCertificate=True;";

        private string _editMode = "NONE"; // "NEW" | "EDIT" | "NONE"
        private string _currentMaHD = "";

        public FormLapHoaDon()
        {
            InitializeComponent();
            SetLabels();
            SetHoverEffects();
        }

        // ================================================================
        // KHỞI TẠO LABEL TIẾNG VIỆT
        // ================================================================
        private void SetLabels()
        {
            lblTitle.Text = "L\u1eacP H\u00d3A \u0110\u01a0N B\u00c1N L\u1ebe";
            lblSubtitle.Text = "TH True Mart \u00b7 L\u1eadp / S\u1eeda / X\u00f3a h\u00f3a \u0111\u01a1n";
            lblStat1Lbl.Text = "T\u1ed4NG H\u00d3A \u0110\u01a0N";
            lblStat2Lbl.Text = "KH\u00c1CH H\u00c0NG";
            lblStat3Lbl.Text = "T\u1ed4NG DOANH THU (\u0111)";
            lblListTitle.Text = "Danh s\u00e1ch h\u00f3a \u0111\u01a1n";
            lblListSub.Text = "Nh\u1ea5p m\u1ed9t h\u00e0ng \u0111\u1ec3 xem chi ti\u1ebft";
            btnLapMoi.Text = "+ L\u1eadp m\u1edbi";
            btnSuaHD.Text = "\u270e S\u1eeda HD";
            btnXoaHD.Text = "\u00d7 X\u00f3a HD";
            btnReload.Text = "\u21ba T\u1ea3i l\u1ea1i";
            btnXuat.Text = "\u21e9 Xu\u1ea5t HD";
            lblDetailTitle.Text = "Chi ti\u1ebft m\u1eb7t h\u00e0ng";
            lblMaHDSel.Text = "HD \u0111ang ch\u1ecdn:";
            lblAddSP.Text = "S\u1ea3n ph\u1ea9m";
            lblAddSoLuong.Text = "S\u1ed1 l\u01b0\u1ee3ng";
            lblAddDonGia.Text = "\u0110\u01a1n gi\u00e1";
            lblAddPhanTram.Text = "Gi\u1ea3m (%)";
            btnThemSP.Text = "+ Th\u00eam SP";
            btnXoaSP.Text = "\u00d7 X\u00f3a SP";
            lblTruocThue.Text = "Tr\u01b0\u1edbc thu\u1ebf:";
            lblTongGiam.Text = "T\u1ed5ng gi\u1ea3m:";
            lblThanhTien.Text = "Th\u00e0nh ti\u1ec1n (VAT):";
            lblEditTitle.Text = "\u25bc  Th\u00f4ng tin h\u00f3a \u0111\u01a1n  (ch\u1ecdn L\u1eadp m\u1edbi ho\u1eb7c S\u1eeda)";
            lblEditMaHD.Text = "M\u00e3 HD";
            lblEditNgayLap.Text = "Ng\u00e0y l\u1eadp";
            lblEditKH.Text = "Kh\u00e1ch h\u00e0ng *";
            lblEditLoaiHD.Text = "Lo\u1ea1i HD *";
            lblEditHinhThuc.Text = "H\u00ecnh th\u1ee9c TT *";
            lblEditVAT.Text = "VAT (vd: 0.10)";
            lblEditGhiChu.Text = "Ghi ch\u00fa";
            btnLapHD.Text = "\u2714 L\u01b0u / L\u1eadp HD";
            btnHuy.Text = "\u00d7 H\u1ee7y b\u1ecf";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 HOADON \u00b7 CT_HD \u00b7 KHACHHANG \u00b7 SANPHAM";
        }

        private void SetHoverEffects()
        {
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnLapMoi, Color.FromArgb(25, 65, 120), Color.FromArgb(13, 43, 90));
            H(btnSuaHD, Color.FromArgb(210, 145, 10), Color.FromArgb(180, 120, 0));
            H(btnXoaHD, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnThemSP, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnXoaSP, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnLapHD, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnXuat, Color.FromArgb(120, 80, 200), Color.FromArgb(100, 60, 180));
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormLapHoaDon_Load(object sender, EventArgs e)
        {
            LoadComboKH();
            LoadComboLoaiHD();
            LoadComboHinhThucTT();
            LoadComboSP();
            LoadHoaDonList();
            ClearEditForm();
        }

        // ================================================================
        // LOAD COMBOBOXES
        // ================================================================
        private void LoadComboKH()
        {
            string sql = "SELECT MA_KH, TEN_KH + ' (' + MA_KH + ')' AS HIENTHI FROM KHACHHANG ORDER BY TEN_KH";
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);
                    cboKhachHang.DataSource = dt;
                    cboKhachHang.DisplayMember = "HIENTHI";
                    cboKhachHang.ValueMember = "MA_KH";
                    cboKhachHang.SelectedIndex = -1;
                }
                catch (SqlException ex) { ShowSqlError("load kh\u00e1ch h\u00e0ng", ex); }
            }
        }

        private void LoadComboLoaiHD()
        {
            string sql = "SELECT MA_LOAIHD, TEN_LOAIHD FROM LOAI_HD ORDER BY MA_LOAIHD";
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);
                    cboLoaiHD.DataSource = dt;
                    cboLoaiHD.DisplayMember = "TEN_LOAIHD";
                    cboLoaiHD.ValueMember = "MA_LOAIHD";
                    cboLoaiHD.SelectedIndex = -1;
                }
                catch (SqlException ex) { ShowSqlError("load lo\u1ea1i h\u00f3a \u0111\u01a1n", ex); }
            }
        }

        private void LoadComboHinhThucTT()
        {
            cboHinhThucTT.Items.Clear();
            cboHinhThucTT.Items.Add("Ti\u1ec1n M\u1eb7t");
            cboHinhThucTT.Items.Add("Th\u1ebb T\u00edn D\u1ee5ng");
            cboHinhThucTT.Items.Add("Chuy\u1ec3n Kho\u1ea3n");
            cboHinhThucTT.SelectedIndex = -1;
        }

        private void LoadComboSP()
        {
            string sql = "SELECT MASP, TENSP + ' [' + MASP + ']' AS HIENTHI FROM SANPHAM ORDER BY TENSP";
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);
                    cmbAddMaSP.DataSource = dt;
                    cmbAddMaSP.DisplayMember = "HIENTHI";
                    cmbAddMaSP.ValueMember = "MASP";
                    cmbAddMaSP.SelectedIndex = -1;
                }
                catch (SqlException ex) { ShowSqlError("load s\u1ea3n ph\u1ea9m", ex); }
            }
        }

        // ================================================================
        // A. DANH SÁCH HÓA ĐƠN
        // ================================================================
        private void LoadHoaDonList()
        {
            string sql = @"
                SELECT HD.MA_HD, HD.NGAYLAPHD, KH.TEN_KH,
                       HD.HINHTHUCTT, HD.THUEVAT,
                       HD.TRIGIATRUOCTHUE, HD.TONGTIENGIAM,
                       HD.TONGCONGTHANHTIEN,
                       ISNULL(HD.GHICHU_HD,'') AS GHICHU_HD,
                       HD.MA_KH, HD.MA_LOAIHD
                FROM HOADON HD
                JOIN KHACHHANG KH ON HD.MA_KH = KH.MA_KH
                ORDER BY HD.NGAYLAPHD DESC";

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);

                    dgvHoaDon.AutoGenerateColumns = true;
                    dgvHoaDon.DataSource = dt;

                    void Col(string name, string header, string fmt = null,
                             DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft,
                             bool visible = true)
                    {
                        if (!dgvHoaDon.Columns.Contains(name)) return;
                        var c = dgvHoaDon.Columns[name];
                        c.HeaderText = header; c.Visible = visible;
                        if (fmt != null) c.DefaultCellStyle.Format = fmt;
                        c.DefaultCellStyle.Alignment = align;
                    }

                    Col("MA_HD", "M\u00e3 HD");
                    Col("NGAYLAPHD", "Ng\u00e0y l\u1eadp", "dd/MM/yyyy", DataGridViewContentAlignment.MiddleCenter);
                    Col("TEN_KH", "Kh\u00e1ch h\u00e0ng");
                    Col("HINHTHUCTT", "H\u00ecnh th\u1ee9c TT");
                    Col("THUEVAT", "VAT", "P0", DataGridViewContentAlignment.MiddleCenter);
                    Col("TRIGIATRUOCTHUE", "Tr\u01b0\u1edbc thu\u1ebf (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("TONGTIENGIAM", "Gi\u1ea3m (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("TONGCONGTHANHTIEN", "Th\u00e0nh ti\u1ec1n (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("GHICHU_HD", "Ghi ch\u00fa");
                    Col("MA_KH", "", visible: false);
                    Col("MA_LOAIHD", "", visible: false);

                    UpdateStatCards(dt);
                }
                catch (SqlException ex) { ShowSqlError("t\u1ea3i danh s\u00e1ch h\u00f3a \u0111\u01a1n", ex); }
            }
        }

        // ================================================================
        // B. CLICK HÀNG → LOAD CHI TIẾT
        // ================================================================
        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvHoaDon.Rows[e.RowIndex];
            if (row.Cells["MA_HD"].Value == null) return;

            _currentMaHD = row.Cells["MA_HD"].Value.ToString();
            txtMaHDSel.Text = _currentMaHD;
            LoadChiTietHD(_currentMaHD);
        }

        private void LoadChiTietHD(string maHD)
        {
            // FIX: đảm bảo alias SQL hoàn toàn là ký tự Latin A (không Cyrillic)
            string sql = @"
                SELECT CT.MASP, SP.TENSP, CT.SOLUONG_TRA AS SOLUONG,
                       CT.DONGIA_HD,
                       CT.PHANTRAMGIAMHD AS PHANTRAMGIAM,
                       CT.GIASAUGIAM, CT.THANHTIENHD
                FROM CT_HD CT
                JOIN SANPHAM SP ON CT.MASP = SP.MASP
                WHERE CT.MA_HD = @MaHD";

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@MaHD", SqlDbType.Char, 10).Value = maHD;
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvChiTietHD.AutoGenerateColumns = true;
                    dgvChiTietHD.DataSource = dt;

                    void Col(string name, string header, string fmt = null,
                             DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvChiTietHD.Columns.Contains(name)) return;
                        var c = dgvChiTietHD.Columns[name];
                        c.HeaderText = header;
                        if (fmt != null) c.DefaultCellStyle.Format = fmt;
                        c.DefaultCellStyle.Alignment = align;
                    }

                    Col("MASP", "M\u00e3 SP");
                    Col("TENSP", "T\u00ean s\u1ea3n ph\u1ea9m");
                    Col("SOLUONG", "S\u1ed1 l\u01b0\u1ee3ng", align: DataGridViewContentAlignment.MiddleCenter);
                    Col("DONGIA_HD", "\u0110\u01a1n gi\u00e1 (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("PHANTRAMGIAM", "Gi\u1ea3m (%)", "P0", DataGridViewContentAlignment.MiddleCenter);
                    Col("GIASAUGIAM", "Gi\u00e1 sau gi\u1ea3m (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("THANHTIENHD", "Th\u00e0nh ti\u1ec1n (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);

                    // FIX: tính tổng từ DataTable vừa load, dùng đúng tên cột
                    CalculateSummary(dt);
                }
                catch (SqlException ex) { ShowSqlError("t\u1ea3i chi ti\u1ebft h\u00f3a \u0111\u01a1n", ex); }
            }
        }

        // ================================================================
        // C. LẬP HÓA ĐƠN MỚI
        // ================================================================
        private void btnLapMoi_Click(object sender, EventArgs e)
        {
            ClearEditForm();
            _editMode = "NEW";

            txtMaHD.Text = GenerateMaHD();
            dtpNgayLapHD.Value = DateTime.Today;
            cboHinhThucTT.SelectedIndex = 0;
            txtVAT.Text = "0.10";

            lblEditTitle.Text = "\u25bc  L\u1eadp h\u00f3a \u0111\u01a1n m\u1edbi: " + txtMaHD.Text;
            lblEditTitle.ForeColor = Color.FromArgb(13, 100, 60);

            dgvChiTietHD.DataSource = null;
            txtMaHDSel.Text = txtMaHD.Text + " (ch\u01b0a l\u01b0u)";
            txtTruocThue.Text = "0"; txtTongGiam.Text = "0"; txtThanhTien.Text = "0";
            _currentMaHD = "";
            cboKhachHang.Focus();
        }

        private string GenerateMaHD()
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(MA_HD,3,LEN(MA_HD)) AS INT)),0)+1 FROM HOADON WHERE ISNUMERIC(SUBSTRING(MA_HD,3,LEN(MA_HD)))=1";
            using (var con = new SqlConnection(connectionString))
            {
                try { con.Open(); return "HD" + Convert.ToInt32(new SqlCommand(sql, con).ExecuteScalar()).ToString("D3"); }
                catch { return "HD" + DateTime.Now.ToString("mmss"); }
            }
        }

        // ================================================================
        // D. SỬA HÓA ĐƠN
        // ================================================================
        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMaHD)) { Warn("Ch\u1ecdn h\u00f3a \u0111\u01a1n c\u1ea7n s\u1eeda."); return; }

            _editMode = "EDIT";
            var row = dgvHoaDon.CurrentRow;
            txtMaHD.Text = _currentMaHD;

            if (row.Cells["NGAYLAPHD"].Value != DBNull.Value)
                dtpNgayLapHD.Value = Convert.ToDateTime(row.Cells["NGAYLAPHD"].Value);

            if (row.Cells["MA_KH"].Value != null)
            {
                string maKH = row.Cells["MA_KH"].Value.ToString();
                var dt = (DataTable)cboKhachHang.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (dt.Rows[i]["MA_KH"].ToString() == maKH) { cboKhachHang.SelectedIndex = i; break; }
            }

            if (row.Cells["MA_LOAIHD"].Value != null)
            {
                string maLoai = row.Cells["MA_LOAIHD"].Value.ToString();
                var dt = (DataTable)cboLoaiHD.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                    if (dt.Rows[i]["MA_LOAIHD"].ToString() == maLoai) { cboLoaiHD.SelectedIndex = i; break; }
            }

            string ht = row.Cells["HINHTHUCTT"].Value?.ToString() ?? "";
            for (int i = 0; i < cboHinhThucTT.Items.Count; i++)
                if (cboHinhThucTT.Items[i].ToString() == ht) { cboHinhThucTT.SelectedIndex = i; break; }

            if (row.Cells["THUEVAT"].Value != DBNull.Value)
                txtVAT.Text = Convert.ToDecimal(row.Cells["THUEVAT"].Value).ToString();

            txtGhiChu.Text = row.Cells["GHICHU_HD"].Value?.ToString() ?? "";

            lblEditTitle.Text = "\u25bc  \u0110ang s\u1eeda: " + _currentMaHD;
            lblEditTitle.ForeColor = Color.FromArgb(160, 80, 0);
        }

        // ================================================================
        // E. XÓA HÓA ĐƠN
        // ================================================================
        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMaHD)) { Warn("Ch\u1ecdn h\u00f3a \u0111\u01a1n c\u1ea7n x\u00f3a."); return; }

            if (MessageBox.Show("X\u00f3a h\u00f3a \u0111\u01a1n [" + _currentMaHD + "] v\u00e0 to\u00e0n b\u1ed9 chi ti\u1ebft?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            using (var con = new SqlConnection(connectionString))
            {
                SqlTransaction tran = null;
                try
                {
                    con.Open();
                    tran = con.BeginTransaction();

                    var c1 = new SqlCommand("DELETE FROM CT_HD WHERE MA_HD=@D", con, tran);
                    c1.Parameters.Add("@D", SqlDbType.Char, 10).Value = _currentMaHD;
                    c1.ExecuteNonQuery();

                    var c2 = new SqlCommand("DELETE FROM HOADON WHERE MA_HD=@D", con, tran);
                    c2.Parameters.Add("@D", SqlDbType.Char, 10).Value = _currentMaHD;
                    c2.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("X\u00f3a th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _currentMaHD = ""; txtMaHDSel.Text = ""; dgvChiTietHD.DataSource = null;
                    txtTruocThue.Text = "0"; txtTongGiam.Text = "0"; txtThanhTien.Text = "0";
                    ClearEditForm(); LoadHoaDonList();
                }
                catch (SqlException ex)
                { tran?.Rollback(); ShowSqlError("x\u00f3a h\u00f3a \u0111\u01a1n", ex); }
            }
        }

        // ================================================================
        // F. LƯU / LẬP HÓA ĐƠN (INSERT hoặc UPDATE header)
        // ================================================================
        private void btnLapHD_Click(object sender, EventArgs e)
        {
            if (_editMode == "NONE")
            {
                MessageBox.Show("Ch\u1ecdn L\u1eadp m\u1edbi ho\u1eb7c S\u1eeda h\u00f3a \u0111\u01a1n tr\u01b0\u1edbc.",
                    "Th\u00f4ng b\u00e1o", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
            }

            if (cboKhachHang.SelectedValue == null) { Warn("Ch\u1ecdn kh\u00e1ch h\u00e0ng."); return; }
            if (cboLoaiHD.SelectedValue == null) { Warn("Ch\u1ecdn lo\u1ea1i h\u00f3a \u0111\u01a1n."); return; }
            if (cboHinhThucTT.SelectedIndex < 0) { Warn("Ch\u1ecdn h\u00ecnh th\u1ee9c thanh to\u00e1n."); return; }
            if (!decimal.TryParse(txtVAT.Text, out decimal vatRate) || vatRate < 0)
            { Warn("VAT kh\u00f4ng h\u1ee3p l\u1ec7 (vd: 0.10)."); return; }

            string maHD = txtMaHD.Text.Trim();
            string maKH = cboKhachHang.SelectedValue.ToString();
            string maLoaiHD = cboLoaiHD.SelectedValue.ToString();
            string hinhThuc = cboHinhThucTT.SelectedItem.ToString();
            string ghiChu = txtGhiChu.Text.Trim();
            DateTime ngayLap = dtpNgayLapHD.Value.Date;

            decimal truocThue = 0, tongGiam = 0;
            decimal.TryParse(txtTruocThue.Text.Replace(",", ""), out truocThue);
            decimal.TryParse(txtTongGiam.Text.Replace(",", ""), out tongGiam);
            decimal sauGiam = truocThue - tongGiam;
            decimal sauThue = sauGiam * (1 + vatRate);
            decimal tongCong = sauThue;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;

                    if (_editMode == "NEW")
                    {
                        string maPX = "PX" + DateTime.Now.ToString("yyMMddHHmm");
                        var cmdPX = new SqlCommand(
                            "INSERT INTO PHIEUXUAT (MA_PX,NGAYXUAT,TRIGIA_PX,DIADIEMGH,MA_KHO,MANV) " +
                            "VALUES (@PX,GETDATE(),0,N'Xu\u1ea5t b\u00e1n l\u1ebb'," +
                            "(SELECT TOP 1 MA_KHO FROM KHO)," +
                            "(SELECT TOP 1 MANV FROM NHANVIEN))", con);
                        cmdPX.Parameters.Add("@PX", SqlDbType.Char, 10).Value = maPX;
                        cmdPX.ExecuteNonQuery();

                        cmd = new SqlCommand(@"
                            INSERT INTO HOADON
                              (MA_HD,NGAYLAPHD,HINHTHUCTT,THUEVAT,
                               TRIGIATRUOCTHUE,TRIGIASAUTHUE,TONGTIENGIAM,
                               TONGCONGTHANHTIEN,GHICHU_HD,MA_KH,MA_LOAIHD,MA_PX)
                            VALUES
                              (@MaHD,@NgayLap,@HT,@VAT,
                               @TruocThue,@SauThue,@TongGiam,
                               @TongCong,@GhiChu,@MaKH,@MaLoai,@MaPX)", con);
                        cmd.Parameters.Add("@MaPX", SqlDbType.Char, 10).Value = maPX;
                    }
                    else
                    {
                        cmd = new SqlCommand(@"
                            UPDATE HOADON SET
                              NGAYLAPHD=@NgayLap, HINHTHUCTT=@HT, THUEVAT=@VAT,
                              TRIGIATRUOCTHUE=@TruocThue, TRIGIASAUTHUE=@SauThue,
                              TONGTIENGIAM=@TongGiam, TONGCONGTHANHTIEN=@TongCong,
                              GHICHU_HD=@GhiChu, MA_KH=@MaKH, MA_LOAIHD=@MaLoai
                            WHERE MA_HD=@MaHD", con);
                    }

                    cmd.Parameters.Add("@MaHD", SqlDbType.Char, 10).Value = maHD;
                    cmd.Parameters.Add("@NgayLap", SqlDbType.Date).Value = ngayLap;
                    cmd.Parameters.Add("@HT", SqlDbType.NVarChar, 100).Value = hinhThuc;
                    cmd.Parameters.Add("@VAT", SqlDbType.Decimal).Value = vatRate;
                    cmd.Parameters.Add("@TruocThue", SqlDbType.Decimal).Value = truocThue;
                    cmd.Parameters.Add("@SauThue", SqlDbType.Decimal).Value = sauThue;
                    cmd.Parameters.Add("@TongGiam", SqlDbType.Decimal).Value = tongGiam;
                    cmd.Parameters.Add("@TongCong", SqlDbType.Decimal).Value = tongCong;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255).Value =
                        string.IsNullOrEmpty(ghiChu) ? (object)DBNull.Value : ghiChu;
                    cmd.Parameters.Add("@MaKH", SqlDbType.Char, 10).Value = maKH;
                    cmd.Parameters.Add("@MaLoai", SqlDbType.Char, 10).Value = maLoaiHD;
                    ((SqlParameter)cmd.Parameters["@VAT"]).Precision = 18;
                    ((SqlParameter)cmd.Parameters["@VAT"]).Scale = 2;
                    ((SqlParameter)cmd.Parameters["@TruocThue"]).Precision = 18;
                    ((SqlParameter)cmd.Parameters["@TruocThue"]).Scale = 2;
                    ((SqlParameter)cmd.Parameters["@SauThue"]).Precision = 18;
                    ((SqlParameter)cmd.Parameters["@SauThue"]).Scale = 2;
                    ((SqlParameter)cmd.Parameters["@TongGiam"]).Precision = 18;
                    ((SqlParameter)cmd.Parameters["@TongGiam"]).Scale = 2;
                    ((SqlParameter)cmd.Parameters["@TongCong"]).Precision = 18;
                    ((SqlParameter)cmd.Parameters["@TongCong"]).Scale = 2;

                    cmd.ExecuteNonQuery();

                    string msg = _editMode == "NEW"
                        ? "L\u1eadp h\u00f3a \u0111\u01a1n [" + maHD + "] th\u00e0nh c\u00f4ng!"
                        : "C\u1eadp nh\u1eadt [" + maHD + "] th\u00e0nh c\u00f4ng!";
                    MessageBox.Show(msg, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _currentMaHD = maHD;
                    txtMaHDSel.Text = maHD;
                    LoadHoaDonList();
                    LoadChiTietHD(_currentMaHD);
                    ClearEditForm();
                }
                catch (SqlException ex) { ShowSqlError("l\u01b0u h\u00f3a \u0111\u01a1n", ex); }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => ClearEditForm();

        // ================================================================
        // G. THÊM SP VÀO CT_HD
        // ================================================================
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMaHD)) { Warn("Ch\u1ecdn ho\u1eb7c l\u01b0u h\u00f3a \u0111\u01a1n tr\u01b0\u1edbc."); return; }
            if (cmbAddMaSP.SelectedValue == null) { Warn("Ch\u1ecdn s\u1ea3n ph\u1ea9m."); return; }
            if (!int.TryParse(txtAddSoLuong.Text, out int sl) || sl <= 0) { Warn("S\u1ed1 l\u01b0\u1ee3ng ph\u1ea3i > 0."); return; }
            if (!decimal.TryParse(txtAddDonGia.Text, out decimal dg) || dg < 0) { Warn("\u0110\u01a1n gi\u00e1 kh\u00f4ng h\u1ee3p l\u1ec7."); return; }
            if (!decimal.TryParse(txtAddPhanTram.Text, out decimal ptg) || ptg < 0 || ptg > 100) { Warn("Gi\u1ea3m gi\u00e1 t\u1eeb 0 \u0111\u1ebfn 100."); return; }

            string maSP = cmbAddMaSP.SelectedValue.ToString();
            decimal ptgDec = ptg / 100m;
            decimal giaSauGiam = dg * (1 - ptgDec);
            decimal thanhTien = sl * giaSauGiam;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var chk = new SqlCommand("SELECT COUNT(*) FROM CT_HD WHERE MA_HD=@D AND MASP=@S", con);
                    chk.Parameters.Add("@D", SqlDbType.Char, 10).Value = _currentMaHD;
                    chk.Parameters.Add("@S", SqlDbType.Char, 10).Value = maSP;
                    bool exists = Convert.ToInt32(chk.ExecuteScalar()) > 0;

                    string sql = exists
                        ? "UPDATE CT_HD SET SOLUONG_TRA=@SL,DONGIA_HD=@DG,PHANTRAMGIAMHD=@PT,GIASAUGIAM=@GS,THANHTIENHD=@TT WHERE MA_HD=@D AND MASP=@S"
                        : "INSERT INTO CT_HD(MA_HD,MASP,SOLUONG_TRA,DONGIA_HD,PHANTRAMGIAMHD,GIASAUGIAM,THANHTIENHD) VALUES(@D,@S,@SL,@DG,@PT,@GS,@TT)";

                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@D", SqlDbType.Char, 10).Value = _currentMaHD;
                    cmd.Parameters.Add("@S", SqlDbType.Char, 10).Value = maSP;
                    cmd.Parameters.Add("@SL", SqlDbType.Int).Value = sl;
                    cmd.Parameters.Add("@DG", SqlDbType.Decimal).Value = dg;
                    cmd.Parameters.Add("@PT", SqlDbType.Decimal).Value = ptgDec;
                    cmd.Parameters.Add("@GS", SqlDbType.Decimal).Value = giaSauGiam;
                    cmd.Parameters.Add("@TT", SqlDbType.Decimal).Value = thanhTien;
                    foreach (string p in new[] { "@DG", "@PT", "@GS", "@TT" })
                    { ((SqlParameter)cmd.Parameters[p]).Precision = 18; ((SqlParameter)cmd.Parameters[p]).Scale = 2; }
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(exists ? "C\u1eadp nh\u1eadt SP th\u00e0nh c\u00f4ng!" : "Th\u00eam SP th\u00e0nh c\u00f4ng!",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadChiTietHD(_currentMaHD);
                    RecalcAndUpdateHD();
                    txtAddSoLuong.Text = "1"; txtAddDonGia.Text = "0"; txtAddPhanTram.Text = "0";
                    cmbAddMaSP.SelectedIndex = -1;
                }
                catch (SqlException ex) { ShowSqlError("th\u00eam s\u1ea3n ph\u1ea9m", ex); }
            }
        }

        // ================================================================
        // H. XÓA SP KHỎI CT_HD
        // ================================================================
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHD.CurrentRow == null) { Warn("Ch\u1ecdn s\u1ea3n ph\u1ea9m c\u1ea7n x\u00f3a."); return; }
            string maSP = dgvChiTietHD.CurrentRow.Cells["MASP"].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(maSP)) return;

            if (MessageBox.Show("X\u00f3a [" + maSP + "] kh\u1ecfi h\u00f3a \u0111\u01a1n [" + _currentMaHD + "]?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("DELETE FROM CT_HD WHERE MA_HD=@D AND MASP=@S", con);
                    cmd.Parameters.Add("@D", SqlDbType.Char, 10).Value = _currentMaHD;
                    cmd.Parameters.Add("@S", SqlDbType.Char, 10).Value = maSP;
                    cmd.ExecuteNonQuery();
                    LoadChiTietHD(_currentMaHD);
                    RecalcAndUpdateHD();
                }
                catch (SqlException ex) { ShowSqlError("x\u00f3a s\u1ea3n ph\u1ea9m", ex); }
            }
        }

        // ================================================================
        // I. TẢI LẠI
        // ================================================================
        private void btnReload_Click(object sender, EventArgs e)
        {
            _currentMaHD = ""; txtMaHDSel.Text = "";
            dgvChiTietHD.DataSource = null;
            txtTruocThue.Text = "0"; txtTongGiam.Text = "0"; txtThanhTien.Text = "0";
            ClearEditForm(); LoadHoaDonList();
        }

        // ================================================================
        // J. XUẤT CHỨNG TỪ
        // ================================================================
        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMaHD))
            {
                Warn("Ch\u1ecdn h\u00f3a \u0111\u01a1n c\u1ea7n xu\u1ea5t.");
                return;
            }
            ChungTuExporter.ExportHoaDon(_currentMaHD);
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private void ClearEditForm()
        {
            _editMode = "NONE";
            txtMaHD.Text = ""; cboKhachHang.SelectedIndex = -1;
            cboLoaiHD.SelectedIndex = -1; cboHinhThucTT.SelectedIndex = -1;
            txtVAT.Text = "0.10"; txtGhiChu.Text = "";
            dtpNgayLapHD.Value = DateTime.Today;
            lblEditTitle.Text = "\u25bc  Th\u00f4ng tin h\u00f3a \u0111\u01a1n  (ch\u1ecdn L\u1eadp m\u1edbi ho\u1eb7c S\u1eeda)";
            lblEditTitle.ForeColor = Color.FromArgb(13, 43, 90);
        }

        /// <summary>
        /// FIX: Tính tổng Trước thuế và Tổng giảm từ DataTable chi tiết.
        /// Dùng đúng tên cột "PHANTRAMGIAM" (alias Latin thuần túy trong SQL).
        /// </summary>
        private void CalculateSummary(DataTable dt)
        {
            decimal truocThue = 0, tongGiam = 0;

            // Lấy VAT rate từ ô nhập, mặc định 10%
            if (!decimal.TryParse(txtVAT.Text, out decimal vatRate))
                vatRate = 0.1m;

            bool hasDonGia = dt.Columns.Contains("DONGIA_HD");
            bool hasSoLuong = dt.Columns.Contains("SOLUONG");
            bool hasPhanTram = dt.Columns.Contains("PHANTRAMGIAM");

            foreach (DataRow row in dt.Rows)
            {
                decimal donGia = (hasDonGia && row["DONGIA_HD"] != DBNull.Value) ? Convert.ToDecimal(row["DONGIA_HD"]) : 0m;
                int soLuong = (hasSoLuong && row["SOLUONG"] != DBNull.Value) ? Convert.ToInt32(row["SOLUONG"]) : 0;
                decimal phanTram = (hasPhanTram && row["PHANTRAMGIAM"] != DBNull.Value) ? Convert.ToDecimal(row["PHANTRAMGIAM"]) : 0m;

                decimal gocHang = donGia * soLuong;          // Trước giảm của dòng
                decimal giamHang = gocHang * phanTram;        // Tiền giảm của dòng

                truocThue += gocHang;
                tongGiam += giamHang;
            }

            decimal sauGiam = truocThue - tongGiam;
            decimal thanhTien = sauGiam * (1 + vatRate);

            txtTruocThue.Text = truocThue.ToString("#,##0");
            txtTongGiam.Text = tongGiam.ToString("#,##0");
            txtThanhTien.Text = thanhTien.ToString("#,##0");
        }

        /// <summary>Tính lại tổng từ CT_HD trong DB và UPDATE HOADON.</summary>
        private void RecalcAndUpdateHD()
        {
            if (string.IsNullOrEmpty(_currentMaHD)) return;
            if (!decimal.TryParse(txtVAT.Text, out decimal vatRate))
                vatRate = 0.1m;

            string sql = @"
                SELECT
                    SUM(SOLUONG_TRA * DONGIA_HD)                  AS TRUOC_THUE,
                    SUM(SOLUONG_TRA * DONGIA_HD * PHANTRAMGIAMHD) AS TONG_GIAM
                FROM CT_HD WHERE MA_HD=@D";

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@D", SqlDbType.Char, 10).Value = _currentMaHD;
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            decimal tt = rdr["TRUOC_THUE"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["TRUOC_THUE"]);
                            decimal tg = rdr["TONG_GIAM"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["TONG_GIAM"]);
                            decimal sauGiam = tt - tg;
                            decimal sauThue = sauGiam * (1 + vatRate);

                            rdr.Close();
                            var upd = new SqlCommand(@"
                                UPDATE HOADON SET
                                  TRIGIATRUOCTHUE=@TT, TONGTIENGIAM=@TG,
                                  TRIGIASAUTHUE=@ST,   TONGCONGTHANHTIEN=@TC
                                WHERE MA_HD=@D", con);
                            upd.Parameters.Add("@TT", SqlDbType.Decimal).Value = tt;
                            upd.Parameters.Add("@TG", SqlDbType.Decimal).Value = tg;
                            upd.Parameters.Add("@ST", SqlDbType.Decimal).Value = sauThue;
                            upd.Parameters.Add("@TC", SqlDbType.Decimal).Value = sauThue;
                            upd.Parameters.Add("@D", SqlDbType.Char, 10).Value = _currentMaHD;
                            foreach (string p in new[] { "@TT", "@TG", "@ST", "@TC" })
                            { ((SqlParameter)upd.Parameters[p]).Precision = 18; ((SqlParameter)upd.Parameters[p]).Scale = 2; }
                            upd.ExecuteNonQuery();
                        }
                    }

                    LoadHoaDonList();
                }
                catch { /* silent – summary bar hiển thị từ CalculateSummary */ }
            }
        }

        private void UpdateStatCards(DataTable dt)
        {
            int soHD = dt.Rows.Count;
            double tongDT = 0;
            var khSet = new HashSet<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (dt.Columns.Contains("TEN_KH") && row["TEN_KH"] != DBNull.Value)
                    khSet.Add(row["TEN_KH"].ToString());
                if (dt.Columns.Contains("TONGCONGTHANHTIEN") && row["TONGCONGTHANHTIEN"] != DBNull.Value)
                    tongDT += Convert.ToDouble(row["TONGCONGTHANHTIEN"]);
            }
            lblStat1Val.Text = soHD.ToString();
            lblStat2Val.Text = khSet.Count.ToString();
            lblStat3Val.Text = tongDT.ToString("#,##0");
            lblListSub.Text = "HOADON \u27f6 KHACHHANG \u00b7 " + soHD + " h\u00f3a \u0111\u01a1n";
        }

        private void ShowSqlError(string ctx, SqlException ex)
            => MessageBox.Show("L\u1ed7i " + ctx + ":\n" + ex.Message, "L\u1ed7i SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void Warn(string msg)
            => MessageBox.Show(msg, "Thi\u1ebfu th\u00f4ng tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}