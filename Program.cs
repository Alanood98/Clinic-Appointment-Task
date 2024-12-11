using ClinicAppointmentApi;
using ClinicAppointmentApi.Repositories;
using ClinicAppointmentApi.Services;


using Microsoft.EntityFrameworkCore;


namespace ClinicAppointmentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Register repositories and services
            builder.Services.AddScoped<IPatientRepo, PatientRepo>();
            builder.Services.AddScoped<IPatientServices, PatientService>();
            builder.Services.AddScoped<IClinicReop, ClinicRepo>();
            builder.Services.AddScoped<IClinicService, ClinicService>();

            // Add controllers
            builder.Services.AddControllers();


            // Add Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
