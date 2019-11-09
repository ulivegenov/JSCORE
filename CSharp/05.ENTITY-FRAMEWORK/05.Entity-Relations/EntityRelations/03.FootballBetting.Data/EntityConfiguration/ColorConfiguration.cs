namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //ColorId, Name

    internal class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            // Primary key
            builder.HasKey(c => c.ColorId);

            // Property validations
            builder.Property(c => c.Name)
                    .HasMaxLength(50)
                    .IsUnicode()
                    .IsRequired();

            // Relations are writed in other entities.
        }
    }
}