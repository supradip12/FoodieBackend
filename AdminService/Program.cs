using AdminService.Models;
using AdminService.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AdminService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
          
            builder.Services.AddControllers();
            builder.Services.AddCors();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IAdminService, AdminService.Services.AdminService>();//request the handler to this job becuse handler automatically call the constructor of the controller class but we have to request in main class to to call service instance by add scopped
            builder.Services.AddDbContext<AdminContext>(
           (option) => option.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDB")));

            var logger = new LoggerConfiguration()
                .WriteTo.File("C:/Users/pulkit/Downloads/Dotnet_Assignment/AdminLogger.log", rollingInterval:RollingInterval.Day)
                .CreateLogger();
            builder.Services.AddSerilog(logger);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}