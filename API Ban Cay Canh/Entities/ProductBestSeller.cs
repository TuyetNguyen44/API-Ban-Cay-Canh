using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Ban_Cay_Canh.Models;

namespace API_Ban_Cay_Canh.Entities
{
    public class ProductBestSeller
    {
        //public Cay cay { get; set; }
        //public GiaCay giacay { get; set; }
        //public Chitietdonhang chitietdonhang { get; set; }
        //public DonHang donhang { get; set; }
        public int MaCay { get; set; }
        public string TenCay { get; set; }
        public int? SoLuong { get; set; }
        public string MoTaChiTiet { get; set; }
        public string MoTaNgan { get; set; }
        public string AnhTo { get; set; }
        public int? MaLoaiCay { get; set; }
        public int MaNhaCungCap { get; set; }
        public int MaGiaSanPham { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public double? DonGia { get; set; }
    }
}
