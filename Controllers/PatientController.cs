using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Patient;
using ClinicAPI.Models;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<List<PatientReadDTO>> GetAllPatients()
        {
           return Ok(_patientService.GetPatients());
        }
       
        [HttpGet("{id}")]
        public ActionResult GetPatientById(int id)
        {
            var patient = _patientService.GetPatientById(id);

            if (patient == null) return NotFound();

            return Ok(patient);
        }
        [HttpPost]
        public ActionResult AddPatient(PatientCreateDTO record)
        {
            var patient = _patientService.AddPatient(record);

            if (patient == null) return BadRequest("Invalid Doctor ID");

            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);

        }

        [HttpPut]
        public ActionResult UpdatePatient( PatientUpdateDTO dto)
        {
            var patient = _patientService.UpdatePatient(dto);
            if (!patient) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id) 
        { 
            var patient = _patientService.DeletePatient(id);
            
            if (!patient) return NotFound();

            return NoContent();
        }

    }
}
