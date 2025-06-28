using ClinicAPI.Repositories.Interfaces;

namespace ClinicAPI.Repositories
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients {  get; }
        Task<int> CompleteAsync();
    }
}
