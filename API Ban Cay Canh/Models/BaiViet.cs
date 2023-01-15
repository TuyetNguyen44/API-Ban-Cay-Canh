using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class BaiViet
    {
        public int Mabaiviet { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public DateTime? Ngaydang { get; set; }
        public int? Manv { get; set; }
        public string Anhbaiviet { get; set; }
    }
}
