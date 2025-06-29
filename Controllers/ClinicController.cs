using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Clinic;
using Microsoft.AspNetCore.Mvc;
using ClinicAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ClinicAPI.Services.Interfaces;
using System.Threading.Tasks;


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
        public async Task<ActionResult<IEnumerable<ClinicReadDTO>>> GetClinics()
        {
            var clinics = await _clinicService.GetAllAsync();
            return Ok(clinics);
        }


        [HttpGet(("{id}"), Name = "GetClinicById")]
       public async Task<ActionResult<ClinicReadDTO>> GetByIdAsync(int id)
        {
            var clinic = await _clinicService.GetByIdAsync(id);
            if (clinic == null) return NotFound();
            return Ok(clinic);

        }


        [HttpPost]
        public async Task<ActionResult<ClinicReadDTO>> AddAsync(ClinicCreateDTO dto)
        {
            var addedClinic = await _clinicService.AddAsync(dto);

            return CreatedAtRoute("GetClinicById", new { id = addedClinic.Id }, addedClinic);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync( int id, ClinicUpdateDTO clinicDTO)
        {
            var clinic = await _clinicService.UpdateAsync(id, clinicDTO);
            if (!clinic) return NotFound();
            return NoContent();
 
        }

  
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)  
        { 
          var clinic = await _clinicService.DeleteAsync(id);
            if (!clinic) return NotFound();
            return NoContent();
    
        
        }
       

    }
}
