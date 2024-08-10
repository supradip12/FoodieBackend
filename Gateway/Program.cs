using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration  = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();


            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddOcelot(configuration);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            app.UseOcelot();

            app.Run();
        }
    }
}