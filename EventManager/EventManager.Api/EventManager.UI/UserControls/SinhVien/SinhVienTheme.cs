using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.SinhVien
{
    /// <summary>
    /// Bảng màu + hàm vẽ dùng chung cho phân hệ Sinh viên, giống giao diện mới của Cán bộ.
    /// Bố cục (vị trí, kích thước, màu nền...) nằm hết trong file .Designer.cs để kéo thả được;
    /// lớp này chỉ thêm phần trang trí mà Designer không làm được (viền card, bo góc nút).
    /// </summary>
    internal static class SinhVienTheme
    {
        public static readonly Color Navy = Color.FromArgb(11, 27, 61);
        public static readonly Color NavyHover = Color.FromArgb(20, 42, 85);
        public static readonly Color Primary = Color.FromArgb(37, 99, 235);
        public static readonly Color PrimaryDark = Color.FromArgb(29, 78, 216);
        public static readonly Color SidebarText = Color.FromArgb(203, 213, 225);
        public static readonly Color Border = Color.FromArgb(226, 232, 240);

        /// <summary>Vẽ viền xám nhạt bo góc cho các panel dạng "card" màu trắng.</summary>
        public static void AttachCardBorder(params Control[] cards)
        {
            foreach (var card in cards)
            {
                card.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using var path = CreateRoundedRectangle(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 8);
                    using var pen = new Pen(Border, 1);
                    e.Graphics.DrawPath(pen, path);
                };
                card.Resize += (s, e) => card.Invalidate();
            }
        }

        /// <summary>Bo tròn góc cho các nút (giữ nguyên khi nút đổi kích thước).</summary>
        public static void RoundButtons(int radius, params Button[] buttons)
        {
            foreach (var btn in buttons)
            {
                ApplyRoundedRegion(btn, radius);
                btn.SizeChanged += (s, e) => ApplyRoundedRegion(btn, radius);
            }
        }

        public static void ApplyRoundedRegion(Control ctrl, int radius)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using var path = CreateRoundedRectangle(new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius);
            ctrl.Region?.Dispose();
            ctrl.Region = new Region(path);
        }

        /// <summary>Làm tròn một panel nhỏ thành hình tròn (avatar).</summary>
        public static void MakeCircle(Control ctrl)
        {
            void apply()
            {
                if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
                using var path = new GraphicsPath();
                path.AddEllipse(0, 0, ctrl.Width, ctrl.Height);
                ctrl.Region?.Dispose();
                ctrl.Region = new Region(path);
            }
            apply();
            ctrl.SizeChanged += (s, e) => apply();
        }

        public static GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
