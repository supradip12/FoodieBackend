using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FeedbackServices.Model
{
    
        public class FeedbackContext : DbContext
        {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {
        }

        public DbSet<Feedback> FeedBacks { get; set; }

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

