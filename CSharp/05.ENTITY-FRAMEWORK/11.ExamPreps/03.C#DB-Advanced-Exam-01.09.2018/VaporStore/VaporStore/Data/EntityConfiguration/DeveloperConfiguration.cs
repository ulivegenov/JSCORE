namespace VaporStore.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using VaporStore.Data.Models;

    public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> developer)
        {
            //Primary key
            developer.HasKey(d => d.Id);
        }
    }
}
