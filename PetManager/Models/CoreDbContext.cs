using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetManager.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BreedInfo> BreedInfos { get; set; } = null!;
        public virtual DbSet<DappvView> DappvViews { get; set; } = null!;
        public virtual DbSet<DewormingHistory> DewormingHistories { get; set; } = null!;
        public virtual DbSet<DewormingInfo> DewormingInfos { get; set; } = null!;
        public virtual DbSet<DewormingView> DewormingViews { get; set; } = null!;
        public virtual DbSet<IntratracView> IntratracViews { get; set; } = null!;
        public virtual DbSet<PetInfo> PetInfos { get; set; } = null!;
        public virtual DbSet<PetType> PetTypes { get; set; } = null!;
        public virtual DbSet<RabiesView> RabiesViews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VaccinationView> VaccinationViews { get; set; } = null!;
        public virtual DbSet<VaccineHistory> VaccineHistories { get; set; } = null!;
        public virtual DbSet<VaccineInfo> VaccineInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=shared-sql-db.database.windows.net;Database=PetStoreManager;User ID=shareddb;Password=Sql@2022;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BreedInfo>(entity =>
            {
                entity.HasKey(e => e.BreedId)
                    .HasName("PK__Table__D1E9AE9DB59864B2");
            });

            modelBuilder.Entity<DappvView>(entity =>
            {
                entity.ToView("DappvView");
            });

            modelBuilder.Entity<DewormingHistory>(entity =>
            {
                entity.HasOne(d => d.Deworming)
                    .WithMany(p => p.DewormingHistories)
                    .HasForeignKey(d => d.DewormingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DewormingHistory_DewormingInfo");

                entity.HasOne(d => d.PetInfo)
                    .WithMany(p => p.DewormingHistories)
                    .HasForeignKey(d => d.PetInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DewormingHistory_PetInfo");
            });

            modelBuilder.Entity<DewormingView>(entity =>
            {
                entity.ToView("DewormingView");
            });

            modelBuilder.Entity<IntratracView>(entity =>
            {
                entity.ToView("IntratracView");
            });

            modelBuilder.Entity<PetInfo>(entity =>
            {
                entity.HasKey(e => e.PetId)
                    .HasName("PK__PetInfo__48E53862F69AE395");

                entity.Property(e => e.BreedId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Breed)
                    .WithMany(p => p.PetInfos)
                    .HasForeignKey(d => d.BreedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PetInfo_BreedInfo");
            });

            modelBuilder.Entity<RabiesView>(entity =>
            {
                entity.ToView("RabiesView");

                entity.Property(e => e.PetId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VaccinationView>(entity =>
            {
                entity.ToView("VaccinationView");
            });

            modelBuilder.Entity<VaccineHistory>(entity =>
            {
                entity.HasOne(d => d.PetInfo)
                    .WithMany(p => p.VaccineHistories)
                    .HasForeignKey(d => d.PetInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VaccineHistory_PetInfo");

                entity.HasOne(d => d.Vaccine)
                    .WithMany(p => p.VaccineHistories)
                    .HasForeignKey(d => d.VaccineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VaccineHistory_VaccineInfo");
            });

            modelBuilder.Entity<VaccineInfo>(entity =>
            {
                entity.HasKey(e => e.VaccineId)
                    .HasName("PK__VaccineI__45DC6889925BF0F7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
