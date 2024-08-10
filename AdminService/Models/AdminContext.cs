
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

namespace AdminService.Models
{
    public class AdminContext : DbContext
    {
                
            public AdminContext(DbContextOptions<AdminContext> options) : base(options)
            {
            }

            public DbSet<Admin> Admins { get; set; }
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

