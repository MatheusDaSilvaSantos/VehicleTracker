using System;
using Microsoft.EntityFrameworkCore;
using VehicleTracker.VehicleData.Domain.Models;

namespace VehicleTracker.VehicleData.Infra.Data.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer(new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd"), "Kalles Grustransporter AB", "Cementvägen 8, 111 11 Södertälje"),
                new Customer(new Guid("20000a0b-ddd6-44c0-8f19-963e5ca783dd"), "Johans Bulk AB  ", "Balkvägen 12, 222 22 Stockholm "),
                new Customer(new Guid("30000a0b-ddd6-44c0-8f19-963e5ca783dd"), "Haralds Värdetransporter AB", "Budgetvägen 1, 333 33 Uppsala")
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle(new Guid("40000a0b-ddd6-44c0-8f19-963e5ca783dd"), "YS2R4X20005399401", "ABC123", new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd")),
                new Vehicle(new Guid("50000a0b-ddd6-44c0-8f19-963e5ca783dd"), "VLUR4X20009093588", "DEF456", new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd")),
                new Vehicle(new Guid("60000a0b-ddd6-44c0-8f19-963e5ca783dd"), "VLUR4X20009048066", "GHI789", new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd")),
                new Vehicle(new Guid("70000a0b-ddd6-44c0-8f19-963e5ca783dd"), "YS2R4X20005388011", "JKL012", new Guid("20000a0b-ddd6-44c0-8f19-963e5ca783dd")),
                new Vehicle(new Guid("80000a0b-ddd6-44c0-8f19-963e5ca783dd"), "YS2R4X20005387949", "MNO345", new Guid("20000a0b-ddd6-44c0-8f19-963e5ca783dd")),
                new Vehicle(new Guid("90000a0b-ddd6-44c0-8f19-963e5ca783dd"), "VLUR4X20009048066", "PQR678", new Guid("30000a0b-ddd6-44c0-8f19-963e5ca783dd")),
                new Vehicle(new Guid("01000a0b-ddd6-44c0-8f19-963e5ca783dd"), "YS2R4X20005387055", "STU901", new Guid("30000a0b-ddd6-44c0-8f19-963e5ca783dd"))
            );

        }
    }
}