using EventManager.UI.Models;
using EventManager.UI.UserControls;
using EventManager.UI.UserControls.CanBo;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Canbo
{
    public partial class CanBoDashboard : Form
    {
        private UserSession _session;

        // Constructor nhận thông tin đăng nhập truyền sang
        public CanBoDashboard(UserSession session)
        {
            InitializeComponent();
            _session = session;

            // Hiển thị tên người dùng lên giao diện
            lblWelcome.Text = $"Xin chào, {_session.Username}";

            // Thiết lập kích thước cửa sổ vừa vặn với màn hình và căn giữa
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1150, 700);
            this.MinimumSize = new Size(950, 550);

            // Cố định nút Đăng xuất ở dưới cùng của sidebar bên trái
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogout.Location = new Point(10, pnlSidebar.ClientSize.Height - btnLogout.Height - 15);
            btnLogout.Width = pnlSidebar.ClientSize.Width - 20;

            // Tự động tải trang chủ khi mở Dashboard
            LoadUserControl(new ucCanBoHome());
        }

        // --- HÀM HỖ TRỢ NHÚNG MÀN HÌNH CON VÀO PNLCONTENT ---
        private void LoadUserControl(UserControl uc)
        {
            pnlContent.Controls.Clear(); // Xóa màn hình cũ
            uc.Dock = DockStyle.Fill;    // Phóng to màn hình mới vừa bằng pnlContent
            pnlContent.Controls.Add(uc); // Thêm vào giao diện
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucCanBoHome());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucBaoCaoThongKe());
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng Dashboard → LoginForm sẽ đóng theo (do FormClosed event)
            }
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucQuanLyTaiLieu());
        }

        private void btnParticipants_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucQuanLyNguoiThamGia());
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucManageNotifications());
        }
    }
}
