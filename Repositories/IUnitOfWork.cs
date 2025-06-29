using ClinicAPI.Repositories.Interfaces;

namespace ClinicAPI.Repositories
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients {  get; }
        IClinicRepository Clinics { get; }
        Task<int> CompleteAsync();
    }
}
