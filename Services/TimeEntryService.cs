using AppointmentApprover.Models;
using AppointmentApprover.Services.DTOs;
using AppointmentApprover.Services.DTOs.Request;
using AppointmentApprover.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentApprover.Services
{
    public class TimeEntryService : ITimeEntry
    {
        private readonly ApplicationDbContext _context;
        public TimeEntryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TimeEntryDto>> GetAll()
        {
            return await _context.TimeEntries.Select(e => new TimeEntryDto()
            {
                Id = e.Id,
                TaskId = e.TaskId,
                Date = e.Date,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                Description = e.Description,
                IsApproved = e.IsApproved,
            }).ToListAsync();
        }
        public async Task<bool> Create(TimeEntryDtoRequest dto)
        {
            var taskFound = await _context.Tasks.FindAsync(dto.TaskId);
            if (taskFound == null)
            {
                return false;
            }
            TimeEntry te = new TimeEntry()
            {
                TaskId = dto.TaskId,
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Description = dto.Description
            };
            await _context.TimeEntries.AddAsync(te);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
