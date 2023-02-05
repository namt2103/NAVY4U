using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NAVY4U.Models;

namespace ProjectFinal1.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        [HttpGet]
        public ActionResult Index()
        {

            khachHang cs = new khachHang();
            CartShop cart = Session["GioHang"] as CartShop;

            Session["CarShop"] = cart;
            return View();

        }


        [HttpPost]
        public ActionResult SaveToDataBase(khachHang x)
        {
            //
            using (var context = new BanHangOnlineEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        //update khachHang infor to khachHang object you have just creared before
                        //
                        // add khachHang info to data model
                        x.maKH = x.soDT;

                        var z = context.khachHangs.Find(x.maKH);

                        if (z == null)
                        {
                            context.Set<khachHang>().Add(x);
                            //save to database--------------[table custommer]
                            context.SaveChanges();
                        }


                        // new an donHang object and add to donHangS domain ----[donHangS]
                        donHang or = new donHang();

                        //update donHang infor to donHangS object you have just create before
                        or.soDH = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                        or.maKH = x.maKH;
                        or.ngayDat = DateTime.Now; or.ngayGH = DateTime.Now.AddDays(3);
                        or.ghiChu = x.ghiChu;
                        or.taiKhoan = "admin";
                        or.diaChiGH = x.diaChi;


                        //add donHang info to data model
                        context.donHangs.Add(or);
                        //save to database--------------[donHangS]
                        context.SaveChanges();

                        // get list of Item from cart shop
                        CartShop cart = Session["GioHang"] as CartShop;
                        //update donHang infor to donHang_DETAILS object you have just create before
                        foreach (ctDonHang i in cart.productsCart.Values)
                        {
                            i.soDH = or.soDH;
                            context.ctDonHangs.Add(i);
                        }

                        //save to database--------------[donHang_DETAILS]
                        context.SaveChanges();

                        // Finish

                        trans.Commit();
                        // 
                        return RedirectToAction("Index", "home");
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        string s = e.Message;
                    }
                }
            }
            // if error retur checkout
            return RedirectToAction("Index", "checkout");
        }
    }
}

