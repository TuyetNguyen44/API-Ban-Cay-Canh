using System;
using System.Collections.Generic;

#nullable disable

namespace API_Ban_Cay_Canh.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public int? UserId { get; set; }
        public string AccountName { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string TrangThai { get; set; }
        public string LoaiQuyen { get; set; }
        public string MatKhau { get; set; }

        public virtual User User { get; set; }
    }
}
