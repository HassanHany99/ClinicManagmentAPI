namespace ClinicAPI.Services.Interfaces;
using ClinicAPI.DTOs.Doctor;

public interface IDoctorService
{

    Task<IEnumerable<DoctorReadDTO>> GetAllAsync();
    Task<DoctorReadDTO?> GetByIdAsync(int id);
    Task<DoctorReadDTO> AddAsync(DoctorCreateDTO dto);
    Task<bool> UpdateAsync(int id, DoctorUpdateDTO dto);
    Task<bool> DeleteAsync(int id);

}
