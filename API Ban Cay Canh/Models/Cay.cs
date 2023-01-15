using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class Cay
    {
        public Cay()
        {
            ChiTietAnhCays = new HashSet<ChiTietAnhCay>();
            Chitietdonhangs = new HashSet<Chitietdonhang>();
            GiaCays = new HashSet<GiaCay>();
        }

        public int MaCay { get; set; }
        public string TenCay { get; set; }
        public int? SoLuong { get; set; }
        public string MoTaChiTiet { get; set; }
        public string MoTaNgan { get; set; }
        public string AnhTo { get; set; }
        public int? MaLoaiCay { get; set; }
        public int MaNhaCungCap { get; set; }

        public virtual LoaiCay MaLoaiCayNavigation { get; set; }
        public virtual ICollection<ChiTietAnhCay> ChiTietAnhCays { get; set; }
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual ICollection<GiaCay> GiaCays { get; set; }
    }
}
