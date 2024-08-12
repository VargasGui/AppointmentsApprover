namespace AppointmentApprover.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
