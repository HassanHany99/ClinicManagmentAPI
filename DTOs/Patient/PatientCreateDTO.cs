using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Patient
{
    public class PatientCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        public int DoctorId { get; set; }

    }
}
