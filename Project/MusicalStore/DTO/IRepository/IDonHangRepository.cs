﻿using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface IDonHangRepository
    {
        public IEnumerable<DonHang> GetListDonHang();
        public IEnumerable<DonHang> GetListDonHangKhachHang(string makh);
        public Task<DonHang> KhoiTaoDonHang(DonHang donHang);
        public Task<IEnumerable<DonHang>> CapNhatTrangThaiDonHang(string makh, string madh, int trangthai);
        public DonHang GetDonHangById(string id);
        public IEnumerable<DonHang> GetDonHangTrangThai(string makh, int trangthai);
    }
}
