﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO.Models;

public partial class CtPhieuNhap
{
    [Key]
    public string MaCtPn { get; set; }  = string.Empty;
    public string MaPn { get; set; } = null!;

    public string MaSp { get; set; } = null!;

    public int? Slnhap { get; set; }

    public double? GiaNhap { get; set; }

    public virtual PhieuNhap MaPnNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
