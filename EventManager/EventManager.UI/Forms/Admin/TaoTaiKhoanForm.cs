using EventManager.UI.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    /// <summary>
    /// Form dùng cho 3 việc: tạo tài khoản, cập nhật tài khoản, đặt lại mật khẩu
    /// </summary>
    public partial class TaoTaiKhoanForm : Form
    {
        private const int MinPasswordLength = 6;

        private enum Mode { Create, Edit, ResetPassword }
        private Mode _mode = Mode.Create;
        private bool _showOptionalFields;
        private bool _hasStudentCode;
        private bool _hasClassName;
        private bool IsStudent => cboVaiTro.Text == "SinhVien";
        private bool RequiresStudentCode => IsStudent && (_mode == Mode.Create || _hasStudentCode);
        private bool RequiresClassName => IsStudent && (_mode == Mode.Create || _hasClassName);

        /// <summary>Dữ liệu người dùng nhập, đọc sau khi form trả về OK</summary>
        public AdminAccountRequest Result { get; private set; }

        // Tạo tài khoản mới
        public TaoTaiKhoanForm()
        {
            InitializeComponent();
            Text = "Tạo tài khoản";
            cboVaiTro.SelectedItem = "SinhVien";
            btnLuu.Click += btnLuu_Click;
            cboVaiTro.SelectedIndexChanged += (_, _) => UpdateFieldLayout();
            lnkThongTinThem.LinkClicked += (_, _) =>
            {
                _showOptionalFields = !_showOptionalFields;
                UpdateFieldLayout();
            };
        }

        // Cập nhật tài khoản: không đổi tên đăng nhập, vai trò (đổi ở màn Phân quyền), mật khẩu
        public TaoTaiKhoanForm(AdminAccountDto account) : this()
        {
            _mode = Mode.Edit;
            Text = "Cập nhật tài khoản";
            _hasStudentCode = !string.IsNullOrWhiteSpace(account.StudentCode);
            _hasClassName = !string.IsNullOrWhiteSpace(account.ClassName);
            FillAccount(account);
            txtMatKhau.Enabled = false;
        }

        public static TaoTaiKhoanForm ForResetPassword(AdminAccountDto account)
        {
            var form = new TaoTaiKhoanForm(account);
            form._mode = Mode.ResetPassword;
            form.Text = "Đặt lại mật khẩu";
            form.lblMatKhau.Text = "Mật khẩu mới *";
            form.txtHoTen.Enabled = false;
            form.txtEmail.Enabled = false;
            form.txtDienThoai.Enabled = false;
            form.txtMaSo.Enabled = false;
            form.txtLop.Enabled = false;
            form.txtMatKhau.Enabled = true;
            return form;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            UpdateFieldLayout();
        }

        private void UpdateFieldLayout()
        {
            bool reset = _mode == Mode.ResetPassword;
            bool editing = _mode == Mode.Edit;
            lblTenDangNhap.Text = _mode == Mode.Create ? "Tên đăng nhập *" : "Tên đăng nhập";
            lblVaiTro.Text = _mode == Mode.Create ? "Vai trò *" : "Vai trò";
            bool showOptional = !reset && (editing || _showOptionalFields);
            bool studentFields = !reset && (IsStudent || (editing && (_hasStudentCode || _hasClassName)));
            lblMaSo.Text = RequiresStudentCode ? "Mã sinh viên *" : "Mã sinh viên";
            lblLop.Text = RequiresClassName ? "Lớp *" : "Lớp";

            tlpForm.SuspendLayout();
            SetRowVisible(1, lblHoTen, txtHoTen, !reset);
            SetRowVisible(2, lblVaiTro, cboVaiTro, !reset);
            SetRowVisible(3, lblMaSo, txtMaSo, studentFields);
            SetRowVisible(4, lblLop, txtLop, studentFields);
            SetRowVisible(5, lblMatKhau, txtMatKhau, !editing);
            SetRowVisible(6, lblEmail, txtEmail, showOptional);
            SetRowVisible(7, lblDienThoai, txtDienThoai, showOptional);
            lnkThongTinThem.Visible = _mode == Mode.Create;
            tlpForm.RowStyles[8].SizeType = _mode == Mode.Create ? SizeType.AutoSize : SizeType.Absolute;
            tlpForm.RowStyles[8].Height = 0;
            lnkThongTinThem.Text = _showOptionalFields ? "Ẩn thông tin tùy chọn" : "Thêm thông tin tùy chọn";
            tlpForm.ResumeLayout(true);
            if (Visible)
            {
                Rectangle workingArea = Screen.FromControl(this).WorkingArea;
                int frameHeight = Height - ClientSize.Height;
                int contentHeight = tlpForm.GetPreferredSize(new Size(ClientSize.Width, 0)).Height;
                ClientSize = new Size(ClientSize.Width, Math.Min(contentHeight, workingArea.Height - frameHeight));
                Top = Math.Max(workingArea.Top, Math.Min(Top, workingArea.Bottom - Height));
            }
        }

        private void SetRowVisible(int index, Control caption, Control field, bool visible)
        {
            caption.Visible = field.Visible = visible;
            var row = tlpForm.RowStyles[index];
            row.SizeType = visible ? SizeType.AutoSize : SizeType.Absolute;
            row.Height = 0;
        }

        private void FillAccount(AdminAccountDto account)
        {
            txtTenDangNhap.Text = account.Username;
            txtHoTen.Text = account.FullName;
            cboVaiTro.SelectedItem = account.Role;
            txtEmail.Text = account.Email;
            txtDienThoai.Text = account.PhoneNumber;
            txtMaSo.Text = account.StudentCode;
            txtLop.Text = account.ClassName;
            txtTenDangNhap.Enabled = false;
            cboVaiTro.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string error = CheckInput();
            if (error != null)
            {
                MessageBox.Show(error, "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool includeOptional = _mode != Mode.ResetPassword;
            bool includeStudentFields = _mode == Mode.Edit || (includeOptional && cboVaiTro.Text == "SinhVien");
            Result = new AdminAccountRequest
            {
                Username = txtTenDangNhap.Text.Trim(),
                FullName = txtHoTen.Text.Trim(),
                Role = cboVaiTro.Text,
                Email = !includeOptional || string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                PhoneNumber = !includeOptional || string.IsNullOrWhiteSpace(txtDienThoai.Text) ? null : txtDienThoai.Text.Trim(),
                // Gửi kèm Mã SV và Lớp: API cập nhật cả 2 trường này, thiếu sẽ bị ghi đè thành rỗng
                StudentCode = !includeStudentFields || string.IsNullOrWhiteSpace(txtMaSo.Text) ? null : txtMaSo.Text.Trim(),
                ClassName = !includeStudentFields || string.IsNullOrWhiteSpace(txtLop.Text) ? null : txtLop.Text.Trim(),
                Password = txtMatKhau.Text
            };
            DialogResult = DialogResult.OK;
        }

        private string CheckInput()
        {
            if (_mode == Mode.ResetPassword)
                return txtMatKhau.Text.Length < MinPasswordLength ? $"Mật khẩu mới phải có ít nhất {MinPasswordLength} ký tự." : null;

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text)) return "Vui lòng nhập tên đăng nhập.";
            if (string.IsNullOrWhiteSpace(txtHoTen.Text)) return "Vui lòng nhập họ tên.";
            if (_mode == Mode.Create && cboVaiTro.SelectedIndex < 0) return "Vui lòng chọn vai trò.";
            if (RequiresStudentCode && string.IsNullOrWhiteSpace(txtMaSo.Text))
                return "Vui lòng nhập mã sinh viên.";
            if (RequiresClassName && string.IsNullOrWhiteSpace(txtLop.Text))
                return "Vui lòng nhập lớp.";
            if (_mode == Mode.Create && txtMatKhau.Text.Length < MinPasswordLength)
                return $"Mật khẩu phải có ít nhất {MinPasswordLength} ký tự.";
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Email không hợp lệ.";
            if (!string.IsNullOrWhiteSpace(txtDienThoai.Text) &&
                !System.Text.RegularExpressions.Regex.IsMatch(txtDienThoai.Text.Trim(), @"^0\d{9,10}$"))
                return "Số điện thoại phải gồm 10-11 chữ số và bắt đầu bằng 0.";
            return null;
        }
    }
}
