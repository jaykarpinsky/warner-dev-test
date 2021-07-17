using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarnerTestJK.Data.Models;

namespace WarnerTestJK.Data.Configuration
{
    public class OtherNameConfiguration : IEntityTypeConfiguration<OtherName>
    {
        public void Configure(EntityTypeBuilder<OtherName> entity)
        {
            entity.ToTable("OtherName");

            entity.Property(e => e.TitleName).HasMaxLength(100);

            entity.Property(e => e.TitleNameLanguage).HasMaxLength(100);

            entity.Property(e => e.TitleNameSortable).HasMaxLength(100);

            entity.Property(e => e.TitleNameType).HasMaxLength(100);

            entity.HasOne(d => d.Title)
                .WithMany(p => p.OtherNames)
                .HasForeignKey(d => d.TitleId)
                .HasConstraintName("OtherName_FK_OtherName_Title");
        }
    }
}
