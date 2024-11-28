using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string TenSp { get; set; } = null!;

    public string? Hang { get; set; }

    public string? Dvt { get; set; }

    public double? Gia { get; set; }

    public string? MoTa { get; set; }

    public string? Hinh { get; set; }

    public int? Slsp { get; set; }

    public string? MaLsp { get; set; }

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ICollection<ChiTietGiamGium> ChiTietGiamGia { get; set; } = new List<ChiTietGiamGium>();

    public virtual ICollection<CtPhieuNhap> CtPhieuNhaps { get; set; } = new List<CtPhieuNhap>();

    public virtual ICollection<CtSanPham> CtSanPhams { get; set; } = new List<CtSanPham>();

    public virtual LoaiSanPham? MaLspNavigation { get; set; }
}
