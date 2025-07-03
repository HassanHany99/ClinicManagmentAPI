using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Appointment
{
    public class AppointmentCreateDTO
    {
       
        public int DoctorId { get; set; }
        public int PatientId {get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
        
        
    }
}
