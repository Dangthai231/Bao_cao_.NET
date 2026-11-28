using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.Admin
{
    public sealed class AdminMetricLabel : Label
    {
        [System.ComponentModel.DefaultValue("")]
        public string Glyph { get; set; } = "";

        protected override void OnPaint(PaintEventArgs e)
        {
            var lines = Text.Split('\n', 2);
            var title = lines[0].TrimEnd('\r');
            var value = lines.Length > 1 ? lines[1] : "";
            int inset = LogicalToDeviceUnits(12);
            int glyphWidth = LogicalToDeviceUnits(32);
            int left = Width >= LogicalToDeviceUnits(160) ? inset + glyphWidth : inset;
            var flags = TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
            using var titleFont = new Font(Font.FontFamily, 9.5F);
            using var valueFont = new Font(Font.FontFamily, 17F, FontStyle.Bold);
            var titleBox = new Rectangle(left, inset, Math.Max(1, Width - left - inset), LogicalToDeviceUnits(24));
            var valueBox = new Rectangle(left, titleBox.Bottom, titleBox.Width, LogicalToDeviceUnits(32));
            TextRenderer.DrawText(e.Graphics, title, titleFont, titleBox, Color.FromArgb(68, 88, 114), flags);
            TextRenderer.DrawText(e.Graphics, value, valueFont, valueBox, ForeColor, flags);
            if (left > inset)
            {
                var iconBox = new Rectangle(inset, 0, glyphWidth, Height);
                if (Glyph == "\uE917")
                {
                    int diameter = LogicalToDeviceUnits(17);
                    int x = iconBox.Left + (iconBox.Width - diameter) / 2;
                    int y = (iconBox.Height - diameter) / 2;
                    int centerX = x + diameter / 2;
                    int centerY = y + diameter / 2;
                    var state = e.Graphics.Save();
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using var pen = new Pen(ForeColor, Math.Max(1, LogicalToDeviceUnits(2)));
                    e.Graphics.DrawEllipse(pen, x, y, diameter, diameter);
                    e.Graphics.DrawLine(pen, centerX, centerY, centerX, y + diameter / 4);
                    e.Graphics.DrawLine(pen, centerX, centerY, x + diameter * 3 / 4, centerY);
                    e.Graphics.Restore(state);
                    return;
                }

                using var iconFont = new Font("Segoe MDL2 Assets", 15F);
                TextRenderer.DrawText(e.Graphics, Glyph, iconFont, iconBox, ForeColor, flags);
            }
        }
    }
}
