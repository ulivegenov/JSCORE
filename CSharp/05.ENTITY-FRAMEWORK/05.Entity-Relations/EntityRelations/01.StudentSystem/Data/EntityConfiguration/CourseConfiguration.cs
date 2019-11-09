namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Primary key
            builder.HasKey(c => c.CourseId);

            // Propery validations
            builder.Property(c => c.Name)
                    .HasMaxLength(80)
                    .IsRequired()
                    .IsUnicode();

            builder.Property(c => c.Description)
                   .IsRequired(false)
                   .IsUnicode();

            // Relations are writed in other entities
        }
    }
}