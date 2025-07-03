using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Clinic
{
    public class ClinicCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
    }
}
