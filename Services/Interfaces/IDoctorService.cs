namespace ClinicAPI.Services.Interfaces;
using ClinicAPI.DTOs.Doctor;

public interface IDoctorService
{

    Task<IEnumerable<DoctorReadDTO>> GetAllAsync();
    DoctorReadDTO GetDoctorById(int id);
    DoctorReadDTO CreateDoctor(DoctorCreateDTO dto);
    bool UpdateDoctor(int id, DoctorUpdateDTO dto);
    bool DeleteDoctor(int id);

}
