using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Ban_Cay_Canh.Models;
namespace API_Ban_Cay_Canh.Controllers
{
    public class LoaiCayController : Controller
    {
        // GET: LoaiCayController
        public BanCayCanhContext db = new BanCayCanhContext();
        [HttpGet]
        [Route("api/LoaiCay/Get")]
        public List<LoaiCay> Get()
        {
            return db.LoaiCays.ToList();
        }

        // GET: LoaiCayController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoaiCayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiCayController/Create
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

        // GET: LoaiCayController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoaiCayController/Edit/5
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

        // GET: LoaiCayController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoaiCayController/Delete/5
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
