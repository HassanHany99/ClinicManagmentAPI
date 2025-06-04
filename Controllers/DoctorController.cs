using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Doctor;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ClinicDbContext _context;

        public DoctorController(ClinicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<DoctorReadDTO>> GetDoctors()
        {
            var doctors = _context.Doctors.ToList();
            var doctorsDTO = _mapper.Map<List<DoctorReadDTO>>(doctors);
            return Ok(doctorsDTO);

        }
        [HttpGet("{id}")]
        public ActionResult GetDoctorById(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null) return NotFound();
            else
            {
                var dto = _mapper.Map<DoctorReadDTO>(doctor);
                return Ok(dto);
            }
        }
        [HttpPost]
        public ActionResult CreateDoctor(DoctorCreateDTO dto)
        {                                

            var doctor = _mapper.Map<Doctor>(dto);
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDoctorById),new {id= doctor.Id},_mapper.Map<DoctorReadDTO>(doctor));
        }
        [HttpPut("{id}")]
        public ActionResult UpdateDoctor(int id , DoctorUpdateDTO dto)
        {
              var doctor = _context.Doctors.FirstOrDefault(x => x.Id == id);
            if (doctor == null) 
            { 
                return NotFound();
            }
                _mapper.Map(dto,doctor);
                _context.SaveChanges();
                return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(int id) {
            var doctor = _context.Doctors.FirstOrDefault(x => x.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            _context.Doctors.Remove(doctor); 
            _context.SaveChanges();
            return NoContent();
        
        }

    }
    }

