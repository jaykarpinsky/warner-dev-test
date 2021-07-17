using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarnerTestJK.Data.Models;

namespace WarnerTestJK.Data.Configuration
{
    public class TitleParticipantConfiguration : IEntityTypeConfiguration<TitleParticipant>
    {
        public void Configure(EntityTypeBuilder<TitleParticipant> entity)
        {
            entity.ToTable("TitleParticipant");

            entity.Property(e => e.RoleType).HasMaxLength(100);

            entity.HasOne(d => d.Participant)
                .WithMany(p => p.TitleParticipants)
                .HasForeignKey(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TitleParticipant_FK_TitleParticipant_Participant");

            entity.HasOne(d => d.Title)
                .WithMany(p => p.TitleParticipants)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TitleParticipant_FK_TitleParticipant_Title");
        }
    }
}
