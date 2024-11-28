using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class TinhTrang
{
    public int MaTt { get; set; }

    public string TenTt { get; set; } = null!;

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
