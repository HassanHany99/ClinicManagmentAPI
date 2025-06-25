using ClinicAPI.Data;
using ClinicAPI.Repositories.Interfaces;

namespace ClinicAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicDbContext _context;
        public IDoctorRepository Doctors { get; }

        public UnitOfWork(ClinicDbContext context, IDoctorRepository doctorsRepository)
        {
            _context = context;
            Doctors =  doctorsRepository;
        }

        public async Task<int> CompleteAsync()
        {
         return  await _context.SaveChangesAsync();
        }
    }
}
