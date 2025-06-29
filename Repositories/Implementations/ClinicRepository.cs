using ClinicAPI.Data;
using ClinicAPI.DTOs.Clinic;
using ClinicAPI.Models;
using ClinicAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories.Implementations
{
    public class ClinicRepository : IClinicRepository
    {
        private readonly ClinicDbContext _context ;

        public ClinicRepository(ClinicDbContext context)
        {
            _context = context;
        }

      public async Task<IEnumerable<Clinic>> GetAllAsync()
        {
            var clinics =  await _context.Clinics
                .AsNoTracking()
                .Include( c=> c.Doctors )
                .ToListAsync();
                 return clinics;
        }

      public async Task<Clinic?> GetByIdAsync(int id)
        {
            var clinic = await _context.Clinics
                .Include( c=> c.Doctors )
                .FirstOrDefaultAsync(x => x.Id == id);

         if ( clinic == null ) return null;
         return clinic;
        }

       public async Task<Clinic> AddAsync(Clinic clinic)
        {
            await _context.Clinics.AddAsync(clinic);
            return clinic;
        }

        public void Delete (Clinic clinic )
        {
            _context.Clinics.Remove(clinic);

        }








    }
}
