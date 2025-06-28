using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Patient;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using ClinicAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ClinicDbContext _context;

        public PatientService(IMapper mapper, ClinicDbContext context , IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = context;
          
        }

        public async Task<IEnumerable<PatientReadDTO>> GetAllAsync()
        {
            var patients = await _unitOfWork.Patients.GetAllAsync();
            
            return _mapper.Map<IEnumerable<PatientReadDTO>>(patients);
        }

        public async Task<PatientReadDTO?> GetByIdAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null) return null;

          return  _mapper.Map<PatientReadDTO>(patient);

        }

        public async Task<PatientReadDTO?> AddAsync(PatientCreateDTO dto)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(dto.DoctorId);
            if (doctor is null) return null;

            var patient = _mapper.Map<Patient>(dto);

          var addedPatient =  await _unitOfWork.Patients.AddAsync(patient);
           await _unitOfWork.CompleteAsync();

            var mapped = await _context.Patients
                .AsNoTracking()
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(x => x.Id == addedPatient.Id);
            var readPatient = _mapper.Map<PatientReadDTO>(mapped);

            return readPatient;
            
        }

        public async Task<bool> UpdateAsync(PatientUpdateDTO dto)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(dto.Id);
            if (patient == null) return false;

            var doctor = await _unitOfWork.Doctors.GetByIdAsync(dto.DoctorId);
            if (doctor is null) return false;
 
            _mapper.Map(dto, patient);
            await _unitOfWork.CompleteAsync();

            return true;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patientDeleted = await _unitOfWork.Patients.DeleteAsync(id);

            if ( !patientDeleted ) return false;

           await _unitOfWork.CompleteAsync();
            
            return true;

        }

    }
}
