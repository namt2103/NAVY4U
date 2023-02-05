using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAVY4U.Models;

namespace TheFourthPractice.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private static BanHangOnlineEntities db= new BanHangOnlineEntities();
        // GET: Admin/Articles
        [HttpGet]
        public ActionResult Index()
        {
            CapNhatDuLieuChoGiaoDien();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string maBaiViet)
        {
            // B1: Dùng lệnh để xóa bài viết dựa vào mã bài viết
            // B2: Cập nhật database 
            // B3: Hiển thị lại danh sách sau khi xóa
            CapNhatDuLieuChoGiaoDien();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Active(string maBaiViet)
        {
            // B1: Dùng lệnh để cấm bài viết dựa vào mã bài viết
            // B2: Cập nhật database 
            // B3: Hiển thị lại danh sách sau khi xóa 
            CapNhatDuLieuChoGiaoDien();
            return View("Index");
        }
        /// <summary>
        /// Hàm phục vụ cho mục tiêu cập nhật dữ liệu cho View của Controller này thông qua ViewData object
        /// 
        /// </summary>
        private void CapNhatDuLieuChoGiaoDien()
        {
            List<baiViet> l = db.baiViets.Where(x => x.daDuyet == true).ToList<baiViet>();
            ViewData["DanhSachBV"] = l;
        }
    }
}