using ClinicAPI.Models;
using ClinicAPI.DTOs.Doctor;

namespace ClinicAPI.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
        Task<Doctor> AddAsync(Doctor doctor);
       Task<bool> DeleteAsync(int id);
    }
}
