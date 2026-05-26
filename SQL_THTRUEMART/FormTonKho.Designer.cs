namespace SQL_THTRUEMART
{
    partial class FormTonKho
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
            this.pnlStat4 = new System.Windows.Forms.Panel();
            this.lblStat4Val = new System.Windows.Forms.Label();
            this.lblStat4Lbl = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.lblListSub = new System.Windows.Forms.Label();
            this.pnlBtns = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblKhoFilter = new System.Windows.Forms.Label();
            this.cboKhuVucKho = new System.Windows.Forms.ComboBox();
            this.lblSpFilter = new System.Windows.Forms.Label();
            this.txtSearchSP = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblTonFilter = new System.Windows.Forms.Label();
            this.cboTonFilter = new System.Windows.Forms.ComboBox();
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlStat1.SuspendLayout(); this.pnlStat2.SuspendLayout();
            this.pnlStat3.SuspendLayout(); this.pnlStat4.SuspendLayout();
            this.pnlBody.SuspendLayout(); this.pnlCard.SuspendLayout();
            this.pnlToolbar.SuspendLayout(); this.pnlBtns.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            var colNav = System.Drawing.Color.FromArgb(13, 43, 90);
            var colBg = System.Drawing.Color.FromArgb(245, 247, 251);
            var colWh = System.Drawing.Color.White;
            var fInp = new System.Drawing.Font("Segoe UI", 9F);
            var fLbl = new System.Drawing.Font("Segoe UI", 8.5F);
            var colLbl = System.Drawing.Color.FromArgb(100, 110, 125);
            var colInp = System.Drawing.Color.FromArgb(250, 251, 253);
            var bs = System.Windows.Forms.BorderStyle.FixedSingle;

            // ── HEADER ──────────────────────────────────────────────
            this.pnlHeader.BackColor = colNav; this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top; this.pnlHeader.Height = 72; this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Controls.Add(this.lblSubtitle); this.pnlHeader.Controls.Add(this.lblTitle);
            this.lblTitle.AutoSize = true; this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblTitle.ForeColor = colWh; this.lblTitle.Location = new System.Drawing.Point(28, 12); this.lblTitle.Text = "BAO CAO TON KHO";
            this.lblSubtitle.AutoSize = true; this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F); this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 190, 230); this.lblSubtitle.Location = new System.Drawing.Point(30, 42); this.lblSubtitle.Text = "TH True Mart - TONKHO - KHO - SANPHAM";

            // ── STATS (4 thẻ) ────────────────────────────────────────
            this.pnlStats.BackColor = colBg; this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top; this.pnlStats.Height = 80; this.pnlStats.Padding = new System.Windows.Forms.Padding(16, 8, 16, 10);
            this.pnlStats.Controls.Add(this.pnlStat4); this.pnlStats.Controls.Add(this.pnlStat3); this.pnlStats.Controls.Add(this.pnlStat2); this.pnlStats.Controls.Add(this.pnlStat1);

            this.pnlStat1.BackColor = colWh; this.pnlStat1.Size = new System.Drawing.Size(200, 62); this.pnlStat1.Location = new System.Drawing.Point(16, 8); this.pnlStat1.Controls.Add(this.lblStat1Lbl); this.pnlStat1.Controls.Add(this.lblStat1Val);
            this.lblStat1Lbl.AutoSize = true; this.lblStat1Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblStat1Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblStat1Lbl.Location = new System.Drawing.Point(12, 8); this.lblStat1Lbl.Text = "TONG SO MAT HANG";
            this.lblStat1Val.AutoSize = true; this.lblStat1Val.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.lblStat1Val.ForeColor = colNav; this.lblStat1Val.Location = new System.Drawing.Point(12, 26); this.lblStat1Val.Name = "lblStat1Val"; this.lblStat1Val.Text = "...";

            this.pnlStat2.BackColor = colWh; this.pnlStat2.Size = new System.Drawing.Size(200, 62); this.pnlStat2.Location = new System.Drawing.Point(228, 8); this.pnlStat2.Controls.Add(this.lblStat2Lbl); this.pnlStat2.Controls.Add(this.lblStat2Val);
            this.lblStat2Lbl.AutoSize = true; this.lblStat2Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblStat2Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblStat2Lbl.Location = new System.Drawing.Point(12, 8); this.lblStat2Lbl.Text = "TONG TRI GIA TON (d)";
            this.lblStat2Val.AutoSize = true; this.lblStat2Val.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.lblStat2Val.ForeColor = System.Drawing.Color.FromArgb(13, 100, 60); this.lblStat2Val.Location = new System.Drawing.Point(12, 28); this.lblStat2Val.Name = "lblStat2Val"; this.lblStat2Val.Text = "...";

            this.pnlStat3.BackColor = colWh; this.pnlStat3.Size = new System.Drawing.Size(200, 62); this.pnlStat3.Location = new System.Drawing.Point(440, 8); this.pnlStat3.Controls.Add(this.lblStat3Lbl); this.pnlStat3.Controls.Add(this.lblStat3Val);
            this.lblStat3Lbl.AutoSize = true; this.lblStat3Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblStat3Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblStat3Lbl.Location = new System.Drawing.Point(12, 8); this.lblStat3Lbl.Text = "SP HET HANG (TON = 0)";
            this.lblStat3Val.AutoSize = true; this.lblStat3Val.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.lblStat3Val.ForeColor = System.Drawing.Color.FromArgb(180, 50, 50); this.lblStat3Val.Location = new System.Drawing.Point(12, 26); this.lblStat3Val.Name = "lblStat3Val"; this.lblStat3Val.Text = "...";

            this.pnlStat4.BackColor = colWh; this.pnlStat4.Size = new System.Drawing.Size(200, 62); this.pnlStat4.Location = new System.Drawing.Point(652, 8); this.pnlStat4.Controls.Add(this.lblStat4Lbl); this.pnlStat4.Controls.Add(this.lblStat4Val);
            this.lblStat4Lbl.AutoSize = true; this.lblStat4Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblStat4Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblStat4Lbl.Location = new System.Drawing.Point(12, 8); this.lblStat4Lbl.Text = "SO KHO DANG QUAN LY";
            this.lblStat4Val.AutoSize = true; this.lblStat4Val.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.lblStat4Val.ForeColor = colNav; this.lblStat4Val.Location = new System.Drawing.Point(12, 26); this.lblStat4Val.Name = "lblStat4Val"; this.lblStat4Val.Text = "...";

            // ── BODY ─────────────────────────────────────────────────
            this.pnlBody.BackColor = colBg; this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlBody.Padding = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.pnlBody.Controls.Add(this.pnlCard);

            this.pnlCard.BackColor = colWh; this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Controls.Add(this.dgvTonKho); this.pnlCard.Controls.Add(this.pnlFilter); this.pnlCard.Controls.Add(this.pnlToolbar);

            // Toolbar
            this.pnlToolbar.BackColor = colWh; this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top; this.pnlToolbar.Height = 44; this.pnlToolbar.Padding = new System.Windows.Forms.Padding(12, 0, 8, 0);
            this.pnlToolbar.Controls.Add(this.lblListSub); this.pnlToolbar.Controls.Add(this.lblListTitle); this.pnlToolbar.Controls.Add(this.pnlBtns);

            this.lblListTitle.AutoSize = true; this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold); this.lblListTitle.ForeColor = colNav; this.lblListTitle.Location = new System.Drawing.Point(12, 7); this.lblListTitle.Name = "lblListTitle"; this.lblListTitle.Text = "Bao cao ton kho";
            this.lblListSub.AutoSize = true; this.lblListSub.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblListSub.ForeColor = System.Drawing.Color.FromArgb(150, 160, 175); this.lblListSub.Location = new System.Drawing.Point(14, 27); this.lblListSub.Name = "lblListSub"; this.lblListSub.Text = "TONKHO - Mau do = het hang  Mau vang = ton thap";

            this.pnlBtns.BackColor = colWh; this.pnlBtns.Dock = System.Windows.Forms.DockStyle.Right; this.pnlBtns.Width = 120; this.pnlBtns.Padding = new System.Windows.Forms.Padding(0, 8, 8, 8);
            this.pnlBtns.Controls.Add(this.btnReload);

            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnReload.FlatAppearance.BorderSize = 1; this.btnReload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 210, 225); this.btnReload.BackColor = System.Drawing.Color.FromArgb(218, 223, 232); this.btnReload.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80); this.btnReload.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold); this.btnReload.Location = new System.Drawing.Point(0, 0); this.btnReload.Size = new System.Drawing.Size(112, 28); this.btnReload.Text = "\u21ba Tai lai"; this.btnReload.Cursor = System.Windows.Forms.Cursors.Hand; this.btnReload.Click += new System.EventHandler(this.btnReload_Click);

            // Filter bar
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(248, 250, 253); this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top; this.pnlFilter.Height = 44; this.pnlFilter.Padding = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.pnlFilter.Controls.Add(this.cboTonFilter); this.pnlFilter.Controls.Add(this.lblTonFilter);
            this.pnlFilter.Controls.Add(this.btnFilter); this.pnlFilter.Controls.Add(this.txtSearchSP); this.pnlFilter.Controls.Add(this.lblSpFilter);
            this.pnlFilter.Controls.Add(this.cboKhuVucKho); this.pnlFilter.Controls.Add(this.lblKhoFilter);

            this.lblKhoFilter.AutoSize = true; this.lblKhoFilter.Font = fLbl; this.lblKhoFilter.ForeColor = colLbl; this.lblKhoFilter.Location = new System.Drawing.Point(12, 14); this.lblKhoFilter.Text = "Kho:";
            this.cboKhuVucKho.Font = fInp; this.cboKhuVucKho.Location = new System.Drawing.Point(42, 10); this.cboKhuVucKho.Size = new System.Drawing.Size(200, 26); this.cboKhuVucKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboKhuVucKho.Name = "cboKhuVucKho"; this.cboKhuVucKho.SelectedIndexChanged += new System.EventHandler(this.cboKhuVucKho_SelectedIndexChanged);

            this.lblSpFilter.AutoSize = true; this.lblSpFilter.Font = fLbl; this.lblSpFilter.ForeColor = colLbl; this.lblSpFilter.Location = new System.Drawing.Point(256, 14); this.lblSpFilter.Text = "Tim SP:";
            this.txtSearchSP.Font = fInp; this.txtSearchSP.Location = new System.Drawing.Point(300, 10); this.txtSearchSP.Size = new System.Drawing.Size(200, 26); this.txtSearchSP.BorderStyle = bs; this.txtSearchSP.BackColor = colInp; this.txtSearchSP.Name = "txtSearchSP"; this.txtSearchSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchSP_KeyDown);

            this.lblTonFilter.AutoSize = true; this.lblTonFilter.Font = fLbl; this.lblTonFilter.ForeColor = colLbl; this.lblTonFilter.Location = new System.Drawing.Point(514, 14); this.lblTonFilter.Text = "Ton kho:";
            this.cboTonFilter.Font = fInp; this.cboTonFilter.Location = new System.Drawing.Point(570, 10); this.cboTonFilter.Size = new System.Drawing.Size(180, 26); this.cboTonFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cboTonFilter.Name = "cboTonFilter"; this.cboTonFilter.SelectedIndexChanged += new System.EventHandler(this.cboTonFilter_SelectedIndexChanged);

            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnFilter.FlatAppearance.BorderSize = 0; this.btnFilter.BackColor = System.Drawing.Color.FromArgb(56, 139, 253); this.btnFilter.ForeColor = colWh; this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold); this.btnFilter.Location = new System.Drawing.Point(762, 10); this.btnFilter.Size = new System.Drawing.Size(80, 26); this.btnFilter.Text = "Loc"; this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand; this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // DataGridView
            this.dgvTonKho.AllowUserToAddRows = false; this.dgvTonKho.AllowUserToDeleteRows = false; this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvTonKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTonKho.BackgroundColor = colWh; this.dgvTonKho.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTonKho.RowHeadersVisible = false; this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing; this.dgvTonKho.ColumnHeadersHeight = 34; this.dgvTonKho.RowTemplate.Height = 32;
            this.dgvTonKho.GridColor = System.Drawing.Color.FromArgb(228, 232, 240); this.dgvTonKho.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTonKho.EnableHeadersVisualStyles = false;
            this.dgvTonKho.ColumnHeadersDefaultCellStyle.BackColor = colNav; this.dgvTonKho.ColumnHeadersDefaultCellStyle.ForeColor = colWh; this.dgvTonKho.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold); this.dgvTonKho.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0); this.dgvTonKho.ColumnHeadersDefaultCellStyle.SelectionBackColor = colNav;
            this.dgvTonKho.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F); this.dgvTonKho.DefaultCellStyle.BackColor = colWh; this.dgvTonKho.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 232, 248); this.dgvTonKho.DefaultCellStyle.SelectionForeColor = colNav; this.dgvTonKho.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvTonKho.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253); this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTonKho_CellFormatting);

            // ── FOOTER ──────────────────────────────────────────────
            this.pnlFooter.BackColor = colNav; this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom; this.pnlFooter.Height = 26; this.pnlFooter.Controls.Add(this.lblFooter);
            this.lblFooter.AutoSize = true; this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(140, 170, 210); this.lblFooter.Location = new System.Drawing.Point(0, 6); this.lblFooter.Text = "  TH True Mart 2025 - TONKHO - KHO - SANPHAM - LOAISP";

            // FORM
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F); this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = colBg; this.ClientSize = new System.Drawing.Size(1200, 820); this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FormTonKho_Load);
            this.Controls.Add(this.pnlBody); this.Controls.Add(this.pnlStats); this.Controls.Add(this.pnlHeader); this.Controls.Add(this.pnlFooter);

            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStat1.ResumeLayout(false); this.pnlStat1.PerformLayout();
            this.pnlStat2.ResumeLayout(false); this.pnlStat2.PerformLayout();
            this.pnlStat3.ResumeLayout(false); this.pnlStat3.PerformLayout();
            this.pnlStat4.ResumeLayout(false); this.pnlStat4.PerformLayout();
            this.pnlBody.ResumeLayout(false); this.pnlCard.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false); this.pnlToolbar.PerformLayout(); this.pnlBtns.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false); this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.pnlFooter.ResumeLayout(false); this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblSubtitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlStat1, pnlStat2, pnlStat3, pnlStat4;
        private System.Windows.Forms.Label lblStat1Val, lblStat1Lbl, lblStat2Val, lblStat2Lbl;
        private System.Windows.Forms.Label lblStat3Val, lblStat3Lbl, lblStat4Val, lblStat4Lbl;
        private System.Windows.Forms.Panel pnlBody, pnlCard, pnlToolbar, pnlBtns, pnlFilter;
        private System.Windows.Forms.Label lblListTitle, lblListSub;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblKhoFilter, lblSpFilter, lblTonFilter;
        private System.Windows.Forms.ComboBox cboKhuVucKho, cboTonFilter;
        private System.Windows.Forms.TextBox txtSearchSP;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}