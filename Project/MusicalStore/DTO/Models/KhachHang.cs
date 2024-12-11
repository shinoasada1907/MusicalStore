using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    [Column(TypeName = "nvarchar(250)")]
    public string TenKh { get; set; } = null!;

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinhKh { get; set; }

    [Column(TypeName = "nvarchar(250)")]
    public string? DiaChi { get; set; }

    [Column(TypeName = "nvarchar(250)")]
    public string? AnhDaiDien { get; set; }

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
