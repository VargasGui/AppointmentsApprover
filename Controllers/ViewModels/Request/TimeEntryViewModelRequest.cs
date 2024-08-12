namespace AppointmentApprover.Controllers.ViewModels.Request
{
    public class TimeEntryViewModelRequest
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Description { get; set; }
    }
}
