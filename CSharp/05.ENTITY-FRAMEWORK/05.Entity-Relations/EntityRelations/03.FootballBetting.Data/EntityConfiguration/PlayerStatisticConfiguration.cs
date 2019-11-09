namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //GameId, PlayerId, ScoredGoals, Assists, MinutesPlayed

    internal class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            // Primary key
            builder.HasKey(ps => new { ps.GameId, ps.PlayerId });

            // Property validations this is a mapping table, the properties are validate in other entitites

            // Relations
            builder.HasOne(ps => ps.Game)
                   .WithMany(g => g.PlayerStatistics)
                   .HasForeignKey(ps => ps.GameId);

            builder.HasOne(ps => ps.Player)
                   .WithMany(p => p.PlayerStatistics)
                   .HasForeignKey(ps => ps.PlayerId);
        }
    }
}