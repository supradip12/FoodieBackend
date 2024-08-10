using Microsoft.EntityFrameworkCore;

namespace DishService.Models
{
    public class DishContext:DbContext
    {
        public DishContext(DbContextOptions<DishContext> options) : base(options)
        {
        }
        public DbSet<Dish> dishes { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"server=.\SQLEXPRESS;initial catalog=foodie;user id =sa;password=Pass@123;trustservercertificate=true", builder =>
        //    {
        //        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        //    });

        //}
    }
}
