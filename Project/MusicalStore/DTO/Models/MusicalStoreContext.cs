using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DTO.Models;

public partial class MusicalStoreContext : DbContext
{
    public MusicalStoreContext()
    {
    }

    public MusicalStoreContext(DbContextOptions<MusicalStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BinhLuan> BinhLuans { get; set; }

    public virtual DbSet<ChiTietGiamGia> ChiTietGiamGia { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<CtDonHang> CtDonHangs { get; set; }

    public virtual DbSet<CtPhieuNhap> CtPhieuNhaps { get; set; }

    public virtual DbSet<CtSanPham> CtSanPhams { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<MaGiamGia> MaGiamGia { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<PtThanhToan> PtThanhToans { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TinhTrang> TinhTrangs { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JDRMAPE;Initial Catalog=MusicalStore;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BinhLuan>(entity =>
        {
            entity.HasKey(e => new { e.MaKh, e.MaSp }).HasName("PK__BINH_LUA__F5579F9FC6E17241");

            entity.ToTable("BINH_LUAN");

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.NoiDung)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.BinhLuans)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BINH_LUAN__MaKH__5DCAEF64");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.BinhLuans)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BINH_LUAN__MaSP__5EBF139D");
        });

        modelBuilder.Entity<ChiTietGiamGia>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.MaGg }).HasName("PK__CHI_TIET__155752F40C7EF9D8");

            entity.ToTable("CHI_TIET_GIAM_GIA");

            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.MaGg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaGG");
            entity.Property(e => e.NgayBd).HasColumnName("NgayBD");
            entity.Property(e => e.NgayKt).HasColumnName("NgayKT");

            entity.HasOne(d => d.MaGgNavigation).WithMany(p => p.ChiTietGiamGia)
                .HasForeignKey(d => d.MaGg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_G__MaGG__5165187F");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietGiamGia)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CHI_TIET_G__MaSP__5070F446");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("PK__CHUC_VU__27258E763D8D5847");

            entity.ToTable("CHUC_VU");

            entity.Property(e => e.MaCv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaCV");
            entity.Property(e => e.TenCv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<CtDonHang>(entity =>
        {
            entity.HasKey(e => new { e.MaCtDh }).HasName("PK__CT_DON_H__52737C6725ADE823");

            entity.ToTable("CT_DON_HANG");

            entity.Property(e => e.MaSP)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSP");

            entity.HasOne(d => d.MaSPNavigation).WithMany(p => p.CtDonHangs)
                .HasForeignKey(d => d.MaSP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SAN__PHAM__MaSP__5AEE82B9");

            entity.Property(e => e.MaDh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaDH");

            entity.HasOne(d => d.MaDhNavigation).WithMany(p => p.CtDonHangs)
                .HasForeignKey(d => d.MaDh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CT_DON_HAN__MaDH__5AEE82B9");
        });

        modelBuilder.Entity<CtPhieuNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaPn, e.MaSp }).HasName("PK__CT_PHIEU__F557B7712CD9316A");

            entity.ToTable("CT_PHIEU_NHAP");

            entity.Property(e => e.MaPn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaPN");
            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.Slnhap).HasColumnName("SLNhap");

            entity.HasOne(d => d.MaPnNavigation).WithMany(p => p.CtPhieuNhaps)
                .HasForeignKey(d => d.MaPn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CT_PHIEU_N__MaPN__6754599E");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.CtPhieuNhaps)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CT_PHIEU_N__MaSP__68487DD7");
        });

        modelBuilder.Entity<CtSanPham>(entity =>
        {
            entity.HasKey(e => e.MaCtsp).HasName("PK__CT_SAN_P__1E4FCECD0651B758");

            entity.ToTable("CT_SAN_PHAM");

            entity.Property(e => e.MaCtsp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCTSP");
            entity.Property(e => e.GioiThieu)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ThongSo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TinhNang)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDh).HasName("PK__DON_HANG__2725866136FFA2BC");

            entity.ToTable("DON_HANG");

            entity.Property(e => e.MaDh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaDH");
            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaPttt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaPTTT");
            entity.Property(e => e.MaTt).HasColumnName("MaTT");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__DON_HANG__MaKH__5629CD9C");

            entity.HasOne(d => d.MaPtttNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaPttt)
                .HasConstraintName("FK__DON_HANG__MaPTTT__5812160E");

            entity.HasOne(d => d.MaTtNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaTt)
                .HasConstraintName("FK__DON_HANG__MaTT__571DF1D5");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KHACH_HA__2725CF1E1C748EF7");

            entity.ToTable("KHACH_HANG");

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.NgaySinhKh).HasColumnName("NgaySinhKH");
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.MaLsp).HasName("PK__LOAI_SAN__3B983FFE73DE8B14");

            entity.ToTable("LOAI_SAN_PHAM");

            entity.Property(e => e.MaLsp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaLSP");
            entity.Property(e => e.TenLsp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TenLSP");
        });

        modelBuilder.Entity<MaGiamGia>(entity =>
        {
            entity.HasKey(e => e.MaGg).HasName("PK__MA_GIAM___2725AE8263AD34E0");

            entity.ToTable("MA_GIAM_GIA");

            entity.Property(e => e.MaGg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaGG");
            entity.Property(e => e.ChiTiet)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NHA_CUNG__3A185DEB0EC52CBD");

            entity.ToTable("NHA_CUNG_CAP");

            entity.Property(e => e.MaNcc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNCC");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NHAN_VIE__2725D70A836C3D7B");

            entity.ToTable("NHAN_VIEN");

            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.DienThoai)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.MaCv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaCV");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TenNV");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaCv)
                .HasConstraintName("FK__NHAN_VIEN__MaCV__3B75D760");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => e.MaPq).HasName("PK__PHAN_QUY__2725E7F37E0A52DF");

            entity.ToTable("PHAN_QUYEN");

            entity.Property(e => e.MaPq)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaPQ");
            entity.Property(e => e.TenPq)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TenPQ");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaPn).HasName("PK__PHIEU_NH__2725E7F0F32683B7");

            entity.ToTable("PHIEU_NHAP");

            entity.Property(e => e.MaPn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaPN");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNCC");
            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNV");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK__PHIEU_NHA__MaNCC__6383C8BA");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__PHIEU_NHAP__MaNV__6477ECF3");
        });

        modelBuilder.Entity<PtThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaPttt).HasName("PK__PT_THANH__B30A28028AF8FF85");

            entity.ToTable("PT_THANH_TOAN");

            entity.Property(e => e.MaPttt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaPTTT");
            entity.Property(e => e.HinhThuc)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NganHang)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Sdt)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Stk)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STK");
            entity.Property(e => e.TenNhan)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SAN_PHAM__2725081C89E7C261");

            entity.ToTable("SAN_PHAM");

            entity.Property(e => e.MaSp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaSP");
            entity.Property(e => e.Dvt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DVT");
            entity.Property(e => e.Hang)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Hinh)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaLsp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaLSP");
            entity.Property(e => e.MoTa)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Slsp).HasColumnName("SLSP");
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TenSP");
            entity.Property(e => e.MaCtsp).HasMaxLength(20).IsUnicode(false).HasColumnName("MaCTSP");
            entity.HasOne(d => d.MaCTSPNavigation).WithMany(p=>p.SanPhams).HasForeignKey(d=>d.MaCtsp).HasConstraintName("FK__CT__SAN_PHAM__MaCTSP");

            entity.HasOne(d => d.MaLspNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLsp)
                .HasConstraintName("FK__SAN_PHAM__MaLSP__48CFD27E");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTk).HasName("PK__TAI_KHOA__2725007095687E5D");

            entity.ToTable("TAI_KHOAN");

            entity.Property(e => e.MaTk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaTK");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.MaPq)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MaPQ");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenTk)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TenTK");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__TAI_KHOAN__MaKH__403A8C7D");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__TAI_KHOAN__MaNV__412EB0B6");

            entity.HasOne(d => d.MaPqNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaPq)
                .HasConstraintName("FK__TAI_KHOAN__MaPQ__4222D4EF");
        });

        modelBuilder.Entity<TinhTrang>(entity =>
        {
            entity.HasKey(e => e.MaTt).HasName("PK__TINH_TRA__272500792636AA7B");

            entity.ToTable("TINH_TRANG");

            entity.Property(e => e.MaTt)
                .ValueGeneratedNever()
                .HasColumnName("MaTT");
            entity.Property(e => e.TenTt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TenTT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
