using ClinicAPI.Models;

namespace ClinicAPI.Repositories.Interfaces
{
    public interface IDiagnosisRepository
    {
        Task<IEnumerable<Diagnosis>> GetAllAsync();
        Task<Diagnosis?> GetByIdAsync(int id);
        Task<Diagnosis> AddAsync(Diagnosis diagnosis);
        Task<bool> DeleteAsync(Diagnosis diagnosis);

    }
}
