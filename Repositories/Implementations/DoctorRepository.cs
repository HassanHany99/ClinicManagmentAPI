using ClinicAPI.Data;
using ClinicAPI.Models;
using ClinicAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories.Implementations
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicDbContext _context;

        public DoctorRepository(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            var doctors = await _context.Doctors
                .AsNoTracking()
                .ToListAsync();
            return doctors;

        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor?> AddAsync(Doctor doctor)
        {
            var clinicExist = await _context.Clinics.AnyAsync(x => x.Id == doctor.ClinicId);
            if (!clinicExist) return null;
            await _context.Doctors.AddAsync(doctor);
            return doctor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            if (doctor is null) return false;
            _context.Doctors.Remove(doctor);
            return true;
        }


    }
}
