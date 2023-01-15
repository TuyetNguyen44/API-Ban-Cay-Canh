using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class BanCayCanhContext : DbContext
    {
        public BanCayCanhContext()
        {
        }

        public BanCayCanhContext(DbContextOptions<BanCayCanhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<Cay> Cays { get; set; }
        public virtual DbSet<ChiTietAnhCay> ChiTietAnhCays { get; set; }
        public virtual DbSet<ChiTietHoaDonXuat> ChiTietHoaDonXuats { get; set; }
        public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual DbSet<CthoaDonNhap> CthoaDonNhaps { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GiaCay> GiaCays { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<HoaDonXuat> HoaDonXuats { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Kho> Khos { get; set; }
        public virtual DbSet<LoaiCay> LoaiCays { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ADMIN\\SQLEXPRESS;Database=BanCayCanh;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountName).HasMaxLength(50);

                entity.Property(e => e.LoaiQuyen).HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Account_Users");
            });

            modelBuilder.Entity<BaiViet>(entity =>
            {
                entity.HasKey(e => e.Mabaiviet);

                entity.ToTable("BaiViet");

                entity.Property(e => e.Anhbaiviet).HasMaxLength(50);

                entity.Property(e => e.Ngaydang).HasColumnType("datetime");
            });

            modelBuilder.Entity<Cay>(entity =>
            {
                entity.HasKey(e => e.MaCay);

                entity.ToTable("Cay");

                entity.Property(e => e.AnhTo).HasMaxLength(50);

                entity.Property(e => e.TenCay).HasMaxLength(150);

                entity.HasOne(d => d.MaLoaiCayNavigation)
                    .WithMany(p => p.Cays)
                    .HasForeignKey(d => d.MaLoaiCay)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Cay_LoaiCay");
            });

            modelBuilder.Entity<ChiTietAnhCay>(entity =>
            {
                entity.HasKey(e => e.MaChiTietAnh);

                entity.ToTable("ChiTietAnhCay");

                entity.Property(e => e.MaChiTietAnh)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Anh)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.MaCayNavigation)
                    .WithMany(p => p.ChiTietAnhCays)
                    .HasForeignKey(d => d.MaCay)
                    .HasConstraintName("FK_ChiTietAnhCay_Cay");
            });

            modelBuilder.Entity<ChiTietHoaDonXuat>(entity =>
            {
                entity.HasKey(e => e.MaCthoaDonXuat);

                entity.ToTable("ChiTietHoaDonXuat");

                entity.Property(e => e.MaCthoaDonXuat).HasColumnName("MaCTHoaDonXuat");

                entity.HasOne(d => d.MaHoaDonXuatNavigation)
                    .WithMany(p => p.ChiTietHoaDonXuats)
                    .HasForeignKey(d => d.MaHoaDonXuat)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ChiTietHoaDonXuat_HoaDonXuat");
            });

            modelBuilder.Entity<Chitietdonhang>(entity =>
            {
                entity.HasKey(e => e.Mactdh);

                entity.ToTable("Chitietdonhang");

                entity.HasOne(d => d.MacayNavigation)
                    .WithMany(p => p.Chitietdonhangs)
                    .HasForeignKey(d => d.Macay)
                    .HasConstraintName("FK_Chitietdonhang_Cay");

                entity.HasOne(d => d.MadhNavigation)
                    .WithMany(p => p.Chitietdonhangs)
                    .HasForeignKey(d => d.Madh)
                    .HasConstraintName("FK_Chitietdonhang_DonHang1");
            });

            modelBuilder.Entity<CthoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.Mactdhn);

                entity.ToTable("CTHoaDonNhap");

                entity.Property(e => e.Donvi).HasMaxLength(50);

                entity.HasOne(d => d.MahdnNavigation)
                    .WithMany(p => p.CthoaDonNhaps)
                    .HasForeignKey(d => d.Mahdn)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CTHoaDonNhap_HoaDonNhap");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.Madh);

                entity.ToTable("DonHang");

                entity.Property(e => e.Ghichu).HasMaxLength(50);

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DonHang_KhachHang");
            });

            modelBuilder.Entity<GiaCay>(entity =>
            {
                entity.HasKey(e => e.MaGiaSanPham);

                entity.ToTable("GiaCay");

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");

                entity.HasOne(d => d.MaCayNavigation)
                    .WithMany(p => p.GiaCays)
                    .HasForeignKey(d => d.MaCay)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_GiaCay_Cay");
            });

            modelBuilder.Entity<HoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaHdn);

                entity.ToTable("HoaDonNhap");

                entity.Property(e => e.MaHdn).HasColumnName("MaHDN");

                entity.Property(e => e.Ghichu).HasMaxLength(250);

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.Property(e => e.SoHoaDon)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HoaDonXuat>(entity =>
            {
                entity.HasKey(e => e.MaHoaDonXuat);

                entity.ToTable("HoaDonXuat");

                entity.Property(e => e.NgayXuat).HasColumnType("date");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.HoaDonXuats)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_HoaDonXuat_NhanVien");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.Makhachhang);

                entity.ToTable("KhachHang");

                entity.Property(e => e.Diachi).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Tenkhachhang).HasMaxLength(50);
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.HasKey(e => e.Makho);

                entity.ToTable("Kho");
            });

            modelBuilder.Entity<LoaiCay>(entity =>
            {
                entity.HasKey(e => e.MaLoaiCay);

                entity.ToTable("LoaiCay");

                entity.Property(e => e.AnhLoaiCay).HasMaxLength(50);

                entity.Property(e => e.TenLoaiCay)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MaMenu);

                entity.ToTable("Menu");

                entity.Property(e => e.MaMenu).ValueGeneratedNever();

                entity.Property(e => e.TenMenu).HasMaxLength(250);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCungCap);

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenNhaCungCap).HasMaxLength(250);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.Manv);

                entity.ToTable("NhanVien");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gioitinh).HasMaxLength(50);

                entity.Property(e => e.Ngaysinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Tennv).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.AnhDaiDien).HasMaxLength(50);

                entity.Property(e => e.DiaChi).IsRequired();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(50);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
