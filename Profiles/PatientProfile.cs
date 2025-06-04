using AutoMapper;
using ClinicAPI.DTOs.Patient;
using ClinicAPI.Models;

namespace ClinicAPI.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile() {
            CreateMap<Patient, PatientReadDTO>()
                .ForMember(dest => dest.DoctorName,opt => opt.MapFrom(src => src.Doctor.Name));
            CreateMap<PatientUpdateDTO, Patient>();
            CreateMap<PatientCreateDTO, Patient>();

        }
    }
}
