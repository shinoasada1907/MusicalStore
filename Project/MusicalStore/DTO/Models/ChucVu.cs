using System;
using System.Collections.Generic;

namespace DTO.Models;

public partial class ChucVu
{
    public string MaCv { get; set; } = null!;

    public string? TenCv { get; set; }

    public int? MucLuong { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
