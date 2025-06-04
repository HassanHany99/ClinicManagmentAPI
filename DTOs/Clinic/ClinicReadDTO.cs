using ClinicAPI.DTOs.Doctor;


namespace ClinicAPI.DTOs.Clinic
{
    public class ClinicReadDTO
    {
        public string Name { get; set; }
        public ICollection<DoctorReadDTO> Doctors { get; set; } = new List<DoctorReadDTO>();

    }
}
