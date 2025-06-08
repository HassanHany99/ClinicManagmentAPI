using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Diagnosis;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController  : ControllerBase 
    {
        private readonly IMapper _mapper;
        private readonly ClinicDbContext _context; 
        public DiagnosisController(IMapper mapper , ClinicDbContext context) {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public ActionResult AddDiagnosis(CreateDiagnosisDTO diagnosisDTO)
        {
           
            var appExists = _context.Appointments.Any(a => a.Id == diagnosisDTO.AppointmentId);
            if (!appExists) 
            { 
                return BadRequest("Invalid Appointment ID");
            }

            var addition = _mapper.Map<Diagnosis>(diagnosisDTO);
            _context.Diagnosis.Add(addition);
            _context.SaveChanges();


            var diagnosis = _context.Diagnosis.Include(d => d.Appointment.Doctor)
             .Include(p => p.Appointment.Patient)
             .Include(a => a.Appointment).FirstOrDefault(x => x.Id == addition.Id);
           var dto = _mapper.Map<ReadDiagnosisDTO>(diagnosis);
            return CreatedAtAction(nameof(GetDiagnosisById),new {id = diagnosis.Id},dto);

        }
        [HttpGet]
        public ActionResult<List<ReadDiagnosisDTO>> GetAllDiagnosis()
        {
            var diagnosis=_context.Diagnosis
                .Include(d => d.Appointment.Doctor)
                .Include(p => p.Appointment.Patient)
                .Include(a => a.Appointment)
                .AsNoTracking()
                .ToList();
            var dtoS = _mapper.Map<List<ReadDiagnosisDTO>>(diagnosis);
            return Ok(dtoS);
        }
        [HttpGet("{id}")]

        public ActionResult GetDiagnosisById(int id)
        {
            var diagnosis = _context.Diagnosis
              .Include(d => d.Appointment.Doctor)
              .Include(p => p.Appointment.Patient)
              .Include(a => a.Appointment)
              .AsNoTracking()
              .FirstOrDefault(x => x.Id == id);
            
            if (diagnosis == null) return NotFound();

            var dtoS = _mapper.Map<ReadDiagnosisDTO>(diagnosis);
            return Ok(dtoS);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDiagnosis(int id ,UpdateDiagnosisDTO dto )
        {
            if (dto == null) return BadRequest("Invalid data");
            var diagnosis = _context.Diagnosis.FirstOrDefault(x => x.Id ==id);
            if (diagnosis == null) return NotFound();
            diagnosis.Description = dto.Description;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDiagnosis(int id)
        {
            var diagnosis = _context.Diagnosis.FirstOrDefault(x => x.Id == id);
            if(diagnosis == null) return NotFound();
            _context.Diagnosis.Remove(diagnosis);
            _context.SaveChanges();
            return NoContent();


        }


    }
}
