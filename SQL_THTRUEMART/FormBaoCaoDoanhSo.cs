using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormBaoCaoDoanhSo : Form
    {
        private readonly string connectionString =
           @"Data Source=XUAN-NGHI\SQLEXPRESS;
              Initial Catalog=SQL_THTRUEMART;
              Integrated Security=True;
              TrustServerCertificate=True;";

        public FormBaoCaoDoanhSo()
        {
            InitializeComponent();
            // Hover effect cho nút
            btnViewReport.MouseEnter += (s, e) =>
                btnViewReport.BackColor = Color.FromArgb(25, 65, 120);
            btnViewReport.MouseLeave += (s, e) =>
                btnViewReport.BackColor = Color.FromArgb(13, 43, 90);
        }

        private void FormBaoCaoDoanhSo_Load(object sender, EventArgs e)
        {
            txtThang.Text = DateTime.Now.Month.ToString();
            txtNam.Text = DateTime.Now.Year.ToString();
        }

        // =======================================================
        // HÀM XỬ LÝ SỰ KIỆN XEM BÁO CÁO  ← KHÔNG ĐỔI
        // =======================================================
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtThang.Text, out int thang) || thang < 1 || thang > 12)
            {
                MessageBox.Show("Vui lòng nhập Tháng hợp lệ (1–12).",
                    "Lỗi tham số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThang.Focus();
                return;
            }

            if (!int.TryParse(txtNam.Text, out int nam) || nam < 2000)
            {
                MessageBox.Show("Vui lòng nhập Năm hợp lệ (>= 2000).",
                    "Lỗi tham số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNam.Focus();
                return;
            }

            LoadBaoCaoDoanhSo(thang, nam);
        }

        // =======================================================
        // GỌI STORED PROCEDURE sp_BaoCao_DoanhSoNV  ← KHÔNG ĐỔI
        // =======================================================
        private void LoadBaoCaoDoanhSo(int thang, int nam)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_BaoCao_DoanhSoNV", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Thang", thang);
                        command.Parameters.AddWithValue("@Nam", nam);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvBaoCao.AutoGenerateColumns = true;
                        dgvBaoCao.DataSource = dataTable;

                        // ── Đổi tên cột header ──────────────────────────────
                        if (dgvBaoCao.Columns.Contains("MANV"))
                            dgvBaoCao.Columns["MANV"].HeaderText = "Mã NV";

                        if (dgvBaoCao.Columns.Contains("TENNV"))
                            dgvBaoCao.Columns["TENNV"].HeaderText = "Tên nhân viên";

                        if (dgvBaoCao.Columns.Contains("TongSoHoaDon"))
                        {
                            dgvBaoCao.Columns["TongSoHoaDon"].HeaderText = "Số hóa đơn";
                            dgvBaoCao.Columns["TongSoHoaDon"].DefaultCellStyle.Alignment =
                                DataGridViewContentAlignment.MiddleCenter;
                        }

                        if (dgvBaoCao.Columns.Contains("TongDoanhSo"))
                        {
                            dgvBaoCao.Columns["TongDoanhSo"].HeaderText = "Tổng doanh số (đ)";
                            dgvBaoCao.Columns["TongDoanhSo"].DefaultCellStyle.Format = "#,##0";
                            dgvBaoCao.Columns["TongDoanhSo"].DefaultCellStyle.Alignment =
                                DataGridViewContentAlignment.MiddleRight;
                        }

                        // ── Cập nhật stat cards từ DataTable ────────────────
                        UpdateStatCards(dataTable, thang, nam);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi gọi SP báo cáo:\n" + ex.Message,
                        "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không xác định:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =======================================================
        // CẬP NHẬT STAT CARDS SAU KHI TẢI DỮ LIỆU  ← MỚI THÊM
        // =======================================================
        private void UpdateStatCards(DataTable dt, int thang, int nam)
        {
            int soNV = dt.Rows.Count;
            long tongHD = 0;
            double tongDS = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (dt.Columns.Contains("TongSoHoaDon") && row["TongSoHoaDon"] != DBNull.Value)
                    tongHD += Convert.ToInt64(row["TongSoHoaDon"]);
                if (dt.Columns.Contains("TongDoanhSo") && row["TongDoanhSo"] != DBNull.Value)
                    tongDS += Convert.ToDouble(row["TongDoanhSo"]);
            }

            lblStat1Val.Text = soNV.ToString();
            lblStat2Val.Text = tongHD.ToString("#,##0");
            lblStat3Val.Text = tongDS.ToString("#,##0") + " đ";

            // Cập nhật sub-label lưới
            lblGridSub.Text = $"Tháng {thang}/{nam} · {soNV} nhân viên · {tongHD:#,##0} hóa đơn";

            // Tô xen kẽ hàng có doanh số cao nhất
            HighlightTopRow(dt);
        }

        // Tô màu accent dòng doanh số cao nhất
        private void HighlightTopRow(DataTable dt)
        {
            if (!dt.Columns.Contains("TongDoanhSo") || dt.Rows.Count == 0) return;

            double max = 0;
            int maxIdx = -1;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["TongDoanhSo"] == DBNull.Value) continue;
                double v = Convert.ToDouble(dt.Rows[i]["TongDoanhSo"]);
                if (v > max) { max = v; maxIdx = i; }
            }

            if (maxIdx < 0 || maxIdx >= dgvBaoCao.Rows.Count) return;

            dgvBaoCao.Rows[maxIdx].DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 235);
            dgvBaoCao.Rows[maxIdx].DefaultCellStyle.ForeColor = Color.FromArgb(13, 100, 60);
            dgvBaoCao.Rows[maxIdx].DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }
    }
}