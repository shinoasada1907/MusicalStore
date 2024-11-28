using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class PtThanhToan
{
    public string MaPttt { get; set; } = null!;

    public string? HinhThuc { get; set; }

    public string? Sdt { get; set; }

    public string? TenNhan { get; set; }

    public string? NganHang { get; set; }

    public string? Stk { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
