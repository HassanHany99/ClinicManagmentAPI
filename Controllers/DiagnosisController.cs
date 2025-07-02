using ClinicAPI.DTOs.Diagnosis;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly IDiagnosisService _diagnosisService;
        public DiagnosisController(IDiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadDiagnosisDTO>>> GetAllAsync()
        {
            var diagnosises = await _diagnosisService.GetAllAsync();
            return Ok(diagnosises);

        }


        [HttpGet(("{id}"), Name = "GetDiagnosisById")]
        public async Task<ActionResult<ReadDiagnosisDTO>> GetByIdAsync(int id)
        {
            var diagnosis = await _diagnosisService.GetByIdAsync(id);

            if (diagnosis == null) return NotFound();

            return Ok(diagnosis);
        }


        [HttpPost]
        public async Task<ActionResult<ReadDiagnosisDTO>> AddAsync(CreateDiagnosisDTO dto)
        {
            var diagnosis = await _diagnosisService.AddAsync(dto);
            if (diagnosis == null)
            {
                return BadRequest("Invalid Appointment Id Or duplicated Description");
            }
            return CreatedAtRoute("GetDiagnosisById", new { id = diagnosis.Id }, diagnosis);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, UpdateDiagnosisDTO dto)
        {
            var diagnosis = await _diagnosisService.UpdateAsync(id, dto);

            if ( !diagnosis ) return NotFound();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var diagnosis = await _diagnosisService.DeleteAsync(id);
            if (!diagnosis) return NotFound();
            return NoContent();

        }


    }
}
