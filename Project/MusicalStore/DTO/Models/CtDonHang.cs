using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models;

public partial class CtDonHang
{
    [Key]
    public string MaCtDh { get; set; }
    public string? MaDh { get; set; } = null!;

    public int SoLuong { get; set; }

    public double? Gia { get; set; }

    public double? Tong { get; set; }

    public string? MaSP { get; set; }

    public virtual DonHang MaDhNavigation { get; set; } = null!;
    public virtual SanPham MaSPNavigation { get; set; } = null!;
}
