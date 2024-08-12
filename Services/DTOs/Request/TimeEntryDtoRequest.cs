namespace AppointmentApprover.Services.DTOs.Request
{
    public class TimeEntryDtoRequest
    {
        public Guid TaskId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Description { get; set; }
    }
}
