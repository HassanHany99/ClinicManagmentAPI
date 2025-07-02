using ClinicAPI.DTOs.Appointment;

namespace ClinicAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentReadDTO>> GetAllAsync();
        Task<AppointmentReadDTO?> GetByIdAsync(int id);
        Task<AppointmentReadDTO?> AddAsync(AppointmentCreateDTO dto);
        Task<bool> UpdateAsync(int id, AppointmentUpdateDTO dto);
        Task<bool> DeleteAsync(int id);






    }
}
