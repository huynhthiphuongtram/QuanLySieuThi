using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLST.DAL.Models
{
    public partial class dbblContext : DbContext
    {
        public dbblContext()
        {
        }

        public dbblContext(DbContextOptions<dbblContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }
        public virtual DbSet<Hanghoa> Hanghoas { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-7NNP8UR;Initial Catalog=dbbl;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_100_CI_AI");

            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.ToTable("chitiethoadon");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ChitietId).HasColumnName("chitietID");

                entity.Property(e => e.HanghoaId).HasColumnName("hanghoaID");

                entity.HasOne(d => d.Chitiet)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.ChitietId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitiethoadon_hoadon");

                entity.HasOne(d => d.Hanghoa)
                    .WithMany(p => p.Chitiethoadons)
                    .HasForeignKey(d => d.HanghoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitiethoadon_hanghoa");
            });

            modelBuilder.Entity<Hanghoa>(entity =>
            {
                entity.HasKey(e => e.IdHh);

                entity.ToTable("hanghoa");

                entity.Property(e => e.IdHh)
                    .ValueGeneratedNever()
                    .HasColumnName("id_hh");

                entity.Property(e => e.Giahang).HasColumnName("giahang");

                entity.Property(e => e.Mota)
                    .HasMaxLength(45)
                    .HasColumnName("mota");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.Property(e => e.Tenhang)
                    .HasMaxLength(45)
                    .HasColumnName("tenhang");

                entity.Property(e => e.Xuatxu)
                    .HasMaxLength(45)
                    .HasColumnName("xuatxu");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.ToTable("hoadon");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdNv).HasColumnName("idNV");

                entity.Property(e => e.Thanhtien).HasColumnName("thanhtien");

                entity.HasOne(d => d.IdNvNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.IdNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_hoadon_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(45)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
