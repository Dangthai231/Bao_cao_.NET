using System.Net.Http.Json;
using EventManager.UI.Models;

namespace EventManager.UI.Services;

public partial class ApiService
{
    private async Task<T> GetAdminAsync<T>(string route)
    {
        using var response = await _httpClient.GetAsync("api/admin/" + route);
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException(await ReadMessageAsync(response), null, response.StatusCode);

        return await response.Content.ReadFromJsonAsync<T>()
            ?? throw new InvalidOperationException("API Admin không trả về dữ liệu.");
    }

    private async Task<(bool Success, string Message)> SendAdminAsync(HttpMethod method, string route, object? body)
    {
        try
        {
            using var request = new HttpRequestMessage(method, "api/admin/" + route);
            if (body != null)
                request.Content = JsonContent.Create(body);
            using var response = await _httpClient.SendAsync(request);
            return (response.IsSuccessStatusCode, await ReadMessageAsync(response));
        }
        catch (Exception ex) when (ex is HttpRequestException or TaskCanceledException)
        {
            return (false, ex.Message);
        }
    }

    public Task<AdminDashboardDto> GetAdminDashboardAsync() => GetAdminAsync<AdminDashboardDto>("dashboard");
    public Task<AdminReportDto> GetAdminReportAsync() => GetAdminAsync<AdminReportDto>("reports");

    public Task<List<AdminAccountDto>> GetAccountsAsync(string? role = null)
        => GetAdminAsync<List<AdminAccountDto>>("accounts?role=" + Uri.EscapeDataString(role ?? ""));
    public Task<List<AdminChangeRequestDto>> GetChangeRequestsAsync()
        => GetAdminAsync<List<AdminChangeRequestDto>>("accounts/requests");
    public Task<(bool Success, string Message)> CreateAccountAsync(AdminAccountRequest body)
        => SendAdminAsync(HttpMethod.Post, "accounts", body);
    public Task<(bool Success, string Message)> UpdateAccountAsync(int id, AdminAccountRequest body)
        => SendAdminAsync(HttpMethod.Put, $"accounts/{id}", body);
    public Task<(bool Success, string Message)> SetAccountActiveAsync(int id, bool isActive)
        => SendAdminAsync(HttpMethod.Put, $"accounts/{id}/state", new AdminLockRequest { IsActive = isActive });
    public Task<(bool Success, string Message)> ResetPasswordAsync(int id, string password)
        => SendAdminAsync(HttpMethod.Put, $"accounts/{id}/password", new AdminPasswordRequest { Password = password });
    public Task<(bool Success, string Message)> ReviewChangeRequestAsync(int id, bool approved, string? reason)
        => SendAdminAsync(HttpMethod.Put, $"accounts/requests/{id}", new AdminReviewRequest { Approved = approved, Reason = reason });

    public Task<AdminPermissionDto> GetPermissionsAsync(int id) => GetAdminAsync<AdminPermissionDto>($"permissions/{id}");
    public Task<(bool Success, string Message)> SetPermissionsAsync(int id, AdminPermissionRequest body)
        => SendAdminAsync(HttpMethod.Put, $"permissions/{id}", body);

    public Task<List<AdminEventDto>> GetAdminEventsAsync(string keyword)
        => GetAdminAsync<List<AdminEventDto>>("events?q=" + Uri.EscapeDataString(keyword));
    public Task<AdminProgressDto> GetEventProgressAsync(int id) => GetAdminAsync<AdminProgressDto>($"events/{id}/progress");
    public Task<List<AdminPlanDto>> GetPlansAsync() => GetAdminAsync<List<AdminPlanDto>>("events/plans");
    public Task<(bool Success, string Message)> CreateAdminEventAsync(AdminEventRequest body)
        => SendAdminAsync(HttpMethod.Post, "events", body);
    public Task<(bool Success, string Message)> UpdateAdminEventAsync(int id, AdminEventRequest body)
        => SendAdminAsync(HttpMethod.Put, $"events/{id}", body);
    public Task<(bool Success, string Message)> AssignManagerAsync(int id, int managerId)
        => SendAdminAsync(HttpMethod.Put, $"events/{id}/assign", new AdminAssignRequest { ManagerId = managerId });
    public Task<(bool Success, string Message)> ReviewPlanAsync(int id, bool approved, string? reason)
        => SendAdminAsync(HttpMethod.Put, $"events/plans/{id}", new AdminReviewRequest { Approved = approved, Reason = reason });

    public Task<List<AdminNotificationDto>> GetAdminNotificationsAsync(string keyword)
        => GetAdminAsync<List<AdminNotificationDto>>("notifications?q=" + Uri.EscapeDataString(keyword));
    public Task<(bool Success, string Message)> CreateAdminNotificationAsync(AdminNotificationRequest body)
        => SendAdminAsync(HttpMethod.Post, "notifications", body);
    public Task<(bool Success, string Message)> UpdateAdminNotificationAsync(int id, AdminNotificationRequest body)
        => SendAdminAsync(HttpMethod.Put, $"notifications/{id}", body);
    public Task<(bool Success, string Message)> ReviewNotificationAsync(int id, bool approved, string? reason)
        => SendAdminAsync(HttpMethod.Put, $"notifications/{id}/review", new AdminReviewRequest { Approved = approved, Reason = reason });
    public Task<(bool Success, string Message)> PublishNotificationAsync(int id)
        => SendAdminAsync(HttpMethod.Put, $"notifications/{id}/publish", null);
    public Task<(bool Success, string Message)> WithdrawNotificationAsync(int id)
        => SendAdminAsync(HttpMethod.Put, $"notifications/{id}/withdraw", null);

    public Task<(bool Success, string Message)> ChangeMyPasswordAsync(string currentPassword, string password)
        => SendAdminAsync(HttpMethod.Put, "settings/password", new AdminPasswordRequest { CurrentPassword = currentPassword, Password = password });
}
