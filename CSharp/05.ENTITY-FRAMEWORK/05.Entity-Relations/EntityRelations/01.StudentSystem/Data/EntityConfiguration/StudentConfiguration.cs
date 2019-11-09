namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Primary key
            builder.HasKey(s => s.StudentId);

            // Property validations
            builder.Property(s => s.Name)
                   .HasMaxLength(100)
                   .IsRequired()
                   .IsUnicode();

            builder.Property(s => s.PhoneNumber)
                   .HasDefaultValueSql("CHAR(10)")
                   .IsRequired(false)
                   .IsUnicode(false);

            builder.Property(s => s.Birthday)
                   .IsRequired(false);

            // Relations are writed in other entities
        }
    }
}