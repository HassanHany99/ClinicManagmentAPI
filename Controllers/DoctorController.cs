using ClinicAPI.DTOs.Doctor;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorReadDTO>>> GetAllAsync()
        {
            var doctors = await _doctorService.GetAllAsync();
            return Ok(doctors);
        }


        [HttpGet("{id}", Name = "GetDoctorByIdAsync")]
        public async Task<ActionResult<DoctorReadDTO>> GetByIdAsync(int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor is null) return NotFound();
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<DoctorReadDTO>> AddAsync(DoctorCreateDTO dto)
        {
            var doctor = await _doctorService.AddAsync(dto);
            if (doctor is null) return BadRequest("Invali clinic ID");
            return CreatedAtRoute("GetDoctorByIdAsync", new { id = doctor.Id }, doctor);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, DoctorUpdateDTO dto)
        {
            var updatedDoctor = await _doctorService.UpdateAsync(id, dto);
            if (updatedDoctor) return NoContent();
            return BadRequest("Invalid Doctor Id");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var IsDeleted = await _doctorService.DeleteAsync(id);
            if (IsDeleted) return NoContent();
            return NotFound();
        }

    }
}
