using NAVY4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAVY4U.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(string tenSP)
        {
            BanHangOnlineEntities bh = new BanHangOnlineEntities();
            var pro = bh.sanPhams.Where(x => x.tenSP == tenSP).FirstOrDefault();
            return View(pro);
        }
        public ActionResult addToCart(string maSP)
        {
            CartShop gioHang = Session["GioHang"] as CartShop;
            gioHang.addItem(maSP);
            Session["GioHang"] = gioHang;
            return View("Index");
        }
    }
}