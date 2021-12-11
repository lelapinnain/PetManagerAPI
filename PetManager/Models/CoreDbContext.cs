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
        public virtual DbSet<PetInfo> PetInfos { get; set; } = null!;
        public virtual DbSet<PetType> PetTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
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

                entity.Property(e => e.BreedId).ValueGeneratedNever();
            });

            modelBuilder.Entity<PetInfo>(entity =>
            {
                entity.HasKey(e => e.PetId)
                    .HasName("PK__PetInfo__48E53862F69AE395");

                entity.Property(e => e.BreedId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<VaccineHistory>(entity =>
            {
                entity.Property(e => e.VaccineHistoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<VaccineInfo>(entity =>
            {
                entity.HasKey(e => e.VaccineId)
                    .HasName("PK__VaccineI__45DC6889925BF0F7");

                entity.Property(e => e.VaccineId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
