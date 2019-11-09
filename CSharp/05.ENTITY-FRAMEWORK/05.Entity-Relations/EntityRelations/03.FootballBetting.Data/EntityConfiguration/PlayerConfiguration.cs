namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //PlayerId, Name, SquadNumber, TeamId, PositionId, IsInjured

    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            // Primary key
            builder.HasKey(p => p.PlayerId);

            // Property validations
            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsUnicode()
                   .IsRequired();

            // Raltions
            builder.HasOne(p => p.Team)
                   .WithMany(t => t.Players)
                   .HasForeignKey(p => p.TeamId);

            builder.HasOne(p => p.Position)
                   .WithMany(pn => pn.Players)
                   .HasForeignKey(p => p.PositionId);
        }
    }
}