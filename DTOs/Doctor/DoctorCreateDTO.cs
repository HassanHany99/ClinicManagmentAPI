using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Doctor
{
    public class DoctorCreateDTO

    {
        [Required(ErrorMessage= "Doctor name is required")]
        public string Name { get; set; }

        public string Speciality { get; set; }

        [Range(1, 50, ErrorMessage = "ID must be between 1 and 8")]
        public int ClinicId { get; set; }
    }
}
