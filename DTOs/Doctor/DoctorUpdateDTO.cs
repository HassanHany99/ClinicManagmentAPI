using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Doctor
{
    public class DoctorUpdateDTO
    {
        [Required(ErrorMessage = "Doctor name is required")]
        public string Name { get; set; }
    }
}
