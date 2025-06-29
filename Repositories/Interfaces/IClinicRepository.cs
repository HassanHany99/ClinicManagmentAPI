using ClinicAPI.DTOs.Clinic;
using ClinicAPI.Models;

namespace ClinicAPI.Repositories.Interfaces
{
    public interface IClinicRepository
    {
        Task<IEnumerable<Clinic>> GetAllAsync();
        Task<Clinic?> GetByIdAsync(int id);
        Task<Clinic> AddAsync(Clinic clinic);
        void Delete(Clinic clinic);
        
    }
}
