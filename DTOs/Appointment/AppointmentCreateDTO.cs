using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Appointment
{
    public class AppointmentCreateDTO
    {
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId {get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
        
        
    }
}
