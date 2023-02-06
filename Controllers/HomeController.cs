using NAVY4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAVY4U.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addToCart(string maSP)
        {
            CartShop gioHang = Session["GioHang"] as CartShop;
            gioHang.addItem(maSP);
            Session["GioHang"] = gioHang;
            return View("Index");
        }
    }
}