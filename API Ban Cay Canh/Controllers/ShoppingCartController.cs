using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Ban_Cay_Canh.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Ban_Cay_Canh.Controllers
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        public BanCayCanhContext db = new BanCayCanhContext();

        // GET: ShoppingCartController
        public class GioHang
        {
            public KhachHang customer { get; set; }
            public List<Chitietdonhang> cart { get; set; }
            public DonHang order { get; set; }
        }
        [HttpPost]
        [Route("SavePayment")]
        public ActionResult AddProduct([FromBody] GioHang c)
        {

            db.KhachHangs.Add(c.customer);
            _ =db.SaveChanges();
            int idcustomer = c.customer.Makhachhang;
            DonHang dh = new DonHang();
            dh.MaKhachHang = idcustomer;
            dh.Diachinhan = c.customer.Diachi;
            dh.Thanhtien = c.order.Thanhtien;
            dh.Ghichu = c.order.Ghichu;
            dh.Tinhtrang = c.order.Tinhtrang;
            dh.NgayDat = System.DateTime.Now;
            db.DonHangs.Add(dh);
            db.SaveChanges();
            int madh = dh.Madh;
            
            if (c.cart.Count > 0)
            {
                foreach (var item in c.cart)
                {
                    item.Madh = madh;
                    db.Chitietdonhangs.Add(item);
                }
                db.SaveChanges();
            }

            return Ok(new { data = "OK" });
        }

    }
}
