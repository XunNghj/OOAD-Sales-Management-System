using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormNhanVien : Form
    {
        private readonly string _conn;
        private string _editMode = "NONE"; // "ADD" | "EDIT"
        private string _currentManv = "";

        private readonly string[] TRANG_THAI = {
            "\u0110ang l\u00e0m vi\u1ec7c",
            "Ngh\u1ec9 vi\u1ec7c",
            "T\u1ea1m ngh\u1ec9"
        };

        public FormNhanVien() : this(
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;")
        { }

        public FormNhanVien(string connectionString)
        {
            _conn = connectionString;
            InitializeComponent();
            SetLabels();
            SetHoverEffects();
        }

        // ================================================================
        // KHỞI TẠO
        // ================================================================
        private void SetLabels()
        {
            lblTitle.Text = "QU\u1ea2N L\u00dd NH\u00c2N VI\u00caN";
            lblSubtitle.Text = "TH True Mart \u00b7 Th\u00eam / S\u1eeda / X\u00f3a nh\u00e2n vi\u00ean";
            lblStat1Lbl.Text = "T\u1ed4NG NH\u00c2N VI\u00caN";
            lblStat2Lbl.Text = "\u0110ANG L\u00c0M VI\u1ec6C";
            lblStat3Lbl.Text = "NGH\u1ec8 VI\u1ec6C";
            lblListTitle.Text = "Danh s\u00e1ch nh\u00e2n vi\u00ean";
            lblListSub.Text = "NHANVIEN \u00b7 Nh\u1ea5p m\u1ed9t h\u00e0ng \u0111\u1ec3 s\u1eeda";
            btnThem.Text = "+ Th\u00eam NV";
            btnSua.Text = "\u270e S\u1eeda NV";
            btnXoa.Text = "\u00d7 X\u00f3a NV";
            btnReload.Text = "\u21ba T\u1ea3i l\u1ea1i";
            btnSearch.Text = "\ud83d\udd0d T\u00ecm";
            lblEManv.Text = "M\u00e3 NV";
            lblETennv.Text = "H\u1ecd t\u00ean *";
            lblESdt.Text = "S\u1ed1 \u0111i\u1ec7n tho\u1ea1i *";
            lblEEmail.Text = "Email *";
            lblEMacv.Text = "Ch\u1ee9c v\u1ee5 *";
            lblEMapb.Text = "Ph\u00f2ng ban *";
            lblETrangThai.Text = "Tr\u1ea1ng th\u00e1i *";
            btnLuu.Text = "\u2714 L\u01b0u";
            btnHuy.Text = "\u00d7 H\u1ee7y";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 NHANVIEN \u00b7 CHUCVU \u00b7 PHONGBAN";
            lblEditTitle.Text = "\u25bc  Th\u00f4ng tin nh\u00e2n vi\u00ean  (ch\u1ecdn Th\u00eam m\u1edbi ho\u1eb7c S\u1eeda)";
        }

        private void SetHoverEffects()
        {
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnThem, Color.FromArgb(25, 65, 120), Color.FromArgb(13, 43, 90));
            H(btnSua, Color.FromArgb(210, 145, 10), Color.FromArgb(180, 120, 0));
            H(btnXoa, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnSearch, Color.FromArgb(80, 160, 255), Color.FromArgb(56, 139, 253));
            H(btnLuu, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            // Filter combobox
            cmbFilterTT.Items.Add("-- T\u1ea5t c\u1ea3 tr\u1ea1ng th\u00e1i --");
            foreach (var tt in TRANG_THAI) cmbFilterTT.Items.Add(tt);
            cmbFilterTT.SelectedIndex = 0;

            // Trang thái edit combobox
            cmbETrangThai.Items.Clear();
            foreach (var tt in TRANG_THAI) cmbETrangThai.Items.Add(tt);

            LoadComboChucVu();
            LoadComboPhongBan();
            LoadNhanVien();
            ClearEditForm();
        }

        // ================================================================
        // LOAD COMBOBOXES
        // ================================================================
        private void LoadComboChucVu()
        {
            string sql = "SELECT MACV, TENCV FROM CHUCVU ORDER BY TENCV";
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);
                    cmbEMacv.DataSource = dt;
                    cmbEMacv.DisplayMember = "TENCV";
                    cmbEMacv.ValueMember = "MACV";
                    cmbEMacv.SelectedIndex = -1;
                }
                catch (SqlException ex) { ShowErr("load ch\u1ee9c v\u1ee5", ex); }
            }
        }

        private void LoadComboPhongBan()
        {
            string sql = "SELECT MAPB, TEN_PB FROM PHONGBAN ORDER BY TEN_PB";
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);
                    cmbEMapb.DataSource = dt;
                    cmbEMapb.DisplayMember = "TEN_PB";
                    cmbEMapb.ValueMember = "MAPB";
                    cmbEMapb.SelectedIndex = -1;
                }
                catch (SqlException ex) { ShowErr("load ph\u00f2ng ban", ex); }
            }
        }

        // ================================================================
        // LOAD DANH SÁCH
        // ================================================================
        private void LoadNhanVien(string keyword = "", string trangThai = "")
        {
            string sql = @"
                SELECT NV.MANV, NV.TENNV, NV.SDT, NV.EMAIL,
                       CV.TENCV, PB.TEN_PB, NV.TRANGTHAI_NV,
                       NV.MACV, NV.MAPB
                FROM NHANVIEN NV
                JOIN CHUCVU  CV ON NV.MACV = CV.MACV
                JOIN PHONGBAN PB ON NV.MAPB = PB.MAPB
                WHERE (@kw = '' OR NV.TENNV LIKE @kw OR NV.MANV LIKE @kw OR NV.SDT LIKE @kw OR NV.EMAIL LIKE @kw)
                  AND (@tt = '' OR NV.TRANGTHAI_NV = @tt)
                ORDER BY NV.MANV";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 100).Value =
                        string.IsNullOrWhiteSpace(keyword) ? "" : "%" + keyword.Trim() + "%";
                    cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 50).Value =
                        string.IsNullOrWhiteSpace(trangThai) ? "" : trangThai;

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvNhanVien.AutoGenerateColumns = true;
                    dgvNhanVien.DataSource = dt;

                    void Col(string name, string header,
                             DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft,
                             bool visible = true)
                    {
                        if (!dgvNhanVien.Columns.Contains(name)) return;
                        dgvNhanVien.Columns[name].HeaderText = header;
                        dgvNhanVien.Columns[name].Visible = visible;
                        dgvNhanVien.Columns[name].DefaultCellStyle.Alignment = align;
                    }

                    Col("MANV", "M\u00e3 NV", DataGridViewContentAlignment.MiddleCenter);
                    Col("TENNV", "H\u1ecd t\u00ean");
                    Col("SDT", "S\u0110T", DataGridViewContentAlignment.MiddleCenter);
                    Col("EMAIL", "Email");
                    Col("TENCV", "Ch\u1ee9c v\u1ee5");
                    Col("TEN_PB", "Ph\u00f2ng ban");
                    Col("TRANGTHAI_NV", "Tr\u1ea1ng th\u00e1i");
                    Col("MACV", "", visible: false);
                    Col("MAPB", "", visible: false);

                    // Tô màu trạng thái
                    foreach (DataGridViewRow row in dgvNhanVien.Rows)
                    {
                        string tt = row.Cells["TRANGTHAI_NV"].Value?.ToString() ?? "";
                        if (tt == TRANG_THAI[0])
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(13, 100, 60);
                        else if (tt == TRANG_THAI[1])
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 50, 50);
                        else
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(140, 100, 20);
                    }

                    UpdateStatCards(dt);
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i danh s\u00e1ch nh\u00e2n vi\u00ean", ex); }
            }
        }

        // ================================================================
        // CLICK HÀNG → ĐIỀN FORM
        // ================================================================
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvNhanVien.Rows[e.RowIndex];
            if (row.Cells["MANV"].Value == null) return;
            _currentManv = row.Cells["MANV"].Value.ToString();
            lblListSub.Text = "Nh\u00e2n vi\u00ean \u0111ang ch\u1ecdn: " + _currentManv;
        }

        // ================================================================
        // THÊM
        // ================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            ClearEditForm();
            _editMode = "ADD";
            txtEManv.Text = GenerateManv();
            cmbETrangThai.SelectedIndex = 0;
            lblEditTitle.Text = "\u25bc  Th\u00eam nh\u00e2n vi\u00ean m\u1edbi: " + txtEManv.Text;
            lblEditTitle.ForeColor = Color.FromArgb(13, 100, 60);
            txtETennv.Focus();
        }

        private string GenerateManv()
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(MANV,3,LEN(MANV)) AS INT)),0)+1 FROM NHANVIEN WHERE ISNUMERIC(SUBSTRING(MANV,3,LEN(MANV)))=1";
            using (var con = new SqlConnection(_conn))
            {
                try { con.Open(); return "NV" + Convert.ToInt32(new SqlCommand(sql, con).ExecuteScalar()).ToString("D3"); }
                catch { return "NV" + DateTime.Now.ToString("mmss"); }
            }
        }

        // ================================================================
        // SỬA
        // ================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentManv)) { Warn("Ch\u1ecdn nh\u00e2n vi\u00ean c\u1ea7n s\u1eeda."); return; }

            var row = dgvNhanVien.CurrentRow;
            _editMode = "EDIT";
            txtEManv.Text = _currentManv;
            txtETennv.Text = row.Cells["TENNV"].Value?.ToString() ?? "";
            txtESdt.Text = row.Cells["SDT"].Value?.ToString() ?? "";
            txtEEmail.Text = row.Cells["EMAIL"].Value?.ToString() ?? "";

            // Chức vụ
            string macv = row.Cells["MACV"].Value?.ToString() ?? "";
            var dtCV = (DataTable)cmbEMacv.DataSource;
            for (int i = 0; i < dtCV.Rows.Count; i++)
                if (dtCV.Rows[i]["MACV"].ToString() == macv) { cmbEMacv.SelectedIndex = i; break; }

            // Phòng ban
            string mapb = row.Cells["MAPB"].Value?.ToString() ?? "";
            var dtPB = (DataTable)cmbEMapb.DataSource;
            for (int i = 0; i < dtPB.Rows.Count; i++)
                if (dtPB.Rows[i]["MAPB"].ToString() == mapb) { cmbEMapb.SelectedIndex = i; break; }

            // Trạng thái
            string tt = row.Cells["TRANGTHAI_NV"].Value?.ToString() ?? "";
            int idx = Array.IndexOf(TRANG_THAI, tt);
            cmbETrangThai.SelectedIndex = idx >= 0 ? idx : 0;

            lblEditTitle.Text = "\u25bc  \u0110ang s\u1eeda: " + _currentManv;
            lblEditTitle.ForeColor = Color.FromArgb(160, 80, 0);
        }

        // ================================================================
        // XÓA
        // ================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentManv)) { Warn("Ch\u1ecdn nh\u00e2n vi\u00ean c\u1ea7n x\u00f3a."); return; }

            // Tên nhân viên
            string ten = dgvNhanVien.CurrentRow?.Cells["TENNV"].Value?.ToString() ?? _currentManv;

            if (MessageBox.Show(
                "X\u00f3a nh\u00e2n vi\u00ean [" + _currentManv + "] " + ten + "?\n\nL\u01b0u \u00fd: n\u1ebfu NV c\u00f3 d\u1eef li\u1ec7u li\u00ean k\u1ebft (h\u00f3a \u0111\u01a1n, \u0111\u01a1n h\u00e0ng...) s\u1ebd kh\u00f4ng x\u00f3a \u0111\u01b0\u1ee3c.",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand("DELETE FROM NHANVIEN WHERE MANV=@M", con);
                    cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = _currentManv;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("X\u00f3a th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _currentManv = ""; ClearEditForm(); LoadNhanVien();
                }
                catch (SqlException ex) { ShowErr("x\u00f3a nh\u00e2n vi\u00ean", ex); }
            }
        }

        // ================================================================
        // LƯU (INSERT / UPDATE)
        // ================================================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_editMode == "NONE") { Warn("Ch\u1ecdn Th\u00eam m\u1edbi ho\u1eb7c S\u1eeda tr\u01b0\u1edbc."); return; }

            string manv = txtEManv.Text.Trim();
            string tennv = txtETennv.Text.Trim();
            string sdt = txtESdt.Text.Trim();
            string email = txtEEmail.Text.Trim();
            string macv = cmbEMacv.SelectedValue?.ToString() ?? "";
            string mapb = cmbEMapb.SelectedValue?.ToString() ?? "";
            string tt = cmbETrangThai.SelectedItem?.ToString() ?? "";

            // Validation
            if (string.IsNullOrEmpty(tennv)) { Warn("Nh\u1eadp h\u1ecd t\u00ean."); txtETennv.Focus(); return; }
            if (string.IsNullOrEmpty(sdt)) { Warn("Nh\u1eadp s\u1ed1 \u0111i\u1ec7n tho\u1ea1i."); txtESdt.Focus(); return; }
            if (string.IsNullOrEmpty(email)) { Warn("Nh\u1eadp email."); txtEEmail.Focus(); return; }
            if (string.IsNullOrEmpty(macv)) { Warn("Ch\u1ecdn ch\u1ee9c v\u1ee5."); cmbEMacv.Focus(); return; }
            if (string.IsNullOrEmpty(mapb)) { Warn("Ch\u1ecdn ph\u00f2ng ban."); cmbEMapb.Focus(); return; }
            if (string.IsNullOrEmpty(tt)) { Warn("Ch\u1ecdn tr\u1ea1ng th\u00e1i."); cmbETrangThai.Focus(); return; }

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd;

                    if (_editMode == "ADD")
                    {
                        cmd = new SqlCommand(@"
                            INSERT INTO NHANVIEN (MANV, TENNV, SDT, EMAIL, MACV, MAPB, TRANGTHAI_NV)
                            VALUES (@M, @TEN, @SDT, @EMAIL, @CV, @PB, @TT)", con);
                        cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = manv;
                    }
                    else
                    {
                        cmd = new SqlCommand(@"
                            UPDATE NHANVIEN SET
                              TENNV=@TEN, SDT=@SDT, EMAIL=@EMAIL,
                              MACV=@CV, MAPB=@PB, TRANGTHAI_NV=@TT
                            WHERE MANV=@M", con);
                        cmd.Parameters.Add("@M", SqlDbType.Char, 10).Value = manv;
                    }

                    cmd.Parameters.Add("@TEN", SqlDbType.NVarChar, 100).Value = tennv;
                    cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 12).Value = sdt;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 100).Value = email;
                    cmd.Parameters.Add("@CV", SqlDbType.Char, 10).Value = macv;
                    cmd.Parameters.Add("@PB", SqlDbType.Char, 10).Value = mapb;
                    cmd.Parameters.Add("@TT", SqlDbType.NVarChar, 50).Value = tt;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        (_editMode == "ADD" ? "Th\u00eam" : "C\u1eadp nh\u1eadt") + " [" + manv + "] th\u00e0nh c\u00f4ng!",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _currentManv = manv;
                    ClearEditForm();
                    LoadNhanVien(txtSearch.Text, GetFilterTT());
                }
                catch (SqlException ex) { ShowErr("l\u01b0u nh\u00e2n vi\u00ean", ex); }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => ClearEditForm();

        // ================================================================
        // TÌM KIẾM & LỌC
        // ================================================================
        private void btnSearch_Click(object sender, EventArgs e)
            => LoadNhanVien(txtSearch.Text, GetFilterTT());

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(sender, e);
        }

        private void cmbFilterTT_SelectedIndexChanged(object sender, EventArgs e)
            => LoadNhanVien(txtSearch.Text, GetFilterTT());

        private string GetFilterTT()
            => cmbFilterTT.SelectedIndex <= 0 ? "" : cmbFilterTT.SelectedItem.ToString();

        // ================================================================
        // TẢI LẠI
        // ================================================================
        private void btnReload_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbFilterTT.SelectedIndex = 0;
            _currentManv = "";
            ClearEditForm();
            LoadNhanVien();
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private void ClearEditForm()
        {
            _editMode = "NONE";
            txtEManv.Text = ""; txtETennv.Text = ""; txtESdt.Text = ""; txtEEmail.Text = "";
            cmbEMacv.SelectedIndex = -1; cmbEMapb.SelectedIndex = -1; cmbETrangThai.SelectedIndex = -1;
            lblEditTitle.Text = "\u25bc  Th\u00f4ng tin nh\u00e2n vi\u00ean  (ch\u1ecdn Th\u00eam m\u1edbi ho\u1eb7c S\u1eeda)";
            lblEditTitle.ForeColor = Color.FromArgb(13, 43, 90);
        }

        private void UpdateStatCards(DataTable dt)
        {
            int total = dt.Rows.Count, active = 0, inactive = 0;
            foreach (DataRow row in dt.Rows)
            {
                string tt = row["TRANGTHAI_NV"]?.ToString() ?? "";
                if (tt == TRANG_THAI[0]) active++;
                else if (tt == TRANG_THAI[1]) inactive++;
            }
            lblStat1Val.Text = total.ToString();
            lblStat2Val.Text = active.ToString();
            lblStat3Val.Text = inactive.ToString();
            lblListSub.Text = "NHANVIEN \u00b7 " + total + " nh\u00e2n vi\u00ean";
        }

        private void ShowErr(string ctx, SqlException ex)
            => MessageBox.Show("L\u1ed7i " + ctx + ":\n" + ex.Message, "L\u1ed7i SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void Warn(string msg)
            => MessageBox.Show(msg, "Thi\u1ebfu th\u00f4ng tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}