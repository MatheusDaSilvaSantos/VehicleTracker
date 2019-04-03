using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleTracker.VehicleData.Domain.Models;

namespace VehicleTracker.VehicleData.Infra.Data.Mappings
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.HasOne(c => c.Customer)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.CustomerId);
        }
    }
}