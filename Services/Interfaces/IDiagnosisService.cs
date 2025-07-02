using ClinicAPI.DTOs.Diagnosis;

namespace ClinicAPI.Services.Interfaces
{
    public interface IDiagnosisService
    {
        Task<IEnumerable<ReadDiagnosisDTO>> GetAllAsync();
        Task<ReadDiagnosisDTO?> GetByIdAsync(int id);
        Task<ReadDiagnosisDTO?> AddAsync(CreateDiagnosisDTO dto);
        Task<bool> UpdateAsync(int id, UpdateDiagnosisDTO dto);
        Task<bool> DeleteAsync(int id);

    }
}
