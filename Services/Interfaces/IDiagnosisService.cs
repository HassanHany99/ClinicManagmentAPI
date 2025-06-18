using ClinicAPI.DTOs.Appointment;
using Microsoft.AspNetCore.Mvc;
using ClinicAPI.DTOs;
using ClinicAPI.DTOs.Diagnosis;

namespace ClinicAPI.Services.Interfaces
{
    public interface IDiagnosisService
    {
       List<ReadDiagnosisDTO> GetAllDiagnoses();
        ReadDiagnosisDTO? GetDiagnosisById(int id);
        ReadDiagnosisDTO AddDiagnosis(CreateDiagnosisDTO diagnosisDTO);
        bool UpdateDiagnosis(int id, UpdateDiagnosisDTO dto);
        bool DeleteDiagnosis(int id);

    }
}
