using System.Net.WebSockets;
using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Appointment;
using ClinicAPI.Models;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<List<AppointmentReadDTO>> GetAllAppointments() {

            var appointments = _appointmentService.GetAllAppointments();
            return appointments;
           
        }
        [HttpGet("{id:int}")]
        public ActionResult GetAppointmentById(int id) {
            var app = _appointmentService.GetAppointmentById(id);
            if (app == null)
            {
                return NotFound();
            }
            return Ok(app);
        }
        [HttpPost]
        public ActionResult CrateAppointment(AppointmentCreateDTO dto) 
        {
            var appointment = _appointmentService.CrateAppointment(dto);
            if (appointment == null)
            {
                return BadRequest("Invalid doctor or patient IDs");
            }

            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id },appointment);
        }

        [HttpPut]
        public ActionResult UpdateAppointment(AppointmentUpdateDTO dto ) {

            var app = _appointmentService.UpdateAppointment(dto);

            if (!app) return NotFound();
            
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAppointment(int id)
        {
            var appointment = _appointmentService.DeleteAppointment(id);    

            if (appointment == null) 
            {
                return NotFound();
            }
            return NoContent();

        }

}
}
