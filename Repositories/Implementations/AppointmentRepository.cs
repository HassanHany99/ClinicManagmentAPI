using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.Models;
using ClinicAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Repositories.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicDbContext _context;

        public AppointmentRepository(ClinicDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            var appointments = await _context.Appointments
                .AsNoTracking()
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Diagnosis)
                .ToListAsync();

            return appointments;

        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Diagnosis)
                .FirstOrDefaultAsync(x=> x.Id == id);

            if (appointment is null) return null;

            return appointment;

        }

        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            return appointment;

        }

        public async Task<bool> DeleteAsync(Appointment appointment)
        {      
            _context.Appointments.Remove(appointment);
            return true;

        }


    }
}
