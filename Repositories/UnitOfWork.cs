using ClinicAPI.Data;
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

        public UnitOfWork(ClinicDbContext context
            , IDoctorRepository doctorsRepository 
            , IPatientRepository patientRepository
            , IClinicRepository clinicRepository
            , IAppointmentRepository appointmentRepository
            , IDiagnosisRepository diagnosisRepository)
        {
            _context = context;
            Doctors =  doctorsRepository;
            Patients = patientRepository;
            Clinics = clinicRepository;
            Appointments = appointmentRepository;
            Diagnosises = diagnosisRepository;
        }

        public async Task<int> CompleteAsync()
        {
         return  await _context.SaveChangesAsync();
        }
    }
}
