using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class ChiTietAnhCay
    {
        public string MaChiTietAnh { get; set; }
        public int MaCay { get; set; }
        public string Anh { get; set; }

        public virtual Cay MaCayNavigation { get; set; }
    }
}
