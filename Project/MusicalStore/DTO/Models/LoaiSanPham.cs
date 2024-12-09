using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class LoaiSanPham
{
    public string MaLsp { get; set; } = null!;

    [Column(TypeName = "nvarchar(150)")]
    public string TenLsp { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
