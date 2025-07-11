using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Clinic
{
    public class ClinicUpdateDTO
    {
        [Required(ErrorMessage = "Clinic Name is required")]
        public string Name { get; set; }

    }
}
