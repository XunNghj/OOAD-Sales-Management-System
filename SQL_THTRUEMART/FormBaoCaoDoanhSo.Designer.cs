namespace SQL_THTRUEMART
{
    partial class FormBaoCaoDoanhSo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlFilterInner = new System.Windows.Forms.Panel();
            this.lblFilterIcon = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.TextBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlStat3 = new System.Windows.Forms.Panel();
            this.lblStat3Lbl = new System.Windows.Forms.Label();
            this.lblStat3Val = new System.Windows.Forms.Label();
            this.pnlStat2 = new System.Windows.Forms.Panel();
            this.lblStat2Lbl = new System.Windows.Forms.Label();
            this.lblStat2Val = new System.Windows.Forms.Label();
            this.pnlStat1 = new System.Windows.Forms.Panel();
            this.lblStat1Lbl = new System.Windows.Forms.Label();
            this.lblStat1Val = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.pnlGridHeader = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.lblGridSub = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlFilterInner.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlStat3.SuspendLayout();
            this.pnlStat2.SuspendLayout();
            this.pnlStat1.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.pnlGridHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1160, 80);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(28, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(418, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO DOANH SỐ NHÂN VIÊN";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(190)))), ((int)(((byte)(230)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 48);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(286, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "TH True Mart · Hệ thống quản lý bán hàng";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlFilter.Controls.Add(this.pnlFilterInner);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 80);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.pnlFilter.Size = new System.Drawing.Size(1160, 78);
            this.pnlFilter.TabIndex = 2;
            // 
            // pnlFilterInner
            // 
            this.pnlFilterInner.BackColor = System.Drawing.Color.White;
            this.pnlFilterInner.Controls.Add(this.lblFilterIcon);
            this.pnlFilterInner.Controls.Add(this.lblThang);
            this.pnlFilterInner.Controls.Add(this.txtThang);
            this.pnlFilterInner.Controls.Add(this.lblNam);
            this.pnlFilterInner.Controls.Add(this.txtNam);
            this.pnlFilterInner.Controls.Add(this.btnViewReport);
            this.pnlFilterInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilterInner.Location = new System.Drawing.Point(20, 14);
            this.pnlFilterInner.Name = "pnlFilterInner";
            this.pnlFilterInner.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.pnlFilterInner.Size = new System.Drawing.Size(1120, 50);
            this.pnlFilterInner.TabIndex = 0;
            // 
            // lblFilterIcon
            // 
            this.lblFilterIcon.AutoSize = true;
            this.lblFilterIcon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilterIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.lblFilterIcon.Location = new System.Drawing.Point(14, 16);
            this.lblFilterIcon.Name = "lblFilterIcon";
            this.lblFilterIcon.Size = new System.Drawing.Size(148, 20);
            this.lblFilterIcon.TabIndex = 0;
            this.lblFilterIcon.Text = "▼  Tham số báo cáo";
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblThang.Location = new System.Drawing.Point(175, -1);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(50, 20);
            this.lblThang.TabIndex = 1;
            this.lblThang.Text = "Tháng";
            // 
            // txtThang
            // 
            this.txtThang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.txtThang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtThang.Location = new System.Drawing.Point(175, 17);
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(70, 30);
            this.txtThang.TabIndex = 2;
            this.txtThang.Text = "1";
            this.txtThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblNam.Location = new System.Drawing.Point(269, -1);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(41, 20);
            this.lblNam.TabIndex = 3;
            this.lblNam.Text = "Năm";
            // 
            // txtNam
            // 
            this.txtNam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.txtNam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNam.Location = new System.Drawing.Point(269, 17);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(84, 30);
            this.txtNam.TabIndex = 4;
            this.txtNam.Text = "2025";
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.btnViewReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.btnViewReport.FlatAppearance.BorderSize = 0;
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnViewReport.ForeColor = System.Drawing.Color.White;
            this.btnViewReport.Location = new System.Drawing.Point(381, 8);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(148, 34);
            this.btnViewReport.TabIndex = 5;
            this.btnViewReport.Text = "XEM BÁO CÁO";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlStats.Controls.Add(this.pnlStat3);
            this.pnlStats.Controls.Add(this.pnlStat2);
            this.pnlStats.Controls.Add(this.pnlStat1);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 158);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(20, 0, 20, 14);
            this.pnlStats.Size = new System.Drawing.Size(1160, 90);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlStat3
            // 
            this.pnlStat3.BackColor = System.Drawing.Color.White;
            this.pnlStat3.Controls.Add(this.lblStat3Lbl);
            this.pnlStat3.Controls.Add(this.lblStat3Val);
            this.pnlStat3.Location = new System.Drawing.Point(444, 10);
            this.pnlStat3.Name = "pnlStat3";
            this.pnlStat3.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlStat3.Size = new System.Drawing.Size(260, 62);
            this.pnlStat3.TabIndex = 0;
            // 
            // lblStat3Lbl
            // 
            this.lblStat3Lbl.AutoSize = true;
            this.lblStat3Lbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStat3Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblStat3Lbl.Location = new System.Drawing.Point(14, 10);
            this.lblStat3Lbl.Name = "lblStat3Lbl";
            this.lblStat3Lbl.Size = new System.Drawing.Size(123, 19);
            this.lblStat3Lbl.TabIndex = 0;
            this.lblStat3Lbl.Text = "TỔNG DOANH SỐ";
            // 
            // lblStat3Val
            // 
            this.lblStat3Val.AutoSize = true;
            this.lblStat3Val.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStat3Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.lblStat3Val.Location = new System.Drawing.Point(12, 26);
            this.lblStat3Val.Name = "lblStat3Val";
            this.lblStat3Val.Size = new System.Drawing.Size(44, 37);
            this.lblStat3Val.TabIndex = 1;
            this.lblStat3Val.Text = "—";
            // 
            // pnlStat2
            // 
            this.pnlStat2.BackColor = System.Drawing.Color.White;
            this.pnlStat2.Controls.Add(this.lblStat2Lbl);
            this.pnlStat2.Controls.Add(this.lblStat2Val);
            this.pnlStat2.Location = new System.Drawing.Point(232, 10);
            this.pnlStat2.Name = "pnlStat2";
            this.pnlStat2.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlStat2.Size = new System.Drawing.Size(200, 62);
            this.pnlStat2.TabIndex = 1;
            // 
            // lblStat2Lbl
            // 
            this.lblStat2Lbl.AutoSize = true;
            this.lblStat2Lbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStat2Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblStat2Lbl.Location = new System.Drawing.Point(14, 10);
            this.lblStat2Lbl.Name = "lblStat2Lbl";
            this.lblStat2Lbl.Size = new System.Drawing.Size(116, 19);
            this.lblStat2Lbl.TabIndex = 0;
            this.lblStat2Lbl.Text = "TỔNG HÓA ĐƠN";
            // 
            // lblStat2Val
            // 
            this.lblStat2Val.AutoSize = true;
            this.lblStat2Val.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStat2Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.lblStat2Val.Location = new System.Drawing.Point(12, 26);
            this.lblStat2Val.Name = "lblStat2Val";
            this.lblStat2Val.Size = new System.Drawing.Size(44, 37);
            this.lblStat2Val.TabIndex = 1;
            this.lblStat2Val.Text = "—";
            // 
            // pnlStat1
            // 
            this.pnlStat1.BackColor = System.Drawing.Color.White;
            this.pnlStat1.Controls.Add(this.lblStat1Lbl);
            this.pnlStat1.Controls.Add(this.lblStat1Val);
            this.pnlStat1.Location = new System.Drawing.Point(20, 10);
            this.pnlStat1.Name = "pnlStat1";
            this.pnlStat1.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlStat1.Size = new System.Drawing.Size(200, 62);
            this.pnlStat1.TabIndex = 2;
            // 
            // lblStat1Lbl
            // 
            this.lblStat1Lbl.AutoSize = true;
            this.lblStat1Lbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStat1Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblStat1Lbl.Location = new System.Drawing.Point(14, 10);
            this.lblStat1Lbl.Name = "lblStat1Lbl";
            this.lblStat1Lbl.Size = new System.Drawing.Size(124, 19);
            this.lblStat1Lbl.TabIndex = 0;
            this.lblStat1Lbl.Text = "TỔNG NHÂN VIÊN";
            // 
            // lblStat1Val
            // 
            this.lblStat1Val.AutoSize = true;
            this.lblStat1Val.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStat1Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.lblStat1Val.Location = new System.Drawing.Point(12, 26);
            this.lblStat1Val.Name = "lblStat1Val";
            this.lblStat1Val.Size = new System.Drawing.Size(44, 37);
            this.lblStat1Val.TabIndex = 1;
            this.lblStat1Val.Text = "—";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlGrid.Controls.Add(this.dgvBaoCao);
            this.pnlGrid.Controls.Add(this.pnlGridHeader);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 248);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.pnlGrid.Size = new System.Drawing.Size(1160, 404);
            this.pnlGrid.TabIndex = 0;
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dgvBaoCao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaoCao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBaoCao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBaoCao.ColumnHeadersHeight = 38;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCao.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.EnableHeadersVisualStyles = false;
            this.dgvBaoCao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.dgvBaoCao.Location = new System.Drawing.Point(20, 46);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersVisible = false;
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 36;
            this.dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.Size = new System.Drawing.Size(1120, 338);
            this.dgvBaoCao.TabIndex = 0;
            // 
            // pnlGridHeader
            // 
            this.pnlGridHeader.BackColor = System.Drawing.Color.White;
            this.pnlGridHeader.Controls.Add(this.lblGridTitle);
            this.pnlGridHeader.Controls.Add(this.lblGridSub);
            this.pnlGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridHeader.Location = new System.Drawing.Point(20, 0);
            this.pnlGridHeader.Name = "pnlGridHeader";
            this.pnlGridHeader.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.pnlGridHeader.Size = new System.Drawing.Size(1120, 46);
            this.pnlGridHeader.TabIndex = 1;
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.lblGridTitle.Location = new System.Drawing.Point(14, 8);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(192, 23);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "Chi tiết theo nhân viên";
            // 
            // lblGridSub
            // 
            this.lblGridSub.AutoSize = true;
            this.lblGridSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblGridSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(165)))));
            this.lblGridSub.Location = new System.Drawing.Point(16, 28);
            this.lblGridSub.Name = "lblGridSub";
            this.lblGridSub.Size = new System.Drawing.Size(300, 20);
            this.lblGridSub.TabIndex = 1;
            this.lblGridSub.Text = "Chưa có dữ liệu · nhấn XEM BÁO CÁO để tải";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 652);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1160, 28);
            this.pnlFooter.TabIndex = 4;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(170)))), ((int)(((byte)(210)))));
            this.lblFooter.Location = new System.Drawing.Point(0, 7);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(478, 19);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "  TH True Mart © 2025 · sp_BaoCao_DoanhSoNV · HOADON ⟶ NHANVIEN";
            // 
            // FormBaoCaoDoanhSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1160, 680);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "FormBaoCaoDoanhSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Doanh Số Nhân Viên · TH True Mart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilterInner.ResumeLayout(false);
            this.pnlFilterInner.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStat3.ResumeLayout(false);
            this.pnlStat3.PerformLayout();
            this.pnlStat2.ResumeLayout(false);
            this.pnlStat2.PerformLayout();
            this.pnlStat1.ResumeLayout(false);
            this.pnlStat1.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.pnlGridHeader.ResumeLayout(false);
            this.pnlGridHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ── CONTROL DECLARATIONS ──────────────────────────────────────────
        private System.Windows.Forms.Panel      pnlHeader;
        private System.Windows.Forms.Label      lblTitle;
        private System.Windows.Forms.Label      lblSubtitle;
        private System.Windows.Forms.Panel      pnlFilter;
        private System.Windows.Forms.Panel      pnlFilterInner;
        private System.Windows.Forms.Label      lblFilterIcon;
        private System.Windows.Forms.Label      lblThang;
        private System.Windows.Forms.TextBox    txtThang;
        private System.Windows.Forms.Label      lblNam;
        private System.Windows.Forms.TextBox    txtNam;
        private System.Windows.Forms.Button     btnViewReport;
        private System.Windows.Forms.Panel      pnlStats;
        private System.Windows.Forms.Panel      pnlStat1;
        private System.Windows.Forms.Label      lblStat1Val;
        private System.Windows.Forms.Label      lblStat1Lbl;
        private System.Windows.Forms.Panel      pnlStat2;
        private System.Windows.Forms.Label      lblStat2Val;
        private System.Windows.Forms.Label      lblStat2Lbl;
        private System.Windows.Forms.Panel      pnlStat3;
        private System.Windows.Forms.Label      lblStat3Val;
        private System.Windows.Forms.Label      lblStat3Lbl;
        private System.Windows.Forms.Panel      pnlGrid;
        private System.Windows.Forms.Panel      pnlGridHeader;
        private System.Windows.Forms.Label      lblGridTitle;
        private System.Windows.Forms.Label      lblGridSub;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Panel      pnlFooter;
        private System.Windows.Forms.Label      lblFooter;
    }
}