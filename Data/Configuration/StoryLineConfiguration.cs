using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarnerTestJK.Data.Models;

namespace WarnerTestJK.Data.Configuration
{
    public class StoryLineConfiguration : IEntityTypeConfiguration<StoryLine>
    {
        public void Configure(EntityTypeBuilder<StoryLine> entity)
        {
            entity.ToTable("StoryLine");

            entity.Property(e => e.Description).HasColumnType("ntext");

            entity.Property(e => e.Language).HasMaxLength(100);

            entity.Property(e => e.Type).HasMaxLength(100);

            entity.HasOne(d => d.Title)
                .WithMany(p => p.StoryLines)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StoryLine_FK_StoryLine_Title");
        }
    }
}
