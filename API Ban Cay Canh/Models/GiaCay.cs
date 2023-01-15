using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class GiaCay
    {
        public int? MaCay { get; set; }
        public int MaGiaSanPham { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public double? DonGia { get; set; }

        public virtual Cay MaCayNavigation { get; set; }
    }
}
