using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Appointment
{
    public class AppointmentUpdateDTO
    {
      //  [Required]
        public DateTime AppointmentDate { get; set; }
    }
}
