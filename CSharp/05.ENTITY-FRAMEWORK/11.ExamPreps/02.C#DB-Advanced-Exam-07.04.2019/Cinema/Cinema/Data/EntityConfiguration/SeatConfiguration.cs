namespace Cinema.Data.EntityConfiguration
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            // Primary key
            builder.HasKey(s => s.Id);

            // Relations
            builder.HasOne(s => s.Hall)
                   .WithMany(h => h.Seats)
                   .HasForeignKey(s => s.HallId);
        }
    }
}
