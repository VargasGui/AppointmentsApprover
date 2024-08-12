namespace AppointmentApprover.Services.DTOs
{
    public class TimeEntryDto
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Description { get; set; }
        public bool? IsApproved { get; set; }
    }
}
