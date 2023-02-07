using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NAVY4U.Models;

namespace NAVY4U.Models
{
    public class Common
    {
        static DbContext db = new DbContext("name=BanHangOnlineEntities");
        /// <summary>
        /// Lấy danh sách tất cả sản phẩm
        /// </summary>
        /// <returns></returns>
        public static List<sanPham> getsanPhams()
        {
            return db.Set<sanPham>().ToList<sanPham>();
        }
        /// <summary>
        /// Lấy danh sách sản phẩm thuộc 1 loại hàng nào đó
        /// </summary>
        /// <param name="maLoai"></param>
        /// <returns></returns>
        public static List<sanPham> getsanPhamsById(int maLoai)
        {
            List<sanPham> sanPhams = new List<sanPham>();
            sanPhams = db.Set<sanPham>().Where(x => x.maLoai == maLoai).ToList<sanPham>();
            return sanPhams;
        }
        /// <summary>
        /// Lấy danh sách các loại hàng
        /// </summary>
        /// <returns></returns>
        public static List<loaiSP> getCategories()
        {
            return db.Set<loaiSP>().ToList<loaiSP>();
        }
        /// <summary>
        /// Lấy thông tin 1 sản phẩm dựa vào mã sản phẩm
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public static sanPham getsanPhamById(string maSP)
        {
            return db.Set<sanPham>().Find(maSP);
        }

        public static string getNameSanPhamById(string maSP)
        {
            return db.Set<sanPham>().Find(maSP).tenSP;
        }
        public static string getImageSanPhamById(string maSP)
        {
            return db.Set<sanPham>().Find(maSP).hinhDD;
        }
        /// <summary>
        /// Lấy ra n bài viết mới nhất từ database 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<baiViet> getBaiViet(int n)
        {
            List<baiViet> l = new List<baiViet>();
            BanHangOnlineEntities db = new BanHangOnlineEntities();
            l = db.baiViets.OrderByDescending(bv => bv.ngayDang).Take(n).ToList<baiViet>();
            return l;
        }
        /// <summary>
        /// Lấy ra tất cả bài viết từ database
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<baiViet> getBaiViet()
        {
            List<baiViet> l = new List<baiViet>();
            BanHangOnlineEntities db = new BanHangOnlineEntities();
            l = db.baiViets.OrderByDescending(bv => bv.ngayDang).ToList<baiViet>();
            return l;
        }
        public static List<donHang> GetDonHangs()
        {
            List<donHang> l = new List<donHang>();
            BanHangOnlineEntities db = new BanHangOnlineEntities();
            l = db.donHangs.OrderByDescending(bv => bv.ngayDat).ToList<donHang>();
            return l;
        }
        public static List<ctDonHang> GetCtDonHangs(string n)
        {
            List<ctDonHang> l = new List<ctDonHang>();
            BanHangOnlineEntities db = new BanHangOnlineEntities();
            l = db.ctDonHangs.Where(x => x.soDH == n).ToList<ctDonHang>();
            return l;
        }
    }
}