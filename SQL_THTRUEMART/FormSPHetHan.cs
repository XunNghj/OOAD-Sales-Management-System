using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormSPHetHan : Form
    {
        private readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        // Cache toàn bộ dữ liệu để filter client-side
        private DataTable _fullData = null;

        public FormSPHetHan()
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
            lblTitle.Text = "TRA CỨU SẢN PHẨM SẮP HẾT HẠN";
            lblSubtitle.Text = "TH True Mart · Cảnh báo HSD · SANPHAM · CT_PHIEUXUAT";
            lblAlert1Lbl.Text = "✘ ĐÃ HẾT HẠN";
            lblAlert2Lbl.Text = "⚠ CÒN ≤ 7 NGÀY";
            lblAlert3Lbl.Text = "⏰ CÒN 8-30 NGÀY";
            lblAlert4Lbl.Text = "TỔNG CẢNH BÁO";
            lblGridTitle.Text = "Danh sách sản phẩm sắp hết hạn";
            lblGridSub.Text = "■ Đỏ = đã hết hạn  ■ Cam = còn ≤ 7 ngày  ■ Vàng = còn 8-30 ngày";
            lblNgayConLai.Text = "Cảnh báo trong (ngày):";
            lblLoaiFilter.Text = "Loại SP:";
            lblMucFilter.Text = "Mức độ:";
            btnViewReport.Text = "🔄 Hiển thị danh sách";
            btnExportNote.Text = "📋 Xuất danh sách";
            lblFooter.Text = "  TH True Mart © 2025 · Cảnh báo HSD · SANPHAM · CT_PHIEUXUAT";
        }

        private void SetHoverEffects()
        {
            var colNav = Color.FromArgb(13, 43, 90);
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnViewReport, Color.FromArgb(25, 65, 120), colNav);
        }

        // ================================================================
        // FORM LOAD
        // ================================================================
        private void FormSPHetHan_Load(object sender, EventArgs e)
        {
            LoadComboLoai();
            LoadComboMuc();
            LoadSanPhamHetHan();
        }

        private void LoadComboLoai()
        {
            cmbLoaiFilter.Items.Clear();
            cmbLoaiFilter.Items.Add("-- Tất cả loại --");
            var dt = Query("SELECT TEN_LOAISP FROM LOAISP ORDER BY TEN_LOAISP");
            if (dt != null) foreach (DataRow row in dt.Rows) cmbLoaiFilter.Items.Add(row["TEN_LOAISP"].ToString());
            cmbLoaiFilter.SelectedIndex = 0;
        }

        private void LoadComboMuc()
        {
            cmbMucFilter.Items.Clear();
            cmbMucFilter.Items.Add("-- Tất cả mức --");
            cmbMucFilter.Items.Add("Đã hết hạn");
            cmbMucFilter.Items.Add("Còn ≤ 7 ngày");
            cmbMucFilter.Items.Add("Còn 8-30 ngày");
            cmbMucFilter.Items.Add("Còn 31+ ngày");
            cmbMucFilter.SelectedIndex = 0;
        }

        // ================================================================
        // LOAD DỮ LIỆU
        // ================================================================
        private void LoadSanPhamHetHan()
        {
            if (!int.TryParse(txtSoNgayConLai.Text.Trim(), out int soNgay) || soNgay <= 0)
            { MessageBox.Show("Nhập số ngày cảnh báo hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            // Thử gọi stored procedure trước
            bool hasSP = false;
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    using (var chk = new SqlCommand("SELECT COUNT(*) FROM sys.objects WHERE type='P' AND name='sp_LayDS_SP_SapHetHan'", con))
                        hasSP = Convert.ToInt32(chk.ExecuteScalar()) > 0;
                }
                catch { }
            }

            if (hasSP)
                LoadViaSP(soNgay);
            else
                LoadViaSQL(soNgay);
        }

        private void LoadViaSP(int soNgay)
        {
            // SP hiện tại không nhận tham số — gọi trực tiếp
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    using (var cmd = new SqlCommand("sp_LayDS_SP_SapHetHan", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Đã xóa phần truyền tham số @SoNgay gây lỗi

                        var dt = new DataTable();
                        new SqlDataAdapter(cmd).Fill(dt);

                        // Thêm cột MucDo nếu chưa có
                        if (!dt.Columns.Contains("MucDo"))
                            AddMucDoColumn(dt);

                        _fullData = dt;
                        ApplyFilterAndShow();
                    }
                }
                catch (SqlException ex) { ShowErr("gọi SP tra cứu HSD", ex); }
            }
        }

        private void LoadViaSQL(int soNgay)
        {
            // Query trực tiếp: tính ngày hết hạn = ngày xuất kho mới nhất + HSDSP
            string sql = @"
                SELECT
                    SP.MASP,
                    SP.TENSP,
                    LSP.TEN_LOAISP,
                    SP.HSDSP                                            AS HSD_Ngay,
                    ISNULL(UltXuat.NgayXuat, GETDATE())                AS NgaySXXuat,
                    DATEADD(DAY, SP.HSDSP,
                        ISNULL(UltXuat.NgayXuat, GETDATE()))           AS NgayHetHan,
                    DATEDIFF(DAY, GETDATE(),
                        DATEADD(DAY, SP.HSDSP,
                            ISNULL(UltXuat.NgayXuat, GETDATE())))      AS HSD_ConLai_Ngay,
                    ISNULL(SP.TRANGTHAI_SP, N'Đang bán')               AS TRANGTHAI_SP,
                    ISNULL(BDG.GIABAN, 0)                              AS GiaBan
                FROM SANPHAM SP
                JOIN LOAISP    LSP ON SP.MA_LOAISP = LSP.MA_LOAISP
                LEFT JOIN BIENDONGGIA BDG
                    ON SP.MASP = BDG.MASP
                   AND BDG.NGAYCAPNHAT_BDG = (
                        SELECT MAX(NGAYCAPNHAT_BDG) FROM BIENDONGGIA WHERE MASP = SP.MASP)
                OUTER APPLY (
                    SELECT TOP 1 PX.NGAYXUAT AS NgayXuat
                    FROM CT_PHIEUXUAT CTPX
                    JOIN PHIEUXUAT PX ON CTPX.MA_PX = PX.MA_PX
                    WHERE CTPX.MASP = SP.MASP
                    ORDER BY PX.NGAYXUAT DESC
                ) UltXuat
                WHERE DATEDIFF(DAY, GETDATE(),
                        DATEADD(DAY, SP.HSDSP,
                            ISNULL(UltXuat.NgayXuat, GETDATE()))) <= @SoNgay
                ORDER BY HSD_ConLai_Ngay ASC";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@SoNgay", SqlDbType.Int).Value = soNgay;
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    AddMucDoColumn(dt);
                    _fullData = dt;
                    ApplyFilterAndShow();
                }
                catch (SqlException ex) { ShowErr("truy vấn HSD", ex); }
            }
        }

        // Thêm cột MucDo dựa theo HSD_ConLai_Ngay
        private void AddMucDoColumn(DataTable dt)
        {
            if (!dt.Columns.Contains("MucDo")) dt.Columns.Add("MucDo", typeof(string));
            if (!dt.Columns.Contains("HSD_ConLai_Ngay")) return;
            foreach (DataRow row in dt.Rows)
            {
                if (row["HSD_ConLai_Ngay"] == DBNull.Value) { row["MucDo"] = "?"; continue; }
                int days = Convert.ToInt32(row["HSD_ConLai_Ngay"]);
                row["MucDo"] = days < 0 ? "Đã hết hạn" :
                               days <= 7 ? "Còn ≤ 7 ngày" :
                               days <= 30 ? "Còn 8-30 ngày" :
                                           "Còn 31+ ngày";
            }
        }

        // ================================================================
        // FILTER + HIỂN THỊ
        // ================================================================
        private void ApplyFilterAndShow()
        {
            if (_fullData == null) return;

            string loaiFilter = cmbLoaiFilter.SelectedIndex <= 0 ? "" : cmbLoaiFilter.SelectedItem.ToString();
            string mucFilter = cmbMucFilter.SelectedIndex <= 0 ? "" : cmbMucFilter.SelectedItem.ToString();

            DataTable view = _fullData.Clone();
            foreach (DataRow row in _fullData.Rows)
            {
                string loai = _fullData.Columns.Contains("TEN_LOAISP") ? row["TEN_LOAISP"]?.ToString() ?? "" : "";
                string muc = row.Table.Columns.Contains("MucDo") ? row["MucDo"]?.ToString() ?? "" : "";
                if (!string.IsNullOrEmpty(loaiFilter) && loai != loaiFilter) continue;
                if (!string.IsNullOrEmpty(mucFilter) && muc != mucFilter) continue;
                view.ImportRow(row);
            }

            dgvSanPham.AutoGenerateColumns = true;
            dgvSanPham.DataSource = view;

            void Col(string n, string h, string fmt = null, bool vis = true,
                     DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
            {
                if (!dgvSanPham.Columns.Contains(n)) return;
                dgvSanPham.Columns[n].HeaderText = h; dgvSanPham.Columns[n].Visible = vis;
                if (fmt != null) dgvSanPham.Columns[n].DefaultCellStyle.Format = fmt;
                dgvSanPham.Columns[n].DefaultCellStyle.Alignment = a;
            }
            Col("MASP", "Mã SP", null, true, DataGridViewContentAlignment.MiddleCenter);
            Col("TENSP", "Tên sản phẩm");
            Col("TEN_LOAISP", "Loại SP");
            Col("HSD_Ngay", "HSD (ngày)", null, true, DataGridViewContentAlignment.MiddleRight);
            Col("NgaySXXuat", "Ngày xuất gần nhất", "dd/MM/yyyy", true, DataGridViewContentAlignment.MiddleCenter);
            Col("NgayHetHan", "Ngày hết hạn", "dd/MM/yyyy", true, DataGridViewContentAlignment.MiddleCenter);
            Col("HSD_ConLai_Ngay", "Còn lại (ngày)", "#,##0", true, DataGridViewContentAlignment.MiddleRight);
            Col("MucDo", "Mức độ", null, true, DataGridViewContentAlignment.MiddleCenter);
            Col("GiaBan", "Giá bán (đ)", "#,##0", true, DataGridViewContentAlignment.MiddleRight);
            Col("TRANGTHAI_SP", "Trạng thái");

            // Ẩn các cột không cần hiển thị
            foreach (DataGridViewColumn dc in dgvSanPham.Columns)
                if (dc.Name == "NgaySanXuat_Xuat") dc.Visible = false;

            UpdateAlertCards(view);
            UpdateGridTitle(view.Rows.Count);
        }

        // ================================================================
        // TÔ MÀU THEO MỨC ĐỘ
        // ================================================================
        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvSanPham.Columns.Contains("HSD_ConLai_Ngay")) return;
            var cellVal = dgvSanPham.Rows[e.RowIndex].Cells["HSD_ConLai_Ngay"].Value;
            if (cellVal == null || cellVal == DBNull.Value) return;

            int days = Convert.ToInt32(cellVal);
            Color bg, fg;
            if (days < 0)
            { bg = Color.FromArgb(255, 220, 220); fg = Color.FromArgb(160, 0, 0); }
            else if (days <= 7)
            { bg = Color.FromArgb(255, 238, 210); fg = Color.FromArgb(160, 80, 0); }
            else if (days <= 30)
            { bg = Color.FromArgb(255, 252, 210); fg = Color.FromArgb(120, 90, 0); }
            else
            { bg = Color.White; fg = Color.FromArgb(40, 50, 65); }

            var row = dgvSanPham.Rows[e.RowIndex];
            row.DefaultCellStyle.BackColor = bg;
            row.DefaultCellStyle.ForeColor = fg;
            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 232, 248);
            row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(13, 43, 90);
        }

        // ================================================================
        // CẬP NHẬT ALERT CARDS
        // ================================================================
        private void UpdateAlertCards(DataTable dt)
        {
            int expired = 0, within7 = 0, within30 = 0;
            if (dt.Columns.Contains("HSD_ConLai_Ngay"))
                foreach (DataRow row in dt.Rows)
                {
                    if (row["HSD_ConLai_Ngay"] == DBNull.Value) continue;
                    int d = Convert.ToInt32(row["HSD_ConLai_Ngay"]);
                    if (d < 0) expired++;
                    else if (d <= 7) within7++;
                    else if (d <= 30) within30++;
                }
            lblAlert1Val.Text = expired.ToString();
            lblAlert2Val.Text = within7.ToString();
            lblAlert3Val.Text = within30.ToString();
            lblAlert4Val.Text = dt.Rows.Count.ToString();
        }

        private void UpdateGridTitle(int count)
        {
            lblGridTitle.Text = "Danh sách sản phẩm sắp hết hạn · " + count + " kết quả";
        }

        // ================================================================
        // EVENTS
        // ================================================================
        private void btnViewReport_Click(object sender, EventArgs e) => LoadSanPhamHetHan();

        private void txtSoNgayConLai_KeyDown(object sender, KeyEventArgs e)
        { if (e.KeyCode == Keys.Enter) LoadSanPhamHetHan(); }

        private void cmbLoaiFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndShow();
        private void cmbMucFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilterAndShow();

        // ================================================================
        // XUẤT DANH SÁCH (copy ra clipboard dạng text)
        // ================================================================
        private void btnExportNote_Click(object sender, EventArgs e)
        {
            if (_fullData == null || _fullData.Rows.Count == 0)
            { MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            var sb = new StringBuilder();
            sb.AppendLine("DANH SÁCH SẢN PHẨM SẮP HẾT HẠN - TH True Mart");
            sb.AppendLine("Xuất ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine(new string('-', 80));
            sb.AppendLine("Mã SP\t\tTên SP\t\t\tCòn lại\tNgày HH\t\tMức độ");
            sb.AppendLine(new string('-', 80));

            foreach (DataRow row in _fullData.Rows)
            {
                string masp = row["MASP"]?.ToString() ?? "";
                string tensp = row["TENSP"]?.ToString() ?? "";
                string conlai = row["HSD_ConLai_Ngay"] != DBNull.Value ? row["HSD_ConLai_Ngay"].ToString() + " ngày" : "?";
                string hh = row["NgayHetHan"] != DBNull.Value ? Convert.ToDateTime(row["NgayHetHan"]).ToString("dd/MM/yyyy") : "?";
                string muc = row.Table.Columns.Contains("MucDo") ? row["MucDo"]?.ToString() ?? "" : "";
                sb.AppendLine($"{masp}\t\t{tensp,-30}\t{conlai,-10}\t{hh}\t{muc}");
            }

            Clipboard.SetText(sb.ToString());
            MessageBox.Show("Dữ liệu đã được copy vào clipboard!\nDán (Ctrl+V) vào Notepad / Excel để lưu.",
                "Xuất thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private DataTable Query(string sql)
        {
            using (var con = new SqlConnection(_conn))
            {
                try { con.Open(); var dt = new DataTable(); new SqlDataAdapter(sql, con).Fill(dt); return dt; }
                catch { return null; }
            }
        }

        private void ShowErr(string ctx, SqlException ex)
            => MessageBox.Show("Lỗi " + ctx + ":\n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}