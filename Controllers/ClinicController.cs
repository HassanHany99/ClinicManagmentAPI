using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Clinic;
using Microsoft.AspNetCore.Mvc;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ClinicDbContext _context;
        public ClinicController(ClinicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // APIs
        [HttpGet]
        public ActionResult<List<ClinicReadDTO>> GetClinics()
        {
            var clinics = _mapper.Map<List<ClinicReadDTO>>(_context.Clinics.Include(c=>c.Doctors).
                AsNoTracking().ToList());
            return Ok(clinics);

        }
        [HttpGet("{id}")]
        public ActionResult<ClinicReadDTO> GetById(int id) {

            var clinic = _context.Clinics.
                Include(c => c.Doctors)
                .FirstOrDefault(x => x.Id == id);
            if (clinic == null)
            {
                return NotFound();
            }
            var dto =_mapper.Map<ClinicReadDTO>(clinic);
             return Ok(dto);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateClinic( int id, ClinicUpdateDTO clinicDTO)
        {
            var UpClinic = _context.Clinics.FirstOrDefault(x => x.Id == id);
            if (UpClinic == null)
            {
                return NotFound();
            }
            _mapper.Map(clinicDTO,UpClinic);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpPost]
        public ActionResult CreateClinic(ClinicCreateDTO dto)
        {
            var clinic = _mapper.Map<Clinic>(dto);
            _context.Clinics.Add(clinic);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = clinic.Id },clinic);

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteClinic(int id) { 
        
            var clinic = _context.Clinics.FirstOrDefault( x => x.Id == id);
            if (clinic == null)
            {
                return NotFound();
            }
            _context.Clinics.Remove(clinic);
            _context.SaveChanges();
            return NoContent();
        
    
        }

    }
}
