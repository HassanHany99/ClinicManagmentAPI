using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Patient;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ClinicDbContext _context;
        public PatientController(IMapper mapper, ClinicDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllPatients()
        {
            var dto = _mapper.Map<List<PatientReadDTO>>(_context.Patients.Include(p=> p.Doctor));

            return Ok(dto);

        }
        [HttpPost()]
        public ActionResult AddPatient(PatientCreateDTO record)
        {
         var patient = _mapper.Map<Patient>(record);
            _context.Patients.Add(patient);
            _context.SaveChanges();
            var dto = _mapper.Map<PatientReadDTO>(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, dto);

        }
        [HttpGet("{id}")]
        public ActionResult GetPatientById(int id) { 
        var patient = _context.Patients.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<PatientReadDTO>(_context.Patients
                .Include
                (p => p.Doctor).FirstOrDefault(x => x.Id == id));
             return Ok(dto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePatient(int id, PatientUpdateDTO dto) {
           var patient = _context.Patients.FirstOrDefault(x => x.Id == id);
            if (patient == null) 
            { 
                return NotFound();
            }
            _mapper.Map(dto, patient);
            _context.SaveChanges();
            return NoContent();    
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id) { 
        var patient = _context.Patients.FirstOrDefault(x => x.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return NoContent();
        
        }



    }
}
