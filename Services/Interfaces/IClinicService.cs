using ClinicAPI.DTOs.Clinic;
using ClinicAPI.DTOs.Doctor;

namespace ClinicAPI.Services.Interfaces
{
    public interface IClinicService 
    {
         List<ClinicReadDTO> GetClinics();
         ClinicReadDTO? GetClinicById(int id);
         ClinicReadDTO CreateClinic(ClinicCreateDTO dto);
         bool UpdateClinic(int id, ClinicUpdateDTO dto);
         bool DeleteClinic(int id);
    }
}
