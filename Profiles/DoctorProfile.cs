using AutoMapper;
using ClinicAPI.Models;
using ClinicAPI.DTOs;
using ClinicAPI.DTOs.Doctor;

namespace ClinicAPI.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile() {
            CreateMap<Doctor, DoctorReadDTO>();
            CreateMap<DoctorCreateDTO, Doctor>();
            CreateMap<DoctorUpdateDTO, Doctor>();
        }
    }
}
