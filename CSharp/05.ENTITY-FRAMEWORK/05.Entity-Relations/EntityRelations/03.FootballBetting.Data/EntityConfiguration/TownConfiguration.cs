namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //TownId, Name, CountryId
    internal class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            // Primary key
            builder.HasKey(t => t.TownId);

            // Property validations
            builder.Property(t => t.Name)
                   .HasMaxLength(30)
                   .IsUnicode()
                   .IsRequired();

            // Relations
            builder.HasOne(t => t.Country)
                   .WithMany(c => c.Towns)
                   .HasForeignKey(t => t.CountryId);
        }
    }
}