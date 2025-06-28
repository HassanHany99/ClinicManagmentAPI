using ClinicAPI.Models;

namespace ClinicAPI.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> AddAsync(Patient patient);
        Task<bool> DeleteAsync(int id);
    }
}
