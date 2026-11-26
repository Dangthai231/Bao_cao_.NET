using System;
using System.Windows.Forms;
using EventManager.UI.Forms.Auth; // Gọi tới thư mục chứa LoginForm của bạn

namespace EventManager.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Các cấu hình mặc định của WinForms .NET mới
            ApplicationConfiguration.Initialize();

            // Trỏ Form bắt đầu là LoginForm
            Application.Run(new LoginForm());
        }
    }
}