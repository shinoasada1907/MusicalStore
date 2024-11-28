using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class CtDonHang
{
    public string MaDh { get; set; } = null!;

    public int SoLuong { get; set; }

    public double? Gia { get; set; }

    public double? Tong { get; set; }

    public virtual DonHang MaDhNavigation { get; set; } = null!;
}
