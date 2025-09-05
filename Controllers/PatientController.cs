using ClinicAPI.DTOs.Patient;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAPI.Controllers
{

    public class PatientController : BaseApiController
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var patients = await _patientService.GetAllAsync();
            return SuccessResponse(patients, "Patients fetched");
        }

        [HttpGet(("{id}"), Name = "GetPatientByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null) return ErrorResponse("Patient not found", 404);

            return SuccessResponse(patient, "Patient fetched");
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(PatientCreateDTO dto)
        {
            var patient = await _patientService.AddAsync(dto);

            if (patient is null) return ErrorResponse("Invalid Doctor ID", 400);

            return SuccessResponse(patient, "Patient added", 201);


        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(PatientUpdateDTO dto)
        {
            var patient = await _patientService.UpdateAsync(dto);

            if (!patient)
            {
                return ErrorResponse("Invalid Doctor or Patient IDs", 400);
            }

            return NoContentResponse();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var patient = await _patientService.DeleteAsync(id);

            if (!patient) return ErrorResponse("Patient not found", 404);

            return NoContentResponse();

        }


    }
}

