namespace SQL_THTRUEMART
{
    partial class FormTheThanhVien
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlStat1 = new System.Windows.Forms.Panel();
            this.lblStat1Val = new System.Windows.Forms.Label();
            this.lblStat1Lbl = new System.Windows.Forms.Label();
            this.pnlStat2 = new System.Windows.Forms.Panel();
            this.lblStat2Val = new System.Windows.Forms.Label();
            this.lblStat2Lbl = new System.Windows.Forms.Label();
            this.pnlStat3 = new System.Windows.Forms.Panel();
            this.lblStat3Val = new System.Windows.Forms.Label();
            this.lblStat3Lbl = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            // LEFT — danh sách KH
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftHead = new System.Windows.Forms.Panel();
            this.lblLeftTitle = new System.Windows.Forms.Label();
            this.txtSearchSDT = new System.Windows.Forms.TextBox();
            this.btnSearchKH = new System.Windows.Forms.Button();
            this.cmbLoaiKHFilter = new System.Windows.Forms.ComboBox();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            // splitter
            this.splitter = new System.Windows.Forms.Splitter();
            // RIGHT — thẻ thành viên
            this.pnlRight = new System.Windows.Forms.Panel();
            // Card thông tin
            this.pnlCardInfo = new System.Windows.Forms.Panel();
            this.lblCardTitle = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblLoaiKH = new System.Windows.Forms.Label();
            this.txtLoaiKH = new System.Windows.Forms.TextBox();
            this.lblMaTTV = new System.Windows.Forms.Label();
            this.txtMaTTV = new System.Windows.Forms.TextBox();
            this.lblNgayCap = new System.Windows.Forms.Label();
            this.txtNgayCap = new System.Windows.Forms.TextBox();
            this.lblDiemHT = new System.Windows.Forms.Label();
            this.txtDiemHienTai = new System.Windows.Forms.TextBox();
            // Tích điểm
            this.pnlDiem = new System.Windows.Forms.Panel();
            this.lblDiemTitle = new System.Windows.Forms.Label();
            this.lblTongTienGD = new System.Windows.Forms.Label();
            this.txtTongTienGiaoDich = new System.Windows.Forms.TextBox();
            this.lblDiemSeThem = new System.Windows.Forms.Label();
            this.txtDiemSeThem = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnCapNhatDiem = new System.Windows.Forms.Button();
            // Lịch sử HĐ
            this.pnlHD = new System.Windows.Forms.Panel();
            this.lblHDTitle = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            // Footer
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlStat1.SuspendLayout(); this.pnlStat2.SuspendLayout(); this.pnlStat3.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlLeft.SuspendLayout(); this.pnlLeftHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.pnlRight.SuspendLayout(); this.pnlCardInfo.SuspendLayout();
            this.pnlDiem.SuspendLayout(); this.pnlHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            var colNav = System.Drawing.Color.FromArgb(13, 43, 90);
            var colBg = System.Drawing.Color.FromArgb(245, 247, 251);
            var colWh = System.Drawing.Color.White;
            var fInp = new System.Drawing.Font("Segoe UI", 9F);
            var fLbl = new System.Drawing.Font("Segoe UI", 8.5F);
            var colLbl = System.Drawing.Color.FromArgb(100, 110, 125);
            var colInp = System.Drawing.Color.FromArgb(250, 251, 253);
            var colRO = System.Drawing.Color.FromArgb(235, 239, 246);
            var bs = System.Windows.Forms.BorderStyle.FixedSingle;

