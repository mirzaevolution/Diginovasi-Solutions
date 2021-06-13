using Diginovasi.BusinessObjects.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diginovasi.Data.EntityConfigurations
{
    public class MaterialEntityConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.Property(c => c.Kode).HasMaxLength(50).IsUnicode(false).IsRequired(true);
            builder.Property(c => c.Deskripsi).HasMaxLength(200).IsUnicode(false);
            builder.Property(c => c.UrlGambar).IsUnicode(false);
            builder.HasMany(c => c.SalesOrderItems)
                .WithOne(c => c.Material)
                .HasForeignKey(c => c.MaterialId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Material");
        }
    }
}
