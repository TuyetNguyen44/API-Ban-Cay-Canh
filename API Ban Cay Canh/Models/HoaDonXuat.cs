using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class HoaDonXuat
    {
        public HoaDonXuat()
        {
            ChiTietHoaDonXuats = new HashSet<ChiTietHoaDonXuat>();
        }

        public int MaHoaDonXuat { get; set; }
        public int SoHoaDon { get; set; }
        public DateTime? NgayXuat { get; set; }
        public int MaKhachHang { get; set; }
        public int? Manv { get; set; }

        public virtual NhanVien ManvNavigation { get; set; }
        public virtual ICollection<ChiTietHoaDonXuat> ChiTietHoaDonXuats { get; set; }
    }
}
