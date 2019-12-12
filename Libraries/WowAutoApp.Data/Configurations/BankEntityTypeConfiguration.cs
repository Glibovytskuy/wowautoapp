using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WowAutoApp.Data.Mapping;
using WowAutoApp.Core.Domain;

namespace WowAutoApp.Data.Configurations
{
    public class BankEntityTypeConfiguration : EntityTypeConfiguration<Bank>
    {
        public override void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.ToTable("Banks");
        }
    }
}