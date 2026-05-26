using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormTonKho : Form
    {
        private readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        // Cache toàn bộ để filter client-side
        private DataTable _fullData = null;

        // Ngưỡng cảnh báo tồn thấp
        private const int NGUONG_THAP = 20;

        public FormTonKho()
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
            lblTitle.Text = "B\u00c1O C\u00c1O T\u1ed2N KHO";
            lblSubtitle.Text = "TH True Mart \u00b7 TONKHO \u00b7 KHO \u00b7 SANPHAM";
            lblStat1Lbl.Text = "T\u1ed4NG M\u1eb6T H\u00c0NG";
            lblStat2Lbl.Text = "T\u1ed4NG TR\u1eca GI\u00c1 T\u1ed2N (\u0111)";
            lblStat3Lbl.Text = "SP H\u1eecT H\u00c0NG (T\u1ed2N = 0)";
            lblStat4Lbl.Text = "S\u1ed0 KHO \u0110ANG QU\u1ea2N L\u00dd";
            lblListTitle.Text = "B\u00e1o c\u00e1o t\u1ed3n kho";
            lblListSub.Text = "TONKHO \u00b7 \u25a0 \u0110\u1ecf = h\u1ebft h\u00e0ng  \u25a0 Cam = t\u1ed3n th\u1ea5p (\u2264 " + NGUONG_THAP + ")  \u25a0 Xanh = \u1ed5n";
            lblKhoFilter.Text = "Kho:";
            lblSpFilter.Text = "T\u00ecm SP:";
            lblTonFilter.Text = "T\u1ed3n kho:";
            btnFilter.Text = "\ud83d\udd0d L\u1ecdc";
            btnReload.Text = "\u21ba T\u1ea3i l\u1ea1i";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 TONKHO \u00b7 KHO \u00b7 SANPHAM \u00b7 LOAISP";
        }

        private void SetHoverEffects()
        {
            var colNav = Color.FromArgb(13, 43, 90);
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnFilter, Color.FromArgb(80, 160, 255), Color.FromArgb(56, 139, 253));
            H(btnReload, Color.FromArgb(200, 210, 225), Color.FromArgb(218, 223, 232));
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormTonKho_Load(object sender, EventArgs e)
        {
            LoadKhoCombo();
            LoadTonFilter();
            LoadTonKhoData();
        }

        private void LoadKhoCombo()
        {
            var dt = Query("SELECT MA_KHO, TEN_KHO FROM KHO ORDER BY MA_KHO");
            if (dt == null) return;
            var allRow = dt.NewRow(); allRow["MA_KHO"] = DBNull.Value; allRow["TEN_KHO"] = "-- T\u1ea5t c\u1ea3 kho --";
            dt.Rows.InsertAt(allRow, 0);
            cboKhuVucKho.DataSource = dt; cboKhuVucKho.DisplayMember = "TEN_KHO"; cboKhuVucKho.ValueMember = "MA_KHO"; cboKhuVucKho.SelectedIndex = 0;
        }

        private void LoadTonFilter()
        {
            cboTonFilter.Items.Clear();
            cboTonFilter.Items.Add("-- T\u1ea5t c\u1ea3 --");
            cboTonFilter.Items.Add("H\u1ebft h\u00e0ng (T\u1ed3n = 0)");
            cboTonFilter.Items.Add("T\u1ed3n th\u1ea5p (\u2264 " + NGUONG_THAP + ")");
            cboTonFilter.Items.Add("C\u00f2n h\u00e0ng (T\u1ed3n > 0)");
            cboTonFilter.SelectedIndex = 0;
        }

        // ================================================================
        // LOAD DỮ LIỆU TỒN KHO
        // ================================================================
        private void LoadTonKhoData()
        {
            string sql = @"
                SELECT
                    TK.MA_KHO,
                    K.TEN_KHO,
                    TK.MASP,
                    SP.TENSP,
                    LSP.TEN_LOAISP,
                    TK.TONCK,
                    ISNULL(TK.TRIGIATONCK, 0)  AS TRIGIATONCK,
                    TK.NGAYCN_TK
                FROM TONKHO TK
                JOIN SANPHAM SP   ON TK.MASP    = SP.MASP
                JOIN KHO     K    ON TK.MA_KHO  = K.MA_KHO
                JOIN LOAISP  LSP  ON SP.MA_LOAISP = LSP.MA_LOAISP
                ORDER BY TK.MA_KHO, LSP.TEN_LOAISP, SP.TENSP";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var dt = new DataTable();
                    new SqlDataAdapter(sql, con).Fill(dt);
                    _fullData = dt;
                    ApplyFilterAndShow();
                    UpdateStats(dt);
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i t\u1ed3n kho", ex); }
            }
        }

        // ================================================================
        // FILTER CLIENT-SIDE
        // ================================================================
        private void ApplyFilterAndShow()
        {
            if (_fullData == null) return;

            string maKho = cboKhuVucKho.SelectedValue == null || cboKhuVucKho.SelectedValue == DBNull.Value
                             ? "" : cboKhuVucKho.SelectedValue.ToString();
            string kw = txtSearchSP.Text.Trim().ToLower();
            int tonIdx = cboTonFilter.SelectedIndex;

            DataTable view = _fullData.Clone();
            foreach (DataRow row in _fullData.Rows)
            {
                // Filter kho
                if (!string.IsNullOrEmpty(maKho) && row["MA_KHO"].ToString() != maKho) continue;

                // Filter search SP
                if (!string.IsNullOrEmpty(kw))
                {
                    string tensp = row["TENSP"].ToString().ToLower();
                    string masp = row["MASP"].ToString().ToLower();
                    if (!tensp.Contains(kw) && !masp.Contains(kw)) continue;
                }

                // Filter tồn
                int ton = row["TONCK"] == DBNull.Value ? 0 : Convert.ToInt32(row["TONCK"]);
                if (tonIdx == 1 && ton != 0) continue;           // Hết hàng
                if (tonIdx == 2 && (ton == 0 || ton > NGUONG_THAP)) continue; // Tồn thấp
                if (tonIdx == 3 && ton <= 0) continue;            // Còn hàng

                view.ImportRow(row);
            }

            dgvTonKho.AutoGenerateColumns = true;
            dgvTonKho.DataSource = view;

            void Col(string n, string h, string fmt = null, bool vis = true,
                     DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
            {
                if (!dgvTonKho.Columns.Contains(n)) return;
                dgvTonKho.Columns[n].HeaderText = h; dgvTonKho.Columns[n].Visible = vis;
                if (fmt != null) dgvTonKho.Columns[n].DefaultCellStyle.Format = fmt;
                dgvTonKho.Columns[n].DefaultCellStyle.Alignment = a;
            }
            Col("MA_KHO", "M\u00e3 Kho", null, true, DataGridViewContentAlignment.MiddleCenter);
            Col("TEN_KHO", "T\u00ean Kho");
            Col("MASP", "M\u00e3 SP", null, true, DataGridViewContentAlignment.MiddleCenter);
            Col("TENSP", "T\u00ean s\u1ea3n ph\u1ea9m");
            Col("TEN_LOAISP", "Lo\u1ea1i SP");
            Col("TONCK", "T\u1ed3n cu\u1ed1i k\u1ef3", "#,##0", true, DataGridViewContentAlignment.MiddleRight);
            Col("TRIGIATONCK", "Tr\u1ecb gi\u00e1 t\u1ed3n (\u0111)", "#,##0", true, DataGridViewContentAlignment.MiddleRight);
            Col("NGAYCN_TK", "Ng\u00e0y CN", "dd/MM/yyyy", true, DataGridViewContentAlignment.MiddleCenter);

            // Update count
            lblListTitle.Text = "B\u00e1o c\u00e1o t\u1ed3n kho \u00b7 " + view.Rows.Count + " d\u00f2ng";
        }

        // ================================================================
        // TÔ MÀU THEO TỒN
        // ================================================================
        private void dgvTonKho_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvTonKho.Columns.Contains("TONCK")) return;
            var val = dgvTonKho.Rows[e.RowIndex].Cells["TONCK"].Value;
            if (val == null || val == DBNull.Value) return;

            int ton = Convert.ToInt32(val);
            var row = dgvTonKho.Rows[e.RowIndex];
            if (ton == 0)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 225, 225);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(160, 0, 0);
            }
            else if (ton <= NGUONG_THAP)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 242, 220);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(150, 90, 0);
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.FromArgb(40, 50, 65);
            }
            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 232, 248);
            row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(13, 43, 90);
        }

        // ================================================================
        // CẬP NHẬT STAT CARDS
        // ================================================================
        private void UpdateStats(DataTable dt)
        {
            int totalRows = dt.Rows.Count;
            long tongTriGia = 0;
            int hetHang = 0;

            foreach (DataRow row in dt.Rows)
            {
                int ton = row["TONCK"] == DBNull.Value ? 0 : Convert.ToInt32(row["TONCK"]);
                if (ton == 0) hetHang++;
                if (row["TRIGIATONCK"] != DBNull.Value)
                    tongTriGia += Convert.ToInt64(row["TRIGIATONCK"]);
            }

            // Số kho (distinct)
            var dtKho = new DataTable();
            if (dt.Rows.Count > 0)
            {
                var maKhos = new System.Collections.Generic.HashSet<string>();
                foreach (DataRow row in dt.Rows) maKhos.Add(row["MA_KHO"].ToString());
                lblStat4Val.Text = maKhos.Count.ToString();
            }

            lblStat1Val.Text = totalRows.ToString();
            lblStat2Val.Text = tongTriGia.ToString("#,##0");
            lblStat3Val.Text = hetHang.ToString();
        }

        // ================================================================
        // EVENTS
        // ================================================================
        private void btnFilter_Click(object sender, EventArgs e) => ApplyFilterAndShow();

        private void btnReload_Click(object sender, EventArgs e)
        {
            cboKhuVucKho.SelectedIndex = 0;
            cboTonFilter.SelectedIndex = 0;
            txtSearchSP.Text = "";
            LoadTonKhoData();
        }

        private void cboKhuVucKho_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndShow();
        private void cboTonFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndShow();

        private void txtSearchSP_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) ApplyFilterAndShow(); }

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
    }
}