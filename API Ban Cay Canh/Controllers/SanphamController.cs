using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using API_Ban_Cay_Canh.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API_Ban_Cay_Canh.Entities;

namespace API_Ban_Cay_Canh.Controllers
{
    public class SanphamController : Controller
    {
        public BanCayCanhContext db = new BanCayCanhContext();
        // GET: SanphamController
        [HttpGet]
        [Route("api/Cay/Get")] ///
        public IActionResult Get()
        {
            var result = from cay in db.Cays join loaicay in db.LoaiCays on cay.MaLoaiCay equals loaicay.MaLoaiCay join giacay in db.GiaCays on cay.MaCay equals giacay.MaCay
                         select new
                         {
                             macay=cay.MaCay,
                             tencay = cay.TenCay,
                             giacay=giacay.DonGia,
                             loaicay=loaicay.TenLoaiCay,
                             anhloaicay=loaicay.AnhLoaiCay,
                             anhto=cay.AnhTo,
                             motangan=cay.MoTaNgan, 
                             maloaicay=loaicay.MaLoaiCay

                            
                         };
            return Ok(result);
        }
        [HttpGet]
        [Route("api/Cay/Get-Best-Seller")]
        public async Task<ActionResult<List<object>>> GetBestSeller()
        {
            var bestTree = db.Cays.FromSqlRaw<Cay>("exec GetBestSeller").ToList();
            var query = from c in bestTree
                        join g in db.GiaCays on c.MaCay equals g.MaCay
                        select new { c.MaCay, c.TenCay,c.MoTaChiTiet,c.MoTaNgan,c.MaLoaiCay, c.MaNhaCungCap,c.AnhTo , g.DonGia};
            var result = query.ToList();
            return Ok(result);
            //return Ok(bestTree.ToList());
         

        }

        [Route("api/Cay/get-by-id/{id}")]
        [HttpGet]
        public IActionResult GetById(int id)

        {
            var kq = from cay in db.Cays
                     join loaicay in db.LoaiCays on cay.MaLoaiCay equals loaicay.MaLoaiCay
                     join giacay in db.GiaCays on cay.MaCay equals giacay.MaCay
                     select new { cay.MaCay, cay.TenCay, cay.MoTaChiTiet, cay.MoTaNgan, giacay.DonGia, cay.AnhTo, loaicay.TenLoaiCay };
            var result = kq.Select(x => new { x.MaCay, x.TenCay, x.AnhTo, x.DonGia, x.MoTaChiTiet, x.MoTaNgan, x.TenLoaiCay }).Where(s => s.MaCay == id).FirstOrDefault();
            return Ok(result);


        }
        [Route("api/Cay/Search/{key}")]
        [HttpGet]
        public IActionResult Search(string key)
        {


            var kq = from cay in db.Cays
                     join loaicay in db.LoaiCays on cay.MaLoaiCay equals loaicay.MaLoaiCay
                     join giacay in db.GiaCays on cay.MaCay equals giacay.MaCay
                     select new
                     {
                         macay = cay.MaCay,
                         tencay = cay.TenCay,
                         giacay = giacay.DonGia,
                         loaicay = loaicay.TenLoaiCay,
                         anhloaicay = loaicay.AnhLoaiCay,
                         anhto = cay.AnhTo,
                         motangan = cay.MoTaNgan,
                         maloaicay = loaicay.MaLoaiCay,
                         motachitiet=cay.MoTaChiTiet
                     };
            var result = kq.Select(x => new { x.macay, x.tencay, x.anhto, x.giacay, x.motangan, x.motachitiet, x.loaicay }).Where(s => s.tencay.Contains(key)||key=="");
            return Ok(result);
        }
        [HttpGet]

        [Route("api/Cay/GetBySoLuong")]

        public IActionResult GetBySoLuong()
        {
            try
            {
                var kq = from cay in db.Cays
                         join loaicay in db.LoaiCays on cay.MaLoaiCay equals loaicay.MaLoaiCay
                         join giacay in db.GiaCays on cay.MaCay equals giacay.MaCay
                         select new { cay.MaCay, cay.TenCay, cay.MoTaChiTiet, cay.MoTaNgan, giacay.DonGia, cay.AnhTo, loaicay.TenLoaiCay, cay.SoLuong };
                var result = kq.Select(x => new { x.MaCay, x.TenCay, x.AnhTo, x.DonGia, x.TenLoaiCay, x.SoLuong }).OrderByDescending(s => s.SoLuong).Take(4).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok("Err");
            }



        }


        [Route("api/Cay/getbycateid/{id}")]
        [HttpGet]
        public IActionResult GetByCateId(int id)
        {
            var a = from cay in db.Cays
                     join loaicay in db.LoaiCays on cay.MaLoaiCay equals loaicay.MaLoaiCay
                     join giacay in db.GiaCays on cay.MaCay equals giacay.MaCay
                     select new { cay.MaCay, cay.TenCay, giacay.DonGia, cay.AnhTo, loaicay.TenLoaiCay, loaicay.MaLoaiCay };
            var result = a.Select(x => new { x.TenCay, x.AnhTo, x.DonGia, x.TenLoaiCay, x.MaLoaiCay }).Where(s => s.MaLoaiCay == id).ToList();
            return Ok(result);

        }
        //[HttpGet]
        //[Route("api/Customer/Get/{id}")]
        //public KhachHang Get(int id)
        //{
        //    return db.KhachHangs.SingleOrDefault(c => c.Makhachhang== id);
        //}
        //[HttpGet]
        //[Route("api/Customer/Login/")]
        //public List<KhachHang> Login(string username, string pass)
        //{

        //    return db.KhachHangs.Where(item => item.UserName == username && item.Password == pass).ToList();

        //}
        //[HttpPost]
        //[Route("api/ Customer/Register")]
        //public List<KhachHang> Post([FromBody] KhachHang kh)
        //{
        //    db.KhachHangs.Add(kh);
        //    db.SaveChanges();
        //    return db.KhachHangs.ToList();

        //}
        // GET: SanphamController/Create
        public ActionResult Create()
        {
            return View();  
        }

        // POST: SanphamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanphamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SanphamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanphamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SanphamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
