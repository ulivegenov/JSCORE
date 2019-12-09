namespace Cinema.Data.EntityConfiguration
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            // Primary key
            builder.HasKey(h => h.Id);
        }
    }
}
