using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Canbo
{
    public class TaskAssignDialog : Form
    {
        private readonly ApiService _apiService = ApiService.Instance;
        private readonly TaskItemDto _task;
        private ComboBox cboUser = null!;
        private Button btnConfirm = null!;
        private Button btnCancel = null!;

        public bool IsAssigned { get; private set; }

        public TaskAssignDialog(TaskItemDto task)
        {
            _task = task;
            InitializeComponent();
            LoadUsersAsync();
        }

        private void InitializeComponent()
        {
            this.Text = $"Phân công công việc: {_task.MaCv}";
            this.Size = new Size(460, 260);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Font = new Font("Segoe UI", 9.25F);

            var lblTaskName = new Label
            {
                Text = $"Công việc: {_task.TenCongViec}",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(20, 20),
                Size = new Size(405, 45)
            };

            var lblSelect = new Label
            {
                Text = "Chọn nhân sự phụ trách:",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(20, 75),
                AutoSize = true
            };

            cboUser = new ComboBox
            {
                Location = new Point(20, 98),
                Size = new Size(405, 28),
                DropDownStyle = ComboBoxStyle.DropDown,
                Font = new Font("Segoe UI", 9.5F)
            };

            btnCancel = new Button
            {
                Text = "Hủy bỏ",
                Location = new Point(220, 155),
                Size = new Size(95, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(71, 85, 105),
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9.25F, FontStyle.Bold)
            };
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancel.Click += (s, e) => this.Close();

            btnConfirm = new Button
            {
                Text = "👤 Phân công",
                Location = new Point(325, 155),
                Size = new Size(100, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9.25F, FontStyle.Bold)
            };
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.Click += BtnConfirm_Click;

            this.Controls.AddRange(new Control[] { lblTaskName, lblSelect, cboUser, btnCancel, btnConfirm });
        }

        private async void LoadUsersAsync()
        {
            try
            {
                var users = await _apiService.GetTaskUsersAsync();
                cboUser.Items.Clear();
                foreach (var u in users)
                {
                    cboUser.Items.Add(u.DisplayText);
                }

                if (!string.IsNullOrWhiteSpace(_task.NhanSu))
                {
                    cboUser.Text = _task.NhanSu;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân sự: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnConfirm_Click(object? sender, EventArgs e)
        {
            string nhanSu = cboUser.Text.Trim();
            if (string.IsNullOrWhiteSpace(nhanSu))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tên nhân sự phụ trách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnConfirm.Enabled = false;
            var (success, msg) = await _apiService.AssignTaskAsync(_task.Id, nhanSu);
            if (success)
            {
                IsAssigned = true;
                MessageBox.Show($"Đã phân công công việc '{_task.MaCv}' cho: {nhanSu}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi phân công: " + msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConfirm.Enabled = true;
            }
        }
    }
}
