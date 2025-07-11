using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Diagnosis
{
    public class UpdateDiagnosisDTO
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}
