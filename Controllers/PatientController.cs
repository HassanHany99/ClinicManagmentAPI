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
        [HttpPost("{id}")]
        public ActionResult AddPatient(PatientCreateDTO record, int id)
        {
         var patient = _mapper.Map<Patient>(record);
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return Ok();

        }

    }
}
