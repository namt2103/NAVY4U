using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAVY4U.Models;

namespace NAVY4U.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet]
        public ActionResult Index()
        {
            CartShop gioHang = Session["GioHang"] as CartShop;
            Session["GioHang"] = gioHang;
            return View();
        }
        public ActionResult Increase(string maSP)
        {
            CartShop gioHang = Session["GioHang"] as CartShop;
            gioHang.addItem(maSP);
            Session["GioHang"] = gioHang;
            return RedirectToAction("Index");
        }
        public ActionResult Decrease(string maSP)
        {
            CartShop gioHang = Session["GioHang"] as CartShop;
            gioHang.decreaseItem(maSP);
            Session["GioHang"] = gioHang;
            return RedirectToAction("Index");
        }
        public ActionResult RemoveTtem(string masp)
        {
            CartShop gioHang = Session["GioHang"] as CartShop;
            gioHang.deleteItem(masp);
            Session["GioHang"] = gioHang;
            return RedirectToAction("Index");
        }
    }
}