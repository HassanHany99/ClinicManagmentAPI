using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Doctor;
using ClinicAPI.Models;
using ClinicAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories.Implementations
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IMapper _mapper;
        private readonly ClinicDbContext _context;

        public DoctorRepository(IMapper mapper, ClinicDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            var doctors = await _context.Doctors
                .AsNoTracking()
                .ToListAsync();
            return doctors;

        }
    }
}
