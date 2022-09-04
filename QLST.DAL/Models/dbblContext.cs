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

        public virtual DbSet<Hanghoa> Hanghoas { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbbl;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Hanghoa>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hanghoa");

                entity.Property(e => e.Giahang)
                    .HasMaxLength(45)
                    .HasColumnName("giahang");

                entity.Property(e => e.IdHh).HasColumnName("id_hh");

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
                entity.HasNoKey();

                entity.ToTable("hoadon");

                entity.Property(e => e.Giahh)
                    .HasMaxLength(45)
                    .HasColumnName("giahh");

                entity.Property(e => e.Idhd).HasColumnName("idhd");

                entity.Property(e => e.Idhh)
                    .HasMaxLength(45)
                    .HasColumnName("idhh");

                entity.Property(e => e.Idkh)
                    .HasMaxLength(45)
                    .HasColumnName("idkh");

                entity.Property(e => e.Loaikhach)
                    .HasMaxLength(45)
                    .HasColumnName("loaikhach");

                entity.Property(e => e.Namehh)
                    .HasMaxLength(45)
                    .HasColumnName("namehh");

                entity.Property(e => e.Namenv)
                    .HasMaxLength(45)
                    .HasColumnName("namenv");

                entity.Property(e => e.Soluonghh)
                    .HasMaxLength(45)
                    .HasColumnName("soluonghh");

                entity.Property(e => e.Thanhtien).HasColumnName("thanhtien");

                entity.Property(e => e.Xuatxu)
                    .HasMaxLength(45)
                    .HasColumnName("xuatxu");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("khachhang");

                entity.Property(e => e.Idkhachhang).HasColumnName("idkhachhang");

                entity.Property(e => e.Ngaysinh)
                    .HasMaxLength(45)
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(45)
                    .HasColumnName("tenkh");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(45)
                    .HasColumnName("role");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
