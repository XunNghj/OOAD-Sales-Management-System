namespace SQL_THTRUEMART
{
    partial class FormPhieuXuat
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlGridWrap = new System.Windows.Forms.Panel();
            this.dgvChiTietPX = new System.Windows.Forms.DataGridView();
            this.pnlGridHead = new System.Windows.Forms.Panel();
            this.pnlGridBtns = new System.Windows.Forms.Panel();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.lblGridHint = new System.Windows.Forms.Label();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblHintSave = new System.Windows.Forms.Label();
            this.lblTongGiaLabel = new System.Windows.Forms.Label();
            this.txtTongGia = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.lblMaPX = new System.Windows.Forms.Label();
            this.txtMaPX = new System.Windows.Forms.TextBox();
            this.lblNgayXuat = new System.Windows.Forms.Label();
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.lblKhoXuat = new System.Windows.Forms.Label();
            this.cboKhoXuat = new System.Windows.Forms.ComboBox();
            this.lblNV = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblDiaDiemGH = new System.Windows.Forms.Label();
            this.txtDiaDiemGH = new System.Windows.Forms.TextBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.splitter = new System.Windows.Forms.Splitter();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.pnlLeftFoot = new System.Windows.Forms.Panel();
            this.btnLapMoiPX = new System.Windows.Forms.Button();
            this.btnSuaPX = new System.Windows.Forms.Button();
            this.btnXoaPX = new System.Windows.Forms.Button();
            this.pnlLeftHead = new System.Windows.Forms.Panel();
            this.btnSearchPX = new System.Windows.Forms.Button();
            this.txtSearchPX = new System.Windows.Forms.TextBox();
            this.lblLeftTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlGridWrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPX)).BeginInit();
            this.pnlGridHead.SuspendLayout();
            this.pnlGridBtns.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlLeftFoot.SuspendLayout();
            this.pnlLeftHead.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 72);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(190)))), ((int)(((byte)(230)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 42);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(176, 20);
            this.lblSubtitle.TabIndex = 0;
            this.lblSubtitle.Text = "TH True Mart - Xuat hang";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(28, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(264, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "LAP PHIEU XUAT KHO";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlBody.Controls.Add(this.pnlRight);
            this.pnlBody.Controls.Add(this.splitter);
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 72);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1200, 722);
            this.pnlBody.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlRight.Controls.Add(this.pnlGridWrap);
            this.pnlRight.Controls.Add(this.pnlSummary);
            this.pnlRight.Controls.Add(this.pnlInfo);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(463, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(6, 8, 8, 0);
            this.pnlRight.Size = new System.Drawing.Size(737, 722);
            this.pnlRight.TabIndex = 0;
            // 
            // pnlGridWrap
            // 
            this.pnlGridWrap.BackColor = System.Drawing.Color.White;
            this.pnlGridWrap.Controls.Add(this.dgvChiTietPX);
            this.pnlGridWrap.Controls.Add(this.pnlGridHead);
            this.pnlGridWrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridWrap.Location = new System.Drawing.Point(6, 168);
            this.pnlGridWrap.Name = "pnlGridWrap";
            this.pnlGridWrap.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlGridWrap.Size = new System.Drawing.Size(723, 500);
            this.pnlGridWrap.TabIndex = 0;
            // 
            // dgvChiTietPX
            // 
            this.dgvChiTietPX.AllowUserToAddRows = false;
            this.dgvChiTietPX.AllowUserToDeleteRows = false;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dgvChiTietPX.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle34;
            this.dgvChiTietPX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPX.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietPX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTietPX.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietPX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
            this.dgvChiTietPX.ColumnHeadersHeight = 34;
            this.dgvChiTietPX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle36.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietPX.DefaultCellStyle = dataGridViewCellStyle36;
            this.dgvChiTietPX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPX.EnableHeadersVisualStyles = false;
            this.dgvChiTietPX.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvChiTietPX.Location = new System.Drawing.Point(0, 52);
            this.dgvChiTietPX.Name = "dgvChiTietPX";
            this.dgvChiTietPX.RowHeadersVisible = false;
            this.dgvChiTietPX.RowHeadersWidth = 51;
            this.dgvChiTietPX.RowTemplate.Height = 34;
            this.dgvChiTietPX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPX.Size = new System.Drawing.Size(723, 448);
            this.dgvChiTietPX.TabIndex = 0;
            this.dgvChiTietPX.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPX_CellValueChanged);
            // 
            // pnlGridHead
            // 
            this.pnlGridHead.BackColor = System.Drawing.Color.White;
            this.pnlGridHead.Controls.Add(this.pnlGridBtns);
            this.pnlGridHead.Controls.Add(this.lblGridHint);
            this.pnlGridHead.Controls.Add(this.lblGridTitle);
            this.pnlGridHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridHead.Location = new System.Drawing.Point(0, 8);
            this.pnlGridHead.Name = "pnlGridHead";
            this.pnlGridHead.Padding = new System.Windows.Forms.Padding(12, 8, 8, 4);
            this.pnlGridHead.Size = new System.Drawing.Size(723, 44);
            this.pnlGridHead.TabIndex = 1;
            // 
            // pnlGridBtns
            // 
            this.pnlGridBtns.BackColor = System.Drawing.Color.White;
            this.pnlGridBtns.Controls.Add(this.btnAddRow);
            this.pnlGridBtns.Controls.Add(this.btnDelRow);
            this.pnlGridBtns.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlGridBtns.Location = new System.Drawing.Point(495, 8);
            this.pnlGridBtns.Name = "pnlGridBtns";
            this.pnlGridBtns.Padding = new System.Windows.Forms.Padding(0, 6, 8, 6);
            this.pnlGridBtns.Size = new System.Drawing.Size(220, 32);
            this.pnlGridBtns.TabIndex = 0;
            // 
            // btnAddRow
            // 
            this.btnAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.btnAddRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRow.FlatAppearance.BorderSize = 0;
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnAddRow.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Location = new System.Drawing.Point(0, 0);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(100, 28);
            this.btnAddRow.TabIndex = 0;
            this.btnAddRow.Text = "+ Them dong";
            this.btnAddRow.UseVisualStyleBackColor = false;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnDelRow
            // 
            this.btnDelRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDelRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelRow.FlatAppearance.BorderSize = 0;
            this.btnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelRow.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnDelRow.ForeColor = System.Drawing.Color.White;
            this.btnDelRow.Location = new System.Drawing.Point(108, 0);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(100, 28);
            this.btnDelRow.TabIndex = 1;
            this.btnDelRow.Text = "- Xoa dong";
            this.btnDelRow.UseVisualStyleBackColor = false;
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // lblGridHint
            // 
            this.lblGridHint.AutoSize = true;
            this.lblGridHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblGridHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblGridHint.Location = new System.Drawing.Point(14, 28);
            this.lblGridHint.Name = "lblGridHint";
            this.lblGridHint.Size = new System.Drawing.Size(506, 19);
            this.lblGridHint.TabIndex = 1;
            this.lblGridHint.Text = "Chon SP - nhap SL - don gia lay tu gia ban moi nhat - ton kho hien thi o cot cuoi" +
    "";
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.lblGridTitle.Location = new System.Drawing.Point(12, 8);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(181, 21);
            this.lblGridTitle.TabIndex = 2;
            this.lblGridTitle.Text = "Chi tiet san pham xuat";
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.pnlSummary.Controls.Add(this.lblHintSave);
            this.pnlSummary.Controls.Add(this.lblTongGiaLabel);
            this.pnlSummary.Controls.Add(this.txtTongGia);
            this.pnlSummary.Controls.Add(this.btnCancel);
            this.pnlSummary.Controls.Add(this.btnSave);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummary.Location = new System.Drawing.Point(6, 668);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(723, 54);
            this.pnlSummary.TabIndex = 1;
            // 
            // lblHintSave
            // 
            this.lblHintSave.AutoSize = true;
            this.lblHintSave.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHintSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
            this.lblHintSave.Location = new System.Drawing.Point(12, 16);
            this.lblHintSave.Name = "lblHintSave";
            this.lblHintSave.Size = new System.Drawing.Size(0, 19);
            this.lblHintSave.TabIndex = 0;
            // 
            // lblTongGiaLabel
            // 
            this.lblTongGiaLabel.AutoSize = true;
            this.lblTongGiaLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongGiaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.lblTongGiaLabel.Location = new System.Drawing.Point(3, 20);
            this.lblTongGiaLabel.Name = "lblTongGiaLabel";
            this.lblTongGiaLabel.Size = new System.Drawing.Size(153, 20);
            this.lblTongGiaLabel.TabIndex = 1;
            this.lblTongGiaLabel.Text = "Tong tri gia xuat (d):";
            // 
            // txtTongGia
            // 
            this.txtTongGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.txtTongGia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTongGia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtTongGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(80)))), ((int)(((byte)(0)))));
            this.txtTongGia.Location = new System.Drawing.Point(162, 16);
            this.txtTongGia.Name = "txtTongGia";
            this.txtTongGia.ReadOnly = true;
            this.txtTongGia.Size = new System.Drawing.Size(162, 25);
            this.txtTongGia.TabIndex = 2;
            this.txtTongGia.Text = "0";
            this.txtTongGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(110)))));
            this.btnCancel.Location = new System.Drawing.Point(623, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Huy bo";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(100)))), ((int)(((byte)(60)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(461, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Luu Phieu Xuat";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblInfoTitle);
            this.pnlInfo.Controls.Add(this.lblMaPX);
            this.pnlInfo.Controls.Add(this.txtMaPX);
            this.pnlInfo.Controls.Add(this.lblNgayXuat);
            this.pnlInfo.Controls.Add(this.dtpNgayXuat);
            this.pnlInfo.Controls.Add(this.lblKhoXuat);
            this.pnlInfo.Controls.Add(this.cboKhoXuat);
            this.pnlInfo.Controls.Add(this.lblNV);
            this.pnlInfo.Controls.Add(this.cboNhanVien);
            this.pnlInfo.Controls.Add(this.lblDiaDiemGH);
            this.pnlInfo.Controls.Add(this.txtDiaDiemGH);
            this.pnlInfo.Controls.Add(this.lblLyDo);
            this.pnlInfo.Controls.Add(this.txtLyDo);
            this.pnlInfo.Controls.Add(this.lblGhiChu);
            this.pnlInfo.Controls.Add(this.txtGhiChu);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(6, 8);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlInfo.Size = new System.Drawing.Size(723, 160);
            this.pnlInfo.TabIndex = 2;
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.lblInfoTitle.Location = new System.Drawing.Point(14, 10);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(170, 21);
            this.lblInfoTitle.TabIndex = 0;
            this.lblInfoTitle.Text = "Thong tin phieu xuat";
            // 
            // lblMaPX
            // 
            this.lblMaPX.AutoSize = true;
            this.lblMaPX.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMaPX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.lblMaPX.Location = new System.Drawing.Point(14, 32);
            this.lblMaPX.Name = "lblMaPX";
            this.lblMaPX.Size = new System.Drawing.Size(81, 20);
            this.lblMaPX.TabIndex = 1;
            this.lblMaPX.Text = "Ma phieu *";
            // 
            // txtMaPX
            // 
            this.txtMaPX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(239)))), ((int)(((byte)(246)))));
            this.txtMaPX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaPX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaPX.Location = new System.Drawing.Point(14, 50);
            this.txtMaPX.Name = "txtMaPX";
            this.txtMaPX.ReadOnly = true;
            this.txtMaPX.Size = new System.Drawing.Size(110, 27);
            this.txtMaPX.TabIndex = 2;
            // 
            // lblNgayXuat
            // 
            this.lblNgayXuat.AutoSize = true;
            this.lblNgayXuat.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNgayXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.lblNgayXuat.Location = new System.Drawing.Point(138, 32);
            this.lblNgayXuat.Name = "lblNgayXuat";
            this.lblNgayXuat.Size = new System.Drawing.Size(76, 20);
            this.lblNgayXuat.TabIndex = 3;
            this.lblNgayXuat.Text = "Ngay xuat";
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayXuat.Location = new System.Drawing.Point(138, 50);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(130, 27);
            this.dtpNgayXuat.TabIndex = 4;
            // 
            // lblKhoXuat
            // 
            this.lblKhoXuat.AutoSize = true;
            this.lblKhoXuat.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblKhoXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.lblKhoXuat.Location = new System.Drawing.Point(282, 32);
            this.lblKhoXuat.Name = "lblKhoXuat";
            this.lblKhoXuat.Size = new System.Drawing.Size(77, 20);
            this.lblKhoXuat.TabIndex = 5;
            this.lblKhoXuat.Text = "Kho xuat *";
            // 
            // cboKhoXuat
            // 
            this.cboKhoXuat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoXuat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKhoXuat.Location = new System.Drawing.Point(282, 50);
            this.cboKhoXuat.Name = "cboKhoXuat";
            this.cboKhoXuat.Size = new System.Drawing.Size(200, 28);
            this.cboKhoXuat.TabIndex = 6;
            // 
            // lblNV
            // 
            this.lblNV.AutoSize = true;
            this.lblNV.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.lblNV.Location = new System.Drawing.Point(496, 32);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(85, 20);
            this.lblNV.TabIndex = 7;
            this.lblNV.Text = "Nhan vien *";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNhanVien.Location = new System.Drawing.Point(496, 50);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(220, 28);
            this.cboNhanVien.TabIndex = 8;
            // 
            // lblDiaDiemGH
            // 
            this.lblDiaDiemGH.AutoSize = true;
            this.lblDiaDiemGH.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDiaDiemGH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.lblDiaDiemGH.Location = new System.Drawing.Point(14, 84);
            this.lblDiaDiemGH.Name = "lblDiaDiemGH";
            this.lblDiaDiemGH.Size = new System.Drawing.Size(151, 20);
            this.lblDiaDiemGH.TabIndex = 9;
            this.lblDiaDiemGH.Text = "Dia diem giao hang *";
            // 
            // txtDiaDiemGH
            // 
            this.txtDiaDiemGH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.txtDiaDiemGH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaDiemGH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiaDiemGH.Location = new System.Drawing.Point(14, 102);
            this.txtDiaDiemGH.Name = "txtDiaDiemGH";
            this.txtDiaDiemGH.Size = new System.Drawing.Size(340, 27);
            this.txtDiaDiemGH.TabIndex = 10;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLyDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.lblLyDo.Location = new System.Drawing.Point(368, 84);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(76, 20);
            this.lblLyDo.TabIndex = 11;
            this.lblLyDo.Text = "Ly do xuat";
            // 
            // txtLyDo
            // 
            this.txtLyDo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.txtLyDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLyDo.Location = new System.Drawing.Point(368, 102);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(200, 27);
            this.txtLyDo.TabIndex = 12;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(125)))));
            this.lblGhiChu.Location = new System.Drawing.Point(582, 84);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(58, 20);
            this.lblGhiChu.TabIndex = 13;
            this.lblGhiChu.Text = "Ghi chu";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGhiChu.Location = new System.Drawing.Point(582, 102);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(200, 27);
            this.txtGhiChu.TabIndex = 14;
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(225)))));
            this.splitter.Location = new System.Drawing.Point(460, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 722);
            this.splitter.TabIndex = 1;
            this.splitter.TabStop = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.pnlLeft.Controls.Add(this.dgvHistory);
            this.pnlLeft.Controls.Add(this.pnlLeftFoot);
            this.pnlLeft.Controls.Add(this.pnlLeftHead);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(8, 8, 4, 8);
            this.pnlLeft.Size = new System.Drawing.Size(460, 722);
            this.pnlLeft.TabIndex = 2;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle32.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.dgvHistory.ColumnHeadersHeight = 32;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle33.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle33;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvHistory.Location = new System.Drawing.Point(8, 84);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 30;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(448, 582);
            this.dgvHistory.TabIndex = 0;
            this.dgvHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistory_CellClick);
            // 
            // pnlLeftFoot
            // 
            this.pnlLeftFoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.pnlLeftFoot.Controls.Add(this.btnLapMoiPX);
            this.pnlLeftFoot.Controls.Add(this.btnSuaPX);
            this.pnlLeftFoot.Controls.Add(this.btnXoaPX);
            this.pnlLeftFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLeftFoot.Location = new System.Drawing.Point(8, 666);
            this.pnlLeftFoot.Name = "pnlLeftFoot";
            this.pnlLeftFoot.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeftFoot.Size = new System.Drawing.Size(448, 48);
            this.pnlLeftFoot.TabIndex = 1;
            // 
            // btnLapMoiPX
            // 
            this.btnLapMoiPX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.btnLapMoiPX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLapMoiPX.FlatAppearance.BorderSize = 0;
            this.btnLapMoiPX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapMoiPX.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLapMoiPX.ForeColor = System.Drawing.Color.White;
            this.btnLapMoiPX.Location = new System.Drawing.Point(10, 0);
            this.btnLapMoiPX.Name = "btnLapMoiPX";
            this.btnLapMoiPX.Size = new System.Drawing.Size(120, 35);
            this.btnLapMoiPX.TabIndex = 0;
            this.btnLapMoiPX.Text = "+ Lap phieu moi";
            this.btnLapMoiPX.UseVisualStyleBackColor = false;
            this.btnLapMoiPX.Click += new System.EventHandler(this.btnLapMoiPX_Click);
            // 
            // btnSuaPX
            // 
            this.btnSuaPX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.btnSuaPX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaPX.FlatAppearance.BorderSize = 0;
            this.btnSuaPX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaPX.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnSuaPX.ForeColor = System.Drawing.Color.White;
            this.btnSuaPX.Location = new System.Drawing.Point(138, 0);
            this.btnSuaPX.Name = "btnSuaPX";
            this.btnSuaPX.Size = new System.Drawing.Size(100, 35);
            this.btnSuaPX.TabIndex = 1;
            this.btnSuaPX.Text = "Sua phieu";
            this.btnSuaPX.UseVisualStyleBackColor = false;
            this.btnSuaPX.Click += new System.EventHandler(this.btnSuaPX_Click);
            // 
            // btnXoaPX
            // 
            this.btnXoaPX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnXoaPX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaPX.FlatAppearance.BorderSize = 0;
            this.btnXoaPX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPX.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaPX.ForeColor = System.Drawing.Color.White;
            this.btnXoaPX.Location = new System.Drawing.Point(246, 0);
            this.btnXoaPX.Name = "btnXoaPX";
            this.btnXoaPX.Size = new System.Drawing.Size(100, 35);
            this.btnXoaPX.TabIndex = 2;
            this.btnXoaPX.Text = "Xoa phieu";
            this.btnXoaPX.UseVisualStyleBackColor = false;
            this.btnXoaPX.Click += new System.EventHandler(this.btnXoaPX_Click);
            // 
            // pnlLeftHead
            // 
            this.pnlLeftHead.BackColor = System.Drawing.Color.White;
            this.pnlLeftHead.Controls.Add(this.btnSearchPX);
            this.pnlLeftHead.Controls.Add(this.txtSearchPX);
            this.pnlLeftHead.Controls.Add(this.lblLeftTitle);
            this.pnlLeftHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftHead.Location = new System.Drawing.Point(8, 8);
            this.pnlLeftHead.Name = "pnlLeftHead";
            this.pnlLeftHead.Padding = new System.Windows.Forms.Padding(10, 8, 10, 6);
            this.pnlLeftHead.Size = new System.Drawing.Size(448, 76);
            this.pnlLeftHead.TabIndex = 2;
            // 
            // btnSearchPX
            // 
            this.btnSearchPX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(139)))), ((int)(((byte)(253)))));
            this.btnSearchPX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPX.FlatAppearance.BorderSize = 0;
            this.btnSearchPX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPX.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSearchPX.ForeColor = System.Drawing.Color.White;
            this.btnSearchPX.Location = new System.Drawing.Point(296, 38);
            this.btnSearchPX.Name = "btnSearchPX";
            this.btnSearchPX.Size = new System.Drawing.Size(58, 26);
            this.btnSearchPX.TabIndex = 0;
            this.btnSearchPX.Text = "Tim";
            this.btnSearchPX.UseVisualStyleBackColor = false;
            this.btnSearchPX.Click += new System.EventHandler(this.btnSearchPX_Click);
            // 
            // txtSearchPX
            // 
            this.txtSearchPX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(253)))));
            this.txtSearchPX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchPX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchPX.Location = new System.Drawing.Point(10, 38);
            this.txtSearchPX.Name = "txtSearchPX";
            this.txtSearchPX.Size = new System.Drawing.Size(280, 27);
            this.txtSearchPX.TabIndex = 1;
            this.txtSearchPX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchPX_KeyDown);
            // 
            // lblLeftTitle
            // 
            this.lblLeftTitle.AutoSize = true;
            this.lblLeftTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLeftTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.lblLeftTitle.Location = new System.Drawing.Point(10, 8);
            this.lblLeftTitle.Name = "lblLeftTitle";
            this.lblLeftTitle.Size = new System.Drawing.Size(148, 21);
            this.lblLeftTitle.TabIndex = 2;
            this.lblLeftTitle.Text = "Lich su phieu xuat";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(43)))), ((int)(((byte)(90)))));
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 794);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1200, 26);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(190)))), ((int)(((byte)(230)))));
            this.lblFooter.Location = new System.Drawing.Point(0, 6);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(398, 19);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "  TH True Mart 2025 - PHIEUXUAT - CT_PHIEUXUAT - TONKHO";
            // 
            // FormPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1200, 820);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FormPhieuXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormPhieuXuat_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlGridWrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPX)).EndInit();
            this.pnlGridHead.ResumeLayout(false);
            this.pnlGridHead.PerformLayout();
            this.pnlGridBtns.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlLeftFoot.ResumeLayout(false);
            this.pnlLeftHead.ResumeLayout(false);
            this.pnlLeftHead.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblSubtitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlLeft, pnlLeftHead, pnlLeftFoot;
        private System.Windows.Forms.Label lblLeftTitle;
        private System.Windows.Forms.TextBox txtSearchPX;
        private System.Windows.Forms.Button btnSearchPX;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnLapMoiPX, btnSuaPX, btnXoaPX;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pnlRight, pnlInfo;
        private System.Windows.Forms.Label lblInfoTitle, lblMaPX, lblNgayXuat, lblKhoXuat, lblNV, lblDiaDiemGH, lblLyDo, lblGhiChu;
        private System.Windows.Forms.TextBox txtMaPX, txtDiaDiemGH, txtLyDo, txtGhiChu;
        private System.Windows.Forms.DateTimePicker dtpNgayXuat;
        private System.Windows.Forms.ComboBox cboKhoXuat, cboNhanVien;
        private System.Windows.Forms.Panel pnlGridWrap, pnlGridHead, pnlGridBtns;
        private System.Windows.Forms.Label lblGridTitle, lblGridHint;
        private System.Windows.Forms.Button btnAddRow, btnDelRow;
        private System.Windows.Forms.DataGridView dgvChiTietPX;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTongGiaLabel, lblHintSave;
        private System.Windows.Forms.TextBox txtTongGia;
        private System.Windows.Forms.Button btnSave, btnCancel;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}