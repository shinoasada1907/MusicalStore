using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class ChucVu
{
    public string MaCv { get; set; } = null!;

    [Column(TypeName = "nvarchar(200)")]
    public string? TenCv { get; set; }

    public int? MucLuong { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
