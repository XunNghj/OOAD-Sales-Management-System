namespace SQL_THTRUEMART
{
    partial class FormSPHetHan
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
            this.pnlAlertBar = new System.Windows.Forms.Panel();
            this.pnlAlert1 = new System.Windows.Forms.Panel();
            this.lblAlert1Val = new System.Windows.Forms.Label();
            this.lblAlert1Lbl = new System.Windows.Forms.Label();
            this.pnlAlert2 = new System.Windows.Forms.Panel();
            this.lblAlert2Val = new System.Windows.Forms.Label();
            this.lblAlert2Lbl = new System.Windows.Forms.Label();
            this.pnlAlert3 = new System.Windows.Forms.Panel();
            this.lblAlert3Val = new System.Windows.Forms.Label();
            this.lblAlert3Lbl = new System.Windows.Forms.Label();
            this.pnlAlert4 = new System.Windows.Forms.Panel();
            this.lblAlert4Val = new System.Windows.Forms.Label();
            this.lblAlert4Lbl = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.lblGridSub = new System.Windows.Forms.Label();
            this.pnlFilterArea = new System.Windows.Forms.Panel();
            this.lblNgayConLai = new System.Windows.Forms.Label();
            this.txtSoNgayConLai = new System.Windows.Forms.TextBox();
            this.lblLoaiFilter = new System.Windows.Forms.Label();
            this.cmbLoaiFilter = new System.Windows.Forms.ComboBox();
            this.lblMucFilter = new System.Windows.Forms.Label();
            this.cmbMucFilter = new System.Windows.Forms.ComboBox();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnExportNote = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlAlertBar.SuspendLayout();
            this.pnlAlert1.SuspendLayout(); this.pnlAlert2.SuspendLayout();
            this.pnlAlert3.SuspendLayout(); this.pnlAlert4.SuspendLayout();
            this.pnlBody.SuspendLayout(); this.pnlCard.SuspendLayout();
            this.pnlToolbar.SuspendLayout(); this.pnlFilterArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            var colNav = System.Drawing.Color.FromArgb(13, 43, 90);
            var colBg = System.Drawing.Color.FromArgb(245, 247, 251);
            var colWh = System.Drawing.Color.White;
            var colRed = System.Drawing.Color.FromArgb(200, 50, 50);
            var colOrg = System.Drawing.Color.FromArgb(180, 100, 0);
            var colYel = System.Drawing.Color.FromArgb(140, 110, 0);
            var colGrn = System.Drawing.Color.FromArgb(13, 100, 60);
            var fInp = new System.Drawing.Font("Segoe UI", 9F);
            var fLbl = new System.Drawing.Font("Segoe UI", 8.5F);
            var colLbl = System.Drawing.Color.FromArgb(100, 110, 125);
            var colInp = System.Drawing.Color.FromArgb(250, 251, 253);
            var bs = System.Windows.Forms.BorderStyle.FixedSingle;

            // ── HEADER ──────────────────────────────────────────────
            this.pnlHeader.BackColor = colNav; this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top; this.pnlHeader.Height = 72; this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Controls.Add(this.lblSubtitle); this.pnlHeader.Controls.Add(this.lblTitle);
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblTitle.ForeColor = colWh; this.lblTitle.Location = new System.Drawing.Point(28, 12); this.lblTitle.Text = "TRA CUU SAN PHAM SAP HET HAN";
            this.lblSubtitle.AutoSize = true; this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 190, 230); this.lblSubtitle.Location = new System.Drawing.Point(30, 42); this.lblSubtitle.Text = "TH True Mart - Canh bao HSD - SANPHAM - CT_PHIEUXUAT";

            // ── ALERT BAR (4 thẻ) ────────────────────────────────────
            this.pnlAlertBar.BackColor = colBg; this.pnlAlertBar.Dock = System.Windows.Forms.DockStyle.Top; this.pnlAlertBar.Height = 84; this.pnlAlertBar.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlAlertBar.Controls.Add(this.pnlAlert4); this.pnlAlertBar.Controls.Add(this.pnlAlert3);
            this.pnlAlertBar.Controls.Add(this.pnlAlert2); this.pnlAlertBar.Controls.Add(this.pnlAlert1);

            // Alert 1 — ĐÃ HẾT HẠN (đỏ đậm)
            this.pnlAlert1.BackColor = System.Drawing.Color.FromArgb(255, 235, 235); this.pnlAlert1.Size = new System.Drawing.Size(190, 64); this.pnlAlert1.Location = new System.Drawing.Point(16, 10);
            this.pnlAlert1.Controls.Add(this.lblAlert1Lbl); this.pnlAlert1.Controls.Add(this.lblAlert1Val);
            this.lblAlert1Lbl.AutoSize = true; this.lblAlert1Lbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.lblAlert1Lbl.ForeColor = colRed; this.lblAlert1Lbl.Location = new System.Drawing.Point(12, 7); this.lblAlert1Lbl.Text = "DA HET HAN";
            this.lblAlert1Val.AutoSize = true; this.lblAlert1Val.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); this.lblAlert1Val.ForeColor = colRed; this.lblAlert1Val.Location = new System.Drawing.Point(12, 24); this.lblAlert1Val.Name = "lblAlert1Val"; this.lblAlert1Val.Text = "-";

            // Alert 2 — 0-7 ngày (cam đỏ)
            this.pnlAlert2.BackColor = System.Drawing.Color.FromArgb(255, 240, 220); this.pnlAlert2.Size = new System.Drawing.Size(190, 64); this.pnlAlert2.Location = new System.Drawing.Point(218, 10);
            this.pnlAlert2.Controls.Add(this.lblAlert2Lbl); this.pnlAlert2.Controls.Add(this.lblAlert2Val);
            this.lblAlert2Lbl.AutoSize = true; this.lblAlert2Lbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.lblAlert2Lbl.ForeColor = colOrg; this.lblAlert2Lbl.Location = new System.Drawing.Point(12, 7); this.lblAlert2Lbl.Text = "CON <= 7 NGAY";
            this.lblAlert2Val.AutoSize = true; this.lblAlert2Val.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); this.lblAlert2Val.ForeColor = colOrg; this.lblAlert2Val.Location = new System.Drawing.Point(12, 24); this.lblAlert2Val.Name = "lblAlert2Val"; this.lblAlert2Val.Text = "-";

            // Alert 3 — 8-30 ngày (vàng)
            this.pnlAlert3.BackColor = System.Drawing.Color.FromArgb(255, 250, 220); this.pnlAlert3.Size = new System.Drawing.Size(190, 64); this.pnlAlert3.Location = new System.Drawing.Point(420, 10);
            this.pnlAlert3.Controls.Add(this.lblAlert3Lbl); this.pnlAlert3.Controls.Add(this.lblAlert3Val);
            this.lblAlert3Lbl.AutoSize = true; this.lblAlert3Lbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.lblAlert3Lbl.ForeColor = colYel; this.lblAlert3Lbl.Location = new System.Drawing.Point(12, 7); this.lblAlert3Lbl.Text = "CON 8-30 NGAY";
            this.lblAlert3Val.AutoSize = true; this.lblAlert3Val.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); this.lblAlert3Val.ForeColor = colYel; this.lblAlert3Val.Location = new System.Drawing.Point(12, 24); this.lblAlert3Val.Name = "lblAlert3Val"; this.lblAlert3Val.Text = "-";

            // Alert 4 — Tổng cảnh báo (navy)
            this.pnlAlert4.BackColor = colWh; this.pnlAlert4.Size = new System.Drawing.Size(190, 64); this.pnlAlert4.Location = new System.Drawing.Point(622, 10);
            this.pnlAlert4.Controls.Add(this.lblAlert4Lbl); this.pnlAlert4.Controls.Add(this.lblAlert4Val);
            this.lblAlert4Lbl.AutoSize = true; this.lblAlert4Lbl.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold); this.lblAlert4Lbl.ForeColor = colNav; this.lblAlert4Lbl.Location = new System.Drawing.Point(12, 7); this.lblAlert4Lbl.Text = "TONG CANH BAO";
            this.lblAlert4Val.AutoSize = true; this.lblAlert4Val.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold); this.lblAlert4Val.ForeColor = colNav; this.lblAlert4Val.Location = new System.Drawing.Point(12, 24); this.lblAlert4Val.Name = "lblAlert4Val"; this.lblAlert4Val.Text = "-";

            // ── BODY ─────────────────────────────────────────────────
            this.pnlBody.BackColor = colBg; this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlBody.Padding = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.pnlBody.Controls.Add(this.pnlCard);

            this.pnlCard.BackColor = colWh; this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Controls.Add(this.dgvSanPham); this.pnlCard.Controls.Add(this.pnlFilterArea); this.pnlCard.Controls.Add(this.pnlToolbar);

            // Toolbar
            this.pnlToolbar.BackColor = colWh; this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top; this.pnlToolbar.Height = 44; this.pnlToolbar.Padding = new System.Windows.Forms.Padding(12, 0, 8, 0);
            this.pnlToolbar.Controls.Add(this.lblGridSub); this.pnlToolbar.Controls.Add(this.lblGridTitle);
            this.lblGridTitle.AutoSize = true; this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold); this.lblGridTitle.ForeColor = colNav; this.lblGridTitle.Location = new System.Drawing.Point(12, 7); this.lblGridTitle.Name = "lblGridTitle"; this.lblGridTitle.Text = "Danh sach san pham sap het han";
            this.lblGridSub.AutoSize = true; this.lblGridSub.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblGridSub.ForeColor = System.Drawing.Color.FromArgb(150, 160, 175); this.lblGridSub.Location = new System.Drawing.Point(14, 27); this.lblGridSub.Name = "lblGridSub"; this.lblGridSub.Text = "Mau do = het han / Mau cam = con <= 7 ngay / Mau vang = con 8-30 ngay";

            // Filter area
            this.pnlFilterArea.BackColor = System.Drawing.Color.FromArgb(248, 250, 253); this.pnlFilterArea.Dock = System.Windows.Forms.DockStyle.Top; this.pnlFilterArea.Height = 48; this.pnlFilterArea.Padding = new System.Windows.Forms.Padding(12, 10, 12, 8);
            this.pnlFilterArea.Controls.Add(this.btnExportNote); this.pnlFilterArea.Controls.Add(this.btnViewReport);
            this.pnlFilterArea.Controls.Add(this.cmbMucFilter); this.pnlFilterArea.Controls.Add(this.lblMucFilter);
            this.pnlFilterArea.Controls.Add(this.cmbLoaiFilter); this.pnlFilterArea.Controls.Add(this.lblLoaiFilter);
            this.pnlFilterArea.Controls.Add(this.txtSoNgayConLai); this.pnlFilterArea.Controls.Add(this.lblNgayConLai);

            this.lblNgayConLai.AutoSize = true; this.lblNgayConLai.Font = fLbl; this.lblNgayConLai.ForeColor = colLbl; this.lblNgayConLai.Location = new System.Drawing.Point(12, 14); this.lblNgayConLai.Text = "Canh bao trong (ngay):";
            this.txtSoNgayConLai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold); this.txtSoNgayConLai.Location = new System.Drawing.Point(148, 10); this.txtSoNgayConLai.Size = new System.Drawing.Size(56, 26); this.txtSoNgayConLai.BorderStyle = bs; this.txtSoNgayConLai.BackColor = colInp; this.txtSoNgayConLai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center; this.txtSoNgayConLai.Text = "30"; this.txtSoNgayConLai.Name = "txtSoNgayConLai"; this.txtSoNgayConLai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoNgayConLai_KeyDown);

            this.lblLoaiFilter.AutoSize = true; this.lblLoaiFilter.Font = fLbl; this.lblLoaiFilter.ForeColor = colLbl; this.lblLoaiFilter.Location = new System.Drawing.Point(218, 14); this.lblLoaiFilter.Text = "Loai SP:";
            this.cmbLoaiFilter.Font = fInp; this.cmbLoaiFilter.Location = new System.Drawing.Point(268, 10); this.cmbLoaiFilter.Size = new System.Drawing.Size(200, 26); this.cmbLoaiFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbLoaiFilter.Name = "cmbLoaiFilter"; this.cmbLoaiFilter.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiFilter_SelectedIndexChanged);

            this.lblMucFilter.AutoSize = true; this.lblMucFilter.Font = fLbl; this.lblMucFilter.ForeColor = colLbl; this.lblMucFilter.Location = new System.Drawing.Point(482, 14); this.lblMucFilter.Text = "Muc do:";
            this.cmbMucFilter.Font = fInp; this.cmbMucFilter.Location = new System.Drawing.Point(534, 10); this.cmbMucFilter.Size = new System.Drawing.Size(180, 26); this.cmbMucFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbMucFilter.Name = "cmbMucFilter"; this.cmbMucFilter.SelectedIndexChanged += new System.EventHandler(this.cmbMucFilter_SelectedIndexChanged);

            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnViewReport.FlatAppearance.BorderSize = 0; this.btnViewReport.BackColor = colNav; this.btnViewReport.ForeColor = colWh; this.btnViewReport.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold); this.btnViewReport.Location = new System.Drawing.Point(726, 9); this.btnViewReport.Size = new System.Drawing.Size(140, 28); this.btnViewReport.Text = "\ud83d\udd04 Hien thi danh sach"; this.btnViewReport.Cursor = System.Windows.Forms.Cursors.Hand; this.btnViewReport.Name = "btnViewReport"; this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);

            this.btnExportNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnExportNote.FlatAppearance.BorderSize = 1; this.btnExportNote.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 210, 225); this.btnExportNote.BackColor = colWh; this.btnExportNote.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80); this.btnExportNote.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.btnExportNote.Location = new System.Drawing.Point(874, 9); this.btnExportNote.Size = new System.Drawing.Size(120, 28); this.btnExportNote.Text = "Xuat danh sach"; this.btnExportNote.Cursor = System.Windows.Forms.Cursors.Hand; this.btnExportNote.Name = "btnExportNote"; this.btnExportNote.Click += new System.EventHandler(this.btnExportNote_Click);

            // DataGridView
            this.dgvSanPham.AllowUserToAddRows = false; this.dgvSanPham.AllowUserToDeleteRows = false; this.dgvSanPham.ReadOnly = true;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = colWh; this.dgvSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSanPham.RowHeadersVisible = false; this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing; this.dgvSanPham.ColumnHeadersHeight = 34; this.dgvSanPham.RowTemplate.Height = 32;
            this.dgvSanPham.GridColor = System.Drawing.Color.FromArgb(228, 232, 240); this.dgvSanPham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSanPham.EnableHeadersVisualStyles = false;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle.BackColor = colNav; this.dgvSanPham.ColumnHeadersDefaultCellStyle.ForeColor = colWh; this.dgvSanPham.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold); this.dgvSanPham.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0); this.dgvSanPham.ColumnHeadersDefaultCellStyle.SelectionBackColor = colNav;
            this.dgvSanPham.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F); this.dgvSanPham.DefaultCellStyle.BackColor = colWh; this.dgvSanPham.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvSanPham.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 250, 252); this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSanPham_CellFormatting);

            // ── FOOTER ──────────────────────────────────────────────
            this.pnlFooter.BackColor = colNav; this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom; this.pnlFooter.Height = 26; this.pnlFooter.Controls.Add(this.lblFooter);
            this.lblFooter.AutoSize = true; this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(140, 170, 210); this.lblFooter.Location = new System.Drawing.Point(0, 6); this.lblFooter.Text = "  TH True Mart 2025 - Canh bao HSD - SANPHAM + CT_PHIEUXUAT";

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = colBg; this.ClientSize = new System.Drawing.Size(1200, 820); this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FormSPHetHan_Load);
            this.Controls.Add(this.pnlBody); this.Controls.Add(this.pnlAlertBar); this.Controls.Add(this.pnlHeader); this.Controls.Add(this.pnlFooter);

            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            this.pnlAlertBar.ResumeLayout(false);
            this.pnlAlert1.ResumeLayout(false); this.pnlAlert1.PerformLayout();
            this.pnlAlert2.ResumeLayout(false); this.pnlAlert2.PerformLayout();
            this.pnlAlert3.ResumeLayout(false); this.pnlAlert3.PerformLayout();
            this.pnlAlert4.ResumeLayout(false); this.pnlAlert4.PerformLayout();
            this.pnlBody.ResumeLayout(false); this.pnlCard.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false); this.pnlToolbar.PerformLayout();
            this.pnlFilterArea.ResumeLayout(false); this.pnlFilterArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.pnlFooter.ResumeLayout(false); this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblSubtitle;
        private System.Windows.Forms.Panel pnlAlertBar;
        private System.Windows.Forms.Panel pnlAlert1, pnlAlert2, pnlAlert3, pnlAlert4;
        private System.Windows.Forms.Label lblAlert1Val, lblAlert1Lbl, lblAlert2Val, lblAlert2Lbl;
        private System.Windows.Forms.Label lblAlert3Val, lblAlert3Lbl, lblAlert4Val, lblAlert4Lbl;
        private System.Windows.Forms.Panel pnlBody, pnlCard, pnlToolbar, pnlFilterArea;
        private System.Windows.Forms.Label lblGridTitle, lblGridSub;
        private System.Windows.Forms.Label lblNgayConLai, lblLoaiFilter, lblMucFilter;
        private System.Windows.Forms.TextBox txtSoNgayConLai;
        private System.Windows.Forms.ComboBox cmbLoaiFilter, cmbMucFilter;
        private System.Windows.Forms.Button btnViewReport, btnExportNote;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}