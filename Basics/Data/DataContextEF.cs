using Basics.Models;
using Microsoft.EntityFrameworkCore;

namespace Basics.Data
{
  public class DataContextEF : DbContext
  {

    public DbSet<Computer>? Computer {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
              options.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;",
              options => options.EnableRetryOnFailure());
            }
        }

         protected override void OnModelCreating(ModelBuilder modelBuilder){

          modelBuilder.HasDefaultSchema("TutorialAppSchema");

          modelBuilder.Entity<Computer>()
            .HasKey(c => c.ComputerId);
            // .ToTable("Computer", "TutorialAppSchema");
         }
    }
}