using AutoMapper;
using ClinicAPI.DTOs.Appointment;
using ClinicAPI.Models;
using ClinicAPI.Repositories;
using ClinicAPI.Services.Interfaces;

namespace ClinicAPI.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;

            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<AppointmentReadDTO>> GetAllAsync()
        {
            var appoinments = await _unitOfWork.Appointments.GetAllAsync();

            return _mapper.Map<IEnumerable<AppointmentReadDTO>>(appoinments);

        }

        public async Task<AppointmentReadDTO?> GetByIdAsync(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);

            if (appointment == null) return null;

            return _mapper.Map<AppointmentReadDTO>(appointment);



        }

        public async Task<AppointmentReadDTO?> AddAsync(AppointmentCreateDTO dto)
        {
            var patientExist = await _unitOfWork.Patients.GetByIdAsync(dto.PatientId);
            if (patientExist is null)
            {
                return null;
            }

            var doctorExist = await _unitOfWork.Doctors.GetByIdAsync(dto.DoctorId);
            if (doctorExist is null)
            {
                return null;
            }
            var appointment = _mapper.Map<Appointment>(dto);

            var appAdded = await _unitOfWork.Appointments.AddAsync(appointment);

            await _unitOfWork.CompleteAsync();

            var fullApp = await _unitOfWork.Appointments.GetByIdAsync(appointment.Id);


            var appRead = _mapper.Map<AppointmentReadDTO>(fullApp);
            return appRead;
        }

        public async Task<bool> UpdateAsync(int id, AppointmentUpdateDTO dto)
        {
            var appointmentExist = await _unitOfWork.Appointments.GetByIdAsync(id);

            if (appointmentExist == null) return false;

            appointmentExist.AppointmentDate = dto.AppointmentDate;
            // Or using :   _mapper.Map(dto, appointmentExist);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);

            if (appointment == null) return false;

            await _unitOfWork.Appointments.DeleteAsync(appointment);
            await _unitOfWork.CompleteAsync();
            return true;


        }

    }
}