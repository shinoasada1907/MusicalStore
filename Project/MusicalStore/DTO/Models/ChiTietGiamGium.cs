using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class ChiTietGiamGium
{
    public DateOnly? NgayBd { get; set; }

    public DateOnly? NgayKt { get; set; }

    public string MaSp { get; set; } = null!;

    public string MaGg { get; set; } = null!;

    public virtual MaGiamGium MaGgNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
