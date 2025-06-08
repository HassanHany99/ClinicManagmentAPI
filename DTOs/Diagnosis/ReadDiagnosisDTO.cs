namespace ClinicAPI.DTOs.Diagnosis
{
    public class ReadDiagnosisDTO
    {       
        public string Description { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
