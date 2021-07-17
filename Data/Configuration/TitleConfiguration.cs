using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarnerTestJK.Data.Models;

namespace WarnerTestJK.Data.Configuration
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> entity)
        {
            entity.ToTable("Title");

            entity.Property(e => e.Id)
                .HasColumnName("TitleId").ValueGeneratedNever();

            entity.Property(e => e.ProcessedDateTimeUtc)
                .HasColumnType("datetime")
                .HasColumnName("ProcessedDateTimeUTC");

            entity.Property(e => e.TitleName).HasMaxLength(100);

            entity.Property(e => e.TitleNameSortable).HasMaxLength(100);


        }
    }
}
