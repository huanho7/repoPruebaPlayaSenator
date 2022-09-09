using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaPlayaSenator.Application.Entities;
using System.IO;



namespace ExampleAPIWithEF.Context
{
    public class PruebaPlayaSenatorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                
                optionsBuilder
                //UseLoggerFactory(_loggerFactory)
                .UseSqlServer(config.GetConnectionString("RemoteConnection"));

            optionsBuilder.UseSqlServer(config.GetConnectionString("RemoteConnection"));

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Characteristic> Characteristic { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelXCharacteristic> HotelXCharacteristic { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Relevance> Relevance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(c =>  c.Id);

            modelBuilder.Entity<Characteristic>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<City>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Hotel>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<HotelXCharacteristic>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Province>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Relevance>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Hotels)
                .WithOne(h => h.Category);

            modelBuilder.Entity<Characteristic>()
                .HasMany(c => c.HotelXCharacteristic)
                .WithOne(h => h.Characteristic);

            modelBuilder.Entity<City>()
                .HasMany(c => c.Hotels)
                .WithOne(h => h.City);

            modelBuilder.Entity<City>()
                .HasOne(c => c.Province)
                .WithMany(h => h.Cities)
                .HasForeignKey(c => c.IdProvince);

            modelBuilder.Entity<Country>()
                .HasMany(p => p.Provinces)
                .WithOne(c => c.Country);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Category)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.IdCategory);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.City)
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.IdCity);

            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.HotelXCharacteristic)
                .WithOne(h => h.Hotel);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Relevance)
                .WithMany(r => r.Hotels)
                .HasForeignKey(h => h.IdRelevance);

            modelBuilder.Entity<HotelXCharacteristic>()
                .HasOne(h => h.Hotel)
                .WithMany(h => h.HotelXCharacteristic)
                .HasForeignKey(h => h.IdHotel);

            modelBuilder.Entity<HotelXCharacteristic>()
                .HasOne(h => h.Characteristic)
                .WithMany(c => c.HotelXCharacteristic)
                .HasForeignKey(h => h.IdCharacteristic);

            modelBuilder.Entity<Province>()
                .HasOne(p => p.Country)
                .WithMany(c => c.Provinces);

            modelBuilder.Entity<Province>()
                .HasMany(p => p.Cities)
                .WithOne(c => c.Province);

            modelBuilder.Entity<Relevance>()
                .HasMany(r => r.Hotels)
                .WithOne(h => h.Relevance);
        }
    }
}
