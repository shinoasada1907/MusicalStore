using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class NhaCungCap
{
    public string MaNcc { get; set; } = null!;

    [Column(TypeName = "nvarchar(250)")]
    public string? TenNcc { get; set; }

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
}
