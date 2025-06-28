using ClinicAPI.DTOs.Patient;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientReadDTO>>> GetAllAsync()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet(("{id}"), Name = "GetPatientByIdAsync")]
        public async Task<ActionResult<PatientReadDTO>> GetByIdAsync(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null) return NotFound();

            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<PatientReadDTO>> AddAsync(PatientCreateDTO dto)
        {
            var patient = await _patientService.AddAsync(dto);

            if (patient is null) return BadRequest("Invalid Doctor ID");

            return
             CreatedAtRoute("GetPatientByIdAsync", new { id = patient.Id }, patient);

        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(PatientUpdateDTO dto)
        {
            var patient = await _patientService.UpdateAsync(dto);

            if (!patient)
            {
                return BadRequest("Invalid Doctor or Patient IDs");
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var patient = await _patientService.DeleteAsync(id);

            if (!patient) return NotFound();

            return NoContent();

        }


    }
}

