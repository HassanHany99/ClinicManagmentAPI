using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Clinic;
using Microsoft.AspNetCore.Mvc;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ClinicAPI.Services.Interfaces;


namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
       
        private readonly IClinicService _clinicService;
        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }
        // APIs
        [HttpGet]
        public ActionResult<List<ClinicReadDTO>> GetClinics()
        {
            return Ok(_clinicService.GetClinics());
        }


        [HttpGet("{id}")]
        public ActionResult<ClinicReadDTO> GetClinicById(int id) {
            var existClinic = _clinicService.GetClinicById(id);
            if (existClinic == null) return NotFound();
            return Ok(existClinic);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClinic( int id, ClinicUpdateDTO clinicDTO)
        {
            var clinic = _clinicService.UpdateClinic(id, clinicDTO);
            if (!clinic) return NotFound();
            return NoContent();
 
        }

        [HttpPost]
        public ActionResult CreateClinic(ClinicCreateDTO dto)
        {
            var clinic = _clinicService.CreateClinic(dto);
            return CreatedAtAction(nameof(GetClinicById), new { id = clinic.Id },clinic);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClinic(int id) 
        { 
            var clinic = _clinicService.DeleteClinic(id);
            if (!clinic) return NotFound();
            return NoContent();
        }

    }
}
