using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Controllers
{
    [Authorize]
    public class NewhireController : Controller
    {
        // GET: Newhire
        public ActionResult Index()
        {
            return View();
        }
    }
}