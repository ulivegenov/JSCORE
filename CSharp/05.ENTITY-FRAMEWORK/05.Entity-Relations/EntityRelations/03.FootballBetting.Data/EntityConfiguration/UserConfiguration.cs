namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    //UserId, Username, Password, Email, Name, Balance

    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary key
            builder.HasKey(u => u.UserId);

            // Property validations
            builder.Property(u => u.Username)
                   .HasMaxLength(30)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(u => u.Password)
                   .HasMaxLength(30)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(u => u.Email)
                   .HasMaxLength(30)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(u => u.Name)
                   .HasMaxLength(50)
                   .IsUnicode()
                   .IsRequired();

            // Relations are writed in other entities
        }
    }
}