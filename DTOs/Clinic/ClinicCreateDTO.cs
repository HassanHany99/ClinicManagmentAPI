using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Clinic
{
    public class ClinicCreateDTO
    {
        [Required(ErrorMessage = "Clinic Name is required")]
        public string name { get; set; }
    }
}
