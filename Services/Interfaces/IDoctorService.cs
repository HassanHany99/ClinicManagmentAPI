namespace ClinicAPI.Services.Interfaces;
using ClinicAPI.DTOs.Doctor;

public interface IDoctorService
{

    List<DoctorReadDTO> GetAllDoctors();
    DoctorReadDTO GetDoctorById(int id);
    DoctorReadDTO CreateDoctor(DoctorCreateDTO dto);
    bool UpdateDoctor(int id, DoctorUpdateDTO dto);
    bool DeleteDoctor(int id);

}
