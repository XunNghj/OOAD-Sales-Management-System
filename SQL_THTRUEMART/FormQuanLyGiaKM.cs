using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormQuanLyGiaKM : Form
    {
        private readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        private decimal _giaHienTai = 0;   // giá hiện tại của SP đang chọn
        private decimal _giaKMSP = 0;   // giá hiện tại của SP đang chọn (tab KM)
        private string _selectedBDG = "";  // MASP|NGAY đang chọn để xóa
        private string _selectedKMRow = ""; // MA_CTKM+MASP đang chọn để xóa

        public FormQuanLyGiaKM()
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
            lblTitle.Text = "QU\u1ea2N L\u00dd GI\u00c1 B\u00c1N V\u00c0 KHUY\u1ebcN M\u00c3I";
            lblSubtitle.Text = "TH True Mart \u00b7 BIENDONGGIA \u00b7 CHUONGTRINHKHUYENMAI \u00b7 CT_CTKM";
            tabGia.Text = "  GI\u00c1 B\u00c1N (BIENDONGGIA)  ";
            tabKM.Text = "  KHUY\u1ebcN M\u00c3I (CT_CTKM)  ";
            lblGiaHisTitle.Text = "L\u1ecbch s\u1eed bi\u1ebfn \u0111\u1ed9ng gi\u00e1";
            lblGiaCardTitle.Text = "C\u1eadp nh\u1eadt gi\u00e1 b\u00e1n s\u1ea3n ph\u1ea9m";
            lblSPGia.Text = "S\u1ea3n ph\u1ea9m *";
            lblGiaHienTai.Text = "Gi\u00e1 b\u00e1n hi\u1ec7n t\u1ea1i (\u0111)";
            lblGiaMoi.Text = "Gi\u00e1 b\u00e1n m\u1edbi (\u0111) *";
            lblNgayApDung.Text = "Ng\u00e0y \u00e1p d\u1ee5ng *";
            lblGhiChuGia.Text = "Ghi ch\u00fa l\u00fd do \u0111i\u1ec1u ch\u1ec9nh";
            btnCapNhatGia.Text = "\u2714 C\u1eadp nh\u1eadt gi\u00e1 b\u00e1n";
            btnXoaGia.Text = "\u00d7 X\u00f3a bi\u1ebfn \u0111\u1ed9ng";
            btnSearchGia.Text = "T\u00ecm";
            lblKMHisTitle.Text = "Danh s\u00e1ch SP trong khuy\u1ebfn m\u00e3i";
            lblKMCardTitle.Text = "Th\u00eam SP v\u00e0o ch\u01b0\u01a1ng tr\u00ecnh khuy\u1ebfn m\u00e3i";
            lblSPKM.Text = "S\u1ea3n ph\u1ea9m *";
            lblCTKM.Text = "Ch\u01b0\u01a1ng tr\u00ecnh KM *";
            lblPHAMTRAMGIAM.Text = "% Gi\u1ea3m (nh\u1eadp 10 = gi\u1ea3m 10%) *";
            lblGiaSauGiam.Text = "Gi\u00e1 sau gi\u1ea3m (\u0111)";
            lblGhiChuKM.Text = "Ghi ch\u00fa";
            btnThemKM.Text = "\u2714 Th\u00eam v\u00e0o KM";
            btnXoaKM.Text = "\u00d7 X\u00f3a kh\u1ecfi KM";
            btnSearchKM.Text = "\u21ba T\u1ea3i l\u1ea1i";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 BIENDONGGIA \u00b7 CHUONGTRINHKHUYENMAI \u00b7 CT_CTKM";
        }

        private void SetHoverEffects()
        {
            var colNav = Color.FromArgb(13, 43, 90);
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnCapNhatGia, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnThemKM, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnXoaGia, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnXoaKM, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnSearchGia, Color.FromArgb(80, 160, 255), Color.FromArgb(56, 139, 253));
            H(btnSearchKM, Color.FromArgb(25, 65, 120), colNav);
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormQuanLyGiaKM_Load(object sender, EventArgs e)
        {
            LoadComboSanPham(cboSanPhamGia);
            LoadComboSanPham(cboSanPhamKM);
            LoadComboCTKM(cboCTKM);
            LoadComboCTKM(cboCTKMFilter, addAll: true);
            dtpNgayApDung.Value = DateTime.Today.AddDays(1);
            LoadGiaHistory();
            LoadKMHistory();
        }

        // ================================================================
        // LOAD COMBOS
        // ================================================================
        private void LoadComboSanPham(ComboBox cbo)
        {
            var dt = Query("SELECT MASP, TENSP + ' [' + MASP + ']' AS HT FROM SANPHAM ORDER BY TENSP");
            if (dt == null) return;
            cbo.DataSource = dt; cbo.DisplayMember = "HT"; cbo.ValueMember = "MASP"; cbo.SelectedIndex = -1;
        }

        private void LoadComboCTKM(ComboBox cbo, bool addAll = false)
        {
            var dt = Query("SELECT MA_CTKM, TEN_CTKM + N' [' + MA_CTKM + ']' AS HT FROM CHUONGTRINHKHUYENMAI ORDER BY TEN_CTKM");
            if (dt == null) return;
            if (addAll) { var row = dt.NewRow(); row["MA_CTKM"] = ""; row["HT"] = "-- T\u1ea5t c\u1ea3 --"; dt.Rows.InsertAt(row, 0); }
            cbo.DataSource = dt; cbo.DisplayMember = "HT"; cbo.ValueMember = "MA_CTKM"; cbo.SelectedIndex = 0;
        }

        // ================================================================
        // TAB GIÁ — LOAD LỊCH SỬ
        // ================================================================
        private void LoadGiaHistory(string keyword = "")
        {
            string sql = @"
                SELECT ROW_NUMBER() OVER(ORDER BY BDG.NGAYCAPNHAT_BDG DESC) AS STT,
                       SP.TENSP, SP.MASP,
                       BDG.GIABAN, BDG.NGAYCAPNHAT_BDG
                FROM BIENDONGGIA BDG
                JOIN SANPHAM SP ON BDG.MASP = SP.MASP
                WHERE @kw='' OR SP.TENSP LIKE @kw OR SP.MASP LIKE @kw
                ORDER BY BDG.NGAYCAPNHAT_BDG DESC";
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

                    dgvGiaHistory.AutoGenerateColumns = true;
                    dgvGiaHistory.DataSource = dt;

                    void Col(string n, string h, string fmt = null,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvGiaHistory.Columns.Contains(n)) return;
                        dgvGiaHistory.Columns[n].HeaderText = h;
                        if (fmt != null) dgvGiaHistory.Columns[n].DefaultCellStyle.Format = fmt;
                        dgvGiaHistory.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("STT", "STT", null, DataGridViewContentAlignment.MiddleCenter);
                    Col("TENSP", "T\u00ean s\u1ea3n ph\u1ea9m");
                    Col("MASP", "M\u00e3 SP", null, DataGridViewContentAlignment.MiddleCenter);
                    Col("GIABAN", "Gi\u00e1 b\u00e1n (\u0111)", "#,##0", DataGridViewContentAlignment.MiddleRight);
                    Col("NGAYCAPNHAT_BDG", "Ng\u00e0y", "dd/MM/yy", DataGridViewContentAlignment.MiddleCenter);
                    if (dgvGiaHistory.Columns.Contains("STT")) dgvGiaHistory.Columns["STT"].Width = 50;
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i bi\u1ebfn \u0111\u1ed9ng gi\u00e1", ex); }
            }
        }

        // Khi chọn SP → load giá hiện tại
        private void cboSanPhamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maSP = cboSanPhamGia.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maSP)) return;
            _giaHienTai = GetGiaHienTai(maSP);
            txtGiaHienTai.Text = _giaHienTai.ToString("#,##0");
            txtGiaBanMoi.Text = "";
            lblGiaDiff.Text = "Thay \u0111\u1ed5i: --";
            lblGiaDiff.ForeColor = Color.FromArgb(100, 110, 125);
        }

        private void txtGiaBanMoi_TextChanged(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtGiaBanMoi.Text.Replace(",", ""), out decimal giaMoi) || giaMoi <= 0)
            { lblGiaDiff.Text = "Thay \u0111\u1ed5i: --"; lblGiaDiff.ForeColor = Color.FromArgb(100, 110, 125); return; }

            decimal diff = giaMoi - _giaHienTai;
            decimal pct = _giaHienTai > 0 ? diff / _giaHienTai * 100 : 0;
            string sign = diff >= 0 ? "+" : "";
            lblGiaDiff.Text = $"Thay \u0111\u1ed5i: {sign}{diff:#,##0} \u0111  ({sign}{pct:F1}%)";
            lblGiaDiff.ForeColor = diff > 0 ? Color.FromArgb(13, 100, 60) :
                                   diff < 0 ? Color.FromArgb(180, 50, 50) :
                                              Color.FromArgb(100, 110, 125);
        }

        private void dgvGiaHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvGiaHistory.Rows[e.RowIndex];
            // Store MASP + date to identify the row for deletion
            string masp = row.Cells["MASP"].Value?.ToString() ?? "";
            string ngay = row.Cells["NGAYCAPNHAT_BDG"].Value?.ToString() ?? "";
            _selectedBDG = masp + "|" + ngay;
        }

        // ── CẬP NHẬT GIÁ ────────────────────────────────────────────
        private void btnCapNhatGia_Click(object sender, EventArgs e)
        {
            string maSP = cboSanPhamGia.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maSP)) { Warn("Ch\u1ecdn s\u1ea3n ph\u1ea9m."); return; }
            if (!decimal.TryParse(txtGiaBanMoi.Text.Replace(",", ""), out decimal giaMoi) || giaMoi <= 0)
            { Warn("Nh\u1eadp gi\u00e1 b\u00e1n m\u1edbi h\u1ee3p l\u1ec7 (> 0)."); txtGiaBanMoi.Focus(); return; }

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    // Gọi stored procedure nếu tồn tại, nếu không thì INSERT trực tiếp
                    bool hasSP = false;
                    using (var chk = new SqlCommand("SELECT COUNT(*) FROM sys.objects WHERE type='P' AND name='sp_CapNhat_GiaBan_Moi'", con))
                        hasSP = Convert.ToInt32(chk.ExecuteScalar()) > 0;

                    if (hasSP)
                    {
                        using (var cmd = new SqlCommand("sp_CapNhat_GiaBan_Moi", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@GiaBanMoi", giaMoi);
                            cmd.Parameters.AddWithValue("@NgayApDung", dtpNgayApDung.Value.Date);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string ghiChu = txtGhiChuGia.Text.Trim();
                        var cmd = new SqlCommand(@"
                            INSERT INTO BIENDONGGIA (MASP, GIABAN, NGAYCAPNHAT_BDG)
                            VALUES (@SP, @GIA, @NGAY)", con);
                        cmd.Parameters.Add("@SP", SqlDbType.Char, 10).Value = maSP;
                        cmd.Parameters.Add("@GIA", SqlDbType.Decimal).Value = giaMoi;
                        ((SqlParameter)cmd.Parameters["@GIA"]).Precision = 18; ((SqlParameter)cmd.Parameters["@GIA"]).Scale = 2;
                        cmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = dtpNgayApDung.Value.Date;
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("C\u1eadp nh\u1eadt gi\u00e1 b\u00e1n th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _giaHienTai = giaMoi;
                    txtGiaHienTai.Text = giaMoi.ToString("#,##0");
                    txtGiaBanMoi.Text = ""; txtGhiChuGia.Text = "";
                    lblGiaDiff.Text = "Thay \u0111\u1ed5i: --"; lblGiaDiff.ForeColor = Color.FromArgb(100, 110, 125);
                    LoadGiaHistory();
                }
                catch (SqlException ex) { ShowErr("c\u1eadp nh\u1eadt gi\u00e1", ex); }
            }
        }

        // ── XÓA BIẾN ĐỘNG GIÁ ────────────────────────────────────────
        private void btnXoaGia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedBDG) || !_selectedBDG.Contains("|"))
            { Warn("Ch\u1ecdn h\u00e0ng bi\u1ebfn \u0111\u1ed9ng gi\u00e1 b\u00ean tr\u00e1i c\u1ea7n x\u00f3a."); return; }

            var parts = _selectedBDG.Split('|');
            string masp = parts[0];
            if (!DateTime.TryParse(parts[1], out DateTime ngay))
            { Warn("Kh\u00f4ng x\u00e1c \u0111\u1ecbnh \u0111\u01b0\u1ee3c ng\u00e0y c\u1ea7n x\u00f3a."); return; }

            if (MessageBox.Show("X\u00f3a bi\u1ebfn \u0111\u1ed9ng gi\u00e1 SP [" + masp + "] ng\u00e0y " + ngay.ToString("dd/MM/yyyy") + "?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("DELETE FROM BIENDONGGIA WHERE MASP=@SP AND NGAYCAPNHAT_BDG=@NGAY", con);
                    cmd.Parameters.Add("@SP", SqlDbType.Char, 10).Value = masp;
                    cmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = ngay.Date;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("X\u00f3a th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _selectedBDG = ""; LoadGiaHistory();
                }
                catch (SqlException ex) { ShowErr("x\u00f3a bi\u1ebfn \u0111\u1ed9ng gi\u00e1", ex); }
            }
        }

        private void btnSearchGia_Click(object sender, EventArgs e) => LoadGiaHistory(txtSearchGia.Text);
        private void txtSearchGia_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) btnSearchGia_Click(sender, e); }

        // ================================================================
        // TAB KHUYẾN MÃI — LOAD LỊCH SỬ
        // ================================================================
        private void LoadKMHistory(string maCTKM = "")
        {
            string sql = @"
                SELECT CK.MA_CTKM, CT.TEN_CTKM, SP.TENSP, SP.MASP,
                       CK.PHAMTRAMGIAM,
                       ISNULL(CK.GHICHU, N'') AS GHICHU
                FROM CT_CTKM CK
                JOIN CHUONGTRINHKHUYENMAI CT ON CK.MA_CTKM = CT.MA_CTKM
                JOIN SANPHAM SP ON CK.MASP = SP.MASP
                WHERE @ma = '' OR CK.MA_CTKM = @ma
                ORDER BY CT.TEN_CTKM, SP.TENSP";
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@ma", SqlDbType.Char, 10).Value = string.IsNullOrEmpty(maCTKM) ? "" : maCTKM;
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvKMHistory.AutoGenerateColumns = true;
                    dgvKMHistory.DataSource = dt;

                    void Col(string n, string h, string fmt = null,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvKMHistory.Columns.Contains(n)) return;
                        dgvKMHistory.Columns[n].HeaderText = h;
                        if (fmt != null) dgvKMHistory.Columns[n].DefaultCellStyle.Format = fmt;
                        dgvKMHistory.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("MA_CTKM", "M\u00e3 KM", null, DataGridViewContentAlignment.MiddleCenter);
                    Col("TEN_CTKM", "Ch\u01b0\u01a1ng tr\u00ecnh");
                    Col("TENSP", "S\u1ea3n ph\u1ea9m");
                    Col("MASP", "M\u00e3 SP", null, DataGridViewContentAlignment.MiddleCenter);
                    Col("PHAMTRAMGIAM", "% Gi\u1ea3m", "P0", DataGridViewContentAlignment.MiddleCenter);
                    Col("GHICHU", "Ghi ch\u00fa");
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i danh s\u00e1ch KM", ex); }
            }
        }

        private void cboCTKMFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = cboCTKMFilter.SelectedValue?.ToString() ?? "";
            LoadKMHistory(ma);
        }

        private void dgvKMHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvKMHistory.Rows[e.RowIndex];
            _selectedKMRow = (row.Cells["MA_CTKM"].Value?.ToString() ?? "") + "|" +
                             (row.Cells["MASP"].Value?.ToString() ?? "");
        }

        private void btnSearchKM_Click(object sender, EventArgs e)
        {
            string ma = cboCTKMFilter.SelectedValue?.ToString() ?? "";
            LoadKMHistory(ma);
        }

        // SP KM chọn → tự lấy giá hiện tại để tính giá sau giảm
        private void cboSanPhamKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maSP = cboSanPhamKM.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maSP)) { _giaKMSP = 0; txtGiaSauGiam.Text = ""; return; }
            _giaKMSP = GetGiaHienTai(maSP);
            CalcGiaSauGiam();
        }

        private void txtPHAMTRAMGIAM_TextChanged(object sender, EventArgs e) => CalcGiaSauGiam();

        private void CalcGiaSauGiam()
        {
            if (!decimal.TryParse(txtPHAMTRAMGIAM.Text.Replace(",", ""), out decimal pct) || pct < 0 || pct > 100 || _giaKMSP <= 0)
            { txtGiaSauGiam.Text = ""; return; }
            decimal giaSau = _giaKMSP * (1 - pct / 100);
            txtGiaSauGiam.Text = giaSau.ToString("#,##0");
        }

        // ── THÊM VÀO KM ─────────────────────────────────────────────
        private void btnThemKM_Click(object sender, EventArgs e)
        {
            string maSP = cboSanPhamKM.SelectedValue?.ToString();
            string maCTKM = cboCTKM.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maSP)) { Warn("Ch\u1ecdn s\u1ea3n ph\u1ea9m."); return; }
            if (string.IsNullOrEmpty(maCTKM)) { Warn("Ch\u1ecdn ch\u01b0\u01a1ng tr\u00ecnh KM."); return; }
            if (!decimal.TryParse(txtPHAMTRAMGIAM.Text.Replace(",", ""), out decimal pct) || pct < 0 || pct > 100)
            { Warn("Nh\u1eadp % gi\u1ea3m h\u1ee3p l\u1ec7 (0 \u2013 100)."); txtPHAMTRAMGIAM.Focus(); return; }

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    bool hasSP = false;
                    using (var chk = new SqlCommand("SELECT COUNT(*) FROM sys.objects WHERE type='P' AND name='sp_ThemSP_VaoCTKM'", con))
                        hasSP = Convert.ToInt32(chk.ExecuteScalar()) > 0;

                    if (hasSP)
                    {
                        using (var cmd = new SqlCommand("sp_ThemSP_VaoCTKM", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaSP", maSP);
                            cmd.Parameters.AddWithValue("@MaCTKM", maCTKM);
                            cmd.Parameters.AddWithValue("@PHAMTRAMGIAM", pct / 100); // SP nhận 0-1
                            cmd.Parameters.AddWithValue("@GhiChu", txtGhiChuKM.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Upsert: nếu đã có thì UPDATE, chưa có thì INSERT
                        var chkEx = new SqlCommand("SELECT COUNT(*) FROM CT_CTKM WHERE MASP=@SP AND MA_CTKM=@KM", con);
                        chkEx.Parameters.Add("@SP", SqlDbType.Char, 10).Value = maSP;
                        chkEx.Parameters.Add("@KM", SqlDbType.Char, 10).Value = maCTKM;
                        bool exists = Convert.ToInt32(chkEx.ExecuteScalar()) > 0;

                        SqlCommand cmdUpsert;
                        if (exists)
                            cmdUpsert = new SqlCommand("UPDATE CT_CTKM SET PHAMTRAMGIAM=@PCT, GHICHU=@GC WHERE MASP=@SP AND MA_CTKM=@KM", con);
                        else
                            cmdUpsert = new SqlCommand("INSERT INTO CT_CTKM (MA_CTKM,MASP,PHAMTRAMGIAM,GHICHU) VALUES (@KM,@SP,@PCT,@GC)", con);

                        cmdUpsert.Parameters.Add("@SP", SqlDbType.Char, 10).Value = maSP;
                        cmdUpsert.Parameters.Add("@KM", SqlDbType.Char, 10).Value = maCTKM;
                        cmdUpsert.Parameters.Add("@PCT", SqlDbType.Decimal).Value = pct / 100m; // store 0.10 not 10
                        ((SqlParameter)cmdUpsert.Parameters["@PCT"]).Precision = 5; ((SqlParameter)cmdUpsert.Parameters["@PCT"]).Scale = 2;
                        cmdUpsert.Parameters.Add("@GC", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(txtGhiChuKM.Text) ? (object)DBNull.Value : txtGhiChuKM.Text.Trim();
                        cmdUpsert.ExecuteNonQuery();
                    }

                    MessageBox.Show("Th\u00eam/c\u1eadp nh\u1eadt SP v\u00e0o KM th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPHAMTRAMGIAM.Text = ""; txtGhiChuKM.Text = ""; txtGiaSauGiam.Text = "";
                    cboSanPhamKM.SelectedIndex = -1;
                    LoadKMHistory(cboCTKMFilter.SelectedValue?.ToString() ?? "");
                }
                catch (SqlException ex) { ShowErr("th\u00eam v\u00e0o KM", ex); }
            }
        }

        // ── XÓA KHỎI KM ─────────────────────────────────────────────
        private void btnXoaKM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedKMRow) || !_selectedKMRow.Contains("|"))
            { Warn("Ch\u1ecdn h\u00e0ng trong danh s\u00e1ch b\u00ean tr\u00e1i c\u1ea7n x\u00f3a."); return; }

            var parts = _selectedKMRow.Split('|');
            string maCTKM = parts[0]; string maSP = parts[1];

            if (MessageBox.Show("X\u00f3a SP [" + maSP + "] kh\u1ecfi ch\u01b0\u01a1ng tr\u00ecnh [" + maCTKM + "]?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("DELETE FROM CT_CTKM WHERE MA_CTKM=@KM AND MASP=@SP", con);
                    cmd.Parameters.Add("@KM", SqlDbType.Char, 10).Value = maCTKM;
                    cmd.Parameters.Add("@SP", SqlDbType.Char, 10).Value = maSP;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("X\u00f3a th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _selectedKMRow = "";
                    LoadKMHistory(cboCTKMFilter.SelectedValue?.ToString() ?? "");
                }
                catch (SqlException ex) { ShowErr("x\u00f3a kh\u1ecfi KM", ex); }
            }
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private decimal GetGiaHienTai(string maSP)
        {
            string sql = "SELECT TOP 1 ISNULL(GIABAN,0) FROM BIENDONGGIA WHERE MASP=@S ORDER BY NGAYCAPNHAT_BDG DESC";
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@S", SqlDbType.Char, 10).Value = maSP;
                    var val = cmd.ExecuteScalar();
                    return val == null || val == DBNull.Value ? 0 : Convert.ToDecimal(val);
                }
                catch { return 0; }
            }
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