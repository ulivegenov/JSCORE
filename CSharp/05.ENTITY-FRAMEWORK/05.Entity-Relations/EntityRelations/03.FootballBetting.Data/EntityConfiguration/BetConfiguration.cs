namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //BetId, Amount, Prediction, DateTime, UserId, GameId

    internal class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            // Primary Key
            builder.HasKey(b => b.BetId);

            // Property validations
            builder.Property(b => b.Prediction)
                   .IsRequired();

            // Realtions
            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bets)
                   .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Game)
                   .WithMany(g => g.Bets)
                   .HasForeignKey(b => b.GameId);
        }
    }
}