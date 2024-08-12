using AppointmentApprover.Services.DTOs;
using AppointmentApprover.Services.DTOs.Request;

namespace AppointmentApprover.Services.Interfaces
{
    public interface ITimeEntry
    {
        Task<List<TimeEntryDto>> GetAll();
        Task<bool> Create(TimeEntryDtoRequest te);
    }
}
