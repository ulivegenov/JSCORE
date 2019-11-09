namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //PositionId, Name

    internal class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            // Primary key
            builder.HasKey(p => p.PositionId);

            // Property validations
            builder.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsUnicode()
                   .IsRequired();

            // Relations are writed in other entities
        }
    }
}