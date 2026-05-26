using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormSanPham : Form
    {
        private readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        private string _editMode = "NONE"; // ADD | EDIT
        private string _currentMasp = "";

        private readonly string[] TRANG_THAI = {
            "\u0110ang b\u00e1n",
            "Ng\u1eebng b\u00e1n",
            "H\u1ebft h\u00e0ng"
        };

        public FormSanPham()
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
            lblTitle.Text = "QU\u1ea2N L\u00dd S\u1ea2N PH\u1ea8M";
            lblSubtitle.Text = "TH True Mart \u00b7 SANPHAM \u00b7 LOAISP \u00b7 DONVITINH \u00b7 BIENDONGGIA";
            lblStat1Lbl.Text = "T\u1ed4NG S\u1ea2N PH\u1ea8M";
            lblStat2Lbl.Text = "\u0110ANG B\u00c1N";
            lblStat3Lbl.Text = "NG\u1eebNG / H\u1ebcT";
            lblListTitle.Text = "Danh s\u00e1ch s\u1ea3n ph\u1ea9m";
            lblListSub.Text = "SANPHAM \u00b7 Nh\u1ea5p m\u1ed9t h\u00e0ng \u0111\u1ec3 s\u1eeda";
            btnThem.Text = "+ Th\u00eam SP";
            btnSua.Text = "\u270e S\u1eeda SP";
            btnXoa.Text = "\u00d7 X\u00f3a SP";
            btnReload.Text = "\u21ba T\u1ea3i l\u1ea1i";
            btnSearch.Text = "\ud83d\udd0d T\u00ecm";
            lblEMasp.Text = "M\u00e3 SP";
            lblETensp.Text = "T\u00ean s\u1ea3n ph\u1ea9m *";
            lblELoai.Text = "Lo\u1ea1i SP *";
            lblEDvt.Text = "\u0110\u01a1n v\u1ecb t\u00ednh *";
            lblEHsd.Text = "H\u1ea1n s\u1eed d\u1ee5ng (ng\u00e0y) *";
            lblETrangThai.Text = "Tr\u1ea1ng th\u00e1i *";
            lblEMoTa.Text = "M\u00f4 t\u1ea3";
            lblENxssp.Text = "Ng\u00e0y SX/Xu\u1ea5t *";
            lblEMadvtqd.Text = "\u0110VT Quy đ\u1ed5i *";
            btnLuu.Text = "\u2714 L\u01b0u";
            btnHuy.Text = "\u00d7 H\u1ee7y";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 SANPHAM \u00b7 LOAISP \u00b7 DONVITINH \u00b7 BIENDONGGIA";
            lblEditTitle.Text = "\u25bc  Th\u00f4ng tin s\u1ea3n ph\u1ea9m  (ch\u1ecdn Th\u00eam m\u1edbi ho\u1eb7c S\u1eeda)";
        }

        private void SetHoverEffects()
        {
            var colNav = Color.FromArgb(13, 43, 90);
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnThem, Color.FromArgb(25, 65, 120), colNav);
            H(btnSua, Color.FromArgb(210, 145, 10), Color.FromArgb(180, 120, 0));
            H(btnXoa, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnSearch, Color.FromArgb(80, 160, 255), Color.FromArgb(56, 139, 253));
            H(btnLuu, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormSanPham_Load(object sender, EventArgs e)
        {
            // Filter combobox
            cmbFilterLoai.Items.Add("-- T\u1ea5t c\u1ea3 lo\u1ea1i --");
            LoadComboLoaiFilter();
            cmbFilterLoai.SelectedIndex = 0;

            // TrangThai edit
            cmbETrangThai.Items.Clear();
            foreach (var tt in TRANG_THAI) cmbETrangThai.Items.Add(tt);

            LoadComboLoai();
            LoadComboDvt();
            LoadSanPham();
            ClearEditForm();
        }

        // ================================================================
        // LOAD COMBOS
        // ================================================================
        private void LoadComboLoai()
        {
            var dt = Query("SELECT MA_LOAISP, TEN_LOAISP FROM LOAISP ORDER BY TEN_LOAISP");
            if (dt == null) return;
            cmbELoai.DataSource = dt; cmbELoai.DisplayMember = "TEN_LOAISP"; cmbELoai.ValueMember = "MA_LOAISP"; cmbELoai.SelectedIndex = -1;
        }

        private void LoadComboDvt()
        {
            var dt = Query("SELECT MADVT, TENDVT FROM DONVITINH ORDER BY TENDVT");
            if (dt == null) return;
            cmbEDvt.DataSource = dt; cmbEDvt.DisplayMember = "TENDVT"; cmbEDvt.ValueMember = "MADVT"; cmbEDvt.SelectedIndex = -1;
            // MADVTQD load từ DONVITINHQUYDOI
            var dt2 = Query("SELECT MADVTQD, TENDVTQD + ' [' + MADVTQD + ']' AS HT FROM DONVITINHQUYDOI ORDER BY TENDVTQD");
            if (dt2 == null) return;
            cmbEMadvtqd.DataSource = dt2; cmbEMadvtqd.DisplayMember = "HT"; cmbEMadvtqd.ValueMember = "MADVTQD"; cmbEMadvtqd.SelectedIndex = -1;
        }

        private void LoadComboLoaiFilter()
        {
            var dt = Query("SELECT TEN_LOAISP FROM LOAISP ORDER BY TEN_LOAISP");
            if (dt == null) return;
            foreach (DataRow row in dt.Rows) cmbFilterLoai.Items.Add(row["TEN_LOAISP"].ToString());
        }

        // ================================================================
        // LOAD DANH SÁCH
        // ================================================================
        private void LoadSanPham(string keyword = "", string loai = "")
        {
            string sql = @"
                SELECT
                    SP.MASP, SP.TENSP,
                    LSP.TEN_LOAISP, DVT.TENDVT,
                    SP.HSDSP        AS HSD_Ngay,
                    ISNULL(SP.TRANGTHAI_SP, N'\u0110ang b\u00e1n') AS TRANGTHAI_SP,
                    SP.NXSSP,
                    SP.MADVTQD,
                    ISNULL(SP.MOTASP, N'') AS MOTASP,
                    ISNULL(BDG.GIABAN, 0)   AS GiaBan,
                    SP.MA_LOAISP, SP.MADVT
                FROM SANPHAM SP
                JOIN LOAISP    LSP ON SP.MA_LOAISP = LSP.MA_LOAISP
                JOIN DONVITINH DVT ON SP.MADVT      = DVT.MADVT
                LEFT JOIN BIENDONGGIA BDG
                    ON SP.MASP = BDG.MASP
                   AND BDG.NGAYCAPNHAT_BDG = (
                        SELECT MAX(NGAYCAPNHAT_BDG) FROM BIENDONGGIA WHERE MASP = SP.MASP)
                WHERE (@kw = N'' OR SP.TENSP LIKE @kw OR SP.MASP LIKE @kw)
                  AND (@loai = N'' OR LSP.TEN_LOAISP = @loai)
                ORDER BY SP.MASP";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 100).Value = string.IsNullOrWhiteSpace(keyword) ? "" : "%" + keyword.Trim() + "%";
                    cmd.Parameters.Add("@loai", SqlDbType.NVarChar, 100).Value = string.IsNullOrWhiteSpace(loai) ? "" : loai.Trim();

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvSanPham.AutoGenerateColumns = true;
                    dgvSanPham.DataSource = dt;

                    void Col(string n, string h, string fmt = null, bool vis = true,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvSanPham.Columns.Contains(n)) return;
                        dgvSanPham.Columns[n].HeaderText = h; dgvSanPham.Columns[n].Visible = vis;
                        if (fmt != null) dgvSanPham.Columns[n].DefaultCellStyle.Format = fmt;
                        dgvSanPham.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("MASP", "M\u00e3 SP", null, true, DataGridViewContentAlignment.MiddleCenter);
                    Col("TENSP", "T\u00ean s\u1ea3n ph\u1ea9m");
                    Col("TEN_LOAISP", "Lo\u1ea1i SP");
                    Col("TENDVT", "\u0110VT", null, true, DataGridViewContentAlignment.MiddleCenter);
                    Col("HSD_Ngay", "H\u1ea1n SD (ng\u00e0y)", null, true, DataGridViewContentAlignment.MiddleRight);
                    Col("TRANGTHAI_SP", "Tr\u1ea1ng th\u00e1i");
                    Col("MOTASP", "M\u00f4 t\u1ea3");
                    Col("GiaBan", "Gi\u00e1 b\u00e1n (\u0111)", "#,##0", true, DataGridViewContentAlignment.MiddleRight);
                    Col("NXSSP", "Ng\u00e0y SX", "dd/MM/yyyy", false);
                    Col("MADVTQD", "", null, false);
                    Col("MA_LOAISP", "", null, false);
                    Col("MADVT", "", null, false);

                    // Tô màu trạng thái
                    foreach (DataGridViewRow row in dgvSanPham.Rows)
                    {
                        string tt = row.Cells["TRANGTHAI_SP"].Value?.ToString() ?? "";
                        if (tt == TRANG_THAI[0])
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(13, 100, 60);
                        else if (tt != TRANG_THAI[0])
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 50, 50);
                    }

                    UpdateStats(dt);
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i danh s\u00e1ch s\u1ea3n ph\u1ea9m", ex); }
            }
        }

        // ================================================================
        // CLICK HÀNG → ĐIỀN FORM
        // ================================================================
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSanPham.Rows[e.RowIndex];
            if (row.Cells["MASP"].Value == null) return;
            _currentMasp = row.Cells["MASP"].Value.ToString();
            lblListSub.Text = "S\u1ea3n ph\u1ea9m \u0111ang ch\u1ecdn: " + _currentMasp;
        }

        // ================================================================
        // THÊM
        // ================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearEditForm();
            _editMode = "ADD";
            txtEMasp.Text = GenerateMasp();
            cmbETrangThai.SelectedIndex = 0;
            lblEditTitle.Text = "\u25bc  Th\u00eam s\u1ea3n ph\u1ea9m m\u1edbi: " + txtEMasp.Text;
            lblEditTitle.ForeColor = Color.FromArgb(13, 100, 60);
            txtETensp.Focus();
        }

        private string GenerateMasp()
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(MASP,3,LEN(MASP)) AS INT)),0)+1 FROM SANPHAM WHERE ISNUMERIC(SUBSTRING(MASP,3,LEN(MASP)))=1";
            using (var con = new SqlConnection(_conn))
            {
                try { con.Open(); return "SP" + Convert.ToInt32(new SqlCommand(sql, con).ExecuteScalar()).ToString("D3"); }
                catch { return "SP" + DateTime.Now.ToString("mmss"); }
            }
        }

        // ================================================================
        // SỬA
        // ================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMasp)) { Warn("Ch\u1ecdn s\u1ea3n ph\u1ea9m c\u1ea7n s\u1eeda."); return; }
            var row = dgvSanPham.CurrentRow;
            _editMode = "EDIT";

            txtEMasp.Text = _currentMasp;
            txtETensp.Text = row.Cells["TENSP"].Value?.ToString() ?? "";
            txtEHsd.Text = row.Cells["HSD_Ngay"].Value?.ToString() ?? "";
            txtEMoTa.Text = row.Cells["MOTASP"].Value?.ToString() ?? "";
            if (row.Cells["NXSSP"].Value != null && row.Cells["NXSSP"].Value != System.DBNull.Value)
                dtpENxssp.Value = Convert.ToDateTime(row.Cells["NXSSP"].Value);
            SetCombo(cmbEMadvtqd, row.Cells["MADVTQD"].Value?.ToString() ?? "");

            SetCombo(cmbELoai, row.Cells["MA_LOAISP"].Value?.ToString() ?? "");
            SetCombo(cmbEDvt, row.Cells["MADVT"].Value?.ToString() ?? "");

            string tt = row.Cells["TRANGTHAI_SP"].Value?.ToString() ?? "";
            int idx = Array.IndexOf(TRANG_THAI, tt);
            cmbETrangThai.SelectedIndex = idx >= 0 ? idx : 0;

            lblEditTitle.Text = "\u25bc  \u0110ang s\u1eeda: " + _currentMasp;
            lblEditTitle.ForeColor = Color.FromArgb(160, 80, 0);
        }

        // ================================================================
        // XÓA
        // ================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentMasp)) { Warn("Ch\u1ecdn s\u1ea3n ph\u1ea9m c\u1ea7n x\u00f3a."); return; }
            string ten = dgvSanPham.CurrentRow?.Cells["TENSP"].Value?.ToString() ?? _currentMasp;

            if (MessageBox.Show("X\u00f3a s\u1ea3n ph\u1ea9m [" + _currentMasp + "] " + ten + "?\n\n(Kh\u00f4ng th\u1ec3 x\u00f3a n\u1ebfu SP \u0111\u00e3 c\u00f3 trong \u0111\u01a1n h\u00e0ng / ph\u00f4i)",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("DELETE FROM SANPHAM WHERE MASP=@M", con);
                    cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = _currentMasp;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("X\u00f3a th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _currentMasp = ""; ClearEditForm(); LoadSanPham();
                }
                catch (SqlException ex) { ShowErr("x\u00f3a s\u1ea3n ph\u1ea9m", ex); }
            }
        }

        // ================================================================
        // LƯU
        // ================================================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_editMode == "NONE") { Warn("Ch\u1ecdn Th\u00eam m\u1edbi ho\u1eb7c S\u1eeda tr\u01b0\u1edbc."); return; }

            string masp = txtEMasp.Text.Trim();
            string tensp = txtETensp.Text.Trim();
            string maLoai = cmbELoai.SelectedValue?.ToString() ?? "";
            string maDvt = cmbEDvt.SelectedValue?.ToString() ?? "";
            string tt = cmbETrangThai.SelectedItem?.ToString() ?? "";
            string moTa = txtEMoTa.Text.Trim();

            if (string.IsNullOrEmpty(tensp)) { Warn("Nh\u1eadp t\u00ean s\u1ea3n ph\u1ea9m."); txtETensp.Focus(); return; }
            if (string.IsNullOrEmpty(maLoai)) { Warn("Ch\u1ecdn lo\u1ea1i SP."); cmbELoai.Focus(); return; }
            if (string.IsNullOrEmpty(maDvt)) { Warn("Ch\u1ecdn \u0111\u01a1n v\u1ecb t\u00ednh."); cmbEDvt.Focus(); return; }
            if (string.IsNullOrEmpty(tt)) { Warn("Ch\u1ecdn tr\u1ea1ng th\u00e1i."); cmbETrangThai.Focus(); return; }

            string maDvtqd = cmbEMadvtqd.SelectedValue?.ToString() ?? "";
            if (string.IsNullOrEmpty(maDvtqd)) { Warn("Ch\u1ecdn \u0111\u01a1n v\u1ecb t\u00ednh quy đ\u1ed5i."); cmbEMadvtqd.Focus(); return; }
            if (!int.TryParse(txtEHsd.Text.Trim(), out int hsd) || hsd < 0)
            { Warn("H\u1ea1n s\u1eed d\u1ee5ng ph\u1ea3i l\u00e0 s\u1ed1 nguy\u00ean \u2265 0."); txtEHsd.Focus(); return; }

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;
                    if (_editMode == "ADD")
                    {
                        cmd = new SqlCommand(@"
                            INSERT INTO SANPHAM (MASP, TENSP, MA_LOAISP, MADVT, MADVTQD, NXSSP, HSDSP, TRANGTHAI_SP, MOTASP)
                            VALUES (@M,@TEN,@LOAI,@DVT,@DVTQD,@NXSSP,@HSD,@TT,@MOTA)", con);
                        cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = masp;
                    }
                    else
                    {
                        cmd = new SqlCommand(@"
                            UPDATE SANPHAM SET
                              TENSP=@TEN, MA_LOAISP=@LOAI, MADVT=@DVT, MADVTQD=@DVTQD,
                              NXSSP=@NXSSP, HSDSP=@HSD, TRANGTHAI_SP=@TT, MOTASP=@MOTA
                            WHERE MASP=@M", con);
                        cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = masp;
                    }
                    cmd.Parameters.Add("@TEN", SqlDbType.NVarChar, 150).Value = tensp;
                    cmd.Parameters.Add("@LOAI", SqlDbType.Char, 10).Value = maLoai;
                    cmd.Parameters.Add("@DVT", SqlDbType.Char, 10).Value = maDvt;
                    cmd.Parameters.Add("@HSD", SqlDbType.Int).Value = hsd;
                    cmd.Parameters.Add("@TT", SqlDbType.NVarChar, 50).Value = tt;
                    cmd.Parameters.Add("@DVTQD", SqlDbType.Char, 10).Value = maDvtqd;
                    cmd.Parameters.Add("@NXSSP", SqlDbType.Date).Value = dtpENxssp.Value.Date;
                    cmd.Parameters.Add("@MOTA", SqlDbType.NVarChar, 255).Value = string.IsNullOrEmpty(moTa) ? (object)DBNull.Value : moTa;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show((_editMode == "ADD" ? "Th\u00eam" : "C\u1eadp nh\u1eadt") + " [" + masp + "] th\u00e0nh c\u00f4ng!",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _currentMasp = masp;
                    ClearEditForm();
                    LoadSanPham(txtSearch.Text, GetFilterLoai());
                }
                catch (SqlException ex) { ShowErr("l\u01b0u s\u1ea3n ph\u1ea9m", ex); }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => ClearEditForm();

        // ================================================================
        // TÌM KIẾM & LỌC
        // ================================================================
        private void btnSearch_Click(object sender, EventArgs e)
            => LoadSanPham(txtSearch.Text, GetFilterLoai());

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e); }

        private void cmbFilterLoai_SelectedIndexChanged(object sender, EventArgs e)
            => LoadSanPham(txtSearch.Text, GetFilterLoai());

        private string GetFilterLoai()
            => cmbFilterLoai.SelectedIndex <= 0 ? "" : cmbFilterLoai.SelectedItem.ToString();

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Text = ""; cmbFilterLoai.SelectedIndex = 0;
            _currentMasp = ""; ClearEditForm(); LoadSanPham();
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private void ClearEditForm()
        {
            _editMode = "NONE";
            txtEMasp.Text = ""; txtETensp.Text = ""; txtEHsd.Text = ""; txtEMoTa.Text = "";
            cmbELoai.SelectedIndex = -1; cmbEDvt.SelectedIndex = -1; cmbETrangThai.SelectedIndex = -1;
            cmbEMadvtqd.SelectedIndex = -1; dtpENxssp.Value = DateTime.Today;
            lblEditTitle.Text = "\u25bc  Th\u00f4ng tin s\u1ea3n ph\u1ea9m  (ch\u1ecdn Th\u00eam m\u1edbi ho\u1eb7c S\u1eeda)";
            lblEditTitle.ForeColor = Color.FromArgb(13, 43, 90);
        }

        private void UpdateStats(DataTable dt)
        {
            int total = dt.Rows.Count, active = 0, inactive = 0;
            foreach (DataRow row in dt.Rows)
            {
                string tt = row["TRANGTHAI_SP"]?.ToString() ?? "";
                if (tt == TRANG_THAI[0]) active++;
                else inactive++;
            }
            lblStat1Val.Text = total.ToString();
            lblStat2Val.Text = active.ToString();
            lblStat3Val.Text = inactive.ToString();
            lblListSub.Text = "SANPHAM \u00b7 " + total + " s\u1ea3n ph\u1ea9m";
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
            => MessageBox.Show(msg, "Thi\u1ebfu th\u00f4ng tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}