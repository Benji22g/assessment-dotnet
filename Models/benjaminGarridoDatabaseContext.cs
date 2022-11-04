using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetC_Assessment___Coding_exercise.Models
{
    public partial class benjaminGarridoDatabaseContext : DbContext
    {
        public benjaminGarridoDatabaseContext()
        {
        }

        public benjaminGarridoDatabaseContext(DbContextOptions<benjaminGarridoDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-O33D1B3\\SQLEXPRESS;Database=benjaminGarridoDatabase;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>(entity =>
            {
                entity.Property(e => e.ClaimId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Vehicle_Id");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("Vehicle_Id");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("Owner");

                entity.Property(e => e.OwnerId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FirstName).HasColumnType("ntext");

                entity.Property(e => e.LastNme).HasColumnType("ntext");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehiclesId);

                entity.Property(e => e.VehiclesId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("Owner_Id");

                entity.Property(e => e.Vin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("year");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.InverseOwner)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("Owner_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
