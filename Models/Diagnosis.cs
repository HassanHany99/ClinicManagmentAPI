namespace ClinicAPI.Models
{
    public class Diagnosis
    {
         public int Id { get; set; }
        public string Description { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
