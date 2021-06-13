using Diginovasi.BusinessObjects.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diginovasi.Data.EntityConfigurations
{
    class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.NoCustomer).HasMaxLength(100).IsRequired().IsUnicode(false);
            builder.Property(c => c.Nama).HasMaxLength(100).IsRequired().IsUnicode(false);
            builder.Property(c => c.NoKontak).HasMaxLength(100).IsRequired().IsUnicode(false);

            builder.HasMany(c => c.SalesOrders)
                   .WithOne(c => c.Customer)
                   .HasForeignKey(c => c.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Customer");
        }
    }
}
