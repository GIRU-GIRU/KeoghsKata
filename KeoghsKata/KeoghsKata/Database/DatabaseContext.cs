using KeoghsKata.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace KeoghsKata.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=KeoghsDatabase.db");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //A database is not required for this kata, but i thought i would make use of it to also learn the EF6 minimal API setup with EF core as this is all new to me
            modelBuilder.Entity<PromotionStoreKeepingUnit>().HasOne(x => x.StoreKeepingUnit);

            modelBuilder.Entity<StoreKeepingUnit>().HasData(
                new StoreKeepingUnit()
                {
                    Id = 1,
                    CreatedUTC = DateTime.UtcNow,
                    ProductName = "A",
                    UnitPrice = 10
                },
                new StoreKeepingUnit()
                {
                    Id = 2,
                    CreatedUTC = DateTime.UtcNow,
                    ProductName = "B",
                    UnitPrice = 15
                },
                new StoreKeepingUnit()
                {
                    Id = 3,
                    CreatedUTC = DateTime.UtcNow,
                    ProductName = "C",
                    UnitPrice = 40
                },
                new StoreKeepingUnit()
                {
                    Id = 4,
                    CreatedUTC = DateTime.UtcNow,
                    ProductName = "D",
                    UnitPrice = 55
                }
            );
        }

        public DbSet<StoreKeepingUnit> StoreKeepingUnits { get; set; }
        public DbSet<PromotionStoreKeepingUnit> Promotions { get; set; }


      
    }
}
