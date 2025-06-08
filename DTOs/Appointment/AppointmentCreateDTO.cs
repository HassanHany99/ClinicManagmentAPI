namespace ClinicAPI.DTOs.Appointment
{
    public class AppointmentCreateDTO
    {
       
        public int DoctorId { get; set; }
        public int PatientId {get; set; }
        public DateTime AppointmentDate { get; set; }
        
        
    }
}
