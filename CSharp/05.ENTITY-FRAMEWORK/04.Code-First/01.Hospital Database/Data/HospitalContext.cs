namespace P01_HospitalDatabase.Data 
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class HospitalContext : DbContext
    {
        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDoctorEntity(modelBuilder);

            ConfigurePatientEntity(modelBuilder);

            ConfigureVisitationEntity(modelBuilder);

            ConfigureDiagnoseEntity(modelBuilder);

            ConfigureMedicamentEntity(modelBuilder);

            ConfigurePatientMedicamentEntity(modelBuilder);
        }

        private void ConfigureDoctorEntity(ModelBuilder modelBuilder)
        {
            // Primary key
            modelBuilder
                .Entity<Doctor>()
                .HasKey(d => d.DoctorId);

            // Property Validations
            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Doctor>()
                        .Property(d => d.Email)
                        .HasMaxLength(80)
                        .IsRequired();

            modelBuilder.Entity<Doctor>()
                        .Property(d => d.Password)
                        .IsRequired();
                      

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Specialty)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();

            // Relations
            modelBuilder
                .Entity<Doctor>()
                .HasMany(d => d.Visitations)
                .WithOne(v => v.Doctor);
        }

        private void ConfigurePatientEntity(ModelBuilder modelBuilder)
        {
            // Primary Key
            modelBuilder.Entity<Patient>()
                        .HasKey(p => p.PatientId);

            // Property validations
            modelBuilder.Entity<Patient>()
                        .Property(p => p.FirstName)
                        .HasMaxLength(50)
                        .IsRequired()
                        .IsUnicode();

            modelBuilder.Entity<Patient>()
                        .Property(p => p.LastName)
                        .HasMaxLength(50)
                        .IsRequired()
                        .IsUnicode();

            modelBuilder.Entity<Patient>()
                        .Property(p => p.Address)
                        .HasMaxLength(250)
                        .IsUnicode();

            modelBuilder.Entity<Patient>()
                        .Property(p => p.Email)
                        .HasMaxLength(80);


            // Rlations in other entity configure methods
        }

        private void ConfigureVisitationEntity(ModelBuilder modelBuilder)
        {
            // Primary Key
            modelBuilder.Entity<Visitation>()
                        .HasKey(v => v.VisitationId);

            // Property validations
            modelBuilder.Entity<Visitation>()
                        .Property(v => v.Date)
                        .HasColumnType("DATETIME2");

            modelBuilder.Entity<Visitation>()
                        .Property(v => v.Comments)
                        .HasMaxLength(250)
                        .IsUnicode();

            // Relations
            modelBuilder.Entity<Visitation>()
                        .HasOne(v => v.Patient)
                        .WithMany(p => p.Visitations)
                        .HasForeignKey(v => v.PatientId);
        }

        private void ConfigureDiagnoseEntity(ModelBuilder modelBuilder)
        {
            //Primary Key
            modelBuilder.Entity<Diagnose>()
                        .HasKey(d => d.DiagnoseId);

            // Propery validations
            modelBuilder.Entity<Diagnose>()
                        .Property(d => d.Name)
                        .HasMaxLength(50)
                        .IsRequired()
                        .IsUnicode();

            modelBuilder.Entity<Diagnose>()
                        .Property(d => d.Comments)
                        .HasMaxLength(250)
                        .IsUnicode();

            // Relations
            modelBuilder.Entity<Diagnose>()
                        .HasOne(d => d.Patient)
                        .WithMany(p => p.Diagnoses)
                        .HasForeignKey(d => d.PatientId);
        }

        private void ConfigureMedicamentEntity(ModelBuilder modelBuilder)
        {
            // Primary Key
            modelBuilder.Entity<Medicament>()
                        .HasKey(m => m.MedicamentId);

            // Property validations
            modelBuilder.Entity<Medicament>()
                        .Property(m => m.Name)
                        .HasMaxLength(50)
                        .IsRequired()
                        .IsUnicode();

            // Relations in PatientMedicament configure method
        }

        private void ConfigurePatientMedicamentEntity(ModelBuilder modelBuilder)
        {
            // Primary Key
            modelBuilder.Entity<PatientMedicament>()
                        .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            // Property validations  --> this is a mapping table, the constraints are in the other entities.

            //Relations
            modelBuilder.Entity<PatientMedicament>()
                        .HasOne(pm => pm.Patient)
                        .WithMany(p => p.Prescriptions)
                        .HasForeignKey(pm => pm.PatientId);

            modelBuilder.Entity<PatientMedicament>()
                        .HasOne(pm => pm.Medicament)
                        .WithMany(m => m.Prescriptions)
                        .HasForeignKey(pm => pm.MedicamentId);
        }
    }
}
