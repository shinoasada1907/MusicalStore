﻿using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface IGiamGiaRepository
    {
        public IEnumerable<MaGiamGia> GetAllMaGiamGia();
        public MaGiamGia GetMaGiamGia(string magiam);
    }
}
