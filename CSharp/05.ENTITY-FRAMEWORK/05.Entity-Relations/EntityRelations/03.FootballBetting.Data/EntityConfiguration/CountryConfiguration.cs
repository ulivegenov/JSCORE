namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //CountryId, Name

    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            // Primary key
            builder.HasKey(c => c.CountryId);

            // Property validations
            builder.Property(c => c.Name)
                   .HasMaxLength(80)
                   .IsUnicode()
                   .IsRequired();

            // Relations are writed in other entities.
        }
    }
}