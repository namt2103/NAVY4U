using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAVY4U.Controllers
{
    public class ArticleListController : Controller
    {
        // GET: ArticleList
        public ActionResult Index()
        {
            return View();
        }
    }
}