            // HEADER
            this.pnlHeader.BackColor = colNav; this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top; this.pnlHeader.Height = 72; this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Controls.Add(this.lblSubtitle); this.pnlHeader.Controls.Add(this.lblTitle);
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblTitle.ForeColor = colWh; this.lblTitle.Location = new System.Drawing.Point(28, 12); this.lblTitle.Text = "QUAN LY THE THANH VIEN";
            this.lblSubtitle.AutoSize = true; this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 190, 230); this.lblSubtitle.Location = new System.Drawing.Point(30, 42); this.lblSubtitle.Text = "TH True Mart - KHACHHANG - THETHANHVIEN - LOAIKH - HOADON";

            // STATS
            this.pnlStats.BackColor = colBg; this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top; this.pnlStats.Height = 76; this.pnlStats.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlStats.Controls.Add(this.pnlStat3); this.pnlStats.Controls.Add(this.pnlStat2); this.pnlStats.Controls.Add(this.pnlStat1);

            this.pnlStat1.BackColor = colWh; this.pnlStat1.Size = new System.Drawing.Size(200, 60); this.pnlStat1.Location = new System.Drawing.Point(16, 8); this.pnlStat1.Controls.Add(this.lblStat1Lbl); this.pnlStat1.Controls.Add(this.lblStat1Val);
            this.lblStat1Lbl.AutoSize = true; this.lblStat1Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblStat1Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblStat1Lbl.Location = new System.Drawing.Point(12, 7); this.lblStat1Lbl.Text = "THANH VIEN";
            this.lblStat1Val.AutoSize = true; this.lblStat1Val.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.lblStat1Val.ForeColor = colNav; this.lblStat1Val.Location = new System.Drawing.Point(12, 24); this.lblStat1Val.Name = "lblStat1Val"; this.lblStat1Val.Text = "...";

            this.pnlStat2.BackColor = colWh; this.pnlStat2.Size = new System.Drawing.Size(200, 60); this.pnlStat2.Location = new System.Drawing.Point(228, 8); this.pnlStat2.Controls.Add(this.lblStat2Lbl); this.pnlStat2.Controls.Add(this.lblStat2Val);
            this.lblStat2Lbl.AutoSize = true; this.lblStat2Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblStat2Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblStat2Lbl.Location = new System.Drawing.Point(12, 7); this.lblStat2Lbl.Text = "TONG DIEM TICH LUY";
            this.lblStat2Val.AutoSize = true; this.lblStat2Val.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.lblStat2Val.ForeColor = System.Drawing.Color.FromArgb(13, 100, 60); this.lblStat2Val.Location = new System.Drawing.Point(12, 24); this.lblStat2Val.Name = "lblStat2Val"; this.lblStat2Val.Text = "...";

            this.pnlStat3.BackColor = colWh; this.pnlStat3.Size = new System.Drawing.Size(200, 60); this.pnlStat3.Location = new System.Drawing.Point(440, 8); this.pnlStat3.Controls.Add(this.lblStat3Lbl); this.pnlStat3.Controls.Add(this.lblStat3Val);
            this.lblStat3Lbl.AutoSize = true; this.lblStat3Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblStat3Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblStat3Lbl.Location = new System.Drawing.Point(12, 7); this.lblStat3Lbl.Text = "KHACH CHUA CO THE";
            this.lblStat3Val.AutoSize = true; this.lblStat3Val.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.lblStat3Val.ForeColor = System.Drawing.Color.FromArgb(160, 90, 0); this.lblStat3Val.Location = new System.Drawing.Point(12, 24); this.lblStat3Val.Name = "lblStat3Val"; this.lblStat3Val.Text = "...";

            // BODY
            this.pnlBody.BackColor = colBg; this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Controls.Add(this.pnlRight); this.pnlBody.Controls.Add(this.splitter); this.pnlBody.Controls.Add(this.pnlLeft);

            // ── LEFT ─────────────────────────────────────────────────
            this.pnlLeft.BackColor = colBg; this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left; this.pnlLeft.Width = 380;
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(8, 8, 4, 8);
            this.pnlLeft.Controls.Add(this.dgvKhachHang); this.pnlLeft.Controls.Add(this.pnlLeftHead);

            this.pnlLeftHead.BackColor = colWh; this.pnlLeftHead.Dock = System.Windows.Forms.DockStyle.Top; this.pnlLeftHead.Height = 94;
            this.pnlLeftHead.Padding = new System.Windows.Forms.Padding(10, 8, 10, 6);
            this.pnlLeftHead.Controls.Add(this.lblLeftTitle);
            this.pnlLeftHead.Controls.Add(this.cmbLoaiKHFilter);
            this.pnlLeftHead.Controls.Add(this.btnSearchKH);
            this.pnlLeftHead.Controls.Add(this.txtSearchSDT);

            this.lblLeftTitle.AutoSize = true; this.lblLeftTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold); this.lblLeftTitle.ForeColor = colNav; this.lblLeftTitle.Location = new System.Drawing.Point(10, 8); this.lblLeftTitle.Text = "Danh sach khach hang";

            this.txtSearchSDT.Font = fInp; this.txtSearchSDT.Location = new System.Drawing.Point(10, 34); this.txtSearchSDT.Size = new System.Drawing.Size(188, 26); this.txtSearchSDT.BorderStyle = bs; this.txtSearchSDT.BackColor = colInp; this.txtSearchSDT.Name = "txtSearchSDT";
            this.txtSearchSDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchSDT_KeyDown);

            this.btnSearchKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSearchKH.FlatAppearance.BorderSize = 0; this.btnSearchKH.BackColor = System.Drawing.Color.FromArgb(56, 139, 253); this.btnSearchKH.ForeColor = colWh; this.btnSearchKH.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.btnSearchKH.Location = new System.Drawing.Point(204, 34); this.btnSearchKH.Size = new System.Drawing.Size(60, 26); this.btnSearchKH.Text = "Tim"; this.btnSearchKH.Cursor = System.Windows.Forms.Cursors.Hand; this.btnSearchKH.Click += new System.EventHandler(this.btnSearchKH_Click);

            this.cmbLoaiKHFilter.Font = fInp; this.cmbLoaiKHFilter.Location = new System.Drawing.Point(10, 64); this.cmbLoaiKHFilter.Size = new System.Drawing.Size(254, 26); this.cmbLoaiKHFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbLoaiKHFilter.Name = "cmbLoaiKHFilter"; this.cmbLoaiKHFilter.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiKHFilter_SelectedIndexChanged);

            // Grid KH
            this.dgvKhachHang.AllowUserToAddRows = false; this.dgvKhachHang.AllowUserToDeleteRows = false; this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.BackgroundColor = colWh; this.dgvKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKhachHang.RowHeadersVisible = false; this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing; this.dgvKhachHang.ColumnHeadersHeight = 32; this.dgvKhachHang.RowTemplate.Height = 30;
            this.dgvKhachHang.GridColor = System.Drawing.Color.FromArgb(228, 232, 240); this.dgvKhachHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKhachHang.EnableHeadersVisualStyles = false; this.dgvKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvKhachHang.ColumnHeadersDefaultCellStyle.BackColor = colNav; this.dgvKhachHang.ColumnHeadersDefaultCellStyle.ForeColor = colWh; this.dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.dgvKhachHang.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0); this.dgvKhachHang.ColumnHeadersDefaultCellStyle.SelectionBackColor = colNav;
            this.dgvKhachHang.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.dgvKhachHang.DefaultCellStyle.BackColor = colWh; this.dgvKhachHang.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 232, 248); this.dgvKhachHang.DefaultCellStyle.SelectionForeColor = colNav; this.dgvKhachHang.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvKhachHang.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253); this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_CellClick);

            // SPLITTER
            this.splitter.BackColor = System.Drawing.Color.FromArgb(220, 228, 240); this.splitter.Dock = System.Windows.Forms.DockStyle.Left; this.splitter.Width = 3;

            // ── RIGHT ────────────────────────────────────────────────
            this.pnlRight.BackColor = colBg; this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlRight.Padding = new System.Windows.Forms.Padding(6, 8, 8, 8);
            this.pnlRight.Controls.Add(this.pnlHD); this.pnlRight.Controls.Add(this.pnlDiem); this.pnlRight.Controls.Add(this.pnlCardInfo);

            // Card thông tin KH + thẻ TV
            this.pnlCardInfo.BackColor = colWh; this.pnlCardInfo.Dock = System.Windows.Forms.DockStyle.Top; this.pnlCardInfo.Height = 130;
            this.pnlCardInfo.Controls.Add(this.lblCardTitle);
            this.pnlCardInfo.Controls.Add(this.lblMaKH); this.pnlCardInfo.Controls.Add(this.txtMaKH);
            this.pnlCardInfo.Controls.Add(this.lblTenKH); this.pnlCardInfo.Controls.Add(this.txtTenKH);
            this.pnlCardInfo.Controls.Add(this.lblSDT); this.pnlCardInfo.Controls.Add(this.txtSDT);
            this.pnlCardInfo.Controls.Add(this.lblDiaChi); this.pnlCardInfo.Controls.Add(this.txtDiaChi);
            this.pnlCardInfo.Controls.Add(this.lblLoaiKH); this.pnlCardInfo.Controls.Add(this.txtLoaiKH);
            this.pnlCardInfo.Controls.Add(this.lblMaTTV); this.pnlCardInfo.Controls.Add(this.txtMaTTV);
            this.pnlCardInfo.Controls.Add(this.lblNgayCap); this.pnlCardInfo.Controls.Add(this.txtNgayCap);
            this.pnlCardInfo.Controls.Add(this.lblDiemHT); this.pnlCardInfo.Controls.Add(this.txtDiemHienTai);

            this.lblCardTitle.AutoSize = true; this.lblCardTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold); this.lblCardTitle.ForeColor = colNav; this.lblCardTitle.Location = new System.Drawing.Point(14, 8); this.lblCardTitle.Name = "lblCardTitle"; this.lblCardTitle.Text = "Thong tin the thanh vien";

            // Row 1: MaKH | TenKH | SDT
            this.lblMaKH.AutoSize = true; this.lblMaKH.Font = fLbl; this.lblMaKH.ForeColor = colLbl; this.lblMaKH.Location = new System.Drawing.Point(14, 28); this.lblMaKH.Text = "Ma KH";
            this.txtMaKH.Font = fInp; this.txtMaKH.Location = new System.Drawing.Point(14, 44); this.txtMaKH.Size = new System.Drawing.Size(80, 26); this.txtMaKH.BorderStyle = bs; this.txtMaKH.BackColor = colRO; this.txtMaKH.ReadOnly = true; this.txtMaKH.Name = "txtMaKH";

            this.lblTenKH.AutoSize = true; this.lblTenKH.Font = fLbl; this.lblTenKH.ForeColor = colLbl; this.lblTenKH.Location = new System.Drawing.Point(108, 28); this.lblTenKH.Text = "Ho ten";
            this.txtTenKH.Font = fInp; this.txtTenKH.Location = new System.Drawing.Point(108, 44); this.txtTenKH.Size = new System.Drawing.Size(200, 26); this.txtTenKH.BorderStyle = bs; this.txtTenKH.BackColor = colRO; this.txtTenKH.ReadOnly = true; this.txtTenKH.Name = "txtTenKH";

            this.lblSDT.AutoSize = true; this.lblSDT.Font = fLbl; this.lblSDT.ForeColor = colLbl; this.lblSDT.Location = new System.Drawing.Point(322, 28); this.lblSDT.Text = "SDT";
            this.txtSDT.Font = fInp; this.txtSDT.Location = new System.Drawing.Point(322, 44); this.txtSDT.Size = new System.Drawing.Size(130, 26); this.txtSDT.BorderStyle = bs; this.txtSDT.BackColor = colRO; this.txtSDT.ReadOnly = true; this.txtSDT.Name = "txtSDT";

            this.lblDiaChi.AutoSize = true; this.lblDiaChi.Font = fLbl; this.lblDiaChi.ForeColor = colLbl; this.lblDiaChi.Location = new System.Drawing.Point(466, 28); this.lblDiaChi.Text = "Dia chi";
            this.txtDiaChi.Font = fInp; this.txtDiaChi.Location = new System.Drawing.Point(466, 44); this.txtDiaChi.Size = new System.Drawing.Size(250, 26); this.txtDiaChi.BorderStyle = bs; this.txtDiaChi.BackColor = colRO; this.txtDiaChi.ReadOnly = true; this.txtDiaChi.Name = "txtDiaChi";

            // Row 2: LoaiKH | MaTTV | NgayCap | DiemHT
            this.lblLoaiKH.AutoSize = true; this.lblLoaiKH.Font = fLbl; this.lblLoaiKH.ForeColor = colLbl; this.lblLoaiKH.Location = new System.Drawing.Point(14, 80); this.lblLoaiKH.Text = "Hang thanh vien";
            this.txtLoaiKH.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold); this.txtLoaiKH.Location = new System.Drawing.Point(14, 96); this.txtLoaiKH.Size = new System.Drawing.Size(150, 26); this.txtLoaiKH.BorderStyle = bs; this.txtLoaiKH.BackColor = System.Drawing.Color.FromArgb(220, 232, 248); this.txtLoaiKH.ForeColor = colNav; this.txtLoaiKH.ReadOnly = true; this.txtLoaiKH.Name = "txtLoaiKH";

            this.lblMaTTV.AutoSize = true; this.lblMaTTV.Font = fLbl; this.lblMaTTV.ForeColor = colLbl; this.lblMaTTV.Location = new System.Drawing.Point(178, 80); this.lblMaTTV.Text = "Ma TTV";
            this.txtMaTTV.Font = fInp; this.txtMaTTV.Location = new System.Drawing.Point(178, 96); this.txtMaTTV.Size = new System.Drawing.Size(110, 26); this.txtMaTTV.BorderStyle = bs; this.txtMaTTV.BackColor = colRO; this.txtMaTTV.ReadOnly = true; this.txtMaTTV.Name = "txtMaTTV";

            this.lblNgayCap.AutoSize = true; this.lblNgayCap.Font = fLbl; this.lblNgayCap.ForeColor = colLbl; this.lblNgayCap.Location = new System.Drawing.Point(302, 80); this.lblNgayCap.Text = "Ngay cap";
            this.txtNgayCap.Font = fInp; this.txtNgayCap.Location = new System.Drawing.Point(302, 96); this.txtNgayCap.Size = new System.Drawing.Size(120, 26); this.txtNgayCap.BorderStyle = bs; this.txtNgayCap.BackColor = colRO; this.txtNgayCap.ReadOnly = true; this.txtNgayCap.Name = "txtNgayCap";

            this.lblDiemHT.AutoSize = true; this.lblDiemHT.Font = fLbl; this.lblDiemHT.ForeColor = colLbl; this.lblDiemHT.Location = new System.Drawing.Point(436, 80); this.lblDiemHT.Text = "DIEM HIEN TAI";
            this.txtDiemHienTai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.txtDiemHienTai.Location = new System.Drawing.Point(436, 96); this.txtDiemHienTai.Size = new System.Drawing.Size(140, 28); this.txtDiemHienTai.BorderStyle = bs; this.txtDiemHienTai.BackColor = System.Drawing.Color.FromArgb(220, 248, 230); this.txtDiemHienTai.ForeColor = System.Drawing.Color.FromArgb(13, 100, 60); this.txtDiemHienTai.ReadOnly = true; this.txtDiemHienTai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right; this.txtDiemHienTai.Name = "txtDiemHienTai";

            // Tích điểm panel
            this.pnlDiem.BackColor = System.Drawing.Color.FromArgb(248, 250, 253); this.pnlDiem.Dock = System.Windows.Forms.DockStyle.Top; this.pnlDiem.Height = 72; this.pnlDiem.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
            this.pnlDiem.Controls.Add(this.lblNote); this.pnlDiem.Controls.Add(this.btnCapNhatDiem);
            this.pnlDiem.Controls.Add(this.txtDiemSeThem); this.pnlDiem.Controls.Add(this.lblDiemSeThem);
            this.pnlDiem.Controls.Add(this.txtTongTienGiaoDich); this.pnlDiem.Controls.Add(this.lblTongTienGD);
            this.pnlDiem.Controls.Add(this.lblDiemTitle);

            this.lblDiemTitle.AutoSize = true; this.lblDiemTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblDiemTitle.ForeColor = colNav; this.lblDiemTitle.Location = new System.Drawing.Point(12, 12); this.lblDiemTitle.Name = "lblDiemTitle"; this.lblDiemTitle.Text = "Cap nhat diem tich luy  (1 diem / 10,000 d)";

            this.lblTongTienGD.AutoSize = true; this.lblTongTienGD.Font = fLbl; this.lblTongTienGD.ForeColor = colLbl; this.lblTongTienGD.Location = new System.Drawing.Point(12, 36); this.lblTongTienGD.Text = "Tong tien giao dich (d) *";
            this.txtTongTienGiaoDich.Font = new System.Drawing.Font("Segoe UI", 9.5F); this.txtTongTienGiaoDich.Location = new System.Drawing.Point(155, 32); this.txtTongTienGiaoDich.Size = new System.Drawing.Size(160, 26); this.txtTongTienGiaoDich.BorderStyle = bs; this.txtTongTienGiaoDich.BackColor = colInp; this.txtTongTienGiaoDich.TextAlign = System.Windows.Forms.HorizontalAlignment.Right; this.txtTongTienGiaoDich.Name = "txtTongTienGiaoDich"; this.txtTongTienGiaoDich.TextChanged += new System.EventHandler(this.txtTongTienGiaoDich_TextChanged);

            this.lblDiemSeThem.AutoSize = true; this.lblDiemSeThem.Font = fLbl; this.lblDiemSeThem.ForeColor = colLbl; this.lblDiemSeThem.Location = new System.Drawing.Point(328, 36); this.lblDiemSeThem.Text = "Diem se them";
            this.txtDiemSeThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold); this.txtDiemSeThem.ReadOnly = true; this.txtDiemSeThem.Location = new System.Drawing.Point(418, 32); this.txtDiemSeThem.Size = new System.Drawing.Size(80, 26); this.txtDiemSeThem.BorderStyle = bs; this.txtDiemSeThem.BackColor = System.Drawing.Color.FromArgb(220, 248, 230); this.txtDiemSeThem.ForeColor = System.Drawing.Color.FromArgb(13, 100, 60); this.txtDiemSeThem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; this.txtDiemSeThem.Name = "txtDiemSeThem";

            this.btnCapNhatDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCapNhatDiem.FlatAppearance.BorderSize = 0; this.btnCapNhatDiem.BackColor = System.Drawing.Color.FromArgb(13, 100, 60); this.btnCapNhatDiem.ForeColor = colWh; this.btnCapNhatDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.btnCapNhatDiem.Location = new System.Drawing.Point(510, 30); this.btnCapNhatDiem.Size = new System.Drawing.Size(160, 30); this.btnCapNhatDiem.Text = "\u2714 Cap nhat diem"; this.btnCapNhatDiem.Cursor = System.Windows.Forms.Cursors.Hand; this.btnCapNhatDiem.Enabled = false; this.btnCapNhatDiem.Name = "btnCapNhatDiem"; this.btnCapNhatDiem.Click += new System.EventHandler(this.btnCapNhatDiem_Click);

            this.lblNote.AutoSize = true; this.lblNote.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic); this.lblNote.ForeColor = System.Drawing.Color.FromArgb(140, 150, 170); this.lblNote.Location = new System.Drawing.Point(12, 62); this.lblNote.Name = "lblNote"; this.lblNote.Text = "* 1 diem tich luy = 10,000 VND chi tieu. Cap nhat se tu dong nang hang neu du dieu kien.";

            // Lịch sử hóa đơn
            this.pnlHD.BackColor = colWh; this.pnlHD.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlHD.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlHD.Controls.Add(this.dgvHoaDon); this.pnlHD.Controls.Add(this.lblHDTitle);

            this.lblHDTitle.AutoSize = true; this.lblHDTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); this.lblHDTitle.ForeColor = colNav; this.lblHDTitle.Location = new System.Drawing.Point(0, 8); this.lblHDTitle.Name = "lblHDTitle"; this.lblHDTitle.Text = "Lich su hoa don cua khach hang";

            this.dgvHoaDon.AllowUserToAddRows = false; this.dgvHoaDon.AllowUserToDeleteRows = false; this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = colWh; this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoaDon.RowHeadersVisible = false; this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing; this.dgvHoaDon.ColumnHeadersHeight = 32; this.dgvHoaDon.RowTemplate.Height = 30;
            this.dgvHoaDon.GridColor = System.Drawing.Color.FromArgb(228, 232, 240); this.dgvHoaDon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(35, 55, 85); this.dgvHoaDon.ColumnHeadersDefaultCellStyle.ForeColor = colWh; this.dgvHoaDon.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.dgvHoaDon.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0); this.dgvHoaDon.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(35, 55, 85);
            this.dgvHoaDon.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.dgvHoaDon.DefaultCellStyle.BackColor = colWh; this.dgvHoaDon.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 232, 248); this.dgvHoaDon.DefaultCellStyle.SelectionForeColor = colNav; this.dgvHoaDon.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvHoaDon.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253); this.dgvHoaDon.Name = "dgvHoaDon";

            // FOOTER
            this.pnlFooter.BackColor = colNav; this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom; this.pnlFooter.Height = 26; this.pnlFooter.Controls.Add(this.lblFooter);
            this.lblFooter.AutoSize = true; this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(140, 170, 210); this.lblFooter.Location = new System.Drawing.Point(0, 6); this.lblFooter.Text = "  TH True Mart 2025 - KHACHHANG - THETHANHVIEN - LOAIKH - HOADON";

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = colBg; this.ClientSize = new System.Drawing.Size(1200, 820); this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FormTheThanhVien_Load);
            this.Controls.Add(this.pnlBody); this.Controls.Add(this.pnlStats); this.Controls.Add(this.pnlHeader); this.Controls.Add(this.pnlFooter);

            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStat1.ResumeLayout(false); this.pnlStat1.PerformLayout();
            this.pnlStat2.ResumeLayout(false); this.pnlStat2.PerformLayout();
            this.pnlStat3.ResumeLayout(false); this.pnlStat3.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false); this.pnlLeftHead.ResumeLayout(false); this.pnlLeftHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.pnlRight.ResumeLayout(false); this.pnlCardInfo.ResumeLayout(false); this.pnlCardInfo.PerformLayout();
            this.pnlDiem.ResumeLayout(false); this.pnlDiem.PerformLayout();
            this.pnlHD.ResumeLayout(false); this.pnlHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlFooter.ResumeLayout(false); this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblSubtitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlStat1, pnlStat2, pnlStat3;
        private System.Windows.Forms.Label lblStat1Val, lblStat1Lbl, lblStat2Val, lblStat2Lbl, lblStat3Val, lblStat3Lbl;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLeft, pnlLeftHead;
        private System.Windows.Forms.Label lblLeftTitle;
        private System.Windows.Forms.TextBox txtSearchSDT;
        private System.Windows.Forms.Button btnSearchKH;
        private System.Windows.Forms.ComboBox cmbLoaiKHFilter;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pnlRight, pnlCardInfo, pnlDiem, pnlHD;
        private System.Windows.Forms.Label lblCardTitle;
        private System.Windows.Forms.Label lblMaKH, lblTenKH, lblSDT, lblDiaChi, lblLoaiKH, lblMaTTV, lblNgayCap, lblDiemHT;
        private System.Windows.Forms.TextBox txtMaKH, txtTenKH, txtSDT, txtDiaChi, txtLoaiKH, txtMaTTV, txtNgayCap, txtDiemHienTai;
        private System.Windows.Forms.Label lblDiemTitle, lblTongTienGD, lblDiemSeThem, lblNote;
        private System.Windows.Forms.TextBox txtTongTienGiaoDich, txtDiemSeThem;
        private System.Windows.Forms.Button btnCapNhatDiem;
        private System.Windows.Forms.Label lblHDTitle;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}