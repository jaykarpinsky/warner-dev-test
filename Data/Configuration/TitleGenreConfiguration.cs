using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarnerTestJK.Data.Models;

namespace WarnerTestJK.Data.Configuration
{
    public class TitleGenreConfiguration : IEntityTypeConfiguration<TitleGenre>
    {
        public void Configure(EntityTypeBuilder<TitleGenre> entity)
        {
            entity.ToTable("TitleGenre");

            entity.HasOne(d => d.Genre)
                .WithMany(p => p.TitleGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TitleGenre_FK_TitleGenre_Genre");

            entity.HasOne(d => d.Title)
                .WithMany(p => p.TitleGenres)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TitleGenre_FK_TitleGenre_Title");
        }
    }
}
