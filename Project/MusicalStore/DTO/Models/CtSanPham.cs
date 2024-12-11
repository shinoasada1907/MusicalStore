using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class CtSanPham
{
    public string? MaCtsp { get; set; } = null!;

    [Column(TypeName = "nvarchar(max)")]
    public string? GioiThieu { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? ThongSo { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? TinhNang { get; set; }
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
