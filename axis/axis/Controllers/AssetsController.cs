using AXIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Controllers
{
    public class AssetsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Assets
        public ActionResult Inventory()
        {
            return View();
        }

        // GET: Inventory By Warehouse
        public ActionResult InvWarehouse()
        {
            return View();
        }

        // GET: Inventory By Warehouse
        public ActionResult PartialInvWarehousebyJob()
        {
            var inventorybyjob = db.AssignmentOfToolsByJobs.Where(a => a.Location == "WAREHOUSE");
            return PartialView(inventorybyjob.ToList());
        }
    }
}