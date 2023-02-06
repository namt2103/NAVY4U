using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAVY4U.Areas.Admin.Controllers
{
    public class ProductListController : Controller
    {
        // GET: Admin/ProductList
        public ActionResult Index()
        {
            return View();
        }
    }
}