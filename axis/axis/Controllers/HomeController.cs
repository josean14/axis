using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Axisweb()
        {
            ViewBag.Message = "Mandar a la pagina de www.Axisrg.com";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "THE COMPANY";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact info";

            return View();
        }
    }
}