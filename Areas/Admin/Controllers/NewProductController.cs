using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheFourthPractice.Areas.Admin.Controllers
{
    public class NewProductController : Controller
    {
        // GET: Admin/NewProduct
        public ActionResult Index()
        {
            return View();
        }
    }
}