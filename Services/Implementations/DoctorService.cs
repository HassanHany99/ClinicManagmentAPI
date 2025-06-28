using AutoMapper;
using ClinicAPI.DTOs.Doctor;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using ClinicAPI.Services.Interfaces;

namespace ClinicAPI.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<DoctorReadDTO>> GetAllAsync()
        {

            var doctors = await _unitOfWork.Doctors.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorReadDTO>>(doctors);
        }

        public async Task<DoctorReadDTO?> GetByIdAsync(int id)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor is null) return null;
            return _mapper.Map<DoctorReadDTO>(doctor);
        }

        public async Task<DoctorReadDTO?> AddAsync(DoctorCreateDTO dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            var cratedDoctor = await _unitOfWork.Doctors.AddAsync(doctor);

            if (cratedDoctor is null) return null;

            await _unitOfWork.CompleteAsync();
            return _mapper.Map<DoctorReadDTO>(cratedDoctor);

        }

        public async Task<bool> UpdateAsync(int id, DoctorUpdateDTO dto)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);

            if (doctor is null) return false;

            _mapper.Map(dto, doctor);

            await _unitOfWork.CompleteAsync();
            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctorDeleted = await _unitOfWork.Doctors.DeleteAsync(id);
            if (!doctorDeleted) return false;
            await _unitOfWork.CompleteAsync();
            return true;

        }

    }
}
