namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    internal class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            // Primary key
            builder.HasKey(r => r.ResourceId);

            // Property validations
            builder.Property(r => r.Name)
                   .HasMaxLength(50)
                   .IsRequired()
                   .IsUnicode();

            builder.Property(r => r.Url)
                   .IsRequired()
                   .IsUnicode(false);

            // Relations
            builder.HasOne(r => r.Course)
                   .WithMany(c => c.Resources)
                   .HasForeignKey(r => r.CourseId);
        }
    }
}