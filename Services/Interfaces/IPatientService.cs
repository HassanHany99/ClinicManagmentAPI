using ClinicAPI.DTOs.Clinic;
using ClinicAPI.DTOs.Doctor;
using ClinicAPI.DTOs.Patient;

namespace ClinicAPI.Services.Interfaces
{
    public interface IPatientService
    {
        List<PatientReadDTO> GetPatients();
        PatientReadDTO? GetPatientById(int id);
        PatientReadDTO? AddPatient(PatientCreateDTO patient);
        bool UpdatePatient(PatientUpdateDTO patientDTO);
        bool DeletePatient(int id);



    }
}
