using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class TinhTrang
{
    public int MaTt { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string TenTt { get; set; } = null!;

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
