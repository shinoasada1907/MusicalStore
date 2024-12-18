using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    [Column(TypeName = "nvarchar(250)")]
    public string TenNv { get; set; } = null!;

    [Column(TypeName = "nvarchar(10)")]
    public string? GioiTinh { get; set; }

    public string? DienThoai { get; set; }

    public string? Cccd { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? MaCv { get; set; }

    public virtual ChucVu? MaCvNavigation { get; set; }

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
