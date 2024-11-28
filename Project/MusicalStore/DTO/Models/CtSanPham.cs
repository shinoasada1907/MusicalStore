using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class CtSanPham
{
    public string MaCtsp { get; set; } = null!;

    public string? GioiThieu { get; set; }

    public string? ThongSo { get; set; }

    public string? TinhNang { get; set; }

    public string? MaSp { get; set; }

    public virtual SanPham? MaSpNavigation { get; set; }
}
