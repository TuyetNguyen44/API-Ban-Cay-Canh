using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class CthoaDonNhap
    {
        public int Mactdhn { get; set; }
        public int? Mahdn { get; set; }
        public int? Soluong { get; set; }
        public int? MaCay { get; set; }
        public string Donvi { get; set; }
        public double? DonGiaNhap { get; set; }

        public virtual HoaDonNhap MahdnNavigation { get; set; }
    }
}
