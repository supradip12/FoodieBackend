using UserService.Models;
using UserService.Service;
using Serilog;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {

           var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddScoped<IUserService, Services>();
            builder.Services.AddDbContext<UserContext>(
             (option) => option.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDB")));



            // Add services to the container.

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "www.abc.com",//builder.Configuration["Jwt:Issuer"],
                     ValidAudience = builder.Configuration["Jwt:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                 };
             });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var logger = new LoggerConfiguration()
            .WriteTo.File("C:/Users/pulkit/Desktop/Foodie/foodieappservice/UserService/UserLog/userLog.log",rollingInterval:RollingInterval.Day)
            .CreateLogger();
            builder.Services.AddSerilog(logger);
            builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("corspolicy");


            app.MapControllers();

            app.Run();
        }
    }
}
    
