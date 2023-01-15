using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class LoaiCay
    {
        public LoaiCay()
        {
            Cays = new HashSet<Cay>();
        }

        public int MaLoaiCay { get; set; }
        public string TenLoaiCay { get; set; }
        public string AnhLoaiCay { get; set; }

        public virtual ICollection<Cay> Cays { get; set; }
    }
}
