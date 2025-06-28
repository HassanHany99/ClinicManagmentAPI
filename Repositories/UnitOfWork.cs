using ClinicAPI.Data;
using ClinicAPI.Repositories.Interfaces;

namespace ClinicAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicDbContext _context;
        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }

        public UnitOfWork(ClinicDbContext context, IDoctorRepository doctorsRepository , IPatientRepository patientRepository)
        {
            _context = context;
            Doctors =  doctorsRepository;
            Patients = patientRepository;
        }

        public async Task<int> CompleteAsync()
        {
         return  await _context.SaveChangesAsync();
        }
    }
}
