using EventManager.UI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EventManager.UI.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("http://localhost:7112/");
        }

        public async Task<UserSession> LoginAsync(string username, string password)
        {
            var loginRequest = new { Username = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                // Nếu API trả về OK, đọc lấy Username và Role
                return await response.Content.ReadFromJsonAsync<UserSession>();
            }
            
            return null; // Đăng nhập thất bại
        }

        public async Task<DashboardSummaryDto> GetDashboardSummaryAsync()
        {
            var response = await _httpClient.GetAsync("api/canbo/dashboard/summary");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<DashboardSummaryDto>();
            return null;
        }

        /// <summary>
        /// Lấy dữ liệu thống kê để vẽ biểu đồ.
        /// fromDate / toDate có thể null (BE mặc định năm hiện tại).
        /// </summary>
        public async Task<ReportDataDto> GetReportStatisticsAsync(DateTime? fromDate, DateTime? toDate)
        {
            var query = "api/canbo/reports/statistics";
            var parts = new List<string>();

            if (fromDate.HasValue)
                parts.Add("fromDate=" + Uri.EscapeDataString(fromDate.Value.ToString("yyyy-MM-dd")));
            if (toDate.HasValue)
                parts.Add("toDate=" + Uri.EscapeDataString(toDate.Value.ToString("yyyy-MM-dd")));

            if (parts.Count > 0)
                query += "?" + string.Join("&", parts);

            var response = await _httpClient.GetAsync(query);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<ReportDataDto>();
            return null;
        }

        // ==========================================
        // CHỨC NĂNG QUẢN LÝ TÀI LIỆU SỰ KIỆN
        // ==========================================
        public async Task<List<DocumentDto>> GetDocumentsAsync()
        {
            var response = await _httpClient.GetAsync("api/canbo/documents");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<DocumentDto>>();
            }
            return new List<DocumentDto>();
        }

        public async Task<bool> UploadDocumentAsync(DocumentDto newDoc)
        {
            var response = await _httpClient.PostAsJsonAsync("api/canbo/documents", newDoc);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/canbo/documents/{id}");
            return response.IsSuccessStatusCode;
        }

        // ==========================================
        // CHỨC NĂNG QUẢN LÝ THÔNG BÁO
        // ==========================================
        public async Task<List<NotificationDto>> GetNotificationsAsync()
        {
            var response = await _httpClient.GetAsync("api/canbo/notifications");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<NotificationDto>>();
            return new List<NotificationDto>();
        }

        public async Task<bool> CreateNotificationAsync(NotificationDto notification)
        {
            var response = await _httpClient.PostAsJsonAsync("api/canbo/notifications", notification);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateNotificationAsync(NotificationDto notification)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/canbo/notifications/{notification.NotificationCode}", notification);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteNotificationAsync(string notificationCode)
        {
            var response = await _httpClient.DeleteAsync($"api/canbo/notifications/{notificationCode}");
            return response.IsSuccessStatusCode;
        }

        // ==========================================
        // CHỨC NĂNG QUẢN LÝ NGƯỜI THAM GIA
        // ==========================================
        public async Task<List<ParticipantDto>> GetParticipantsAsync()
        {
            var response = await _httpClient.GetAsync("api/canbo/participants");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<ParticipantDto>>();
            return new List<ParticipantDto>();
        }

        public async Task<bool> UpdateAttendanceStatusAsync(string participantCode, string attendanceStatus)
        {
            var body = new { AttendanceStatus = attendanceStatus };
            var response = await _httpClient.PutAsJsonAsync($"api/canbo/participants/{participantCode}/attendance", body);
            return response.IsSuccessStatusCode;
        }
    }
}
