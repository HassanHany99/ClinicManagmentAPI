namespace ClinicAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
     
    }
}

