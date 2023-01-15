using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDonXuats = new HashSet<HoaDonXuat>();
        }

        public int Manv { get; set; }
        public string Tennv { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Gioitinh { get; set; }
        public string Quequan { get; set; }
        public DateTime? Ngaysinh { get; set; }

        public virtual ICollection<HoaDonXuat> HoaDonXuats { get; set; }
    }
}
