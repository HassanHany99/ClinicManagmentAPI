using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Patient;
using ClinicAPI.Models;
using ClinicAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly ClinicDbContext _context;

        public PatientService(IMapper mapper, ClinicDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<PatientReadDTO> GetPatients()
        {
            var patients = _mapper.Map<List<PatientReadDTO>>(_context.Patients
                .AsNoTracking()
                .Include(p => p.Doctor).ToList());
            return patients;
        }

        public PatientReadDTO? GetPatientById(int id)
        {

            var patient = _context.Patients
                .AsNoTracking()
                .Include(p => p.Doctor)
                .FirstOrDefault(p => p.Id == id);

            if (patient == null) return null;

            var patientRead = _mapper.Map<PatientReadDTO>(patient);
            return patientRead;
        }

        public PatientReadDTO? AddPatient(PatientCreateDTO patientDTO)
        {
            var doctorExist = _context.Doctors.Any(x => x.Id == patientDTO.DoctorId);
            if (!doctorExist) return null;

            var patient = _mapper.Map<Patient>(patientDTO);
            _context.Patients.Add(patient);
            _context.SaveChanges();
            var readPatient =_mapper.Map<PatientReadDTO>(_context.Patients
                .AsNoTracking()
                .Include(p => p.Doctor)
                .FirstOrDefault(x => x.Id ==patient.Id));
            return  readPatient;
        }

        public bool UpdatePatient(PatientUpdateDTO patientDTO)
        {
            var doctorExist = _context.Doctors.Any(x => x.Id == patientDTO.DoctorId);
                if (!doctorExist) return false;
            var patientExist = _context.Patients.Any(x => x.Id == patientDTO.Id);
            if (!patientExist) return false;

            var patient = _mapper.Map<Patient>(patientDTO);

            _context.Patients.Update(patient);
            _context.SaveChanges();
            return true;

        }

        public bool DeletePatient(int id)
        {
            var patient = _context.Patients.FirstOrDefault(x=> x.Id == id);

            if (patient == null) return false;
            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return true;

        }

    }
}
