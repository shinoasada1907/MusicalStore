using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class TaiKhoan
{
    [Required]
    public string MaTk { get; set; } = null!;

    [Column(TypeName = "nvarchar(250)")]
    public string TenTk { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? Email { get; set; } = string.Empty;

    public string? MaKh { get; set; }

    public string? MaNv { get; set; } 

    public string? MaPq { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual PhanQuyen? MaPqNavigation { get; set; }
}
