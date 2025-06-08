using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Appointment;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ClinicDbContext _context;

        public AppointmentController(IMapper mapper, ClinicDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<AppointmentReadDTO>> GetAppointments() {

            var dto = _mapper.Map<List<AppointmentReadDTO>>
                (_context.Appointments.Include(a => a.Doctor)
                .Include(a => a.Patient).Include(a => a.Diagnosis).ToList());
            return Ok(dto);
        }
        [HttpGet("{id:int}")]
        public ActionResult GetAppointmentById(int id) {
            var app = _context.Appointments.Include( a => a.Doctor)
                .Include( a=> a.Patient).Include (a=> a.Diagnosis)
                .FirstOrDefault( x => x.Id == id);
            if (app == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<AppointmentReadDTO>(app);
            return Ok(dto);
        }
        [HttpPost]
        public ActionResult CrateAppointment(AppointmentCreateDTO dto) {

            bool patientExists = _context.Patients.Any(p => p.Id == dto.PatientId);
            if (!patientExists)
            {
                return BadRequest("Invalid Patient");
            }
            bool doctorExists = _context.Doctors.Any(d => d.Id == dto.DoctorId);
            if (!doctorExists)
            {
                return BadRequest("Invalid Doctor");
            }
            var app = _mapper.Map<Appointment>(dto);
            _context.Appointments.Add(app);
            _context.SaveChanges();

            var Rdto = _context.Appointments
                 .Include(a => a.Doctor)
                 .Include(a => a.Patient)
                 .Include(a => a.Diagnosis)
                 .FirstOrDefault(x => x.Id == app.Id); ;
            var readDto = _mapper.Map<AppointmentReadDTO>(Rdto);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = app.Id }, readDto);

        }

        [HttpPut]
        public ActionResult UpdateAppointment(AppointmentUpdateDTO dto ) {

            var app = _context.Appointments.FirstOrDefault(a => a.Id == dto.Id);
            if (app == null) 
            {
                return NotFound("Appiontment Not Found");
            }
            _mapper.Map(dto, app);
            _context.SaveChanges();
            return Ok(); 
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);

            if (appointment == null) 
            {
                return NotFound();
            }
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return NoContent();

        }

}
}
