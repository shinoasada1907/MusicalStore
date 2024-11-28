using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class LoaiSanPham
{
    public string MaLsp { get; set; } = null!;

    public string TenLsp { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
