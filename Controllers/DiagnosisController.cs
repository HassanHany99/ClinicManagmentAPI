using ClinicAPI.DTOs.Diagnosis;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{

    public class DiagnosisController : BaseApiController
    {
        private readonly IDiagnosisService _diagnosisService;
        public DiagnosisController(IDiagnosisService diagnosisService)
        {
            _diagnosisService = diagnosisService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var diagnosises = await _diagnosisService.GetAllAsync();
            return SuccessResponse(diagnosises, "Diagnosises fetched ", 200);

        }


        [HttpGet(("{id}"), Name = "GetDiagnosisById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var diagnosis = await _diagnosisService.GetByIdAsync(id);

            if (diagnosis == null) return ErrorResponse("Diagnosis not found", 404);

            return SuccessResponse(diagnosis, "Diagnosis fetched ", 200);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateDiagnosisDTO dto)
        {
            var diagnosis = await _diagnosisService.AddAsync(dto);
            if (diagnosis == null)
            {
                return ErrorResponse("Invalid Appointment Id Or duplicated Description", 400);
            }
            return SuccessResponse(diagnosis, "Diagnosis added", 201);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateDiagnosisDTO dto)
        {
            var diagnosis = await _diagnosisService.UpdateAsync(id, dto);

            if (!diagnosis) return ErrorResponse("Diagnosis not found", 404);

            return NoContentResponse();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var diagnosis = await _diagnosisService.DeleteAsync(id);
            if (!diagnosis) return ErrorResponse("Diagnosis not found", 404);
            return NoContentResponse();

        }


    }
}
