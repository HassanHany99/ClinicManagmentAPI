using ClinicAPI.Data;
using ClinicAPI.Models;
using ClinicAPI.Repositories.Implementations;
using ClinicAPI.Repositories.Interfaces;
using ClinicAPI.Repositories;
using ClinicAPI.Services.Implementations;
using ClinicAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ClinicAPI.Repositories;
namespace ClinicAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
                                                                                          
            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Connect with DbContext.
            builder.Services.AddDbContext<ClinicDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IClinicService, ClinicService>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IAppointmentService,AppointmentService>();
            builder.Services.AddScoped<IDiagnosisService, DiagnosisService>();

            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




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
