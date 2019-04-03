using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleTracker.VehicleData.Domain.Models;

namespace VehicleTracker.VehicleData.Infra.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.HasMany(v => v.Vehicles)
                .WithOne(c => c.Customer)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
