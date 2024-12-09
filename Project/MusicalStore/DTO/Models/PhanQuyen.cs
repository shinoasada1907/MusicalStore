using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class PhanQuyen
{
    public string MaPq { get; set; } = null!;
    [Column(TypeName = "nvarchar(150)")]
    public string? TenPq { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
