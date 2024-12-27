﻿namespace DTO.Models;

public partial class DonHang
{
    public string MaDh { get; set; } = null!;

    public double TongTienHang { get; set; }

    public DateOnly NgayLap { get; set; }
    public string? MaKh { get; set; }

    public int? MaTt { get; set; }

    public string? MaPttt { get; set; }

    public virtual ICollection<CtDonHang> CtDonHangs { get; set; } = new List<CtDonHang>();

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual PtThanhToan? MaPtttNavigation { get; set; }

    public virtual TinhTrang? MaTtNavigation { get; set; }
}
