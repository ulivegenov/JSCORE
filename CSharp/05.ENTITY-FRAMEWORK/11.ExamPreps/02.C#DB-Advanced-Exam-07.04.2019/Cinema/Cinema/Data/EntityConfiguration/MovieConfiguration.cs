namespace Cinema.Data.EntityConfiguration
{
    using Cinema.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            // Primary key
            builder.HasKey(m => m.Id);
        }
    }
}
