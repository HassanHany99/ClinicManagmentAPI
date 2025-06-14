namespace ClinicAPI.Services.Interfaces;
using ClinicAPI.DTOs.Doctor;

public interface IDoctorService
{

    List<DoctorReadDTO> GetDoctors();
    DoctorReadDTO GetDoctorById(int id);
    DoctorReadDTO CreateDoctor(DoctorCreateDTO dto);
    bool UpdateDoctor(int id, DoctorUpdateDTO dto);
    bool DeleteDoctor(int id);

}
