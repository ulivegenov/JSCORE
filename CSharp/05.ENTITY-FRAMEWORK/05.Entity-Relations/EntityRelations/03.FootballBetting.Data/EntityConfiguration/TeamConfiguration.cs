namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //TeamId, Name, LogoUrl, Initials(JUV, LIV, ARS…), Budget, PrimaryKitColorId, SecondaryKitColorId, TownId

    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            // Primary key
            builder.HasKey(t => t.TeamId);

            // Property validations
            builder.Property(t => t.Name)
                   .HasMaxLength(30)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(t => t.LogoUrl)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(t => t.Initials)
                   .HasMaxLength(3)
                   .HasDefaultValueSql("CHAR(3)")
                   .IsUnicode(false)
                   .IsRequired();

            // Relations
            builder.HasOne(t => t.PrimaryKitColor)
                   .WithMany(pkc => pkc.PrimaryKitTeams)
                   .HasForeignKey(t => t.PrimaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SecondaryKitColor)
                   .WithMany(skc => skc.SecondaryKitTeams)
                   .HasForeignKey(t => t.SecondaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Town)
                   .WithMany(tn => tn.Teams)
                   .HasForeignKey(t => t.TownId);
        }
    }
}