using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using VehicleTracker.VehicleData.Domain.Models;
using VehicleTracker.VehicleData.Infra.Data.Mappings;
using VehicleTracker.VehicleData.Infra.Data.SeedData;

namespace VehicleTracker.VehicleData.Infra.Data.Context
{
    public class VehicleDataContext : DbContext
    {
        public VehicleDataContext(DbContextOptions options) : base(options)
        {

        }
        private readonly IHostingEnvironment _env;

        public VehicleDataContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // get the configuration from the app settings

            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(_env.ContentRootPath)
                    .AddJsonFile("appsettings.json")
                    .Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
