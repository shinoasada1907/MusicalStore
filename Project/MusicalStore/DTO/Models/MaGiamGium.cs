using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class MaGiamGium
{
    public string MaGg { get; set; } = null!;

    public int? GiaTriGiam { get; set; }

    public string? ChiTiet { get; set; }

    public virtual ICollection<ChiTietGiamGium> ChiTietGiamGia { get; set; } = new List<ChiTietGiamGium>();
}
