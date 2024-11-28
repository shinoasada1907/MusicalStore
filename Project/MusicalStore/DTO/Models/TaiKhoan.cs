using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class TaiKhoan
{
    public string MaTk { get; set; } = null!;

    public string TenTk { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? Email { get; set; }

    public string? MaKh { get; set; }

    public string? MaNv { get; set; }

    public string? MaPq { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual PhanQuyen? MaPqNavigation { get; set; }
}
