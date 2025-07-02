using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Diagnosis;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using ClinicAPI.Services.Interfaces;

namespace ClinicAPI.Services.Implementations
{
    public class DiagnosisService : IDiagnosisService

    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DiagnosisService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ReadDiagnosisDTO>> GetAllAsync()
        {
            var diagnosises = await _unitOfWork.Diagnosises.GetAllAsync();

            return _mapper.Map<IEnumerable<ReadDiagnosisDTO>>(diagnosises);

        }

        public async Task<ReadDiagnosisDTO?> GetByIdAsync(int id)
        {
            var diagnosis = await _unitOfWork.Diagnosises.GetByIdAsync(id);

            if (diagnosis is null) return null;

            return _mapper.Map<ReadDiagnosisDTO>(diagnosis);

        }


        public async Task<ReadDiagnosisDTO?> AddAsync(CreateDiagnosisDTO dto)
        {
            var appExists = await _unitOfWork.Appointments.GetByIdAsync(dto.AppointmentId);
            if (appExists == null) return null;

            if (appExists.Diagnosis != null && appExists.Diagnosis.Description != null)
            {
                return null;
            }
            var diagnosis = _mapper.Map<Diagnosis>(dto);
            await _unitOfWork.Diagnosises.AddAsync(diagnosis);
            await _unitOfWork.CompleteAsync();

            var readDiagnosis = await _unitOfWork.Diagnosises.GetByIdAsync(diagnosis.Id);

            var diagnosisRead = _mapper.Map<ReadDiagnosisDTO>(readDiagnosis);

            return diagnosisRead;

        }


        public async Task<bool> UpdateAsync(int id , UpdateDiagnosisDTO dto)
        {
            var diagnosis = await _unitOfWork.Diagnosises.GetByIdAsync(id);
            if (diagnosis == null) return false;

            _mapper.Map(dto, diagnosis);

            await _unitOfWork.CompleteAsync();
 
            return true;
        }

       public async Task<bool> DeleteAsync(int id)
        {
            var diagnosis = await _unitOfWork.Diagnosises.GetByIdAsync(id);

            if (diagnosis == null) return false;

            await _unitOfWork.Diagnosises.DeleteAsync(diagnosis);

            await _unitOfWork.CompleteAsync();

            return true;


        }

    }
}
