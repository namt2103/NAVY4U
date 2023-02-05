using NAVY4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAVY4U.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpPost]
        public ActionResult Index(string q)
        {
            BanHangOnlineEntities bh = new BanHangOnlineEntities();
            var sanPhams = bh.sanPhams.Where(n => n.tenSP.Contains(q)).OrderByDescending(n => n.tenSP);
            return View(sanPhams);
        }
    }
}