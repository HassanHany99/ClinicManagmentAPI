using ClinicAPI.Data;
using ClinicAPI.Repositories.Implementations;
using ClinicAPI.Repositories.Interfaces;

namespace ClinicAPI.Repositories

{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicDbContext _context;

        public UnitOfWork(ClinicDbContext context)
        {
            _context = context;

        }

        private IDoctorRepository? _doctor;
        public IDoctorRepository Doctors => _doctor ??= new DoctorRepository(_context);

        private IPatientRepository? _patient;
        public IPatientRepository Patients => _patient ??= new PatientRepository(_context);

        private IClinicRepository? _clinic;
        public IClinicRepository Clinics => _clinic ??= new ClinicRepository(_context);  
      
        private IAppointmentRepository? _appointment;
        public IAppointmentRepository Appointments  => _appointment ??= new AppointmentRepository(_context);

        private IDiagnosisRepository? _diagnosis;
        public IDiagnosisRepository Diagnosises => _diagnosis ??= new DiagnosisRepository(_context);


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
