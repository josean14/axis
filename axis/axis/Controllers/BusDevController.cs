using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Controllers
{
    [Authorize]
    public class BusDevController : Controller
    {
        // GET: BusDev
        public ActionResult Index()
        {
            return View();
        }
    }
}