using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class PhieuNhap
{
    public string MaPn { get; set; } = null!;

    public DateOnly? NgayLap { get; set; }

    public DateOnly? NgayXuat { get; set; }

    public string? MaNcc { get; set; }

    public string? MaNv { get; set; }

    public virtual ICollection<CtPhieuNhap> CtPhieuNhaps { get; set; } = new List<CtPhieuNhap>();

    public virtual NhaCungCap? MaNccNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }
}
