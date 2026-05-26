using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormChiTiet_HD : Form
    {
        private readonly string connectionString =
           @"Data Source=XUAN-NGHI\SQLEXPRESS;
              Initial Catalog=SQL_THTRUEMART;
              Integrated Security=True;
              TrustServerCertificate=True;";

        public FormChiTiet_HD()
        {
            InitializeComponent();

            // Hover effect nút Tính VAT
            btnTinhVAT.MouseEnter += (s, e) =>
                btnTinhVAT.BackColor = Color.FromArgb(10, 130, 75);
            btnTinhVAT.MouseLeave += (s, e) =>
                btnTinhVAT.BackColor = Color.FromArgb(13, 100, 60);

            // Enter trong txtMaHDCheck → kích nút luôn
            txtMaHDCheck.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) btnTinhVAT.PerformClick();
            };
        }

        private void FormChiTietHD_Load(object sender, EventArgs e)
        {
            LoadBaoCaoNgay();
        }

        // =======================================================
        // A. TẢI BÁO CÁO TỔNG HỢP THEO NGÀY (View)  ← KHÔNG ĐỔI
        // =======================================================
        private void LoadBaoCaoNgay()
        {
            string sqlQuery = "SELECT * FROM V_BAOCAO_DOANHTHU_NGAY ORDER BY Ngay DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvBaoCaoNgay.AutoGenerateColumns = true;
                    dgvBaoCaoNgay.DataSource = dataTable;

                    // ── Đặt tên cột ──────────────────────────────────────
                    if (dgvBaoCaoNgay.Columns.Contains("Ngay"))
                    {
                        dgvBaoCaoNgay.Columns["Ngay"].HeaderText = "Ngày lập HD";
                        dgvBaoCaoNgay.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }

                    if (dgvBaoCaoNgay.Columns.Contains("TongTriGiaTruocThue"))
                        dgvBaoCaoNgay.Columns["TongTriGiaTruocThue"].HeaderText = "Tổng trước thuế";

                    if (dgvBaoCaoNgay.Columns.Contains("TongThanhTien"))
                        dgvBaoCaoNgay.Columns["TongThanhTien"].HeaderText = "Tổng thành tiền";

                    // Định dạng tiền tất cả cột "Tong"
                    foreach (DataGridViewColumn col in dgvBaoCaoNgay.Columns)
                    {
                        if (col.Name.Contains("Tong"))
                        {
                            col.DefaultCellStyle.Format = "#,##0";
                            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }

                    // Căn giữa cột ngày
                    if (dgvBaoCaoNgay.Columns.Contains("Ngay"))
                        dgvBaoCaoNgay.Columns["Ngay"].DefaultCellStyle.Alignment =
                            DataGridViewContentAlignment.MiddleCenter;

                    // ── Cập nhật stat cards ───────────────────────────────
                    UpdateStatCards(dataTable);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi tải báo cáo (View):\n" + ex.Message,
                        "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =======================================================
        // B. TÍNH TOÁN GIÁ TRỊ VAT  ← KHÔNG ĐỔI
        // =======================================================
        private void btnTinhVAT_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHDCheck.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập Mã Hóa đơn cần kiểm tra VAT.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDCheck.Focus();
                return;
            }

            string sqlQuery = "SELECT dbo.fn_TinhThueVAT(@MaHD)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaHD", maHD);
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            decimal vatValue = Convert.ToDecimal(result);
                            txtGiaTriVAT.Text = vatValue.ToString("#,##0");
                            txtGiaTriVAT.BackColor = Color.FromArgb(240, 248, 235);
                            txtGiaTriVAT.ForeColor = Color.FromArgb(13, 100, 60);
                        }
                        else
                        {
                            txtGiaTriVAT.Text = "0";
                            txtGiaTriVAT.BackColor = Color.FromArgb(255, 245, 245);
                            txtGiaTriVAT.ForeColor = Color.FromArgb(160, 40, 40);
                            MessageBox.Show("Không tìm thấy hóa đơn này hoặc hóa đơn không có giá trị.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi gọi Function fn_TinhThueVAT:\n" + ex.Message,
                        "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =======================================================
        // CẬP NHẬT STAT CARDS  ← MỚI THÊM
        // =======================================================
        private void UpdateStatCards(DataTable dt)
        {
            int soNgay = dt.Rows.Count;
            double tongTT = 0;
            double tongDS = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (dt.Columns.Contains("TongTriGiaTruocThue") &&
                    row["TongTriGiaTruocThue"] != DBNull.Value)
                    tongTT += Convert.ToDouble(row["TongTriGiaTruocThue"]);

                if (dt.Columns.Contains("TongThanhTien") &&
                    row["TongThanhTien"] != DBNull.Value)
                    tongDS += Convert.ToDouble(row["TongThanhTien"]);
            }

            lblStat1Val.Text = soNgay.ToString();
            lblStat2Val.Text = tongTT.ToString("#,##0");
            lblStat3Val.Text = tongDS.ToString("#,##0");

            // Cập nhật sub-label lưới
            lblGridSub.Text = $"V_BAOCAO_DOANHTHU_NGAY · {soNgay} ngày · sắp xếp mới nhất trước";

            // Tô ngày doanh thu cao nhất
            HighlightTopRow(dt);
        }

        private void HighlightTopRow(DataTable dt)
        {
            if (!dt.Columns.Contains("TongThanhTien") || dt.Rows.Count == 0) return;

            double max = 0;
            int maxIdx = -1;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["TongThanhTien"] == DBNull.Value) continue;
                double v = Convert.ToDouble(dt.Rows[i]["TongThanhTien"]);
                if (v > max) { max = v; maxIdx = i; }
            }

            if (maxIdx < 0 || maxIdx >= dgvBaoCaoNgay.Rows.Count) return;

            dgvBaoCaoNgay.Rows[maxIdx].DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 235);
            dgvBaoCaoNgay.Rows[maxIdx].DefaultCellStyle.ForeColor = Color.FromArgb(13, 100, 60);
            dgvBaoCaoNgay.Rows[maxIdx].DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }
    }
}