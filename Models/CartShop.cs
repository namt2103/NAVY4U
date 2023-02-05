using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAVY4U.Models
{
    public class CartShop
    {
        public string MaKH { get; set; }
        public string taiKhoan { get; set; }
        public string diaChi { get; set; }
        public DateTime ngayDat { get; set; }
        public DateTime ngayGiao { get; set;}
        public SortedList<string, ctDonHang> productsCart { get; set; }
        public CartShop()
        {
            this.MaKH = "";
            this.taiKhoan = "";
            this.diaChi = "";
            this.ngayDat = DateTime.Now;
            this.ngayGiao = DateTime.Now.AddDays(3);
            this.productsCart = new SortedList<string, ctDonHang>();
        }

        /// <summary>
        /// Kiểm tra giỏ hàng đã chọn sản phẩm nào chưa
        /// </summary>
        /// <returns>true/false</returns>
        public bool IsEmpty()
        {
            return (productsCart.Keys.Count == 0);
        }
        /// <summary>
        /// Phương thức thêm sản phẩm vào giỏ hàng
        /// </summary>
        /// <param name="maSP"></param>
        public void addItem(string maSP)
        {
            if(productsCart.Keys.Contains(maSP))
            {
                ctDonHang x = productsCart.Values[productsCart.IndexOfKey(maSP)];
                x.soLuong++;
                updateOneItem(x);
            }
            else
            {
                // Tạo 1 giỏ hàng mới
                ctDonHang i = new ctDonHang();

                // Cập nhật thông tin hiện hành cho đối tượng
                i.maSP = maSP;
                i.soLuong = 1;

                // Lấy giá bán / giảm giá từ bảng sanPham
                sanPham s = Common.getsanPhamById(i.maSP);
                i.giaBan = s.giaBan;
                i.giamGia = s.giamGia;

                // Thêm sản phẩm vào giỏ hàng
                productsCart.Add(maSP, i);
            }
        }
        /// <summary>
        /// Cập nhật thêm sp trong giỏ hàng
        /// </summary>
        /// <param name="x"></param>
        public void updateOneItem(ctDonHang x)
        {
            this.productsCart.Remove(x.maSP);
            this.productsCart.Add(x.maSP, x);
        }
        /// <summary>
        /// Phương thức xoá sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="maSP"></param>
        public void deleteItem(string maSP)
        {
            if(productsCart.Keys.Contains(maSP))
                productsCart.Remove(maSP);
        }
        /// <summary>
        /// Phương thức giảm số lượng sản phẩm hoặc xoá sản phẩm trong giỏ
        /// </summary>
        /// <param name="maSP"></param>
        public void decreaseItem(string maSP) 
        {
            if (productsCart.Keys.Contains(maSP))
            {
                ctDonHang x = productsCart.Values[productsCart.IndexOfKey(maSP)];
                if (x.soLuong > 1)
                {
                    x.soLuong--;
                }
                else
                    deleteItem(maSP);
            }
        }
        /// <summary>
        /// Phương thức tính tiền cho 1 sản phẩm
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public long moneyOfProduct(ctDonHang x)
        {
            return (long)(x.giaBan * x.soLuong - (x.giaBan * x.soLuong * x.giamGia / 100));
        }
        /// <summary>
        /// Phương thức tính tổng tiền đơn hàng
        /// </summary>
        /// <returns></returns>
        public long totalOfCartShop()
        {
            long total = 0;
            foreach (var item in productsCart.Values)
                total += moneyOfProduct(item);
            return total;
        }
    }
}