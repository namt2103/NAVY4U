using NAVY4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheFourthPractice.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string acc, string pass)
        {
            string mk = Security.encryption(pass);
            taiKhoanTV ttdn = new BanHangOnlineEntities()
                .taiKhoanTVs.Where(x => x.taiKhoan.Equals(acc.ToLower().Trim()) && x.matKhau.Equals(mk))
                .FirstOrDefault<taiKhoanTV>();
            bool isAuthentic = ttdn != null && ttdn.taiKhoan.Equals(acc.ToLower().Trim()) && ttdn.matKhau.Equals(mk);
            if (isAuthentic)
            {
                Session["TTDangNhap"] = ttdn;
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            return View();
        }
    }
}