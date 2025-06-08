using AutoMapper;
using ClinicAPI.Models;
using ClinicAPI.DTOs;
using ClinicAPI.DTOs.Appointment;

namespace ClinicAPI.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile() {

            CreateMap<Appointment, AppointmentReadDTO>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name))
                .ForMember(dest => dest.DiagnosisDescription , opt => opt.MapFrom(src => src.Diagnosis.Description))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name));

            CreateMap<AppointmentCreateDTO, Appointment>()
                .ForMember( dest => dest.Id , opt => opt.Ignore());
               
            CreateMap<AppointmentUpdateDTO, Appointment>();
        }
    }
}
