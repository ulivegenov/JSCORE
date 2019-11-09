namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    internal class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            // Primary key
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            // Propery validations --> This is a mapping table => No property validations

            // Relations
            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.CourseEnrollments)
                   .HasForeignKey(sc => sc.StudentId);

            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.StudentsEnrolled)
                   .HasForeignKey(sc => sc.CourseId);
        }
    }
}