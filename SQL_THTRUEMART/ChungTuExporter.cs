using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    /// <summary>
    /// Xuất chứng từ nâng cao với màn hình Xem trước (Preview).
    /// Hỗ trợ xuất PDF (thông qua trình In) và Excel (.xls) giữ nguyên định dạng mẫu biểu hoàn hảo.
    /// </summary>
    public static class ChungTuExporter
    {
        private static readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        // Thông tin công ty
        private const string CONG_TY = "CÔNG TY CỔ PHẦN SIÊU THỊ TH TRUEMART";
        private const string DIA_CHI = "Địa chỉ: 123 Đường Nguyễn Văn Linh, Q.7, TP.HCM";
        private const string MST = "Mã số thuế: 0317xxxxxx  |  ĐT: 028-xxxx-xxxx";

        // ================================================================
        // PUBLIC ENTRY POINTS
        // ================================================================

        public static void ExportHoaDon(string maHD)
        {
            var data = LoadHoaDon(maHD);
            if (data == null) return;
            BuildHoaDon(data, out string html, out string excel);
            ShowPreviewAndSave($"HoaDon_{maHD}", html, excel);
        }

        public static void ExportPhieuNhap(string soPN)
        {
            var data = LoadPhieuNhap(soPN);
            if (data == null) return;
            BuildPhieuNhap(data, out string html, out string excel);
            ShowPreviewAndSave($"PhieuNhap_{soPN}", html, excel);
        }

        public static void ExportPhieuXuat(string maPX)
        {
            var data = LoadPhieuXuat(maPX);
            if (data == null) return;
            BuildPhieuXuat(data, out string html, out string excel);
            ShowPreviewAndSave($"PhieuXuat_{maPX}", html, excel);
        }

        public static void ExportPhieuTraHang(string maPTH)
        {
            var data = LoadPhieuTraHang(maPTH);
            if (data == null) return;
            BuildPhieuTraHang(data, out string html, out string excel);
            ShowPreviewAndSave($"PhieuTraHang_{maPTH}", html, excel);
        }

        // ================================================================
        // DATA LOADERS
        // ================================================================

        private static Dictionary<string, object> LoadHoaDon(string maHD)
        {
            string sql = @"
                SELECT HD.MA_HD, HD.NGAYLAPHD, HD.HINHTHUCTT,
                       HD.TRIGIATRUOCTHUE, HD.TONGTIENGIAM, HD.TONGCONGTHANHTIEN,
                       KH.TEN_KH, KH.DIACHI_KH, KH.SDT_KH, KH.MA_KH,
                       TTV.SOTHE,
                       NV.TENNV
                FROM HOADON HD
                JOIN KHACHHANG KH ON HD.MA_KH = KH.MA_KH
                LEFT JOIN THETHANHVIEN TTV ON KH.MA_KH = TTV.MA_KH
                LEFT JOIN PHIEUXUAT PX ON HD.MA_PX = PX.MA_PX
                LEFT JOIN NHANVIEN NV ON PX.MANV = NV.MANV
                WHERE HD.MA_HD = @M";

            string sqlDT = @"
                SELECT SP.TENSP, DVT.TENDVT, 
                       CT.SOLUONG_TRA, 
                       CT.DONGIA_HD, 
                       CT.THANHTIENHD
                FROM CT_HD CT
                JOIN SANPHAM SP ON CT.MASP = SP.MASP
                JOIN DONVITINH DVT ON SP.MADVT = DVT.MADVT
                WHERE CT.MA_HD = @M
                ORDER BY CT.MASP";

            return LoadDocData(maHD, sql, sqlDT, "CT_HD");
        }

        private static Dictionary<string, object> LoadPhieuNhap(string soPN)
        {
            string sql = @"
                SELECT PN.SO_PN, PN.NGAYNHAP, PN.LYDONHAP, PN.TRIGIA_PN, PN.GHICHU_PN,
                       NCC.TEN_NCC, NCC.MA_NCC, NCC.DIACHI_NCC,
                       NV.TENNV, NV.MANV,
                       'KHO TONG' AS TEN_KHO, '' AS MA_KHO
                FROM PHIEUNHAP PN
                JOIN NHACUNGCAP NCC ON PN.MA_NCC = NCC.MA_NCC
                JOIN NHANVIEN   NV  ON PN.MANV   = NV.MANV
                WHERE PN.SO_PN = @M";

            string sqlDT = @"
                SELECT SP.TENSP, DVT.TENDVT,
                       CT.SOLUONGNHAP AS SOLUONG, CT.DONGIA_PN AS DONGIA,
                       CT.THANHTIEN_PN AS THANHTIEN, '' AS GHICHU
                FROM CT_PHIEUNHAP CT
                JOIN SANPHAM SP ON CT.MASP = SP.MASP
                JOIN DONVITINH DVT ON SP.MADVT = DVT.MADVT
                WHERE CT.SO_PN = @M";

            return LoadDocData(soPN, sql, sqlDT, "CT_PN");
        }

        private static Dictionary<string, object> LoadPhieuXuat(string maPX)
        {
            string sql = @"
                SELECT PX.MA_PX, PX.NGAYXUAT, PX.LYDOXUAT, PX.TRIGIA_PX,
                       PX.DIADIEMGH, PX.GHICHU_PX,
                       KHO.TEN_KHO, KHO.MA_KHO,
                       NV.TENNV, NV.MANV
                FROM PHIEUXUAT PX
                JOIN KHO      KHO ON PX.MA_KHO = KHO.MA_KHO
                JOIN NHANVIEN NV  ON PX.MANV   = NV.MANV
                WHERE PX.MA_PX = @M";

            string sqlDT = @"
                SELECT SP.TENSP, DVT.TENDVT,
                       CT.SOLUONGXUAT AS SOLUONG,
                       CT.SOLUONGXUAT AS SOLUONG_THUC,
                       CT.DONGIA_PX AS DONGIA,
                       CT.THANHTIEN_PX AS THANHTIEN, '' AS GHICHU
                FROM CT_PHIEUXUAT CT
                JOIN SANPHAM SP ON CT.MASP = SP.MASP
                JOIN DONVITINH DVT ON SP.MADVT = DVT.MADVT
                WHERE CT.MA_PX = @M";

            return LoadDocData(maPX, sql, sqlDT, "CT_PX");
        }

        private static Dictionary<string, object> LoadPhieuTraHang(string maPTH)
        {
            string sql = @"
                SELECT PTH.MA_PTH, PTH.NGAYTRA, PTH.LYDOTRA,
                       PTH.TONGTIENHOAN, PTH.TRANGTHAI_TRAHANG, PTH.PHUONGTHUCHOAN,
                       PTH.GHICHU_TRAHANG,
                       KH.TEN_KH, KH.MA_KH, KH.DIACHI_KH, KH.SDT_KH,
                       NV.TENNV, NV.MANV
                FROM PHIEUTRAHANG PTH
                JOIN KHACHHANG KH ON PTH.MA_KH = KH.MA_KH
                JOIN NHANVIEN  NV ON PTH.MANV   = NV.MANV
                WHERE PTH.MA_PTH = @M";

            string sqlDT = @"
                SELECT CT.MA_HD AS TEN_SP_OR_HD,
                       N'Phôi' AS TENDVT,
                       CT.SOLUONG_TRA AS SOLUONG,
                       CT.DONGIA_TRA  AS DONGIA,
                       CT.THANHTIEN_TRA AS THANHTIEN, '' AS GHICHU
                FROM CT_PHIEUTRAHANG CT
                WHERE CT.MA_PTH = @M";

            return LoadDocData(maPTH, sql, sqlDT, "CT_PTH");
        }

        private static Dictionary<string, object> LoadDocData(string key, string sqlHeader, string sqlDetail, string dtKey)
        {
            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmdH = new SqlCommand(sqlHeader, con);
                    cmdH.Parameters.Add("@M", SqlDbType.NVarChar, 50).Value = key;
                    var dtH = new DataTable();
                    new SqlDataAdapter(cmdH).Fill(dtH);

                    if (dtH.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu: " + key,
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }

                    var cmdD = new SqlCommand(sqlDetail, con);
                    cmdD.Parameters.Add("@M", SqlDbType.NVarChar, 50).Value = key;
                    var dtD = new DataTable();
                    new SqlDataAdapter(cmdD).Fill(dtD);

                    var d = new Dictionary<string, object> { ["HEADER"] = dtH.Rows[0], [dtKey] = dtD };
                    return d;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu:\n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        // ================================================================
        // DATA PREPARATION & DOC BUILDERS
        // ================================================================

        private static void BuildHoaDon(Dictionary<string, object> data, out string html, out string excel)
        {
            var h = (DataRow)data["HEADER"];
            var dt = (DataTable)data["CT_HD"];

            string maHD = Str(h, "MA_HD");
            string ngay = FormatDate(h, "NGAYLAPHD");
            string tenKH = Str(h, "TEN_KH");
            string diaChiKH = Str(h, "DIACHI_KH");
            string sdtKH = Str(h, "SDT_KH");
            string httt = Str(h, "HINHTHUCTT");
            string maTTV = Str(h, "SOTHE");
            string nvBan = Str(h, "TENNV");
            decimal truocThue = Dec(h, "TRIGIATRUOCTHUE");
            decimal giam = Dec(h, "TONGTIENGIAM");
            decimal tong = Dec(h, "TONGCONGTHANHTIEN");
            decimal thue = tong - truocThue + giam;

            var infoRows = new List<(string, string, string, string)>
            {
                ("Tên khách hàng:", tenKH, "Nhân viên:", nvBan),
                ("Địa chỉ:", diaChiKH, "Số điện thoại:", sdtKH),
                ("Hình thức thanh toán:", httt, "Số thẻ TV:", maTTV),
            };

            var cols = new[] { "Tên sản phẩm", "ĐVT", "Số lượng", "Đơn giá", "Thành tiền", "Ghi chú" };
            Func<DataRow, string[]> rowData = r => new[]{
                Str(r,"TENSP"), Str(r,"TENDVT"), Num(r,"SOLUONG_TRA"), Money(r,"DONGIA_HD"), Money(r,"THANHTIENHD"), ""
            };

            var summaryRows = new List<(string, string, bool)>
            {
                ("Tổng tiền hàng:", Money(truocThue), false),
                ("Thuế VAT (%):", "10%", false),
                ("Tiền thuế GTGT:", Money(thue), false),
                ("Tổng tiền giảm (KM/điểm):", Money(giam), false),
                ("TỔNG CỘNG THANH TOÁN:", Money(tong), true),
            };

            var signs = new[] { "Người mua hàng", "Nhân viên bán hàng" };

            string titleMain = "HÓA ĐƠN BÁN HÀNG";
            string titleSub = $"Số hóa đơn: {maHD}   |   Ngày lập: {ngay}";
            string formInfo1 = "Mẫu số: 01 - BH";
            string formInfo2 = "(TT 200/2014/TT-BTC)";

            GenerateDocs(titleMain, titleSub, formInfo1, formInfo2, infoRows, cols, dt, rowData, summaryRows, AmountInWords(tong), signs, "", out html, out excel);
        }

        private static void BuildPhieuNhap(Dictionary<string, object> data, out string html, out string excel)
        {
            var h = (DataRow)data["HEADER"];
            var dt = (DataTable)data["CT_PN"];

            string soPN = Str(h, "SO_PN");
            string maNCC = Str(h, "MA_NCC");
            string tenNCC = Str(h, "TEN_NCC");
            string dchiNCC = Str(h, "DIACHI_NCC");
            string tenNV = Str(h, "TENNV");
            string maNV = Str(h, "MANV");
            string tenKho = Str(h, "TEN_KHO");
            string lyDo = Str(h, "LYDONHAP");
            string ghiChu = Str(h, "GHICHU_PN");
            decimal triGia = Dec(h, "TRIGIA_PN");

            var infoRows = new List<(string, string, string, string)>
            {
                ("Nhà cung cấp:", tenNCC, "Mã NCC:", maNCC),
                ("Địa chỉ NCC:", dchiNCC, "", ""),
                ("Nhân viên nhập kho:", tenNV, "Mã NV:", maNV),
                ("Kho nhập:", tenKho, "", ""),
                ("Lý do nhập:", lyDo, "", ""),
            };

            var cols = new[] { "Tên hàng hóa", "ĐVT", "Số lượng", "Đơn giá", "Thành tiền", "Ghi chú" };
            Func<DataRow, string[]> rowData = r => new[]{
                Str(r,"TENSP"), Str(r,"TENDVT"), Num(r,"SOLUONG"), Money(r,"DONGIA"), Money(r,"THANHTIEN"), ""
            };

            var summaryRows = new List<(string, string, bool)> { ("Tổng trị giá nhập kho:", Money(triGia), true) };
            var signs = new[] { "Người lập phiếu", "Thủ kho", "Giám đốc / Trưởng phòng" };

            string titleMain = "PHIẾU NHẬP KHO";
            string titleSub = $"Số phiếu: {soPN}   |   Ngày {FormatDMY(h, "NGAYNHAP")}";
            string formInfo1 = "Mẫu số: 01 - VT";
            string formInfo2 = "(TT 200/2014/TT-BTC)";

            GenerateDocs(titleMain, titleSub, formInfo1, formInfo2, infoRows, cols, dt, rowData, summaryRows, AmountInWords(triGia), signs, ghiChu, out html, out excel);
        }

        private static void BuildPhieuXuat(Dictionary<string, object> data, out string html, out string excel)
        {
            var h = (DataRow)data["HEADER"];
            var dt = (DataTable)data["CT_PX"];

            string maPX = Str(h, "MA_PX");
            string tenKho = Str(h, "TEN_KHO");
            string maKho = Str(h, "MA_KHO");
            string ddiemGH = Str(h, "DIADIEMGH");
            string tenNV = Str(h, "TENNV");
            string maNV = Str(h, "MANV");
            string lyDo = Str(h, "LYDOXUAT");
            string ghiChu = Str(h, "GHICHU_PX");
            decimal triGia = Dec(h, "TRIGIA_PX");

            var infoRows = new List<(string, string, string, string)>
            {
                ("Kho xuất:", tenKho, "Mã kho:", maKho),
                ("Địa điểm giao hàng:", ddiemGH, "", ""),
                ("Nhân viên xuất kho:", tenNV, "Mã NV:", maNV),
                ("Lý do xuất:", lyDo, "", ""),
                ("Ghi chú:", ghiChu, "", ""),
            };

            var cols = new[] { "Tên hàng hóa", "ĐVT", "SL yêu cầu", "SL thực xuất", "Đơn giá", "Thành tiền", "Ghi chú" };
            Func<DataRow, string[]> rowData = r => new[]{
                Str(r,"TENSP"), Str(r,"TENDVT"), Num(r,"SOLUONG"), Num(r,"SOLUONG_THUC"), Money(r,"DONGIA"), Money(r,"THANHTIEN"), ""
            };

            var summaryRows = new List<(string, string, bool)> { ("Tổng trị giá xuất kho:", Money(triGia), true) };
            var signs = new[] { "Người lập phiếu", "Thủ kho", "Giám đốc / Trưởng phòng" };

            string titleMain = "PHIẾU XUẤT KHO";
            string titleSub = $"Số phiếu: {maPX}   |   Ngày {FormatDMY(h, "NGAYXUAT")}";
            string formInfo1 = "Mẫu số: 02 - VT";
            string formInfo2 = "(TT 200/2014/TT-BTC)";

            GenerateDocs(titleMain, titleSub, formInfo1, formInfo2, infoRows, cols, dt, rowData, summaryRows, AmountInWords(triGia), signs, "", out html, out excel);
        }

        private static void BuildPhieuTraHang(Dictionary<string, object> data, out string html, out string excel)
        {
            var h = (DataRow)data["HEADER"];
            var dt = (DataTable)data["CT_PTH"];

            string maPTH = Str(h, "MA_PTH");
            string tenKH = Str(h, "TEN_KH");
            string maKH = Str(h, "MA_KH");
            string dchiKH = Str(h, "DIACHI_KH");
            string sdtKH = Str(h, "SDT_KH");
            string tenNV = Str(h, "TENNV");
            string maNV = Str(h, "MANV");
            string lyDo = Str(h, "LYDOTRA");
            string trangThai = Str(h, "TRANGTHAI_TRAHANG");
            string ptHoan = Str(h, "PHUONGTHUCHOAN");
            string ghiChu = Str(h, "GHICHU_TRAHANG");
            decimal tongHoan = Dec(h, "TONGTIENHOAN");

            var infoRows = new List<(string, string, string, string)>
            {
                ("Khách hàng:", tenKH, "Mã KH:", maKH),
                ("Địa chỉ:", dchiKH, "SĐT:", sdtKH),
                ("Nhân viên xử lý:", tenNV, "Mã NV:", maNV),
                ("Lý do trả:", lyDo, "", ""),
                ("Trạng thái:", trangThai, "P.Thức hoàn:", ptHoan),
                ("Ghi chú:", ghiChu, "", ""),
            };

            var cols = new[] { "Mã HĐ / Hàng hóa", "ĐVT", "SL trả", "Đơn giá", "Thành tiền", "Ghi chú" };
            Func<DataRow, string[]> rowData = r => new[]{
                Str(r,"TEN_SP_OR_HD"), Str(r,"TENDVT"), Num(r,"SOLUONG"), Money(r,"DONGIA"), Money(r,"THANHTIEN"), ""
            };

            var summaryRows = new List<(string, string, bool)> { ("Tổng tiền hoàn:", Money(tongHoan), true) };
            var signs = new[] { "Khách hàng", "Nhân viên xử lý", "Giám đốc / Trưởng phòng" };

            string titleMain = "PHIẾU TRẢ HÀNG";
            string titleSub = $"Số phiếu: {maPTH}   |   Ngày {FormatDMY(h, "NGAYTRA")}";
            string formInfo1 = "Cộng hoà xã hội chủ nghĩa Việt Nam";
            string formInfo2 = "Độc lập - Tự do - Hạnh phúc";

            GenerateDocs(titleMain, titleSub, formInfo1, formInfo2, infoRows, cols, dt, rowData, summaryRows, AmountInWords(tongHoan), signs, "", out html, out excel);
        }

        // ================================================================
        // HTML GENERATOR & EXCEL GENERATOR (BẢNG BIỂU ĐẸP)
        // ================================================================

        private static void GenerateDocs(string titleMain, string titleSub, string formInfo1, string formInfo2,
            List<(string, string, string, string)> infoRows,
            string[] cols, DataTable dt, Func<DataRow, string[]> rowData,
            List<(string, string, bool)> summaryRows, string amountInWords, string[] signs, string note,
            out string html, out string excelData)
        {
            // ----------------------------------------------------
            // 1. TẠO HTML (Cho màn hình Xem Trước + Xuất PDF)
            // ----------------------------------------------------
            string titleHtml = $"{titleMain}<br/><span style='font-size:14px; font-weight:normal'>{titleSub.Replace("   |   ", " &nbsp;|&nbsp; ")}</span>";
            string formInfoHtml = $"{formInfo1}<br/>{formInfo2}";

            var sbHtml = new StringBuilder();
            sbHtml.AppendLine("<html><head><meta charset='utf-8'><style>");
            sbHtml.AppendLine("body { font-family: 'Times New Roman', serif; padding: 30px; color: #000; font-size: 15px; background-color: white; }");
            sbHtml.AppendLine(".title { font-size: 24px; font-weight: bold; text-align: center; margin: 30px 0; text-transform: uppercase; }");
            sbHtml.AppendLine(".info-table { width: 100%; margin-bottom: 25px; }");
            sbHtml.AppendLine(".info-table td { padding: 5px; }");
            sbHtml.AppendLine(".data-table { width: 100%; border-collapse: collapse; margin-bottom: 25px; }");
            sbHtml.AppendLine(".data-table th, .data-table td { border: 1px solid #000; padding: 8px; text-align: left; }");
            sbHtml.AppendLine(".data-table th { font-weight: bold; text-align: center; background-color: #f9f9f9; }");
            sbHtml.AppendLine(".signatures { width: 100%; text-align: center; margin-top: 40px; }");
            sbHtml.AppendLine("</style></head><body>");

            sbHtml.AppendLine("<table style='width:100%; border-bottom: 2px solid #000; margin-bottom: 20px;'><tr>");
            sbHtml.AppendLine($"<td style='text-align:left; padding-bottom:10px;'><div style='font-size:16px; font-weight:bold;'>{CONG_TY}</div><div>{DIA_CHI}</div><div>{MST}</div></td>");
            sbHtml.AppendLine($"<td style='text-align:right; font-style:italic;' valign='top'>{formInfoHtml}</td>");
            sbHtml.AppendLine("</tr></table>");

            sbHtml.AppendLine($"<div class='title'>{titleHtml}</div>");

            sbHtml.AppendLine("<table class='info-table'>");
            foreach (var (l1, v1, l2, v2) in infoRows)
            {
                sbHtml.AppendLine($"<tr><td style='width:18%'>{l1}</td><td style='width:32%'><b>{v1}</b></td><td style='width:18%'>{l2}</td><td style='width:32%'><b>{v2}</b></td></tr>");
            }
            sbHtml.AppendLine("</table>");

            sbHtml.AppendLine("<table class='data-table'><thead><tr>");
            sbHtml.AppendLine("<th style='width:5%; text-align:center'>STT</th>");
            foreach (var c in cols) sbHtml.AppendLine($"<th>{c}</th>");
            sbHtml.AppendLine("</tr></thead><tbody>");

            int j = 1;
            foreach (DataRow row in dt.Rows)
            {
                sbHtml.AppendLine("<tr>");
                sbHtml.AppendLine($"<td style='text-align:center'>{j++}</td>");
                var cells = rowData(row);
                foreach (var cell in cells) sbHtml.AppendLine($"<td>{cell}</td>");
                sbHtml.AppendLine("</tr>");
            }
            sbHtml.AppendLine("</tbody></table>");

            sbHtml.AppendLine("<table style='width:100%; margin-bottom: 20px;'><tr><td style='width:40%' valign='top'>");
            if (!string.IsNullOrEmpty(note)) sbHtml.AppendLine($"<b>Ghi chú:</b><br/>{note.Replace("\n", "<br/>")}");
            sbHtml.AppendLine("</td><td style='width:60%' align='right'>");
            sbHtml.AppendLine("<table style='width:100%; border-collapse: collapse;'>");
            foreach (var (label, val, bold) in summaryRows)
            {
                string fw = bold ? "font-weight:bold; font-size:17px;" : "";
                sbHtml.AppendLine($"<tr><td style='text-align:right; padding:5px; {fw}'>{label}</td><td style='text-align:right; padding:5px; {fw}'>{val}</td></tr>");
            }
            sbHtml.AppendLine("</table></td></tr></table>");

            if (!string.IsNullOrEmpty(amountInWords))
                sbHtml.AppendLine($"<div style='font-style: italic; margin-bottom: 30px;'>Số tiền bằng chữ: <b>{amountInWords}</b></div>");

            sbHtml.AppendLine("<table class='signatures'><tr>");
            foreach (var s in signs) sbHtml.AppendLine($"<td style='width:{100 / signs.Length}%' valign='top'><b>{s}</b><br/><i>(Ký, ghi rõ họ tên)</i><br/><br/><br/><br/><br/></td>");
            sbHtml.AppendLine("</tr></table>");

            sbHtml.AppendLine("</body></html>");
            html = sbHtml.ToString();


            // ----------------------------------------------------
            // 2. TẠO DỮ LIỆU EXCEL (HTML Bảng biểu Mẫu chuẩn .xls)
            // ----------------------------------------------------
            var sbXls = new StringBuilder();
            sbXls.AppendLine("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
            sbXls.AppendLine("<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            sbXls.AppendLine("<style>");
            sbXls.AppendLine(".b { font-weight: bold; }");
            sbXls.AppendLine(".c { text-align: center; }");
            sbXls.AppendLine(".r { text-align: right; }");
            sbXls.AppendLine(".i { font-style: italic; }");
            sbXls.AppendLine(".border td, .border th { border: 1px solid windowtext; }");
            sbXls.AppendLine("</style></head><body>");

            int totalCols = cols.Length + 1;
            sbXls.AppendLine("<table style=\"border-collapse: collapse; font-family: 'Times New Roman'; font-size: 12pt;\">");

            // Header Công ty
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols - 2}\" class=\"b\">{CONG_TY}</td><td colspan=\"2\" class=\"r b\">{formInfo1}</td></tr>");
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols - 2}\">{DIA_CHI}</td><td colspan=\"2\" class=\"r i\">{formInfo2}</td></tr>");
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\">{MST}</td></tr>");
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\"></td></tr>");

            // Tiêu đề
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\" class=\"c b\" style=\"font-size: 16pt;\">{titleMain}</td></tr>");
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\" class=\"c i\">{titleSub.Replace("   |   ", " | ")}</td></tr>");
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\"></td></tr>");

            // Khối Thông tin
            foreach (var (l1, v1, l2, v2) in infoRows)
            {
                int colSpanV1 = Math.Max(1, totalCols / 2 - 1);
                int colSpanV2 = totalCols - 1 - colSpanV1 - 1;
                if (colSpanV2 < 1) colSpanV2 = 1;

                sbXls.AppendLine($"<tr><td>{l1}</td><td colspan=\"{colSpanV1}\" class=\"b\">{v1}</td><td>{l2}</td><td colspan=\"{colSpanV2}\" class=\"b\">{v2}</td></tr>");
            }
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\"></td></tr>");

            // Tiêu đề Bảng dữ liệu
            sbXls.AppendLine("<tr class=\"border\" style=\"background-color: #e2e2e2;\">");
            sbXls.AppendLine("<th class=\"c b\">STT</th>");
            foreach (var c in cols) sbXls.AppendLine($"<th class=\"b\">{c}</th>");
            sbXls.AppendLine("</tr>");

            // Dòng dữ liệu (có viền)
            int idx = 1;
            foreach (DataRow row in dt.Rows)
            {
                sbXls.AppendLine("<tr class=\"border\">");
                sbXls.AppendLine($"<td class=\"c\">{idx++}</td>");
                var cells = rowData(row);
                foreach (var c in cells) sbXls.AppendLine($"<td>{c}</td>");
                sbXls.AppendLine("</tr>");
            }
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\"></td></tr>");

            // Ghi chú và Tổng kết
            if (!string.IsNullOrEmpty(note))
                sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\" class=\"i\">Ghi chú: {note}</td></tr>");

            foreach (var (label, val, bold) in summaryRows)
            {
                string css = bold ? "b r" : "r";
                sbXls.AppendLine($"<tr><td colspan=\"{totalCols - 1}\" class=\"{css}\">{label}</td><td class=\"{css}\">{val}</td></tr>");
            }

            // Số tiền bằng chữ
            if (!string.IsNullOrEmpty(amountInWords))
            {
                sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\" class=\"i\">Số tiền bằng chữ: <span class=\"b\">{amountInWords}</span></td></tr>");
            }
            sbXls.AppendLine($"<tr><td colspan=\"{totalCols}\"></td></tr>");

            // Chữ ký (chia đều cột)
            sbXls.AppendLine("<tr>");
            int sigWidth = totalCols / signs.Length;
            int extra = totalCols % signs.Length;
            for (int s = 0; s < signs.Length; s++)
            {
                int span = sigWidth + (s == signs.Length - 1 ? extra : 0);
                sbXls.AppendLine($"<td colspan=\"{span}\" class=\"c b\">{signs[s]}</td>");
            }
            sbXls.AppendLine("</tr>");
            sbXls.AppendLine("<tr>");
            for (int s = 0; s < signs.Length; s++)
            {
                int span = sigWidth + (s == signs.Length - 1 ? extra : 0);
                sbXls.AppendLine($"<td colspan=\"{span}\" class=\"c i\">(Ký, ghi rõ họ tên)</td>");
            }
            sbXls.AppendLine("</tr>");

            sbXls.AppendLine("</table></body></html>");
            excelData = sbXls.ToString();
        }

        private static void ShowPreviewAndSave(string docId, string htmlContent, string excelContent)
        {
            Form f = new Form
            {
                Text = "Xem trước chứng từ - " + docId,
                Width = 950,
                Height = 750,
                StartPosition = FormStartPosition.CenterScreen
            };

            Panel pnlTop = new Panel { Dock = DockStyle.Top, Height = 65, BackColor = Color.FromArgb(240, 244, 248) };
            Label lblHint = new Label
            {
                Text = "Bạn đang xem trước chứng từ. Hãy chọn định dạng để lưu:",
                AutoSize = true,
                Left = 20,
                Top = 22,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 40, 60)
            };

            Button btnPdf = new Button { Text = "📄 Lưu dạng PDF", Left = 460, Top = 15, Width = 140, Height = 36, BackColor = Color.FromArgb(200, 60, 60), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, Font = new Font("Segoe UI", 9f, FontStyle.Bold) };
            Button btnExcel = new Button { Text = "📊 Lưu dạng Excel (.xls)", Left = 610, Top = 15, Width = 190, Height = 36, BackColor = Color.FromArgb(20, 120, 70), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand, Font = new Font("Segoe UI", 9f, FontStyle.Bold) };
            btnPdf.FlatAppearance.BorderSize = 0;
            btnExcel.FlatAppearance.BorderSize = 0;

            pnlTop.Controls.AddRange(new Control[] { lblHint, btnPdf, btnExcel });

            WebBrowser wb = new WebBrowser { Dock = DockStyle.Fill, DocumentText = htmlContent };

            f.Controls.Add(wb);
            f.Controls.Add(pnlTop);

            btnPdf.Click += (s, e) => {
                // Gọi giao diện Print của WebBrowser, từ đây có thể chọn "Microsoft Print to PDF" hoặc in trực tiếp ra máy in cực kỳ đẹp
                wb.ShowPrintDialog();
            };

            btnExcel.Click += (s, e) => {
                // LƯU Ý: Xuất file đuôi .xls để Excel tự động render HTML thành bảng biểu hoàn hảo
                string xlsPath = GetSavePath(docId, "Excel Document (*.xls)|*.xls", ".xls");
                if (xlsPath != null)
                {
                    File.WriteAllText(xlsPath, excelContent, Encoding.UTF8);
                    OpenFile(xlsPath);
                }
            };

            f.ShowDialog();
        }

        // ================================================================
        // UTILITY METHODS
        // ================================================================

        private static string GetSavePath(string suggestion, string filter, string defaultExt)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Title = "Lưu chứng từ";
                dlg.Filter = filter;
                dlg.FileName = suggestion + "_" + DateTime.Now.ToString("yyyyMMdd") + defaultExt;
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : null;
            }
        }

        private static void OpenFile(string path)
        {
            try { Process.Start(new ProcessStartInfo(path) { UseShellExecute = true }); }
            catch { MessageBox.Show("File đã lưu tại:\n" + path, "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private static string Str(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col)) return "";
            return r[col] == DBNull.Value ? "" : r[col].ToString().Trim();
        }

        private static decimal Dec(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col) || r[col] == DBNull.Value) return 0;
            return Convert.ToDecimal(r[col]);
        }

        private static string Money(DataRow r, string col) => Money(Dec(r, col));
        private static string Money(decimal v) => v.ToString("#,##0") + " đ";

        private static string Num(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col) || r[col] == DBNull.Value) return "0";
            return Convert.ToDecimal(r[col]).ToString("#,##0");
        }

        private static string FormatDate(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col) || r[col] == DBNull.Value) return "........";
            return Convert.ToDateTime(r[col]).ToString("dd/MM/yyyy");
        }

        private static string FormatDMY(DataRow r, string col)
        {
            if (!r.Table.Columns.Contains(col) || r[col] == DBNull.Value) return "......... tháng ......... năm .........";
            var d = Convert.ToDateTime(r[col]);
            return $"{d.Day} tháng {d.Month} năm {d.Year}";
        }

        private static string AmountInWords(decimal amount)
        {
            if (amount == 0) return "Không đồng";
            long v = (long)Math.Round(amount);
            return v.ToString("#,##0") + " đồng";
        }
    }
}