using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class NhaCungCap
{
    public string MaNcc { get; set; } = null!;

    public string? TenNcc { get; set; }

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
}
