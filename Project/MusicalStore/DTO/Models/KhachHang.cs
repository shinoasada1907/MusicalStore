using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string TenKh { get; set; } = null!;

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinhKh { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
