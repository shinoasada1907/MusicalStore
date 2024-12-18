using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    [Column(TypeName = "nvarchar(250)")]

    public string TenSp { get; set; } = null!;

    public string? Hang { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public string? Dvt { get; set; }

    public double? Gia { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? MoTa { get; set; }

    public string? MaCtsp { get; set; }

    public string? Hinh { get; set; }

    public int? Slsp { get; set; }

    public string? MaLsp { get; set; }

    public string? MaCtGiamGia { get; set; }

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ICollection<ChiTietGiamGia> ChiTietGiamGia { get; set; } = new List<ChiTietGiamGia>();

    public virtual ICollection<CtPhieuNhap> CtPhieuNhaps { get; set; } = new List<CtPhieuNhap>();
    public virtual ICollection<CtDonHang> CtDonHangs { get; set; } = new List<CtDonHang>();

    public virtual LoaiSanPham? MaLspNavigation { get; set; }

    public virtual CtSanPham? MaCTSPNavigation { get; set; }

    public virtual ChiTietGiamGia? MaCtGiamGiaNavigation { get; set; }
}
