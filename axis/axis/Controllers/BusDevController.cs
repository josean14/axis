using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Controllers
{
    [MyAuthorize(Roles = "Administrator, FieldManager, AFManager, SalesManager, Salesman")]
    public class BusDevController : Controller
    {
        // GET: BusDev
        public ActionResult Index()
        {
            return View();
        }
    }
}