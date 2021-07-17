using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarnerTestJK.Data.Models;

namespace WarnerTestJK.Data.Configuration
{
    public class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> entity)
        {
            entity.ToTable("Award");

            entity.Property(e => e.AwardCategory)
                .HasMaxLength(100)
                .HasColumnName("Award");

            entity.Property(e => e.AwardCompany).HasMaxLength(100);

            entity.HasOne(d => d.Title)
                .WithMany(p => p.Awards)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Award_FK_Award_Title");
        }
    }
}
