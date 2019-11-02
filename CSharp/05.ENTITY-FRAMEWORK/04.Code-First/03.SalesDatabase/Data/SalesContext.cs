namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureProductEntity(modelBuilder);

            ConfigureCustomerEntity(modelBuilder);

            ConfigureStoreEntity(modelBuilder);

            ConfigureSaleEntity(modelBuilder);
        }

        private void ConfigureProductEntity(ModelBuilder modelBuilder)
        {
            // Primary Key
            modelBuilder.Entity<Product>()
                        .HasKey(p => p.ProductId);

            // Propety validations
            modelBuilder.Entity<Product>()
                        .Property(p => p.Name)
                        .HasMaxLength(50)
                        .IsRequired()
                        .IsUnicode();

            modelBuilder.Entity<Product>()
                        .Property(p => p.Description)
                        .HasMaxLength(250)
                        .HasDefaultValue("No description")
                        .IsUnicode();

            // Relations in Sale configure method
        }

        private void ConfigureCustomerEntity(ModelBuilder modelBuilder)
        {
            // Primary Key
            modelBuilder.Entity<Customer>()
                        .HasKey(c => c.CustomerId);

            // Propety validations
            modelBuilder.Entity<Customer>()
                        .Property(c => c.Name)
                        .HasMaxLength(100)
                        .IsRequired()
                        .IsUnicode();

            modelBuilder.Entity<Customer>()
                        .Property(c => c.Email)
                        .HasMaxLength(80)
                        .IsRequired();

            modelBuilder.Entity<Customer>()
                        .Property(c => c.CreditCardNumber)
                        .HasColumnType("CHAR(19)");

            // Relations in Sale configure method
        }

        private void ConfigureStoreEntity(ModelBuilder modelBuilder)
        {
            // Primary Key
            modelBuilder.Entity<Store>()
                        .HasKey(s => s.StoreId);

            // Propety validations
            modelBuilder.Entity<Store>()
                        .Property(s => s.Name)
                        .HasMaxLength(80)
                        .IsRequired()
                        .IsUnicode();

            // Relations in Sale configure method
        }

        private void ConfigureSaleEntity(ModelBuilder modelBuilder)
        {
            // Primary Key
            modelBuilder.Entity<Sale>()
                        .HasKey(s => s.SaleId);

            // Propety validations
            modelBuilder.Entity<Sale>()
                        .Property(s => s.Date)
                        .HasDefaultValueSql("GETDATE()");

            // Relations
            modelBuilder.Entity<Sale>()
                        .HasOne(s => s.Customer)
                        .WithMany(c => c.Sales)
                        .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Sale>()
                        .HasOne(s => s.Product)
                        .WithMany(p => p.Sales)
                        .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<Sale>()
                        .HasOne(s => s.Store)
                        .WithMany(st => st.Sales)
                        .HasForeignKey(s => s.StoreId);
        }
    }
}
