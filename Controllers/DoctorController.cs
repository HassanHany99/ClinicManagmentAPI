using ClinicAPI.DTOs.Doctor;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{
    [Authorize]

    public class DoctorController : BaseApiController
    {

        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var doctors = await _doctorService.GetAllAsync();
            return SuccessResponse(doctors, "Doctors fetched", 200);
        }


        [HttpGet("{id}", Name = "GetDoctorByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor is null) return ErrorResponse("Doctor not found", 404);
            return SuccessResponse(doctor, "Doctor fetched", 200);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DoctorCreateDTO dto)
        {
            var doctor = await _doctorService.AddAsync(dto);
            if (doctor is null) return ErrorResponse("Invalid clinic ID", 400);
            return SuccessResponse(doctor, "Doctor added", 201);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, DoctorUpdateDTO dto)
        {
            var updatedDoctor = await _doctorService.UpdateAsync(id, dto);
            if (updatedDoctor) return NoContentResponse();
            return ErrorResponse("Doctor not found", 404);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var IsDeleted = await _doctorService.DeleteAsync(id);
            if (IsDeleted) return NoContentResponse();
            return ErrorResponse("Doctor not found", 404);
        }

    }
}
