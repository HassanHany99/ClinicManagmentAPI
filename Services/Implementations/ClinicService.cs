using AutoMapper;
using ClinicAPI.DTOs.Clinic;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using ClinicAPI.Services.Interfaces;

namespace ClinicAPI.Services.Implementations
{
    public class ClinicService : IClinicService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClinicService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClinicReadDTO>> GetAllAsync()
        {
            var clinics = await _unitOfWork.Clinics.GetAllAsync();

            var result = _mapper.Map<IEnumerable<ClinicReadDTO>>(clinics);
            return result;



        }

        public async Task<ClinicReadDTO?> GetByIdAsync(int id)
        {
            var clinic = await _unitOfWork.Clinics.GetByIdAsync(id);

            if (clinic == null) return null;

            return _mapper.Map<ClinicReadDTO>(clinic);
        }

        public async Task<ClinicReadDTO?> AddAsync(ClinicCreateDTO dto)
        {
            var clinic = _mapper.Map<Clinic>(dto);

            await _unitOfWork.Clinics.AddAsync(clinic);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ClinicReadDTO>(clinic);
        }

        public async Task<bool> UpdateAsync(int id, ClinicUpdateDTO dto)
        {
            var existClinic = await _unitOfWork.Clinics.GetByIdAsync(id);
            if (existClinic == null) return false;

            _mapper.Map(dto, existClinic);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existClinic = await _unitOfWork.Clinics.GetByIdAsync(id);

            if (existClinic == null) return false;

            _unitOfWork.Clinics.Delete(existClinic);
            await _unitOfWork.CompleteAsync();

            return true;

        }

    }
}
