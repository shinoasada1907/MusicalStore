using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class PtThanhToan
{
    public string MaPttt { get; set; } = null!;

    [Column(TypeName = "nvarchar(200)")]
    public string? HinhThuc { get; set; }

    public string? Sdt { get; set; }

    public string? TenNhan { get; set; }

    public string? NganHang { get; set; }

    public string? Stk { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
