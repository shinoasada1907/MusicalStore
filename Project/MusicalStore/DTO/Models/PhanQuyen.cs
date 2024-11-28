using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PhanQuyen
{
    public string MaPq { get; set; } = null!;

    public string? TenPq { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
