using ClinicAPI.Models;

namespace ClinicAPI.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
     //   Task<DoctorReadDTO> GetDoctorById(int id);
      //  Task<DoctorReadDTO> AddDoctor(DoctorCreateDTO dto);
       // bool UpdateDoctor(int id, DoctorUpdateDTO dto);
      //  bool DeleteDoctor(int id);
    }
}
