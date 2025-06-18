using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Diagnosis;
using ClinicAPI.Models;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Services.Implementations
{
    public class DiagnosisService : IDiagnosisService

    {
        private readonly IMapper _mapper;
        private readonly ClinicDbContext _context;

        public DiagnosisService(IMapper mapper, ClinicDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<ReadDiagnosisDTO> GetAllDiagnoses()
        {
            var diagnosises= _context.Diagnosis
                .AsNoTracking()
                .Include(d => d.Appointment.Doctor)
                .Include(p => p.Appointment.Patient)
                .Include(a => a.Appointment)
                .ToList();

            var diagnosisesRead = _mapper.Map<List<ReadDiagnosisDTO>>(diagnosises);

            return diagnosisesRead;
        }

        public ReadDiagnosisDTO? GetDiagnosisById(int id)
        { 
            var diagnosis = _context.Diagnosis.FirstOrDefault(d => d.Id == id);

            if (diagnosis == null) return null;

            var diagnosisRead = _mapper.Map<ReadDiagnosisDTO>(
                 _context.Diagnosis
                .AsNoTracking()
                .Include(d => d.Appointment.Doctor)
                .Include(p => p.Appointment.Patient)
                .Include(a => a.Appointment)
                .FirstOrDefault(x => x.Id == id));

            return diagnosisRead;
        }

        public ReadDiagnosisDTO? AddDiagnosis(CreateDiagnosisDTO diagnosisDTO)
        {
            var isAPPExist = _context.Appointments.Include(a=>a.Diagnosis).FirstOrDefault(x => x.Id == diagnosisDTO.AppointmentId);
            if (isAPPExist == null) return null;

            if (isAPPExist.Diagnosis != null && isAPPExist.Diagnosis.Description != null)
            {
                return null;
            }
            var diagnosis = _mapper.Map<Diagnosis>(diagnosisDTO);

            _context.Diagnosis.Add(diagnosis);
            _context.SaveChanges();
            
            var diagnosisRead=_mapper.Map<ReadDiagnosisDTO>(_context.Diagnosis
                .AsNoTracking()
                .Include(d => d.Appointment.Doctor)
                .Include(p => p.Appointment.Patient)
                .Include(a => a.Appointment)
                .FirstOrDefault(x => x.Id == diagnosis.Id));
            return diagnosisRead;

        }
        public bool UpdateDiagnosis(int id, UpdateDiagnosisDTO dto)
        {
            var diagnosisExist = _context.Diagnosis.FirstOrDefault(x => x.Id == id);
            if (diagnosisExist == null) return false;

            _mapper.Map(dto, diagnosisExist);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteDiagnosis(int id)
        {
            var diagnosisExist = _context.Diagnosis.FirstOrDefault(x => x.Id == id);
            if (diagnosisExist == null) return false;

            _context.Diagnosis.Remove(diagnosisExist);
            _context.SaveChanges();  
            return true;

        }

    }
}
