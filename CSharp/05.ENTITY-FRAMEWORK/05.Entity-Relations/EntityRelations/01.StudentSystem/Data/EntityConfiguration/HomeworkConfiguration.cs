namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    internal class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            // Primary key
            builder.HasKey(h => h.HomeworkId);

            // Property validations
            builder.Property(h => h.Content)
                   .IsRequired()
                   .IsUnicode(false);

            // Realtions
            builder.HasOne(h => h.Student)
                   .WithMany(s => s.HomeworkSubmissions)
                   .HasForeignKey(h => h.StudentId);

            builder.HasOne(h => h.Course)
                   .WithMany(c => c.HomeworkSubmissions)
                   .HasForeignKey(h => h.CourseId);
        }
    }
}