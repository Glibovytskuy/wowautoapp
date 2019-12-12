using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WowAutoApp.Data.Mapping;
using WowAutoApp.Core.Domain;

namespace WowAutoApp.Data.Configurations
{
    public class AddressEntityTypeConfiguration : EntityTypeConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
        }
    }
}