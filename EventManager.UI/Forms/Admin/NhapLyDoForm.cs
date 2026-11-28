using System;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    /// <summary>
    /// Hộp thoại nhập lý do khi Admin từ chối (thông báo, kế hoạch, yêu cầu đổi thông tin)
    /// </summary>
    public partial class NhapLyDoForm : Form
    {
        public string Reason => txtLyDo.Text.Trim();

        public NhapLyDoForm()
        {
            InitializeComponent();
            btnXacNhan.Click += btnXacNhan_Click;
        }

        public NhapLyDoForm(string title) : this()
        {
            Text = title;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (Reason.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập lý do từ chối.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLyDo.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        /// <summary>Hiện hộp thoại, trả về lý do hoặc null nếu người dùng bấm Hủy</summary>
        public static string Ask(IWin32Window owner, string title)
        {
            using (var form = new NhapLyDoForm(title))
            {
                return form.ShowDialog(owner) == DialogResult.OK ? form.Reason : null;
            }
        }
    }
}
