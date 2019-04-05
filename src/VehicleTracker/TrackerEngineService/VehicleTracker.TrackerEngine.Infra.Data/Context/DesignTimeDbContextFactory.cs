using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VehicleTracker.TrackerEngine.Infra.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EventStoreSqlContext>
    {
        public EventStoreSqlContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EventStoreSqlContext>();
            builder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new EventStoreSqlContext(builder.Options);


        }
    }
}
