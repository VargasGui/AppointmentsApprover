using AppointmentApprover.Controllers.ViewModels;
using AppointmentApprover.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using AppointmentApprover.Services.Interfaces;
using AppointmentApprover.Controllers.ViewModels.Request;
using AppointmentApprover.Services.DTOs.Request;

namespace AppointmentApprover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntry _service;
        public TimeEntryController(ITimeEntry service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("api/time-entry")]
        [ProducesResponseType(typeof(List<TimeEntryViewModel>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            var te = await _service.GetAll();
            if (!te.Any())
            {
                return NoContent();
            }
            return Ok(te.Select(e => new TimeEntryViewModel
            {
                Id = e.Id,
                TaskId = e.TaskId,
                Date = e.Date,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                Description = e.Description,
                IsApproved = e.IsApproved,
            }).ToList());
        }
        [HttpPost]
        [Route("api/time-entry")]
        [ProducesResponseType(typeof(bool), 201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create(Guid taskId, [FromBody] TimeEntryViewModelRequest te)
        {
            if (te == null || taskId == Guid.Empty)
            {
                return BadRequest();
            }
            var teDto = new TimeEntryDtoRequest()
            {
                TaskId = taskId,
                Date = te.Date,
                StartTime = te.StartTime,
                EndTime = te.EndTime,
                Description = te.Description,
            };
            bool created = await _service.Create(teDto);
            if (!created)
            {
                return BadRequest();
            }
            return StatusCode(201, true);
        }
    }
}
