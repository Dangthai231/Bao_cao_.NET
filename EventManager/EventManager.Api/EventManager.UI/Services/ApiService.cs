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

        // ==========================================
        // PHÂN HỆ SINH VIÊN
        // Các hàm thao tác trả về (Success, Message) để hiển thị đúng thông báo lỗi từ Backend
        // ==========================================

        // --- Tra cứu sự kiện ---
        public async Task<List<StudentEventDto>> GetStudentEventsAsync(int userId, string keyword, DateTime? fromDate, DateTime? toDate)
        {
            var parts = new List<string> { "userId=" + userId };
            if (!string.IsNullOrWhiteSpace(keyword))
                parts.Add("keyword=" + Uri.EscapeDataString(keyword.Trim()));
            if (fromDate.HasValue)
                parts.Add("fromDate=" + fromDate.Value.ToString("yyyy-MM-dd"));
            if (toDate.HasValue)
                parts.Add("toDate=" + toDate.Value.ToString("yyyy-MM-dd"));

            var response = await _httpClient.GetAsync("api/sinhvien/events?" + string.Join("&", parts));
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<StudentEventDto>>();
            return new List<StudentEventDto>();
        }

        public async Task<StudentEventDto> GetStudentEventDetailAsync(int eventId, int userId)
        {
            var response = await _httpClient.GetAsync($"api/sinhvien/events/{eventId}?userId={userId}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<StudentEventDto>();
            return null;
        }

        // --- Đăng ký tham gia ---
        public async Task<List<RegistrationDto>> GetMyRegistrationsAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/sinhvien/registrations?userId={userId}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<RegistrationDto>>();
            return new List<RegistrationDto>();
        }

        public async Task<(bool Success, string Message)> RegisterEventAsync(int userId, int eventId)
        {
            var body = new { UserId = userId, EventId = eventId };
            var response = await _httpClient.PostAsJsonAsync("api/sinhvien/registrations", body);
            if (response.IsSuccessStatusCode)
                return (true, "Đăng ký tham gia sự kiện thành công!");
            return (false, await ReadMessageAsync(response));
        }

        public async Task<(bool Success, string Message)> CancelRegistrationAsync(int registrationId, int userId)
        {
            var response = await _httpClient.PutAsync($"api/sinhvien/registrations/{registrationId}/cancel?userId={userId}", null);
            return (response.IsSuccessStatusCode, await ReadMessageAsync(response));
        }

        // --- Đánh giá và phản hồi ---
        public async Task<List<StudentEventDto>> GetFeedbackEligibleEventsAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/sinhvien/feedbacks/eligible-events?userId={userId}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<StudentEventDto>>();
            return new List<StudentEventDto>();
        }

        public async Task<List<FeedbackDto>> GetMyFeedbacksAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/sinhvien/feedbacks?userId={userId}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<FeedbackDto>>();
            return new List<FeedbackDto>();
        }

        public async Task<(bool Success, string Message)> SubmitFeedbackAsync(int userId, int eventId, int rating, string comment)
        {
            var body = new { UserId = userId, EventId = eventId, Rating = rating, Comment = comment };
            var response = await _httpClient.PostAsJsonAsync("api/sinhvien/feedbacks", body);
            return (response.IsSuccessStatusCode, await ReadMessageAsync(response));
        }

        public async Task<(bool Success, string Message)> DeleteFeedbackAsync(int feedbackId, int userId)
        {
            var response = await _httpClient.DeleteAsync($"api/sinhvien/feedbacks/{feedbackId}?userId={userId}");
            return (response.IsSuccessStatusCode, await ReadMessageAsync(response));
        }

        // --- Thông tin cá nhân ---
        public async Task<StudentProfileDto> GetStudentProfileAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/sinhvien/profile/{userId}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<StudentProfileDto>();
            return null;
        }

        public async Task<(bool Success, string Message)> UpdateStudentProfileAsync(int userId, UpdateProfileRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/sinhvien/profile/{userId}", request);
            return (response.IsSuccessStatusCode, await ReadMessageAsync(response));
        }

        /// <summary>
        /// Đọc trường "message" trong JSON Backend trả về, ví dụ: { "message": "Bạn đã đăng ký sự kiện này rồi!" }
        /// </summary>
        private static async Task<string> ReadMessageAsync(HttpResponseMessage response)
        {
            try
            {
                var body = await response.Content.ReadFromJsonAsync<ApiMessage>();
                if (!string.IsNullOrWhiteSpace(body?.Message))
                    return body.Message;
            }
            catch
            {
                // Body không phải JSON → dùng thông báo mặc định
            }
            return response.IsSuccessStatusCode ? "Thành công!" : $"Lỗi từ máy chủ ({(int)response.StatusCode})";
        }

        private class ApiMessage
        {
            public string Message { get; set; }
        }
    }
}
