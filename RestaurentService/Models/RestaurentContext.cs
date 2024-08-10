using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace RestaurentService.Models
{
    public class RestaurentContext:DbContext
    {
       
        public RestaurentContext(DbContextOptions<RestaurentContext> options) : base(options)
        {

        }

        public DbSet<Restaurent> Restaurents { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS;initial catalog=foodie;user id =sa;password=Pass@123;trustservercertificate=true", builder =>
        //    {
        //        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        //    });

        }
    }

