namespace EventManager.Api.DTOs
{
    public class CreatePlanDto
    {
        public string PlanName { get; set; } = string.Empty;
        public string Objective { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal Budget { get; set; }
    }
}
