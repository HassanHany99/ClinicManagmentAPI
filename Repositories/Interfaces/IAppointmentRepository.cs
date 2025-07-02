using ClinicAPI.Models;

namespace ClinicAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(int id);
        Task<Appointment> AddAsync(Appointment appointment);
        Task<bool> DeleteAsync(Appointment appointment);

    }
}
