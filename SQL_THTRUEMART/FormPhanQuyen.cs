using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SQL_THTRUEMART
{
    public partial class FormPhanQuyen : Form
    {
        private readonly string _conn =
            @"Data Source=XUAN-NGHI\SQLEXPRESS;" +
            "Initial Catalog=SQL_THTRUEMART;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        private string _selectedUser = "";   // user đang chọn (cột A)
        private string _selectedRole = "";   // role đang chọn (cột B)

        public FormPhanQuyen()
        {
            InitializeComponent();
            SetLabels();
            SetHoverEffects();
        }

        // ================================================================
        // LABEL TIẾNG VIỆT + HOVER
        // ================================================================
        private void SetLabels()
        {
            lblTitle.Text = "QU\u1ea2N L\u00dd PH\u00c2N QUY\u1ec0N";
            lblSubtitle.Text = "TH True Mart \u00b7 Security Dashboard";
            lblBadge1Lbl.Text = "USERS / ROLES";
            lblBadge2Lbl.Text = "VAI TR\u00d2 (ROLES)";
            lblBadge3Lbl.Text = "QUY\u1ec0N \u0110\u01af\u1ee2C C\u1ea4P";
            lblColATitle.Text = "Users & Roles";
            lblColBTitle.Text = "Vai tr\u00f2 \u0111\u01b0\u1ee3c g\u00e1n";
            lblColBSel.Text = "Ch\u1ecdn user \u0111\u1ec3 xem roles";
            lblColCTitle.Text = "Chi ti\u1ebft Quy\u1ec1n";
            lblColCSel.Text = "Ch\u1ecdn role \u0111\u1ec3 xem quy\u1ec1n";
            btnGrantRole.Text = "+ G\u00e1n Role";
            btnRevokeRole.Text = "\u2212 Thu h\u1ed3i Role";
            btnRefresh.Text = "\u21ba T\u1ea3i l\u1ea1i";
            btnSearchUser.Text = "T\u00ecm";
            lblFooter.Text = "  TH True Mart \u00a9 2025 \u00b7 sys.database_principals \u00b7 VAITRO \u00b7 PHANQUYEN";
        }

        private void SetHoverEffects()
        {
            void H(Button b, Color on, Color off)
            { b.MouseEnter += (s, e) => b.BackColor = on; b.MouseLeave += (s, e) => b.BackColor = off; }
            H(btnGrantRole, Color.FromArgb(10, 130, 75), Color.FromArgb(13, 100, 60));
            H(btnRevokeRole, Color.FromArgb(220, 70, 70), Color.FromArgb(200, 50, 50));
            H(btnSearchUser, Color.FromArgb(80, 160, 255), Color.FromArgb(56, 139, 253));
        }

        // ================================================================
        // LOAD
        // ================================================================
        private void FormPhanQuyen_Load(object sender, EventArgs e)
            => LoadUsers();

        private void LoadUsers(string keyword = "")
        {
            // Kết hợp: users thật từ sys.database_principals + users trong TAIKHOAN
            string sql = @"
                SELECT
                    p.name        AS TenUser,
                    p.type_desc   AS LoaiUser,
                    ISNULL(nv.TENNV, '')        AS TenNhanVien,
                    ISNULL(cv.TENCV, '')         AS ChucVu
                FROM sys.database_principals p
                LEFT JOIN TAIKHOAN tk  ON p.name = tk.TENTK
                LEFT JOIN NHANVIEN nv  ON tk.MANV = nv.MANV
                LEFT JOIN CHUCVU   cv  ON nv.MACV = cv.MACV
                WHERE p.type IN ('S','U','R')
                  AND p.name NOT LIKE '##%'
                  AND p.name NOT IN ('dbo','guest','INFORMATION_SCHEMA','sys','public')
                  AND (@kw = '' OR p.name LIKE @kw OR nv.TENNV LIKE @kw)
                ORDER BY p.type_desc DESC, p.name";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 100).Value =
                        string.IsNullOrWhiteSpace(keyword) ? "" : "%" + keyword.Trim() + "%";

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvUsers.AutoGenerateColumns = true;
                    dgvUsers.DataSource = dt;

                    void Col(string n, string h, bool vis = true,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvUsers.Columns.Contains(n)) return;
                        dgvUsers.Columns[n].HeaderText = h;
                        dgvUsers.Columns[n].Visible = vis;
                        dgvUsers.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("TenUser", "T\u00ean User / Role");
                    Col("LoaiUser", "Lo\u1ea1i");
                    Col("TenNhanVien", "Nh\u00e2n vi\u00ean");
                    Col("ChucVu", "Ch\u1ee9c v\u1ee5");

                    // Tô màu theo loại
                    foreach (DataGridViewRow row in dgvUsers.Rows)
                    {
                        string loai = row.Cells["LoaiUser"].Value?.ToString() ?? "";
                        if (loai == "DATABASE_ROLE")
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(80, 40, 160);
                        else if (loai == "SQL_USER" || loai == "WINDOWS_USER")
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(13, 43, 90);
                    }

                    UpdateBadge1(dt.Rows.Count);
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i users", ex); }
            }
        }

        // ================================================================
        // CLICK USER → LOAD ROLES CỦA USER
        // ================================================================
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvUsers.Rows[e.RowIndex];
            if (row.Cells["TenUser"].Value == null) return;

            _selectedUser = row.Cells["TenUser"].Value.ToString();
            lblColBSel.Text = "User: " + _selectedUser;
            LoadRolesOfUser(_selectedUser);

            // Reset cột C
            dgvPermissions.DataSource = null;
            lblColCSel.Text = "Ch\u1ecdn role \u0111\u1ec3 xem quy\u1ec1n";
            _selectedRole = "";
        }

        private void LoadRolesOfUser(string userName)
        {
            // Roles được gán cho user qua sys + bảng VAITRO nội bộ
            string sql = @"
                SELECT
                    r.name       AS TenRole,
                    r.type_desc  AS LoaiRole,
                    ISNULL(
                        (SELECT COUNT(*) FROM sys.database_permissions p
                         JOIN sys.database_principals rp ON p.grantee_principal_id = rp.principal_id
                         WHERE rp.name = r.name), 0) AS SoQuyen
                FROM sys.database_role_members drm
                JOIN sys.database_principals   r  ON drm.role_principal_id   = r.principal_id
                JOIN sys.database_principals   m  ON drm.member_principal_id = m.principal_id
                WHERE m.name = @UserName
                ORDER BY r.name";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName;

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvRoles.AutoGenerateColumns = true;
                    dgvRoles.DataSource = dt;

                    void Col(string n, string h)
                    {
                        if (!dgvRoles.Columns.Contains(n)) return;
                        dgvRoles.Columns[n].HeaderText = h;
                    }
                    Col("TenRole", "T\u00ean Role");
                    Col("LoaiRole", "Lo\u1ea1i");
                    Col("SoQuyen", "S\u1ed1 quy\u1ec1n");

                    // Badge 2
                    lblBadge2Val.Text = dt.Rows.Count.ToString();
                    lblColBSel.Text = "User: " + userName + " \u2192 " + dt.Rows.Count + " roles";
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i roles", ex); }
            }
        }

        // ================================================================
        // CLICK ROLE → LOAD PERMISSIONS
        // ================================================================
        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvRoles.Rows[e.RowIndex];
            if (row.Cells["TenRole"].Value == null) return;

            _selectedRole = row.Cells["TenRole"].Value.ToString();
            lblColCSel.Text = "Role: " + _selectedRole;
            LoadPermissionsOfRole(_selectedRole);
        }

        private void LoadPermissionsOfRole(string roleName)
        {
            string sql = @"
                SELECT
                    DP.permission_name               AS Quyen,
                    DP.state_desc                    AS TrangThai,
                    ISNULL(OBJECT_NAME(DP.major_id), 'DATABASE') AS DoiTuong,
                    DB_P.name                        AS CapCho
                FROM sys.database_permissions DP
                JOIN sys.database_principals  DB_P
                     ON DP.grantee_principal_id = DB_P.principal_id
                WHERE DB_P.name = @RoleName
                ORDER BY DoiTuong, Quyen";

            using (var con = new SqlConnection(_conn))
            {
                try
                {
                    con.Open();
                    var cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 100).Value = roleName;

                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);

                    dgvPermissions.AutoGenerateColumns = true;
                    dgvPermissions.DataSource = dt;

                    void Col(string n, string h,
                             DataGridViewContentAlignment a = DataGridViewContentAlignment.MiddleLeft)
                    {
                        if (!dgvPermissions.Columns.Contains(n)) return;
                        dgvPermissions.Columns[n].HeaderText = h;
                        dgvPermissions.Columns[n].DefaultCellStyle.Alignment = a;
                    }
                    Col("Quyen", "Quy\u1ec1n");
                    Col("TrangThai", "Tr\u1ea1ng th\u00e1i", DataGridViewContentAlignment.MiddleCenter);
                    Col("DoiTuong", "\u0110\u1ed1i t\u01b0\u1ee3ng");
                    Col("CapCho", "C\u1ea5p cho");

                    // Tô màu GRANT=xanh / DENY=đỏ
                    foreach (DataGridViewRow row in dgvPermissions.Rows)
                    {
                        string tt = row.Cells["TrangThai"].Value?.ToString() ?? "";
                        if (tt == "GRANT_WITH_GRANT_OPTION" || tt == "GRANT")
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(13, 100, 60);
                        else if (tt == "DENY")
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 50, 50);
                    }

                    lblBadge3Val.Text = dt.Rows.Count.ToString();
                    lblColCSel.Text = "Role: " + roleName + " \u2192 " + dt.Rows.Count + " quy\u1ec1n";
                }
                catch (SqlException ex) { ShowErr("t\u1ea3i quy\u1ec1n", ex); }
            }
        }

        // ================================================================
        // GÁN / THU HỒI ROLE
        // ================================================================
        private void btnGrantRole_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedUser)) { Warn("Ch\u1ecdn user tr\u01b0\u1edbc."); return; }

            // Lấy danh sách tất cả roles để user chọn
            using (var dlg = new Form())
            {
                dlg.Text = "Ch\u1ecdn Role c\u1ea7n g\u00e1n cho: " + _selectedUser;
                dlg.Size = new Size(380, 160);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.BackColor = Color.White;

                var lbl = new Label { Text = "Role:", Location = new Point(20, 20), AutoSize = true };
                var cmb = new ComboBox { Location = new Point(70, 17), Size = new Size(260, 28), DropDownStyle = ComboBoxStyle.DropDownList };
                var btn = new Button
                {
                    Text = "G\u00e1n",
                    Location = new Point(130, 70),
                    Size = new Size(120, 34),
                    BackColor = Color.FromArgb(13, 100, 60),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btn.FlatAppearance.BorderSize = 0;
                dlg.Controls.AddRange(new System.Windows.Forms.Control[] { lbl, cmb, btn });

                // Load roles
                using (var con = new SqlConnection(_conn))
                {
                    try
                    {
                        con.Open();
                        var dt = new DataTable();
                        new SqlDataAdapter(
                            "SELECT name FROM sys.database_principals WHERE type='R' AND name NOT LIKE '##%' ORDER BY name",
                            con).Fill(dt);
                        cmb.DataSource = dt; cmb.DisplayMember = "name"; cmb.ValueMember = "name";
                    }
                    catch { }
                }

                btn.Click += (s, ev) =>
                {
                    if (cmb.SelectedValue == null) return;
                    string role = cmb.SelectedValue.ToString();
                    try
                    {
                        using (var con = new SqlConnection(_conn))
                        {
                            con.Open();
                            // ALTER ROLE không dùng parameter — dùng whitelist đơn giản
                            string safe = role.Replace("]", "").Replace("[", "");
                            string user = _selectedUser.Replace("]", "").Replace("[", "");
                            new SqlCommand($"ALTER ROLE [{safe}] ADD MEMBER [{user}]", con).ExecuteNonQuery();
                        }
                        MessageBox.Show("G\u00e1n role [" + role + "] cho [" + _selectedUser + "] th\u00e0nh c\u00f4ng!",
                            "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dlg.Close();
                        LoadRolesOfUser(_selectedUser);
                    }
                    catch (SqlException ex) { ShowErr("g\u00e1n role", ex); }
                };

                dlg.ShowDialog(this);
            }
        }

        private void btnRevokeRole_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedUser)) { Warn("Ch\u1ecdn user tr\u01b0\u1edbc."); return; }
            if (string.IsNullOrEmpty(_selectedRole)) { Warn("Ch\u1ecdn role c\u1ea7n thu h\u1ed3i t\u1eeb c\u1ed9t B."); return; }

            if (MessageBox.Show(
                "Thu h\u1ed3i role [" + _selectedRole + "] kh\u1ecfi [" + _selectedUser + "]?",
                "X\u00e1c nh\u1eadn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

            try
            {
                using (var con = new SqlConnection(_conn))
                {
                    con.Open();
                    string safeRole = _selectedRole.Replace("]", "").Replace("[", "");
                    string safeUser = _selectedUser.Replace("]", "").Replace("[", "");
                    new SqlCommand($"ALTER ROLE [{safeRole}] DROP MEMBER [{safeUser}]", con).ExecuteNonQuery();
                }
                MessageBox.Show("Thu h\u1ed3i th\u00e0nh c\u00f4ng!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRolesOfUser(_selectedUser);
                dgvPermissions.DataSource = null;
                lblColCSel.Text = "Ch\u1ecdn role \u0111\u1ec3 xem quy\u1ec1n";
                _selectedRole = "";
            }
            catch (SqlException ex) { ShowErr("thu h\u1ed3i role", ex); }
        }

        // ================================================================
        // TÌM KIẾM
        // ================================================================
        private void btnSearchUser_Click(object sender, EventArgs e)
            => LoadUsers(txtSearchUser.Text);

        private void txtSearchUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearchUser_Click(sender, e);
        }

        // ================================================================
        // TẢI LẠI
        // ================================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchUser.Text = "";
            _selectedUser = ""; _selectedRole = "";
            dgvRoles.DataSource = null;
            dgvPermissions.DataSource = null;
            lblColBSel.Text = "Ch\u1ecdn user \u0111\u1ec3 xem roles";
            lblColCSel.Text = "Ch\u1ecdn role \u0111\u1ec3 xem quy\u1ec1n";
            lblBadge2Val.Text = "-"; lblBadge3Val.Text = "-";
            LoadUsers();
        }

        // ================================================================
        // HELPERS
        // ================================================================
        private void UpdateBadge1(int count)
        {
            lblBadge1Val.Text = count.ToString();
        }

        private void ShowErr(string ctx, SqlException ex)
            => MessageBox.Show("L\u1ed7i " + ctx + ":\n" + ex.Message,
               "L\u1ed7i SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void Warn(string msg)
            => MessageBox.Show(msg, "Th\u00f4ng b\u00e1o",
               MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}