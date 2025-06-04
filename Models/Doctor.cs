namespace ClinicAPI.Models
{
    public class Doctor

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; } = null!;
        public int ClinicId { get; set; } 
        public Clinic Clinic { get; set; }=null!;
        public ICollection<Patient> Patients { get; set; } = new List<Patient>(); 
        public ICollection<Appointment> Appointments { get; set; } =new List<Appointment>();

      
    }
}
