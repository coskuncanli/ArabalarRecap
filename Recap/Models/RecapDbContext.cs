using Microsoft.EntityFrameworkCore;

namespace Recap.Models
{

    public class RecapDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=Araba;trusted_connection=true");
        }

        public DbSet<Araba> Arabalar { get; set; }
    }
}
