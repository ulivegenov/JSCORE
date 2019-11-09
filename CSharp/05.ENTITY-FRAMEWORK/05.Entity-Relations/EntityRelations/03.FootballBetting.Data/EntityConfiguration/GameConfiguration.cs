namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, DateTime, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Primary key
            builder.HasKey(g => g.GameId);

            // Propery validations
            builder.Property(g => g.Result)
                   .IsRequired();

            // Relations
            builder.HasOne(g => g.HomeTeam)
                   .WithMany(ht => ht.HomeGames)
                   .HasForeignKey(g => g.HomeTeamId);

            builder.HasOne(g => g.AwayTeam)
                   .WithMany(at => at.AwayGames)
                   .HasForeignKey(g => g.AwayTeamId);
        }
    }
}