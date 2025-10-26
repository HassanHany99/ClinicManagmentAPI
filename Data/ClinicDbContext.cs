using Microsoft.EntityFrameworkCore;
using ClinicAPI.Models;

namespace ClinicAPI.Data
{                                  
    public class ClinicDbContext :DbContext
    {
        public DbSet<Doctor> Doctors => Set<Doctor>(); 
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Clinic> Clinics => Set<Clinic>();
        public DbSet<Diagnosis> Diagnosis => Set<Diagnosis>();
        public DbSet<User> Users => Set<User>();

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Doctor -> Clinic (M : 1)
            builder.Entity<Doctor>()
                .HasOne(d => d.Clinic)
                .WithMany(c => c.Doctors)
                .HasForeignKey(d => d.ClinicId);

            // Doctor -> Patient (1 : M)
            builder.Entity<Doctor>()
                  .HasMany(d => d.Patients)
                  .WithOne(p => p.Doctor)
                  .HasForeignKey(key => key.DoctorId)
                  .OnDelete(DeleteBehavior.Restrict);

            // Doctor -> Appointment (1 : M)
             builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(p => p.Appointments)
                .HasForeignKey(k => k.DoctorId)
                 .OnDelete(DeleteBehavior.Restrict); 

            // Appointment -> Patient (M : 1)

            builder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                 .OnDelete(DeleteBehavior.Restrict); 

            // Appointment -> Dignosis (1 : 1)

            builder.Entity<Appointment>()
                .HasOne(a => a.Diagnosis)
                .WithOne(d => d.Appointment)
                .HasForeignKey<Diagnosis>(d => d.AppointmentId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
