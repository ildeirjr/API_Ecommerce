using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Ecommerce
{
    public partial class db_api_ecommerceContext : DbContext
    {
        public db_api_ecommerceContext()
        {
        }

        public db_api_ecommerceContext(DbContextOptions<db_api_ecommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=Database\\db_api_ecommerce.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasIndex(e => e.Id, "IX_Order_Id")
                    .IsUnique();

                entity.Property(e => e.Address).HasColumnType("VARCHAR (300)");

                entity.Property(e => e.CreatedDate).HasColumnType("DATETIME");

                entity.Property(e => e.DeliveryDate).HasColumnType("DATETIME");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TeamId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.Id, "IX_Product_Id")
                    .IsUnique();

                entity.Property(e => e.Name).HasColumnType("VARCHAR (200)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.HasIndex(e => e.Id, "IX_Team_Id")
                    .IsUnique();

                entity.Property(e => e.Name).HasColumnType("VARCHAR (200)");

                entity.Property(e => e.VehicleLicensePlate).HasColumnType("VARCHAR (10)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Id, "IX_User_ID")
                    .IsUnique();

                entity.Property(e => e.Name).HasColumnType("VARCHAR (200)");

                entity.Property(e => e.Password).HasColumnType("VARCHAR (200)");

                entity.Property(e => e.Role).HasColumnType("VARCHAR (50)");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
