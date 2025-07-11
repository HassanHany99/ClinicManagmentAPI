using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Diagnosis
{
    public class CreateDiagnosisDTO
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required]
        public int AppointmentId { get; set; }
    }
}
