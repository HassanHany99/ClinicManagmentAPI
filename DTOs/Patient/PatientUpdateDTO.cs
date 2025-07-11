using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Patient
{
    public class PatientUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } 
       

    }
}
