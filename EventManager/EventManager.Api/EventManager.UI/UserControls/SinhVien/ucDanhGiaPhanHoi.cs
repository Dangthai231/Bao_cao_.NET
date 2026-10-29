using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.SinhVien
{
    /// <summary>
    /// Use case "Đánh giá và phản hồi sự kiện"
    /// </summary>
    public partial class ucDanhGiaPhanHoi : UserControl
    {
        private readonly ApiService _apiService;
        private readonly UserSession _session;
        private List<FeedbackDto> _feedbacks = new List<FeedbackDto>();

        private static readonly string[] RatingTexts =
        {
            "★★★★★  (5) - Rất hài lòng",
            "★★★★☆  (4) - Hài lòng",
            "★★★☆☆  (3) - Bình thường",
            "★★☆☆☆  (2) - Chưa hài lòng",
            "★☆☆☆☆  (1) - Rất không hài lòng"
        };

        public ucDanhGiaPhanHoi(UserSession session)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _session = session;

            cboRating.Items.AddRange(RatingTexts);
            cboRating.SelectedIndex = 0;

            cboEvent.DisplayMember = "Title";
            cboEvent.ValueMember = "Id";

            this.Load += async (s, e) => await LoadDataAsync();
            btnSend.Click += async (s, e) => await SendFeedbackAsync();
            btnReset.Click += (s, e) => ResetForm();
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += async (s, e) => await DeleteSelectedAsync();
            cboEvent.SelectedIndexChanged += (s, e) => FillExistingFeedback();

            dgvFeedbacks.AutoGenerateColumns = false;
            dgvFeedbacks.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) btnEdit_Click(s, e); };

            // Bỏ chọn dòng đầu tiên mà DataGridView tự chọn sau khi nạp dữ liệu (tránh xóa nhầm)
            dgvFeedbacks.DataBindingComplete += (s, e) =>
            {
                dgvFeedbacks.ClearSelection();
                dgvFeedbacks.CurrentCell = null;
            };
        }

        private async Task LoadDataAsync()
        {
            try
            {
                // Chỉ những sự kiện đã đăng ký và đã diễn ra mới được đánh giá
                var events = await _apiService.GetFeedbackEligibleEventsAsync(_session.UserId);
                cboEvent.DataSource = events;
                lblNoEvent.Visible = events.Count == 0;
                btnSend.Enabled = events.Count > 0;

                _feedbacks = await _apiService.GetMyFeedbacksAsync(_session.UserId);
                dgvFeedbacks.DataSource = null;
                dgvFeedbacks.DataSource = _feedbacks;

                FillExistingFeedback();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu đánh giá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nếu sự kiện đang chọn đã có đánh giá → hiển thị lại để sinh viên sửa
        private void FillExistingFeedback()
        {
            if (cboEvent.SelectedItem is not StudentEventDto ev) return;

            var existing = _feedbacks.FirstOrDefault(f => f.EventId == ev.Id);
            if (existing != null)
            {
                cboRating.SelectedIndex = 5 - existing.Rating;
                txtComment.Text = existing.Comment;
                btnSend.Text = "Cập nhật đánh giá";
            }
            else
            {
                cboRating.SelectedIndex = 0;
                txtComment.Clear();
                btnSend.Text = "Gửi đánh giá";
            }
        }

        private async Task SendFeedbackAsync()
        {
            if (cboEvent.SelectedItem is not StudentEventDto ev)
            {
                MessageBox.Show("Vui lòng chọn sự kiện cần đánh giá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rating = 5 - cboRating.SelectedIndex;
            string comment = txtComment.Text.Trim();

            if (rating <= 2 && string.IsNullOrEmpty(comment))
            {
                MessageBox.Show("Vui lòng cho Ban tổ chức biết lý do bạn chưa hài lòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComment.Focus();
                return;
            }

            try
            {
                btnSend.Enabled = false;
                var (success, message) = await _apiService.SubmitFeedbackAsync(_session.UserId, ev.Id, rating, comment);
                MessageBox.Show(message, success ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (success)
                {
                    int selectedId = ev.Id;
                    await LoadDataAsync();
                    cboEvent.SelectedValue = selectedId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = cboEvent.Items.Count > 0;
            }
        }

        private void ResetForm()
        {
            cboRating.SelectedIndex = 0;
            txtComment.Clear();
        }

        // Chọn đánh giá trong lịch sử → đưa lên form để sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFeedbacks.CurrentRow?.DataBoundItem is not FeedbackDto f)
            {
                MessageBox.Show("Vui lòng chọn một đánh giá để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cboEvent.SelectedValue = f.EventId;
            FillExistingFeedback();
            txtComment.Focus();
        }

        private async Task DeleteSelectedAsync()
        {
            if (dgvFeedbacks.CurrentRow?.DataBoundItem is not FeedbackDto f)
            {
                MessageBox.Show("Vui lòng chọn một đánh giá để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var answer = MessageBox.Show($"Xóa đánh giá cho sự kiện \"{f.EventTitle}\"?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            try
            {
                var (success, message) = await _apiService.DeleteFeedbackAsync(f.Id, _session.UserId);
                MessageBox.Show(message, success ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (success)
                    await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
