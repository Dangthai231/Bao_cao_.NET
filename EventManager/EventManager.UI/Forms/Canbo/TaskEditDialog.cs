using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Canbo
{
    public class TaskEditDialog : Form
    {
        private readonly ApiService _apiService = ApiService.Instance;
        private readonly TaskItemDto? _existingTask;

        private TextBox txtTitle = null!;
        private TextBox txtDescription = null!;
        private ComboBox cboEvent = null!;
        private ComboBox cboUser = null!;
        private ComboBox cboPriority = null!;
        private DateTimePicker dtpDueDate = null!;
        private NumericUpDown numProgress = null!;
        private ComboBox cboStatus = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        public bool IsSaved { get; private set; }

        public TaskEditDialog(TaskItemDto? existingTask = null)
        {
            _existingTask = existingTask;
            InitializeComponent();
            LoadDataAsync();
        }

        private void InitializeComponent()
        {
            this.Text = _existingTask == null ? "Lập kế hoạch công việc mới" : $"Chỉnh sửa công việc - {_existingTask.MaCv}";
            this.Size = new Size(580, 640);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Font = new Font("Segoe UI", 9.25F);

            var pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(20, 12, 20, 12)
            };
            pnlHeader.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            };

            var lblHeaderTitle = new Label
            {
                Text = _existingTask == null ? "📋  Lập kế hoạch công việc" : $"✏️  Chỉnh sửa công việc: {_existingTask.MaCv}",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                AutoSize = true,
                Location = new Point(18, 16)
            };
            pnlHeader.Controls.Add(lblHeaderTitle);
            this.Controls.Add(pnlHeader);

            var pnlBody = new Panel
            {
                Location = new Point(20, 75),
                Size = new Size(525, 470),
                BackColor = Color.White,
                Padding = new Padding(20)
            };
            pnlBody.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlBody.Width - 1, pnlBody.Height - 1);
            };

            int y = 15;

            // Tên công việc
            var lblTitle = new Label { Text = "Tên công việc *", Location = new Point(20, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            txtTitle = new TextBox { Location = new Point(20, y + 22), Size = new Size(480, 26), Font = new Font("Segoe UI", 9.5F) };
            pnlBody.Controls.AddRange(new Control[] { lblTitle, txtTitle });
            y += 58;

            // Mô tả
            var lblDesc = new Label { Text = "Mô tả chi tiết", Location = new Point(20, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            txtDescription = new TextBox { Location = new Point(20, y + 22), Size = new Size(480, 60), Multiline = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Segoe UI", 9.5F) };
            pnlBody.Controls.AddRange(new Control[] { lblDesc, txtDescription });
            y += 92;

            // Sự kiện
            var lblEvent = new Label { Text = "Thuộc sự kiện", Location = new Point(20, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            cboEvent = new ComboBox { Location = new Point(20, y + 22), Size = new Size(480, 26), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5F) };
            pnlBody.Controls.AddRange(new Control[] { lblEvent, cboEvent });
            y += 58;

            // Nhân sự phụ trách
            var lblUser = new Label { Text = "Nhân sự phụ trách", Location = new Point(20, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            cboUser = new ComboBox { Location = new Point(20, y + 22), Size = new Size(230, 26), DropDownStyle = ComboBoxStyle.DropDown, Font = new Font("Segoe UI", 9.5F) };
            pnlBody.Controls.AddRange(new Control[] { lblUser, cboUser });

            // Mức độ ưu tiên
            var lblPriority = new Label { Text = "Mức độ ưu tiên", Location = new Point(270, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            cboPriority = new ComboBox { Location = new Point(270, y + 22), Size = new Size(230, 26), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5F) };
            cboPriority.Items.AddRange(new object[] { "Cao", "Trung bình", "Thấp" });
            cboPriority.SelectedIndex = 1;
            pnlBody.Controls.AddRange(new Control[] { lblPriority, cboPriority });
            y += 58;

            // Hạn chót
            var lblDueDate = new Label { Text = "Hạn chót", Location = new Point(20, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            dtpDueDate = new DateTimePicker { Location = new Point(20, y + 22), Size = new Size(230, 26), Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(7), Font = new Font("Segoe UI", 9.5F) };
            pnlBody.Controls.AddRange(new Control[] { lblDueDate, dtpDueDate });

            // Trạng thái
            var lblStatus = new Label { Text = "Trạng thái", Location = new Point(270, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            cboStatus = new ComboBox { Location = new Point(270, y + 22), Size = new Size(230, 26), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5F) };
            cboStatus.Items.AddRange(new object[] { "Chưa bắt đầu", "Đang thực hiện", "Hoàn thành", "Tạm hoãn" });
            cboStatus.SelectedIndex = 0;
            pnlBody.Controls.AddRange(new Control[] { lblStatus, cboStatus });
            y += 58;

            // Tiến độ %
            var lblProgress = new Label { Text = "Tiến độ thực hiện (%)", Location = new Point(20, y), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(51, 65, 85) };
            numProgress = new NumericUpDown { Location = new Point(20, y + 22), Size = new Size(120, 26), Minimum = 0, Maximum = 100, Value = 0, Font = new Font("Segoe UI", 9.5F) };
            pnlBody.Controls.AddRange(new Control[] { lblProgress, numProgress });

            numProgress.ValueChanged += (s, e) =>
            {
                if (numProgress.Value == 100 && cboStatus.Text != "Hoàn thành")
                    cboStatus.Text = "Hoàn thành";
                else if (numProgress.Value > 0 && numProgress.Value < 100 && cboStatus.Text == "Chưa bắt đầu")
                    cboStatus.Text = "Đang thực hiện";
            };

            cboStatus.SelectedIndexChanged += (s, e) =>
            {
                if (cboStatus.Text == "Hoàn thành" && numProgress.Value < 100)
                    numProgress.Value = 100;
            };

            this.Controls.Add(pnlBody);

            // Nút Lưu và Hủy ở góc dưới
            btnCancel = new Button
            {
                Text = "Hủy bỏ",
                Location = new Point(340, 560),
                Size = new Size(95, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(71, 85, 105),
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9.25F, FontStyle.Bold)
            };
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancel.Click += (s, e) => this.Close();

            btnSave = new Button
            {
                Text = _existingTask == null ? "➕ Tạo công việc" : "💾 Lưu thay đổi",
                Location = new Point(445, 560),
                Size = new Size(100, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9.25F, FontStyle.Bold)
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            this.Controls.AddRange(new Control[] { btnCancel, btnSave });
        }

        private async void LoadDataAsync()
        {
            try
            {
                var events = await _apiService.GetTaskEventsAsync();
                cboEvent.Items.Clear();
                cboEvent.Items.Add(new ComboBoxItem { Text = "-- Không chọn --", Value = (long)0 });
                foreach (var ev in events)
                {
                    cboEvent.Items.Add(new ComboBoxItem { Text = ev.TenSuKien, Value = ev.Id });
                }
                cboEvent.SelectedIndex = 0;

                var users = await _apiService.GetTaskUsersAsync();
                cboUser.Items.Clear();
                foreach (var u in users)
                {
                    cboUser.Items.Add(u.DisplayText);
                }

                // Điền dữ liệu nếu là sửa
                if (_existingTask != null)
                {
                    txtTitle.Text = _existingTask.TenCongViec;
                    txtDescription.Text = _existingTask.MoTa ?? "";

                    if (_existingTask.SuKienId.HasValue)
                    {
                        for (int i = 0; i < cboEvent.Items.Count; i++)
                        {
                            if (cboEvent.Items[i] is ComboBoxItem item && (long)item.Value == _existingTask.SuKienId.Value)
                            {
                                cboEvent.SelectedIndex = i;
                                break;
                            }
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(_existingTask.NhanSu))
                    {
                        cboUser.Text = _existingTask.NhanSu;
                    }

                    if (!string.IsNullOrWhiteSpace(_existingTask.MucDoUuTien))
                    {
                        cboPriority.Text = _existingTask.MucDoUuTien;
                    }

                    if (_existingTask.HanChot.HasValue)
                    {
                        dtpDueDate.Value = _existingTask.HanChot.Value;
                    }

                    numProgress.Value = Math.Clamp(_existingTask.TienDo, 0, 100);

                    if (!string.IsNullOrWhiteSpace(_existingTask.TrangThai))
                    {
                        cboStatus.Text = _existingTask.TrangThai;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin hỗ trợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên công việc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            long? suKienId = null;
            string? tenSuKien = null;
            if (cboEvent.SelectedItem is ComboBoxItem selectedEvent && (long)selectedEvent.Value > 0)
            {
                suKienId = (long)selectedEvent.Value;
                tenSuKien = selectedEvent.Text;
            }

            btnSave.Enabled = false;

            if (_existingTask == null)
            {
                var dto = new CreateTaskDto
                {
                    TenCongViec = txtTitle.Text.Trim(),
                    MoTa = txtDescription.Text.Trim(),
                    SuKienId = suKienId,
                    TenSuKien = tenSuKien,
                    NhanSu = cboUser.Text.Trim(),
                    MucDoUuTien = cboPriority.Text,
                    HanChot = dtpDueDate.Value.Date,
                    TienDo = (int)numProgress.Value,
                    TrangThai = cboStatus.Text
                };

                var (success, msg) = await _apiService.CreateTaskAsync(dto);
                if (success)
                {
                    IsSaved = true;
                    MessageBox.Show("Lập kế hoạch công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi tạo công việc: " + msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
            }
            else
            {
                var dto = new UpdateTaskDto
                {
                    TenCongViec = txtTitle.Text.Trim(),
                    MoTa = txtDescription.Text.Trim(),
                    SuKienId = suKienId,
                    TenSuKien = tenSuKien,
                    NhanSu = cboUser.Text.Trim(),
                    MucDoUuTien = cboPriority.Text,
                    HanChot = dtpDueDate.Value.Date,
                    TienDo = (int)numProgress.Value,
                    TrangThai = cboStatus.Text
                };

                var (success, msg) = await _apiService.UpdateTaskAsync(_existingTask.Id, dto);
                if (success)
                {
                    IsSaved = true;
                    MessageBox.Show("Cập nhật công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi cập nhật công việc: " + msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
            }
        }

        private class ComboBoxItem
        {
            public string Text { get; set; } = string.Empty;
            public object Value { get; set; } = null!;
            public override string ToString() => Text;
        }
    }
}
