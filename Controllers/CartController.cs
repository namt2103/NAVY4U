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
            ViewData["Cart"] = gioHang;
            return View();
        }
    }
}