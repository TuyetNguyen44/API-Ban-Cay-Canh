using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int Makhachhang { get; set; }
        public string Tenkhachhang { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }


        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
