using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace SQLServerWebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public ApplicationDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=ITHS-HP-EB-059\SQLEXPRESS;Database=MyDb;Trusted_Connection=True;TrustServerCertificate=True;")
                        .LogTo(message => Debug.WriteLine(message))
                        .EnableSensitiveDataLogging();
        }
    }
}
