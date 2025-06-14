using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Clinic;
using ClinicAPI.Models;
using ClinicAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI.Services.Implementations
{
    public class ClinicService : IClinicService
    {
       private readonly IMapper _mapper;
       private readonly ClinicDbContext _context;

       public ClinicService(IMapper mapper , ClinicDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<ClinicReadDTO> GetClinics()
        {
            var clinics = _context.Clinics
                .AsNoTracking()
                .Include(c => c.Doctors).ToList();
            
            return _mapper.Map<List<ClinicReadDTO>>(clinics);

        }

        public ClinicReadDTO? GetClinicById(int id)
        {
            var existClinic = _context.Clinics
                .AsNoTracking().Include( c => c.Doctors)
                .FirstOrDefault(c => c.Id == id);

             if (existClinic == null) return null;

            return _mapper.Map<ClinicReadDTO>(existClinic);
        }
        public ClinicReadDTO CreateClinic (ClinicCreateDTO dto)
        {
            var clinic =_mapper.Map<Clinic>(dto);

            _context.Clinics.Add(clinic);
            _context.SaveChanges();

            return _mapper.Map<ClinicReadDTO>(clinic);
        }

       public bool UpdateClinic(int id, ClinicUpdateDTO dto)
        {
            var existClinic=_context.Clinics.FirstOrDefault(c => c.Id == id);

            if(existClinic == null) return false;

            _mapper.Map(dto,existClinic);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteClinic(int id)
        {
            var existClinic = _context.Clinics.FirstOrDefault(c => c.Id == id);

            if ( existClinic == null) return false;

            _context.Clinics.Remove(existClinic);
            _context.SaveChanges();

            return true ;

        }

    }
}
