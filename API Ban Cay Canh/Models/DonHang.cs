using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            Chitietdonhangs = new HashSet<Chitietdonhang>();
        }

        public int Madh { get; set; }
        public int? MaKhachHang { get; set; }
        public string Diachinhan { get; set; }
        public int? Tinhtrang { get; set; }
        public double? Thanhtien { get; set; }
        public string Ghichu { get; set; }
        public DateTime? NgayDat { get; set; }

        public virtual KhachHang MaKhachHangNavigation { get; set; }
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
    }
}
