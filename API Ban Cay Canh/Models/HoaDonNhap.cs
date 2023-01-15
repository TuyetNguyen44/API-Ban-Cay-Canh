using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class HoaDonNhap
    {
        public HoaDonNhap()
        {
            CthoaDonNhaps = new HashSet<CthoaDonNhap>();
        }

        public int MaHdn { get; set; }
        public int? Manv { get; set; }
        public DateTime? NgayNhap { get; set; }
        public int? MaNhaCungCap { get; set; }
        public string Ghichu { get; set; }
        public string SoHoaDon { get; set; }

        public virtual ICollection<CthoaDonNhap> CthoaDonNhaps { get; set; }
    }
}
