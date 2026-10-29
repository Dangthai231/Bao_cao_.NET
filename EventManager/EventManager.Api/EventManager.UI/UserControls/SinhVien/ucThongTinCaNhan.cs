using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.SinhVien
{
    /// <summary>
    /// Use case "Quản lý thông tin cá nhân": Xem thông tin cá nhân, Cập nhật thông tin
    /// </summary>
    public partial class ucThongTinCaNhan : UserControl
    {
        private readonly ApiService _apiService;
        private readonly UserSession _session;
        private StudentProfileDto _profile;

        public ucThongTinCaNhan(UserSession session)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _session = session;

            this.Load += async (s, e) => await LoadProfileAsync();
            btnEdit.Click += (s, e) => SetEditMode(true);
            btnCancelEdit.Click += (s, e) => { ShowProfile(); SetEditMode(false); };
            btnSave.Click += async (s, e) => await SaveAsync();

            SetEditMode(false);
        }

        // 1. Xem thông tin cá nhân
        private async Task LoadProfileAsync()
        {
            try
            {
                _profile = await _apiService.GetStudentProfileAsync(_session.UserId);
                if (_profile == null)
                {
                    MessageBox.Show("Không tải được thông tin cá nhân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ShowProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowProfile()
        {
            if (_profile == null) return;

            txtUsername.Text = _profile.Username;
            txtStudentCode.Text = _profile.StudentCode;
            txtFullName.Text = _profile.FullName;
            txtClassName.Text = _profile.ClassName;
            txtEmail.Text = _profile.Email;
            txtPhone.Text = _profile.PhoneNumber;

            dtpDateOfBirth.Checked = _profile.DateOfBirth.HasValue;
            if (_profile.DateOfBirth.HasValue)
                dtpDateOfBirth.Value = _profile.DateOfBirth.Value;

            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void SetEditMode(bool editing)
        {
            // Tài khoản và Mã sinh viên luôn chỉ đọc
            txtFullName.ReadOnly = !editing;
            txtClassName.ReadOnly = !editing;
            txtEmail.ReadOnly = !editing;
            txtPhone.ReadOnly = !editing;
            dtpDateOfBirth.Enabled = editing;
            grpPassword.Enabled = editing;

            btnEdit.Visible = !editing;
            btnSave.Visible = editing;
            btnCancelEdit.Visible = editing;
        }

        // 2. Cập nhật thông tin
        private async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Họ và tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            bool changePassword = txtNewPassword.Text.Length > 0;
            if (changePassword && txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            var request = new UpdateProfileRequest
            {
                FullName = txtFullName.Text.Trim(),
                ClassName = txtClassName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                DateOfBirth = dtpDateOfBirth.Checked ? dtpDateOfBirth.Value.Date : null,
                CurrentPassword = changePassword ? txtCurrentPassword.Text : null,
                NewPassword = changePassword ? txtNewPassword.Text : null
            };

            try
            {
                btnSave.Enabled = false;
                var (success, message) = await _apiService.UpdateStudentProfileAsync(_session.UserId, request);
                MessageBox.Show(message, success ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (success)
                {
                    _session.FullName = request.FullName;
                    await LoadProfileAsync();
                    SetEditMode(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }
    }
}
