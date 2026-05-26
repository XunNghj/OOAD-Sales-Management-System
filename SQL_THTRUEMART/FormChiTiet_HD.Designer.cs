namespace SQL_THTRUEMART
{
    partial class FormChiTiet_HD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvBaoCaoNgay = new System.Windows.Forms.DataGridView();
            this.pnlGridHeader = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.lblGridSub = new System.Windows.Forms.Label();
            this.pnlVAT = new System.Windows.Forms.Panel();
            this.pnlVATInner = new System.Windows.Forms.Panel();
            this.lblVATTitle = new System.Windows.Forms.Label();
            this.lblVATDesc = new System.Windows.Forms.Label();
            this.pnlVATRow = new System.Windows.Forms.Panel();
            this.lblMaHDCheck = new System.Windows.Forms.Label();
            this.txtMaHDCheck = new System.Windows.Forms.TextBox();
            this.btnTinhVAT = new System.Windows.Forms.Button();
            this.lblSep = new System.Windows.Forms.Label();
            this.lblGiaTriVAT = new System.Windows.Forms.Label();
            this.txtGiaTriVAT = new System.Windows.Forms.TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlStat3.SuspendLayout();
            this.pnlStat2.SuspendLayout();
            this.pnlStat1.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoNgay)).BeginInit();
            this.pnlGridHeader.SuspendLayout();
            this.pnlVAT.SuspendLayout();
            this.pnlVATInner.SuspendLayout();
            this.pnlVATRow.SuspendLayout();
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
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(28, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(509, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHI TIẾT HÓA ĐƠN & BÁO CÁO TỔNG HỢP";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(190)))), ((int)(((byte)(230)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 48);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(341, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "TH True Mart · Doanh thu theo ngày · Kiểm tra VAT";
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlStats.Controls.Add(this.pnlStat3);
            this.pnlStats.Controls.Add(this.pnlStat2);
            this.pnlStats.Controls.Add(this.pnlStat1);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 80);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(20, 10, 20, 14);
            this.pnlStats.Size = new System.Drawing.Size(1160, 90);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlStat3
            // 
            this.pnlStat3.BackColor = System.Drawing.Color.White;
            this.pnlStat3.Controls.Add(this.lblStat3Lbl);
            this.pnlStat3.Controls.Add(this.lblStat3Val);
            this.pnlStat3.Location = new System.Drawing.Point(470, 10);
            this.pnlStat3.Name = "pnlStat3";
            this.pnlStat3.Size = new System.Drawing.Size(260, 66);
            this.pnlStat3.TabIndex = 0;
            // 
            // lblStat3Lbl
            // 
            this.lblStat3Lbl.AutoSize = true;
            this.lblStat3Lbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStat3Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblStat3Lbl.Location = new System.Drawing.Point(14, 10);
            this.lblStat3Lbl.Name = "lblStat3Lbl";
            this.lblStat3Lbl.Size = new System.Drawing.Size(149, 19);
            this.lblStat3Lbl.TabIndex = 0;
            this.lblStat3Lbl.Text = "TỔNG THÀNH TIỀN (đ)";
            // 
            // lblStat3Val
            // 
            this.lblStat3Val.AutoSize = true;
            this.lblStat3Val.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStat3Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.lblStat3Val.Location = new System.Drawing.Point(12, 28);
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
            this.pnlStat2.Location = new System.Drawing.Point(228, 10);
            this.pnlStat2.Name = "pnlStat2";
            this.pnlStat2.Size = new System.Drawing.Size(230, 66);
            this.pnlStat2.TabIndex = 1;
            // 
            // lblStat2Lbl
            // 
            this.lblStat2Lbl.AutoSize = true;
            this.lblStat2Lbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStat2Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblStat2Lbl.Location = new System.Drawing.Point(14, 10);
            this.lblStat2Lbl.Name = "lblStat2Lbl";
            this.lblStat2Lbl.Size = new System.Drawing.Size(154, 19);
            this.lblStat2Lbl.TabIndex = 0;
            this.lblStat2Lbl.Text = "TỔNG TRƯỚC THUẾ (đ)";
            // 
            // lblStat2Val
            // 
            this.lblStat2Val.AutoSize = true;
            this.lblStat2Val.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStat2Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.lblStat2Val.Location = new System.Drawing.Point(12, 28);
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
            this.pnlStat1.Size = new System.Drawing.Size(196, 66);
            this.pnlStat1.TabIndex = 2;
            // 
            // lblStat1Lbl
            // 
            this.lblStat1Lbl.AutoSize = true;
            this.lblStat1Lbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStat1Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(145)))));
            this.lblStat1Lbl.Location = new System.Drawing.Point(14, 10);
            this.lblStat1Lbl.Name = "lblStat1Lbl";
            this.lblStat1Lbl.Size = new System.Drawing.Size(176, 19);
            this.lblStat1Lbl.TabIndex = 0;
            this.lblStat1Lbl.Text = "SỐ NGÀY CÓ DOANH THU";
            // 
            // lblStat1Val
            // 
            this.lblStat1Val.AutoSize = true;
            this.lblStat1Val.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStat1Val.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.lblStat1Val.Location = new System.Drawing.Point(12, 28);
            this.lblStat1Val.Name = "lblStat1Val";
            this.lblStat1Val.Size = new System.Drawing.Size(44, 37);
            this.lblStat1Val.TabIndex = 1;
            this.lblStat1Val.Text = "—";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlBody.Controls.Add(this.pnlGrid);
            this.pnlBody.Controls.Add(this.pnlVAT);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 170);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.pnlBody.Size = new System.Drawing.Size(1160, 502);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlGrid.Controls.Add(this.dgvBaoCaoNgay);
            this.pnlGrid.Controls.Add(this.pnlGridHeader);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(20, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnlGrid.Size = new System.Drawing.Size(1120, 382);
            this.pnlGrid.TabIndex = 0;
            // 
            // dgvBaoCaoNgay
            // 
            this.dgvBaoCaoNgay.AllowUserToAddRows = false;
            this.dgvBaoCaoNgay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dgvBaoCaoNgay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBaoCaoNgay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoNgay.BackgroundColor = System.Drawing.Color.White;
            this.dgvBaoCaoNgay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBaoCaoNgay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCaoNgay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBaoCaoNgay.ColumnHeadersHeight = 38;
            this.dgvBaoCaoNgay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCaoNgay.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBaoCaoNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCaoNgay.EnableHeadersVisualStyles = false;
            this.dgvBaoCaoNgay.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(240)))));
            this.dgvBaoCaoNgay.Location = new System.Drawing.Point(0, 46);
            this.dgvBaoCaoNgay.Name = "dgvBaoCaoNgay";
            this.dgvBaoCaoNgay.ReadOnly = true;
            this.dgvBaoCaoNgay.RowHeadersVisible = false;
            this.dgvBaoCaoNgay.RowHeadersWidth = 51;
            this.dgvBaoCaoNgay.RowTemplate.Height = 36;
            this.dgvBaoCaoNgay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCaoNgay.Size = new System.Drawing.Size(1120, 328);
            this.dgvBaoCaoNgay.TabIndex = 0;
            // 
            // pnlGridHeader
            // 
            this.pnlGridHeader.BackColor = System.Drawing.Color.White;
            this.pnlGridHeader.Controls.Add(this.lblGridTitle);
            this.pnlGridHeader.Controls.Add(this.lblGridSub);
            this.pnlGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlGridHeader.Name = "pnlGridHeader";
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
            this.lblGridTitle.Size = new System.Drawing.Size(179, 23);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "Doanh thu theo ngày";
            // 
            // lblGridSub
            // 
            this.lblGridSub.AutoSize = true;
            this.lblGridSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblGridSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(165)))));
            this.lblGridSub.Location = new System.Drawing.Point(16, 28);
            this.lblGridSub.Name = "lblGridSub";
            this.lblGridSub.Size = new System.Drawing.Size(381, 20);
            this.lblGridSub.TabIndex = 1;
            this.lblGridSub.Text = "V_BAOCAO_DOANHTHU_NGAY · sắp xếp mới nhất trước";
            // 
            // pnlVAT
            // 
            this.pnlVAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlVAT.Controls.Add(this.pnlVATInner);
            this.pnlVAT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlVAT.Location = new System.Drawing.Point(20, 382);
            this.pnlVAT.Name = "pnlVAT";
            this.pnlVAT.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnlVAT.Size = new System.Drawing.Size(1120, 120);
            this.pnlVAT.TabIndex = 1;
            // 
            // pnlVATInner
            // 
            this.pnlVATInner.BackColor = System.Drawing.Color.White;
            this.pnlVATInner.Controls.Add(this.lblVATTitle);
            this.pnlVATInner.Controls.Add(this.lblVATDesc);
            this.pnlVATInner.Controls.Add(this.pnlVATRow);
            this.pnlVATInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVATInner.Location = new System.Drawing.Point(0, 10);
            this.pnlVATInner.Name = "pnlVATInner";
            this.pnlVATInner.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.pnlVATInner.Size = new System.Drawing.Size(1120, 100);
            this.pnlVATInner.TabIndex = 0;
            // 
            // lblVATTitle
            // 
            this.lblVATTitle.AutoSize = true;
            this.lblVATTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVATTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.lblVATTitle.Location = new System.Drawing.Point(18, 12);
            this.lblVATTitle.Name = "lblVATTitle";
            this.lblVATTitle.Size = new System.Drawing.Size(263, 21);
            this.lblVATTitle.TabIndex = 0;
            this.lblVATTitle.Text = "▼  Kiểm tra VAT theo mã hóa đơn";
            // 
            // lblVATDesc
            // 
            this.lblVATDesc.AutoSize = true;
            this.lblVATDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVATDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(165)))));
            this.lblVATDesc.Location = new System.Drawing.Point(20, 32);
            this.lblVATDesc.Name = "lblVATDesc";
            this.lblVATDesc.Size = new System.Drawing.Size(462, 19);
            this.lblVATDesc.TabIndex = 1;
            this.lblVATDesc.Text = "Gọi fn_TinhThueVAT(@MaHD) · HOADON.THUEVAT × TRIGIATRUOCTHUE";
            // 
            // pnlVATRow
            // 
            this.pnlVATRow.BackColor = System.Drawing.Color.Transparent;
            this.pnlVATRow.Controls.Add(this.lblMaHDCheck);
            this.pnlVATRow.Controls.Add(this.txtMaHDCheck);
            this.pnlVATRow.Controls.Add(this.btnTinhVAT);
            this.pnlVATRow.Controls.Add(this.lblSep);
            this.pnlVATRow.Controls.Add(this.lblGiaTriVAT);
            this.pnlVATRow.Controls.Add(this.txtGiaTriVAT);
            this.pnlVATRow.Location = new System.Drawing.Point(18, 52);
            this.pnlVATRow.Name = "pnlVATRow";
            this.pnlVATRow.Size = new System.Drawing.Size(860, 36);
            this.pnlVATRow.TabIndex = 2;
            // 
            // lblMaHDCheck
            // 
            this.lblMaHDCheck.AutoSize = true;
            this.lblMaHDCheck.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaHDCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.lblMaHDCheck.Location = new System.Drawing.Point(0, 8);
            this.lblMaHDCheck.Name = "lblMaHDCheck";
            this.lblMaHDCheck.Size = new System.Drawing.Size(89, 20);
            this.lblMaHDCheck.TabIndex = 0;
            this.lblMaHDCheck.Text = "Mã hóa đơn";
            // 
            // txtMaHDCheck
            // 
            this.txtMaHDCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.txtMaHDCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaHDCheck.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaHDCheck.Location = new System.Drawing.Point(96, 4);
            this.txtMaHDCheck.Name = "txtMaHDCheck";
            this.txtMaHDCheck.Size = new System.Drawing.Size(120, 30);
            this.txtMaHDCheck.TabIndex = 1;
            this.txtMaHDCheck.Text = "HD001";
            this.txtMaHDCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTinhVAT
            // 
            this.btnTinhVAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.btnTinhVAT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTinhVAT.FlatAppearance.BorderSize = 0;
            this.btnTinhVAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhVAT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTinhVAT.ForeColor = System.Drawing.Color.White;
            this.btnTinhVAT.Location = new System.Drawing.Point(230, 2);
            this.btnTinhVAT.Name = "btnTinhVAT";
            this.btnTinhVAT.Size = new System.Drawing.Size(110, 32);
            this.btnTinhVAT.TabIndex = 2;
            this.btnTinhVAT.Text = "Tính VAT";
            this.btnTinhVAT.UseVisualStyleBackColor = false;
            this.btnTinhVAT.Click += new System.EventHandler(this.btnTinhVAT_Click);
            // 
            // lblSep
            // 
            this.lblSep.AutoSize = true;
            this.lblSep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(185)))), ((int)(((byte)(195)))));
            this.lblSep.Location = new System.Drawing.Point(352, 8);
            this.lblSep.Name = "lblSep";
            this.lblSep.Size = new System.Drawing.Size(22, 20);
            this.lblSep.TabIndex = 3;
            this.lblSep.Text = "→";
            // 
            // lblGiaTriVAT
            // 
            this.lblGiaTriVAT.AutoSize = true;
            this.lblGiaTriVAT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGiaTriVAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(105)))));
            this.lblGiaTriVAT.Location = new System.Drawing.Point(374, 8);
            this.lblGiaTriVAT.Name = "lblGiaTriVAT";
            this.lblGiaTriVAT.Size = new System.Drawing.Size(101, 20);
            this.lblGiaTriVAT.TabIndex = 4;
            this.lblGiaTriVAT.Text = "Giá trị VAT (đ)";
            // 
            // txtGiaTriVAT
            // 
            this.txtGiaTriVAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(235)))));
            this.txtGiaTriVAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGiaTriVAT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtGiaTriVAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.txtGiaTriVAT.Location = new System.Drawing.Point(478, 2);
            this.txtGiaTriVAT.Name = "txtGiaTriVAT";
            this.txtGiaTriVAT.ReadOnly = true;
            this.txtGiaTriVAT.Size = new System.Drawing.Size(190, 32);
            this.txtGiaTriVAT.TabIndex = 5;
            this.txtGiaTriVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 672);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1160, 28);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(170)))), ((int)(((byte)(210)))));
            this.lblFooter.Location = new System.Drawing.Point(0, 7);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(538, 19);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "  TH True Mart © 2025 · V_BAOCAO_DOANHTHU_NGAY · fn_TinhThueVAT · HOADON";
            // 
            // FormChiTiet_HD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1160, 700);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 580);
            this.Name = "FormChiTiet_HD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Hóa Đơn & Báo Cáo Tổng Hợp · TH True Mart";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormChiTietHD_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStat3.ResumeLayout(false);
            this.pnlStat3.PerformLayout();
            this.pnlStat2.ResumeLayout(false);
            this.pnlStat2.PerformLayout();
            this.pnlStat1.ResumeLayout(false);
            this.pnlStat1.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoNgay)).EndInit();
            this.pnlGridHeader.ResumeLayout(false);
            this.pnlGridHeader.PerformLayout();
            this.pnlVAT.ResumeLayout(false);
            this.pnlVATInner.ResumeLayout(false);
            this.pnlVATInner.PerformLayout();
            this.pnlVATRow.ResumeLayout(false);
            this.pnlVATRow.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlStat1;
        private System.Windows.Forms.Label lblStat1Val;
        private System.Windows.Forms.Label lblStat1Lbl;
        private System.Windows.Forms.Panel pnlStat2;
        private System.Windows.Forms.Label lblStat2Val;
        private System.Windows.Forms.Label lblStat2Lbl;
        private System.Windows.Forms.Panel pnlStat3;
        private System.Windows.Forms.Label lblStat3Val;
        private System.Windows.Forms.Label lblStat3Lbl;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlGridHeader;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Label lblGridSub;
        private System.Windows.Forms.DataGridView dgvBaoCaoNgay;
        private System.Windows.Forms.Panel pnlVAT;
        private System.Windows.Forms.Panel pnlVATInner;
        private System.Windows.Forms.Label lblVATTitle;
        private System.Windows.Forms.Label lblVATDesc;
        private System.Windows.Forms.Panel pnlVATRow;
        private System.Windows.Forms.Label lblMaHDCheck;
        private System.Windows.Forms.TextBox txtMaHDCheck;
        private System.Windows.Forms.Button btnTinhVAT;
        private System.Windows.Forms.Label lblSep;
        private System.Windows.Forms.Label lblGiaTriVAT;
        private System.Windows.Forms.TextBox txtGiaTriVAT;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}