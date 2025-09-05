using ClinicAPI.DTOs.Appointment;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{

    public class AppointmentController : BaseApiController
    {
        private readonly IAppointmentService _appointmentService;


        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {

            var appointments = await _appointmentService.GetAllAsync();
            return SuccessResponse(appointments);

        }

        [HttpGet(("{id:int}"), Name = "GetAppointmentById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment == null) return ErrorResponse("Appointment Not Found", 404);

            return SuccessResponse(appointment, " Appointment fetched");

        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(AppointmentCreateDTO dto)
        {
            var appointment = await _appointmentService.AddAsync(dto);
            if (appointment == null)
            {
                return ErrorResponse("Invalid doctor or patient IDs", 400);
            }

            return SuccessResponse(appointment, "Appointment Created", 201);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, AppointmentUpdateDTO dto)
        {
            var appointment = await _appointmentService.UpdateAsync(id, dto);
            if (!appointment) return ErrorResponse("Appointment Not Found", 404);
            return NoContentResponse();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var appointment = await _appointmentService.DeleteAsync(id);

            if (!appointment)
            {
                return ErrorResponse("Appointment Not Found", 404);
            }

            return NoContentResponse();

        }

    }
}
