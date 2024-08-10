using FeedbackServices.Model;
using FeedbackServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace FeedbackServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddConsulConfig(builder.Configuration);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
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
            //request for the controller to handle the instance creation
            builder.Services.AddScoped<IFeedbackService, FeedbackService>();

            builder.Services.AddDbContext<FeedbackContext>(
           (option) => option.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDB")));
            //builder.Services.AddDbContext<FeedbackService.Models.FeedbackContext>(
            // (option) => option.UseSqlServer(builder.Configuration.GetConnectionString("FeedbackDB")));


            var logger = new LoggerConfiguration()
            .WriteTo
            .File("C:\\Users\\pulkit\\Downloads\\feedbacklog\\feedbacklog.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
            builder.Services.AddSerilog(logger);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseConsul(builder.Configuration);

            app.MapControllers();

            app.Run();
        }
    }

}