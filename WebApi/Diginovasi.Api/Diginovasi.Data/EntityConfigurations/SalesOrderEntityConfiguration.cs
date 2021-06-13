using Diginovasi.BusinessObjects.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diginovasi.Data.EntityConfigurations
{
    class SalesOrderEntityConfiguration : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.NoSalesOrder).HasMaxLength(20).IsRequired(false).IsUnicode(false);
            builder.HasMany(c => c.SalesOrderItems)
                .WithOne(c => c.Sales)
                .HasForeignKey(c => c.SalesId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("SalesOrder");
        }
    }
}
