using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class Chitietdonhang
    {
        public int Soluong { get; set; }
        public double Dongia { get; set; }
        public int Macay { get; set; }
        public int Madh { get; set; }
        public int Mactdh { get; set; }

        public virtual Cay MacayNavigation { get; set; }
        public virtual DonHang MadhNavigation { get; set; }
    }
}
