using EventManager.UI.Models;
using System;
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
        // Đừng quên using EventManager.Api.DTOs; ở trên cùng nếu bạn để DTO chung
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
            var parts = new System.Collections.Generic.List<string>();

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

        //chức năng quản lý tài liệu sự kiện
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
            // Gọi API POST để gửi dữ liệu lên Backend
            var response = await _httpClient.PostAsJsonAsync("api/canbo/documents", newDoc);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDocumentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/canbo/documents/{id}");
            return response.IsSuccessStatusCode;
        }
        //chức năng quản lý công việc
        // Hàm lấy dữ liệu (GET)
        public async Task<CreatePlanDto> GetPlanAsync(int planId)
        {
            // Cập nhật URL có thêm chữ /tasks/plan
            var response = await _httpClient.GetAsync($"api/canbo/tasks/plan/{planId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CreatePlanDto>();
            }
            return null;
        }

        // Hàm lưu dữ liệu (POST)
        public async Task<bool> SavePlanAsync(CreatePlanDto newPlan)
        {
            // Cập nhật URL thành /tasks/plan
            var response = await _httpClient.PostAsJsonAsync("api/canbo/tasks/plan", newPlan);
            return response.IsSuccessStatusCode;
        }
       //CHỨC NĂNG QUẢN LÝ THÔNG BÁO

        // Lấy danh sách thông báo
        public async Task<List<NotificationDto>> GetNotificationsAsync()
        {
            var response = await _httpClient.GetAsync("api/canbo/notifications");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<NotificationDto>>();
            return new List<NotificationDto>();
        }

        // Tạo thông báo mới
        public async Task<bool> CreateNotificationAsync(NotificationDto notification)
        {
            var response = await _httpClient.PostAsJsonAsync("api/canbo/notifications", notification);
            return response.IsSuccessStatusCode;
        }

        // Cập nhật thông báo
        public async Task<bool> UpdateNotificationAsync(NotificationDto notification)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/canbo/notifications/{notification.NotificationCode}", notification);
            return response.IsSuccessStatusCode;
        }

        // Xóa thông báo
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