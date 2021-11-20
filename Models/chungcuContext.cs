using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DETHI.Models
{
    public partial class chungcuContext : DbContext
    {
        public chungcuContext()
        {
        }

        public chungcuContext(DbContextOptions<chungcuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Canho> Canho { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Nvbt> Nvbt { get; set; }
        public virtual DbSet<Thietbi> Thietbi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=chungcu;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Canho>(entity =>
            {
                entity.HasKey(e => e.MaCanHo)
                    .HasName("PK__CANHO__400495C54638D9BA");

                entity.ToTable("CANHO");

                entity.Property(e => e.MaCanHo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ChuCanHo)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__NHANVIEN__77B2CA470EB91914");

                entity.ToTable("NHANVIEN");

                entity.HasIndex(e => e.SoDienThoai)
                    .HasName("UQ__NHANVIEN__0389B7BD55859E9D")
                    .IsUnique();

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhanVien)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Nvbt>(entity =>
            {
                entity.HasKey(e => new { e.MaNhanVien, e.MaThietBi, e.MaCanHo, e.LanThu });

                entity.ToTable("NVBT");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaThietBi)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MaCanHo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgayBaoTri).HasColumnType("datetime");

                entity.HasOne(d => d.MaCanHoNavigation)
                    .WithMany(p => p.Nvbt)
                    .HasForeignKey(d => d.MaCanHo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NVBT_CANHO");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.Nvbt)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NVBT_NHANVIEN");

                entity.HasOne(d => d.MaThietBiNavigation)
                    .WithMany(p => p.Nvbt)
                    .HasForeignKey(d => d.MaThietBi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NVBT_THIETBI");
            });

            modelBuilder.Entity<Thietbi>(entity =>
            {
                entity.HasKey(e => e.MaThietBi)
                    .HasName("PK__THIETBI__8AEC71F72F898C20");

                entity.ToTable("THIETBI");

                entity.Property(e => e.MaThietBi)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenThietBi)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
