using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Diagnosis;
using ClinicAPI.Models;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisController  : ControllerBase 
    {
        private readonly IDiagnosisService _diagnosisService;
        public DiagnosisController( IDiagnosisService diagnosisService) 
        {
            _diagnosisService = diagnosisService;
        }

        [HttpGet]
        public ActionResult<List<ReadDiagnosisDTO>> GetAllDiagnoses()
        {
            var diagnosises = _diagnosisService.GetAllDiagnoses();
            return Ok(diagnosises);
        }
        [HttpGet("{id}")]
        public ActionResult GetDiagnosisById(int id)
        {
            var diagnosis = _diagnosisService.GetDiagnosisById(id);

            if (diagnosis == null) return NotFound();

            return Ok(diagnosis);

        }

        [HttpPost]
        public ActionResult AddDiagnosis(CreateDiagnosisDTO diagnosisDTO)
        {
            var diagnosis = _diagnosisService.AddDiagnosis(diagnosisDTO);
            if (diagnosis == null)
            { 
                return BadRequest("Invalid Appointment Id Or duplicated Description");
              }
            return CreatedAtAction(nameof(GetDiagnosisById),new {id = diagnosis.Id},diagnosis);
    
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateDiagnosis(int id ,UpdateDiagnosisDTO dto )
        {
            var diagnosis = _diagnosisService.UpdateDiagnosis(id,dto);

            if (!diagnosis) return NotFound();

            return NoContent();
          
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDiagnosis(int id)
        {
            var diagnosis = _diagnosisService.DeleteDiagnosis(id);
            if (!diagnosis) return NotFound();
            return NoContent();

        }


    }
}
