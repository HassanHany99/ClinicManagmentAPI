using ClinicAPI.Data;
using ClinicAPI.Models;
using ClinicAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories.Implementations
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicDbContext _context;

        public PatientRepository(ClinicDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            var patients = await _context.Patients
                .AsNoTracking()
                .Include(p => p.Doctor)
                .ToListAsync();
            return patients;
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            var patient = await _context.Patients
                .Include(p =>p.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (patient is null) return null;
            return patient;
  
        }

        public async Task<Patient> AddAsync(Patient patient) 
        { 
           await _context.Patients.AddAsync(patient);
           return patient;
  
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await GetByIdAsync(id);

            if (patient is null) return false;

           _context.Patients.Remove(patient);
            return true;

        }


    }
}
