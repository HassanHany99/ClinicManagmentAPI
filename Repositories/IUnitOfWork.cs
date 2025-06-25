using ClinicAPI.Repositories.Interfaces;

namespace ClinicAPI.Repositories
{
    public interface IUnitOfWork
    {
        IDoctorRepository Doctors { get; }
        Task<int> CompleteAsync();
    }
}
