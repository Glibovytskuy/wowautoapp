using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WowAutoApp.Data.Mapping;
using WowAutoApp.Core.Domain;

namespace WowAutoApp.Data.Configurations
{
    public class VehicleEntityTypeConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
        }
    }
}