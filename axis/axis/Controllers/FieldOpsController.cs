using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Controllers
{
    [Authorize]
    public class FieldOpsController : Controller
    {
        // GET: FieldOps
        public ActionResult Index()
        {
            return View();
        }

        // GET: MAP
        public ActionResult JobBoard()
        {
            return View();
        }
    }
}