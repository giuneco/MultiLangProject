using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiLangProject.Controllers
{
    public class MyViewController : Controller
    {
        // GET: MyView
        public ActionResult Index()
        {
            ViewData["Message"] = "Test view Engine";
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Test normal view";
            return View();
        }
    }
}