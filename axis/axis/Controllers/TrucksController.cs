using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Controllers
{
    public class TrucksController : Controller
    {
        // GET: Trucks
        public ActionResult List()
        {
            return View();
        }
    }
}