using EventManager.UI.Services;
using System;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.Admin
{
    /// <summary>
    /// Cài đặt: Admin tự đổi mật khẩu
    /// </summary>
    public partial class CaiDatPanel : UserControl
    {
        private const int MinPasswordLength = 6;
        private readonly ApiService _apiService = ApiService.Instance;

        public CaiDatPanel()
        {
            InitializeComponent();
            if (AdminHelper.IsDesignMode) return;

            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
        }

        private async void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMatKhauMoi.Text.Length < MinPasswordLength)
            {
                MessageBox.Show($"Mật khẩu mới phải có ít nhất {MinPasswordLength} ký tự.", "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.", "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnDoiMatKhau.Enabled = false;
            var result = await _apiService.ChangeMyPasswordAsync(txtMatKhauCu.Text, txtMatKhauMoi.Text);
            btnDoiMatKhau.Enabled = true;

            if (AdminHelper.ShowResult(result))
            {
                txtMatKhauCu.Clear();
                txtMatKhauMoi.Clear();
                txtNhapLai.Clear();
            }
        }
    }
}
