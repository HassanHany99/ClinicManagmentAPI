using ClinicAPI.Data;
using ClinicAPI.Repositories.Implementations;
using ClinicAPI.Repositories.Interfaces;

namespace ClinicAPI.Repositories

{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicDbContext _context;
        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }
        public IClinicRepository Clinics { get; }
        public IAppointmentRepository Appointments { get; }
        public IDiagnosisRepository Diagnosises { get; }

        public UnitOfWork(ClinicDbContext context)
        {
            _context = context;
            Doctors = new DoctorRepository(_context);
            Patients = new PatientRepository(_context);
            Clinics = new ClinicRepository(_context);
            Appointments = new AppointmentRepository(_context);
            Diagnosises = new DiagnosisRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
