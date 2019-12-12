using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WowAutoApp.Data.Mapping;
using WowAutoApp.Core.Domain;

namespace WowAutoApp.Data.Configurations
{
    public class BusinessEntityTypeConfiguration : EntityTypeConfiguration<Buisness>
    {
        public override void Configure(EntityTypeBuilder<Buisness> builder)
        {
            builder.ToTable("Buisnesses");
        }
    }
}