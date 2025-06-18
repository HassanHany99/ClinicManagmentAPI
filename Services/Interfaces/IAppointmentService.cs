using ClinicAPI.DTOs.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        List<AppointmentReadDTO> GetAllAppointments();
        AppointmentReadDTO? GetAppointmentById(int id);
        AppointmentReadDTO CreateAppointment(AppointmentCreateDTO dto);
        bool UpdateAppointment(int id ,AppointmentUpdateDTO dto);
        bool DeleteAppointment(int id);






    }
}
