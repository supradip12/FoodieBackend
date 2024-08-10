using Microsoft.EntityFrameworkCore;

namespace UserService.Models
{
    public class UserContext:DbContext
    {
   
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }       

        public DbSet<User> users { get; set; }


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

