using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NAVY4U.Models;

namespace TheFourthPractice.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Admin/Order
        private static BanHangOnlineEntities database = new BanHangOnlineEntities();
        private static bool daDuyet;
        public ActionResult ListOrder(string IsActive)
        {
            if (string.IsNullOrEmpty(IsActive))
            {
                ModelState.AddModelError("", "You need enter the product title");
                return View();
            }
            try
            {
                daDuyet = IsActive.Equals("1");
                getListProduct();
                return View();
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", exception.Message);
                return View();

            }
        }
        private void getListProduct()
        {
            //List<donHang> l = database.donHangs.Where(x => x.ACTIVATED == daDuyet).ToList<donHang>();

            //ViewData["ListOrder"] = l;
            List<donHang> g = database.donHangs.ToList<donHang>();
            ViewData["ListOrder"] = g;

            ViewBag.ActiveOrHide = daDuyet ? "Hide" : "Active";
        }
    }
}