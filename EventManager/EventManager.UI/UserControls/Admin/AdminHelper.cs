using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.Admin
{
    /// <summary>
    /// Các hàm dùng chung cho giao diện Admin: hộp thoại xác nhận, hiển thị kết quả, đổi tên trạng thái
    /// </summary>
    public static class AdminHelper
    {
        /// <summary>true khi đang mở trong Visual Studio Designer (không gọi API)</summary>
        public static bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public static bool Confirm(string message)
        {
            return MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>Hiện kết quả trả về từ API, trả về true nếu thành công</summary>
        public static bool ShowResult((bool Success, string Message) result)
        {
            if (result.Success)
                MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return result.Success;
        }

        public static void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string RoleName(string role) => role switch
        {
            "Admin" => "Quản trị viên",
            "CanBo" => "Cán bộ",
            "SinhVien" => "Sinh viên",
            _ => role
        };

        public static void ConfigureOptionalDate(DateTimePicker picker)
        {
            void UpdateDisplay() => picker.CustomFormat = picker.Checked ? "dd/MM/yyyy" : "'Chưa chọn'";
            picker.ValueChanged += (_, _) => UpdateDisplay();
            picker.DropDown += (_, _) => { picker.CustomFormat = "dd/MM/yyyy"; };
            picker.CloseUp += (_, _) => UpdateDisplay();
            UpdateDisplay();
        }

        public static bool TryReadDateRange(DateTimePicker start, DateTimePicker end,
            out DateTime? from, out DateTime? through)
        {
            from = start.Checked ? start.Value.Date : null;
            through = end.Checked ? end.Value.Date : null;
            return from == null || through == null || from <= through;
        }

        // ── Trạng thái sự kiện: CSDL lưu tiếng Anh, giao diện hiện tiếng Việt ──
        public static string EventStatusText(string status)
        {
            switch (status)
            {
                case "Ongoing": return "Đang diễn ra";
                case "Completed": return "Hoàn thành";
                case "Cancelled": return "Đã hủy";
                default: return status;
            }
        }

        public static string EventStatusCode(string text)
        {
            switch (text)
            {
                case "Đang diễn ra": return "Ongoing";
                case "Hoàn thành": return "Completed";
                case "Đã hủy": return "Cancelled";
                default: return text;
            }
        }

        /// <summary>Thông báo "Nháp" và "Đã gửi" (của Cán bộ) đều đang chờ Admin duyệt</summary>
        public static bool IsPendingNotification(string status)
        {
            return status == "Chờ duyệt" || status == "Nháp" || status == "Đã gửi";
        }
    }
}
