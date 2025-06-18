using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Appointment;
using ClinicAPI.Models;
using ClinicAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly ClinicDbContext _context;
        public AppointmentService(IMapper mapper, ClinicDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<AppointmentReadDTO> GetAllAppointments()
        {
            var appsList = _context.Appointments.AsNoTracking()
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Diagnosis)
                .ToList();
            var appointmentsDTO = _mapper.Map<List<AppointmentReadDTO>>(appsList);

            return appointmentsDTO;
        }

        public AppointmentReadDTO? GetAppointmentById(int id)
        {
            var app = _context.Appointments
                .AsNoTracking()
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Diagnosis)
                .FirstOrDefault(x => x.Id == id);

            if (app == null) return null;

            var appointmentDTO = _mapper.Map<AppointmentReadDTO>(app);
            return appointmentDTO;
        }

        public AppointmentReadDTO? CreateAppointment(AppointmentCreateDTO dto)
        {
            bool patientExists = _context.Patients.Any(p => p.Id == dto.PatientId);
            if (!patientExists)
            {
                return null;
            }
            bool doctorExists = _context.Doctors.Any(d => d.Id == dto.DoctorId);
            if (!doctorExists)
            {
                return null;
            }
            var appointment = _mapper.Map<Appointment>(dto);

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            var appRead = _mapper.Map<AppointmentReadDTO>(_context.Appointments
                 .Include(a => a.Doctor)
                 .Include(a => a.Patient)
                 .Include(a => a.Diagnosis)
                 .FirstOrDefault(x => x.Id == appointment.Id));
            return appRead;
        }

        public bool UpdateAppointment( int id ,AppointmentUpdateDTO dto)
        {
            var appointmentExist = _context.Appointments.FirstOrDefault(x => x.Id == id);

            if (appointmentExist == null) return false;

            _mapper.Map(dto, appointmentExist);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteAppointment(int id)
        {
            var appointmentExist = _context.Appointments.FirstOrDefault(x => x.Id == id);

            if (appointmentExist == null) return false;

            _context.Appointments.Remove(appointmentExist);
            _context.SaveChanges();
            return true;
        }

    }
}