using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Models;

public partial class GioHang
{
    public string MaGh { get; set; } = null!;

    [Column(TypeName = "nvarchar(250)")]
    public string MaKh { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public int SoLuong { get; set; } = 0;
    public double? Gia { get; set; } // Giá sản phẩm (Gia)

}
