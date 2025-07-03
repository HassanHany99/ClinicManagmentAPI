using ClinicAPI.Data;
using ClinicAPI.Models;
using ClinicAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories.Implementations
{
    public class DiagnosisRepository : IDiagnosisRepository

    {
        private readonly ClinicDbContext _context;

        public DiagnosisRepository(ClinicDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Diagnosis>> GetAllAsync()
        {
            var diagnosises = await _context.Diagnosis
                .AsNoTracking()
                .Include(d => d.Appointment.Doctor)
                .Include(d => d.Appointment.Patient)
                .Include(d => d.Appointment)
                .ToListAsync();
            return diagnosises;

        }
        public async Task<Diagnosis?> GetByIdAsync(int id)
        {
            var diagnosis = await _context.Diagnosis
                  .Include(d => d.Appointment.Doctor)
                  .Include(d => d.Appointment.Patient)
                  .Include(d => d.Appointment)
                  .FirstOrDefaultAsync(x => x.Id == id);

            if (diagnosis is null) return null;

            return diagnosis;
        }

        public async Task<Diagnosis> AddAsync(Diagnosis diagnosis)
        {
            await _context.Diagnosis.AddAsync(diagnosis);
            return diagnosis;
        }

        public async Task<bool> DeleteAsync(Diagnosis diagnosis)
        {
            _context.Diagnosis.Remove(diagnosis);
            return true;

        }

    }
}
