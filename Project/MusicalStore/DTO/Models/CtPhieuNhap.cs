using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class CtPhieuNhap
{
    public string MaPn { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public int? Slnhap { get; set; }

    public double? GiaNhap { get; set; }

    public virtual PhieuNhap MaPnNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
