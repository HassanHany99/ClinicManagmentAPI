﻿namespace ClinicAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
   
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } 

        public int PatientId { get; set; }
        public Patient Patient { get; set; } 

        public Diagnosis Diagnosis { get; set; }    
    }
}
