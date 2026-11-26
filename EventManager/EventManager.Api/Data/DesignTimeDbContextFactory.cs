using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EventManager.Api.Data
{
    /// <summary>
    /// Dùng khi chạy "dotnet ef migrations add ...": khai báo sẵn phiên bản MySQL
    /// để tạo migration mà không cần kết nối tới database (ServerVersion.AutoDetect cần kết nối).
    /// Lệnh "dotnet ef database update" vẫn kết nối DB thật theo appsettings.json.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                   ?? "Server=localhost;Database=event_management_db;Uid=root;Pwd=";

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)))
                .Options;

            return new AppDbContext(options);
        }
    }
}
