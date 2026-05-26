namespace SQL_THTRUEMART
{
    partial class FormPhanQuyen
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
            // ── Header ──
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            // ── Badge bar ──
            this.pnlBadgeBar = new System.Windows.Forms.Panel();
            this.pnlBadge1 = new System.Windows.Forms.Panel();
            this.lblBadge1Val = new System.Windows.Forms.Label();
            this.lblBadge1Lbl = new System.Windows.Forms.Label();
            this.pnlBadge2 = new System.Windows.Forms.Panel();
            this.lblBadge2Val = new System.Windows.Forms.Label();
            this.lblBadge2Lbl = new System.Windows.Forms.Label();
            this.pnlBadge3 = new System.Windows.Forms.Panel();
            this.lblBadge3Val = new System.Windows.Forms.Label();
            this.lblBadge3Lbl = new System.Windows.Forms.Label();
            // ── 3-column body ──
            this.pnlBody = new System.Windows.Forms.Panel();
            // Col A: Users
            this.pnlColA = new System.Windows.Forms.Panel();
            this.pnlColACard = new System.Windows.Forms.Panel();
            this.pnlColAHead = new System.Windows.Forms.Panel();
            this.lblColATitle = new System.Windows.Forms.Label();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            // Col B: Roles
            this.pnlColB = new System.Windows.Forms.Panel();
            this.pnlColBCard = new System.Windows.Forms.Panel();
            this.pnlColBHead = new System.Windows.Forms.Panel();
            this.lblColBTitle = new System.Windows.Forms.Label();
            this.lblColBSel = new System.Windows.Forms.Label();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.pnlColBBtns = new System.Windows.Forms.Panel();
            this.btnGrantRole = new System.Windows.Forms.Button();
            this.btnRevokeRole = new System.Windows.Forms.Button();
            // Col C: Permissions
            this.pnlColC = new System.Windows.Forms.Panel();
            this.pnlColCCard = new System.Windows.Forms.Panel();
            this.pnlColCHead = new System.Windows.Forms.Panel();
            this.lblColCTitle = new System.Windows.Forms.Label();
            this.lblColCSel = new System.Windows.Forms.Label();
            this.dgvPermissions = new System.Windows.Forms.DataGridView();
            this.pnlColCBtns = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            // ── Footer ──
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlBadgeBar.SuspendLayout();
            this.pnlBadge1.SuspendLayout(); this.pnlBadge2.SuspendLayout(); this.pnlBadge3.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlColA.SuspendLayout(); this.pnlColACard.SuspendLayout(); this.pnlColAHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlColB.SuspendLayout(); this.pnlColBCard.SuspendLayout(); this.pnlColBHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.pnlColBBtns.SuspendLayout();
            this.pnlColC.SuspendLayout(); this.pnlColCCard.SuspendLayout(); this.pnlColCHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).BeginInit();
            this.pnlColCBtns.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            var colNav = System.Drawing.Color.FromArgb(13, 43, 90);
            var colBg = System.Drawing.Color.FromArgb(245, 247, 251);
            var colWhite = System.Drawing.Color.White;

            // ── HEADER ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = colNav;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 72;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = colWhite;
            this.lblTitle.Location = new System.Drawing.Point(28, 12);
            this.lblTitle.Text = "QUAN LY PHAN QUYEN";

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 190, 230);
            this.lblSubtitle.Location = new System.Drawing.Point(30, 42);
            this.lblSubtitle.Text = "TH True Mart - Security Dashboard";

            // ── BADGE BAR ────────────────────────────────────────────────
            this.pnlBadgeBar.BackColor = colBg;
            this.pnlBadgeBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBadgeBar.Height = 76;
            this.pnlBadgeBar.Padding = new System.Windows.Forms.Padding(16, 8, 16, 10);
            this.pnlBadgeBar.Controls.Add(this.pnlBadge3);
            this.pnlBadgeBar.Controls.Add(this.pnlBadge2);
            this.pnlBadgeBar.Controls.Add(this.pnlBadge1);

            // badge helper (inline)
            this.pnlBadge1.BackColor = colWhite; this.pnlBadge1.Size = new System.Drawing.Size(200, 58); this.pnlBadge1.Location = new System.Drawing.Point(16, 8); this.pnlBadge1.Controls.Add(this.lblBadge1Lbl); this.pnlBadge1.Controls.Add(this.lblBadge1Val);
            this.lblBadge1Lbl.AutoSize = true; this.lblBadge1Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblBadge1Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblBadge1Lbl.Location = new System.Drawing.Point(12, 7); this.lblBadge1Lbl.Text = "USERS / ROLES";
            this.lblBadge1Val.AutoSize = true; this.lblBadge1Val.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.lblBadge1Val.ForeColor = colNav; this.lblBadge1Val.Location = new System.Drawing.Point(12, 24); this.lblBadge1Val.Name = "lblBadge1Val"; this.lblBadge1Val.Text = "...";

            this.pnlBadge2.BackColor = colWhite; this.pnlBadge2.Size = new System.Drawing.Size(200, 58); this.pnlBadge2.Location = new System.Drawing.Point(228, 8); this.pnlBadge2.Controls.Add(this.lblBadge2Lbl); this.pnlBadge2.Controls.Add(this.lblBadge2Val);
            this.lblBadge2Lbl.AutoSize = true; this.lblBadge2Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblBadge2Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblBadge2Lbl.Location = new System.Drawing.Point(12, 7); this.lblBadge2Lbl.Text = "ROLES (VAI TRO)";
            this.lblBadge2Val.AutoSize = true; this.lblBadge2Val.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.lblBadge2Val.ForeColor = System.Drawing.Color.FromArgb(80, 40, 160); this.lblBadge2Val.Location = new System.Drawing.Point(12, 24); this.lblBadge2Val.Name = "lblBadge2Val"; this.lblBadge2Val.Text = "...";

            this.pnlBadge3.BackColor = colWhite; this.pnlBadge3.Size = new System.Drawing.Size(200, 58); this.pnlBadge3.Location = new System.Drawing.Point(440, 8); this.pnlBadge3.Controls.Add(this.lblBadge3Lbl); this.pnlBadge3.Controls.Add(this.lblBadge3Val);
            this.lblBadge3Lbl.AutoSize = true; this.lblBadge3Lbl.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblBadge3Lbl.ForeColor = System.Drawing.Color.FromArgb(120, 130, 145); this.lblBadge3Lbl.Location = new System.Drawing.Point(12, 7); this.lblBadge3Lbl.Text = "QUYEN DUOC CAP";
            this.lblBadge3Val.AutoSize = true; this.lblBadge3Val.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold); this.lblBadge3Val.ForeColor = System.Drawing.Color.FromArgb(13, 100, 60); this.lblBadge3Val.Location = new System.Drawing.Point(12, 24); this.lblBadge3Val.Name = "lblBadge3Val"; this.lblBadge3Val.Text = "...";

            // ── BODY (3 columns) ─────────────────────────────────────────
            this.pnlBody.BackColor = colBg;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.pnlBody.Controls.Add(this.pnlColC);
            this.pnlBody.Controls.Add(this.pnlColB);
            this.pnlBody.Controls.Add(this.pnlColA);

            // ── COL A: USERS ─────────────────────────────────────────────
            this.pnlColA.BackColor = colBg;
            this.pnlColA.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlColA.Width = 280;
            this.pnlColA.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlColA.Controls.Add(this.pnlColACard);

            this.pnlColACard.BackColor = colWhite;
            this.pnlColACard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColACard.Controls.Add(this.dgvUsers);
            this.pnlColACard.Controls.Add(this.pnlColAHead);

            this.pnlColAHead.BackColor = colWhite;
            this.pnlColAHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColAHead.Height = 78;
            this.pnlColAHead.Padding = new System.Windows.Forms.Padding(10, 8, 10, 6);
            this.pnlColAHead.Controls.Add(this.btnSearchUser);
            this.pnlColAHead.Controls.Add(this.txtSearchUser);
            this.pnlColAHead.Controls.Add(this.lblColATitle);

            this.lblColATitle.AutoSize = true;
            this.lblColATitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblColATitle.ForeColor = colNav;
            this.lblColATitle.Location = new System.Drawing.Point(10, 8);
            this.lblColATitle.Text = "Users & Roles";

            this.txtSearchUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchUser.Location = new System.Drawing.Point(10, 42);
            this.txtSearchUser.Size = new System.Drawing.Size(170, 26);
            this.txtSearchUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchUser.BackColor = System.Drawing.Color.FromArgb(250, 251, 253);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchUser_KeyDown);

            this.btnSearchUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchUser.FlatAppearance.BorderSize = 0;
            this.btnSearchUser.BackColor = System.Drawing.Color.FromArgb(56, 139, 253);
            this.btnSearchUser.ForeColor = colWhite;
            this.btnSearchUser.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSearchUser.Location = new System.Drawing.Point(188, 42);
            this.btnSearchUser.Size = new System.Drawing.Size(60, 26);
            this.btnSearchUser.Text = "Tim";
            this.btnSearchUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);

            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = colWhite;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.ColumnHeadersHeight = 32;
            this.dgvUsers.RowTemplate.Height = 30;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(228, 232, 240);
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = colNav;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = colWhite;
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvUsers.ColumnHeadersDefaultCellStyle.SelectionBackColor = colNav;
            this.dgvUsers.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsers.DefaultCellStyle.BackColor = colWhite;
            this.dgvUsers.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 232, 248);
            this.dgvUsers.DefaultCellStyle.SelectionForeColor = colNav;
            this.dgvUsers.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);

            // ── COL B: ROLES ─────────────────────────────────────────────
            this.pnlColB.BackColor = colBg;
            this.pnlColB.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlColB.Width = 340;
            this.pnlColB.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlColB.Controls.Add(this.pnlColBCard);

            this.pnlColBCard.BackColor = colWhite;
            this.pnlColBCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColBCard.Controls.Add(this.dgvRoles);
            this.pnlColBCard.Controls.Add(this.pnlColBBtns);
            this.pnlColBCard.Controls.Add(this.pnlColBHead);

            this.pnlColBHead.BackColor = colWhite;
            this.pnlColBHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColBHead.Height = 56;
            this.pnlColBHead.Padding = new System.Windows.Forms.Padding(10, 8, 10, 6);
            this.pnlColBHead.Controls.Add(this.lblColBSel);
            this.pnlColBHead.Controls.Add(this.lblColBTitle);

            this.lblColBTitle.AutoSize = true;
            this.lblColBTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblColBTitle.ForeColor = colNav;
            this.lblColBTitle.Location = new System.Drawing.Point(10, 8);
            this.lblColBTitle.Text = "Vai tro (Roles)";

            this.lblColBSel.AutoSize = true;
            this.lblColBSel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblColBSel.ForeColor = System.Drawing.Color.FromArgb(130, 140, 160);
            this.lblColBSel.Location = new System.Drawing.Point(10, 28);
            this.lblColBSel.Name = "lblColBSel";
            this.lblColBSel.Text = "Chon user de xem roles duoc gan";

            this.pnlColBBtns.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            this.pnlColBBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlColBBtns.Height = 44;
            this.pnlColBBtns.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlColBBtns.Controls.Add(this.btnGrantRole);
            this.pnlColBBtns.Controls.Add(this.btnRevokeRole);

            this.btnGrantRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrantRole.FlatAppearance.BorderSize = 0;
            this.btnGrantRole.BackColor = System.Drawing.Color.FromArgb(13, 100, 60);
            this.btnGrantRole.ForeColor = colWhite;
            this.btnGrantRole.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnGrantRole.Location = new System.Drawing.Point(10, 0);
            this.btnGrantRole.Size = new System.Drawing.Size(130, 28);
            this.btnGrantRole.Text = "+ Gan Role";
            this.btnGrantRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrantRole.Click += new System.EventHandler(this.btnGrantRole_Click);

            this.btnRevokeRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRevokeRole.FlatAppearance.BorderSize = 0;
            this.btnRevokeRole.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnRevokeRole.ForeColor = colWhite;
            this.btnRevokeRole.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnRevokeRole.Location = new System.Drawing.Point(148, 0);
            this.btnRevokeRole.Size = new System.Drawing.Size(130, 28);
            this.btnRevokeRole.Text = "- Thu hoi Role";
            this.btnRevokeRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRevokeRole.Click += new System.EventHandler(this.btnRevokeRole_Click);

            // dgvRoles — same style as dgvUsers
            this.dgvRoles.AllowUserToAddRows = false; this.dgvRoles.AllowUserToDeleteRows = false; this.dgvRoles.ReadOnly = true;
            this.dgvRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.BackgroundColor = colWhite; this.dgvRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRoles.RowHeadersVisible = false; this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoles.ColumnHeadersHeight = 32; this.dgvRoles.RowTemplate.Height = 30;
            this.dgvRoles.GridColor = System.Drawing.Color.FromArgb(228, 232, 240);
            this.dgvRoles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRoles.EnableHeadersVisualStyles = false; this.dgvRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvRoles.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(60, 30, 130);
            this.dgvRoles.ColumnHeadersDefaultCellStyle.ForeColor = colWhite;
            this.dgvRoles.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvRoles.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvRoles.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(60, 30, 130);
            this.dgvRoles.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRoles.DefaultCellStyle.BackColor = colWhite;
            this.dgvRoles.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 220, 255);
            this.dgvRoles.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(60, 30, 130);
            this.dgvRoles.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvRoles.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 248, 255);
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellClick);

            // ── COL C: PERMISSIONS ───────────────────────────────────────
            this.pnlColC.BackColor = colBg;
            this.pnlColC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColC.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.pnlColC.Controls.Add(this.pnlColCCard);

            this.pnlColCCard.BackColor = colWhite;
            this.pnlColCCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColCCard.Controls.Add(this.dgvPermissions);
            this.pnlColCCard.Controls.Add(this.pnlColCBtns);
            this.pnlColCCard.Controls.Add(this.pnlColCHead);

            this.pnlColCHead.BackColor = colWhite;
            this.pnlColCHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColCHead.Height = 56;
            this.pnlColCHead.Padding = new System.Windows.Forms.Padding(10, 8, 10, 6);
            this.pnlColCHead.Controls.Add(this.lblColCSel);
            this.pnlColCHead.Controls.Add(this.lblColCTitle);

            this.lblColCTitle.AutoSize = true;
            this.lblColCTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblColCTitle.ForeColor = colNav;
            this.lblColCTitle.Location = new System.Drawing.Point(10, 8);
            this.lblColCTitle.Text = "Chi tiet Quyen (Permissions)";

            this.lblColCSel.AutoSize = true;
            this.lblColCSel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblColCSel.ForeColor = System.Drawing.Color.FromArgb(130, 140, 160);
            this.lblColCSel.Location = new System.Drawing.Point(10, 28);
            this.lblColCSel.Name = "lblColCSel";
            this.lblColCSel.Text = "Chon role de xem quyen chi tiet";

            this.pnlColCBtns.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            this.pnlColCBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlColCBtns.Height = 44;
            this.pnlColCBtns.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlColCBtns.Controls.Add(this.btnRefresh);

            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 1;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 210, 225);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(218, 223, 232);
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(10, 0);
            this.btnRefresh.Size = new System.Drawing.Size(120, 28);
            this.btnRefresh.Text = "\u21ba Tai lai";
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // dgvPermissions
            this.dgvPermissions.AllowUserToAddRows = false; this.dgvPermissions.AllowUserToDeleteRows = false; this.dgvPermissions.ReadOnly = true;
            this.dgvPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPermissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPermissions.BackgroundColor = colWhite; this.dgvPermissions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPermissions.RowHeadersVisible = false; this.dgvPermissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPermissions.ColumnHeadersHeight = 32; this.dgvPermissions.RowTemplate.Height = 30;
            this.dgvPermissions.GridColor = System.Drawing.Color.FromArgb(228, 232, 240);
            this.dgvPermissions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPermissions.EnableHeadersVisualStyles = false; this.dgvPermissions.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPermissions.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(13, 100, 60);
            this.dgvPermissions.ColumnHeadersDefaultCellStyle.ForeColor = colWhite;
            this.dgvPermissions.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvPermissions.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvPermissions.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(13, 100, 60);
            this.dgvPermissions.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvPermissions.DefaultCellStyle.BackColor = colWhite;
            this.dgvPermissions.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(220, 248, 232);
            this.dgvPermissions.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(13, 100, 60);
            this.dgvPermissions.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvPermissions.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 255, 250);
            this.dgvPermissions.Name = "dgvPermissions";

            // ── FOOTER ──────────────────────────────────────────────────
            this.pnlFooter.BackColor = colNav;
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 26;
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.lblFooter.AutoSize = true; this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F); this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(140, 170, 210); this.lblFooter.Location = new System.Drawing.Point(0, 6); this.lblFooter.Text = "  TH True Mart 2025 - sys.database_principals - VAITRO - PHANQUYEN";

            // ── FORM ────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = colBg;
            this.ClientSize = new System.Drawing.Size(1160, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Load += new System.EventHandler(this.FormPhanQuyen_Load);

            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBadgeBar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);

            this.pnlHeader.ResumeLayout(false); this.pnlHeader.PerformLayout();
            this.pnlBadgeBar.ResumeLayout(false);
            this.pnlBadge1.ResumeLayout(false); this.pnlBadge1.PerformLayout();
            this.pnlBadge2.ResumeLayout(false); this.pnlBadge2.PerformLayout();
            this.pnlBadge3.ResumeLayout(false); this.pnlBadge3.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlColA.ResumeLayout(false); this.pnlColACard.ResumeLayout(false);
            this.pnlColAHead.ResumeLayout(false); this.pnlColAHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlColB.ResumeLayout(false); this.pnlColBCard.ResumeLayout(false);
            this.pnlColBHead.ResumeLayout(false); this.pnlColBHead.PerformLayout();
            this.pnlColBBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.pnlColC.ResumeLayout(false); this.pnlColCCard.ResumeLayout(false);
            this.pnlColCHead.ResumeLayout(false); this.pnlColCHead.PerformLayout();
            this.pnlColCBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).EndInit();
            this.pnlFooter.ResumeLayout(false); this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblSubtitle;
        private System.Windows.Forms.Panel pnlBadgeBar;
        private System.Windows.Forms.Panel pnlBadge1, pnlBadge2, pnlBadge3;
        private System.Windows.Forms.Label lblBadge1Val, lblBadge1Lbl, lblBadge2Val, lblBadge2Lbl, lblBadge3Val, lblBadge3Lbl;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlColA, pnlColACard, pnlColAHead;
        private System.Windows.Forms.Label lblColATitle;
        private System.Windows.Forms.TextBox txtSearchUser;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel pnlColB, pnlColBCard, pnlColBHead, pnlColBBtns;
        private System.Windows.Forms.Label lblColBTitle, lblColBSel;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnGrantRole, btnRevokeRole;
        private System.Windows.Forms.Panel pnlColC, pnlColCCard, pnlColCHead, pnlColCBtns;
        private System.Windows.Forms.Label lblColCTitle, lblColCSel;
        private System.Windows.Forms.DataGridView dgvPermissions;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}