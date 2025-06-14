using AutoMapper;
using ClinicAPI.Data;
using ClinicAPI.DTOs.Doctor;
using ClinicAPI.Models;
using ClinicAPI.Services.Interfaces;

namespace ClinicAPI.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
       private readonly IMapper _mapper;
       private readonly ClinicDbContext _context;

       public DoctorService(IMapper mapper , ClinicDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public List<DoctorReadDTO> GetDoctors() {
            var doctors = _mapper.Map<List<DoctorReadDTO>>(_context.Doctors.ToList());
            return doctors;
        }

        public DoctorReadDTO? GetDoctorById(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null) return null;
            return _mapper.Map<DoctorReadDTO>(doctor);
            
        }

       public DoctorReadDTO CreateDoctor(DoctorCreateDTO dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            var doctorRead = _mapper.Map<DoctorReadDTO>(doctor);
            return doctorRead;
        }


       public bool UpdateDoctor(int Id, DoctorUpdateDTO dto)
        {
            var doctor = _context.Doctors.FirstOrDefault(x => x.Id == Id);
            if (doctor == null) return false;
            _mapper.Map(dto, doctor);
            _context.SaveChanges();
            return true;

        }
         public bool DeleteDoctor(int id)
        {
            var doctor =_context.Doctors.FirstOrDefault( x => x.Id == id);
            if (doctor == null) return false;
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return true;

        }

    }
}
