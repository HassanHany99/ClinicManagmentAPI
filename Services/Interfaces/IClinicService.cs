using ClinicAPI.DTOs.Clinic;

namespace ClinicAPI.Services.Interfaces
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicReadDTO>> GetAllAsync();
        Task<ClinicReadDTO?> GetByIdAsync(int id);
        Task<ClinicReadDTO?> AddAsync(ClinicCreateDTO dto);
        Task<bool> UpdateAsync(int id, ClinicUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
