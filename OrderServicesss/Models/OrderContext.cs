using Microsoft.EntityFrameworkCore;

namespace OrderServicesss.Models
{
    public class OrderContext : DbContext
    {
              

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public DbSet<Order> Orderss { get; set; }
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
