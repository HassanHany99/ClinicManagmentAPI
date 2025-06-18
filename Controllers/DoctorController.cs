using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Doctor;
using ClinicAPI.Models;
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
        public ActionResult<List<DoctorReadDTO>> GetAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            return Ok(doctors);
        }


        [HttpGet("{id}")]
        public ActionResult GetDoctorById(int id)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if ( doctor == null)return NotFound();
            return Ok(doctor);
          
           
        }
        [HttpPost]
        public ActionResult CreateDoctor(DoctorCreateDTO dto)
        {  
            var created = _doctorService.CreateDoctor(dto);
            return  CreatedAtAction( nameof(GetDoctorById), new {id = created.Id} 
                , created);  
        }



        [HttpPut("{id}")]
        public ActionResult UpdateDoctor(int id , DoctorUpdateDTO dto)
        {
            var updatedDoctor = _doctorService.UpdateDoctor(id, dto);
            if (updatedDoctor) return NoContent();
            return BadRequest("Invalid Doctor Id"); 
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(int id) {
            
            var IsDeleted =_doctorService.DeleteDoctor(id);
            if(IsDeleted) return NoContent();
            return NotFound();

        }

    }
    }

