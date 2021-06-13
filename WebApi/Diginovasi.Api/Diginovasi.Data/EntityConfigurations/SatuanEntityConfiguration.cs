using Diginovasi.BusinessObjects.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diginovasi.Data.EntityConfigurations
{
    public class SatuanEntityConfiguration : IEntityTypeConfiguration<Satuan>
    {
        public void Configure(EntityTypeBuilder<Satuan> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Kode).HasMaxLength(50).IsUnicode(false).IsRequired(true);
            builder.Property(c => c.Deskripsi).HasMaxLength(200).IsUnicode(false);
            builder.HasMany(c => c.Materials).WithOne(c => c.Satuan).HasForeignKey(c => c.SatuanId).OnDelete(DeleteBehavior.SetNull);
            builder.ToTable("Satuan");
        }
    }
}
