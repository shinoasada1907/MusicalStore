using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class MaGiamGia
{
    public string MaGg { get; set; } = null!;

    public int? GiaTriGiam { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? ChiTiet { get; set; }

    public virtual ICollection<ChiTietGiamGia> ChiTietGiamGia { get; set; } = new List<ChiTietGiamGia>();
}
