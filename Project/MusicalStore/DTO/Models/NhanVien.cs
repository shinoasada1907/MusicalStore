using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string TenNv { get; set; } = null!;

    public string? GioiTinh { get; set; }

    public string? DienThoai { get; set; }

    public string? Cccd { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? MaCv { get; set; }

    public virtual ChucVu? MaCvNavigation { get; set; }

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
