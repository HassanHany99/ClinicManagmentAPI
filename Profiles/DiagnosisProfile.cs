using AutoMapper;
using ClinicAPI.Models;
using ClinicAPI.DTOs;
using ClinicAPI.DTOs.Diagnosis;

namespace ClinicAPI.Profiles
{
    public class DiagnosisProfile : Profile
    {
        public DiagnosisProfile()
        {
            CreateMap<CreateDiagnosisDTO, Diagnosis>();
            CreateMap<Diagnosis, ReadDiagnosisDTO>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(a => a.Appointment.Doctor.Name))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(a => a.Appointment.Patient.Name))
                .ForMember(dest => dest.AppointmentDate , opt => opt.MapFrom(a => a.Appointment.AppointmentDate));
            CreateMap<UpdateDiagnosisDTO, Diagnosis>();




        }
    }
}
