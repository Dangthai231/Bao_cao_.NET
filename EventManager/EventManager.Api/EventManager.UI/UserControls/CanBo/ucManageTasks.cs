using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.CanBo
{
    public partial class ucManageTasks : UserControl
    {
        private readonly ApiService _apiService;
        public ucManageTasks()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void btnSavePlan_Click(object sender, EventArgs e)
        {
            // 1. Gom dữ liệu từ UI vào DTO
            var newPlan = new CreatePlanDto
            {
                PlanName = txtPlanName.Text.Trim(),
                Objective = txtObjective.Text.Trim(),
                Description = rtbDescription.Text.Trim(),
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                Location = txtLocation.Text.Trim(),
                // Thực tế cần có TryParse để bẫy lỗi nếu người dùng gõ chữ vào ô số
                Budget = decimal.Parse(txtBudget.Text.Trim())
            };

            // 2. Gọi ApiService gửi DTO lên Backend (POST /api/canbo/tasks/plan)
            // bool isSuccess = await _apiService.CreatePlanAsync(newPlan);
            // ... (Xử lý thông báo thành công/thất bại)
        }
        // Sự kiện khi Load giao diện lần đầu
        private void ucManageTasks_Load(object sender, EventArgs e)
        {
        }

        private void pbOverallProgress_Click(object sender, EventArgs e)
        {

        }
    }
}
