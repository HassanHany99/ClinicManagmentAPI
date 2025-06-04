using AutoMapper;
using ClinicAPI.DTOs.Clinic;
using ClinicAPI.Models;

namespace ClinicAPI.Profiles
{
    public class ClinicProfile : Profile
    {
        public ClinicProfile() {
            CreateMap<Clinic, ClinicReadDTO>();
            CreateMap<ClinicCreateDTO , Clinic>();
            CreateMap<ClinicUpdateDTO, Clinic>();
        }
    }
}
