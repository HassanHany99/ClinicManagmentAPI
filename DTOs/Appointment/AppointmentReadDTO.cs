using System.ComponentModel.DataAnnotations;

namespace ClinicAPI.DTOs.Appointment
{
    public class AppointmentReadDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string DiagnosisDescription { get; set; }
    }
}
