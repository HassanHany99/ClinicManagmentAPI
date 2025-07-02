using System.Text.Json.Serialization;
using ClinicAPI.Data;
using ClinicAPI.Repositories;
using ClinicAPI.Repositories.Implementations;
using ClinicAPI.Repositories.Interfaces;
using ClinicAPI.Services.Implementations;
using ClinicAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ClinicAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers()
                  .AddJsonOptions(x =>
                {
                       x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Connect with DbContext.
            builder.Services.AddDbContext<ClinicDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            //SERVICES
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IClinicService, ClinicService>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IDiagnosisService, DiagnosisService>();
            // REPOs
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IClinicRepository,ClinicRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();

            //Mapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //-------------------------------------------------------------
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
    }
}
