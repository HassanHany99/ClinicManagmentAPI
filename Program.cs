using System.Text.Json.Serialization;
using ClinicAPI.Data;
using ClinicAPI.Filters;
using ClinicAPI.Middleware;
using ClinicAPI.Repositories;
using ClinicAPI.Services.Implementations;
using ClinicAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers + Filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAttribute>();
})

.AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});



// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Connect with DbContext.
builder.Services.AddDbContext<ClinicDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));


// Services
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDiagnosisService, DiagnosisService>();

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Exception Handling Middleware
app.UseMiddleware<ExceptionMiddleware>();

// Dev tools
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
