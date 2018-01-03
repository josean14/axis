using AXIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Controllers
{
    [Authorize]
    public class AssetsController : Controller
    {
        private AXISDB db = new AXISDB();
        private AXISDB db2 = new AXISDB();

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

        // GET: Inventory By Warehouse JOB
        public ActionResult PartialInvWarehousebyJob(string sortOrder, string currentFilter, string searchString)
        {
            //var inventorybyjob = db.AssignmentOfToolsByJobs.Where(a => a.Location == "WAREHOUSE");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ManufacturerSortParm = String.IsNullOrEmpty(sortOrder) ? "manufacturer_desc" : "";
            ViewBag.ModelSortParm = sortOrder == "Model" ? "modeldesc" : "Model";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";

            if (searchString != null)
            {
                
            }
            else
            {
                searchString = currentFilter;
            }


            ViewBag.CurrentFilter = searchString;

            var inventorybyjob = from s in db.AssignmentOfToolsByJobs.Where(c => c.Location == "WAREHOUSE")
                                  select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                inventorybyjob = inventorybyjob.Where(s => s.Category.Contains(searchString));
                                       
            }

            switch (sortOrder)
            {
                case "manufacturer_desc":
                    inventorybyjob = inventorybyjob.OrderByDescending(s => s.Manufacturer);
                    break;
                case "Model":
                    inventorybyjob = inventorybyjob.OrderBy(s => s.Model);
                    break;
                case "model_desc":
                    inventorybyjob = inventorybyjob.OrderByDescending(s => s.Model);
                    break;
                case "Category":
                    inventorybyjob = inventorybyjob.OrderBy(s => s.Category);
                    break;
                case "category_desc":
                    inventorybyjob = inventorybyjob.OrderByDescending(s => s.Category);
                    break;
                default: //Name ascending
                    inventorybyjob = inventorybyjob.OrderBy(s => s.Manufacturer);
                    break;
            }
            return PartialView(inventorybyjob.ToList());
        }

        // GET: Inventory By Warehouse TRUCKS
        public ActionResult PartialInvWarehousebyTruck()
        {
            var inventorybytruck = db2.AssignmentOfToolsByTrucks.Where(a => a.Location == "WAREHOUSE");

            return PartialView(inventorybytruck.ToList());
        }
    }
}