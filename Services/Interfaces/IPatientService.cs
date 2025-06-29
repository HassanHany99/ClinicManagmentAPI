using ClinicAPI.DTOs.Patient;

namespace ClinicAPI.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientReadDTO>> GetAllAsync();
        Task<PatientReadDTO?> GetByIdAsync(int id);
        Task<PatientReadDTO?> AddAsync(PatientCreateDTO dto);
        Task<bool> UpdateAsync(PatientUpdateDTO patientDTO);
        Task<bool> DeleteAsync(int id);

    }
}
