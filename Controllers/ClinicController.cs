using ClinicAPI.DTOs.Clinic;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ClinicAPI.Controllers
{

    public class ClinicController : BaseApiController
    {

        private readonly IClinicService _clinicService;
        public ClinicController(IClinicService clinicService)
        {
            _clinicService = clinicService;
        }

        // APIs
        [HttpGet]
        public async Task<IActionResult> GetClinics()
        {
            var clinics = await _clinicService.GetAllAsync();
            return SuccessResponse(clinics, "Clinics fetched");
        }


        [HttpGet(("{id}"), Name = "GetClinicById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var clinic = await _clinicService.GetByIdAsync(id);
            if (clinic == null) return ErrorResponse("Clinic not found", 404);
            return SuccessResponse(clinic, "Clinic fetched");

        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(ClinicCreateDTO dto)
        {
            var addedClinic = await _clinicService.AddAsync(dto);

            return SuccessResponse(addedClinic, "Clinic Added", 201);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ClinicUpdateDTO clinicDTO)
        {
            var clinic = await _clinicService.UpdateAsync(id, clinicDTO);
            if (!clinic) return ErrorResponse("Clinic not found", 404);
            return NoContentResponse();

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var clinic = await _clinicService.DeleteAsync(id);
            if (!clinic) return ErrorResponse("Clinic not found", 404);
            return NoContentResponse();

        }


    }
}
