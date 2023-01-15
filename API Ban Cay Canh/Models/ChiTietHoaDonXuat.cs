using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class ChiTietHoaDonXuat
    {
        public int MaCthoaDonXuat { get; set; }
        public int? MaHoaDonXuat { get; set; }
        public int? MaCay { get; set; }
        public int? Soluong { get; set; }
        public double? GiaBan { get; set; }
        public double? ChietKhau { get; set; }

        public virtual HoaDonXuat MaHoaDonXuatNavigation { get; set; }
    }
}
