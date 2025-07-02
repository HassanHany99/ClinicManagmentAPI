using ClinicAPI.DTOs.Appointment;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;


        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentReadDTO>>> GetAllAppointments()
        {

            var appointments = await _appointmentService.GetAllAsync();
            return Ok(appointments);


        }


        [HttpGet(("{id:int}"), Name = "GetAppointmentById")]
        public async Task<ActionResult<AppointmentReadDTO>> GetByIdAsync(int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment == null) return NotFound();

            return Ok(appointment);

        }


        [HttpPost]
        public async Task<ActionResult<AppointmentReadDTO>> AddAsync(AppointmentCreateDTO dto)
        {
            var appointment = await _appointmentService.AddAsync(dto);
            if (appointment == null)
            {
                return BadRequest("Invalid doctor or patient IDs");
            }

            return CreatedAtRoute("GetAppointmentById", new { id = appointment.Id }, appointment);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, AppointmentUpdateDTO dto)
        {
            var appointment = await _appointmentService.UpdateAsync(id, dto);
            if (!appointment) return NotFound();
            return NoContent();
        }



        [HttpDelete("{id}")]
        public async  Task<ActionResult> DeleteAsync(int id)
        {
            var appointment = await _appointmentService.DeleteAsync(id);

            if (!appointment)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
