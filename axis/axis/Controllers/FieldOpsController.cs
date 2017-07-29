using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;
using PagedList;

namespace AXIS.Controllers
{
    [Authorize]
    public class FieldOpsController : Controller
    {
        private AXISDB db = new AXISDB();
        private AXISDB db2 = new AXISDB();

        // GET: FieldOps
        public ActionResult Index()
        {
            return View();
        }

        // GET: MAP
        public ActionResult JobBoard()
        {
            //var rversions = db.Rversions.Where(c => c.Status == "Contract").Include(Rfq);
            //var datos2 = db.Rfqs.Include(c => c.Farm).Where(r => r.Status == "Contract");
            var datos = db.Contracts.Include(c => c.Rversion).Include(d => d.Rversion.Rfq.Farm).Where(r => r.Rversion.Status == "Contract");
            var teches = db2.FieldOperations.Include(b => b.Tech).Include(g => g.PurchaseOrder);
            
            string markers = "[";
            string markers2 = "";
            int numVal;
            foreach (var item in datos)
            {

                numVal = item.Rversion.Rfq.FarmId;
                //var farm = db.Farms.Where(s => s.FarmId.Equals(numVal)).First();

                markers += "{";
                markers += string.Format("'Id': '{0}',", item.ContractId);
                markers += string.Format("'PlaceName': '{0}',", item.Rversion.Rfq.Farm.FarmName);
                markers += string.Format("'TypeFarm': '{0}',", item.Rversion.Rfq.Farm.TypeFarm);
                markers += string.Format("'GeoLat': '{0}',", item.Rversion.Rfq.Farm.GeoLat);
                markers += string.Format("'GeoLong': '{0}',", item.Rversion.Rfq.Farm.GeoLong);
                markers += string.Format("'Rfq': '{0}',", item.RfqId);

                var teches2 = teches.Where(s => s.PurchaseOrder.ContractId == item.ContractId);
                foreach (var item2 in teches2)
                {
                    markers2 += "";
                    markers2 += string.Format(" {0}, ", item2.Tech.FullName);
                }

                markers += string.Format("'Teches': '{0}',", markers2);
                markers2 = "";
                markers += "},";
            }
            markers += "]";

            ViewBag.Markers = markers;


            return View();
        }

        public ActionResult PartialViewtable(int ContractId)
        {

            ViewBag.ContractId = ContractId;
            var fieldOperations = db.FieldOperations.Where(a => a.PurchaseOrder.ContractId == ContractId).Include(f => f.PurchaseOrder).Include(f => f.Tech);
            return PartialView(fieldOperations.ToList());
        }

        // GET: VIEWTABLE
        public ActionResult Viewtable(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //var jobboard = db.Contracts.Include(c => c.Rversion).Include(d => d.Rversion.Rfq.Farm).Where(r => r.Rversion.Status == "Contract");
            var jobboardteches = db2.FieldOperations.Include(b => b.Tech).Include(g => g.PurchaseOrder);

            ViewBag.CurrentSort = sortOrder;
            ViewBag.ContractSortParm = String.IsNullOrEmpty(sortOrder) ? "contract_desc" : "";
            ViewBag.SitenameSortParm = sortOrder == "Sitename" ? "sitename_desc" : "Sitename";
            ViewBag.DatenameSortParm = sortOrder == "Datetname" ? "datename_desc" : "Datetname";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var jobboard = from s in db.Contracts.Include(c => c.Rversion.Rfq.Farm)
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    jobboard = jobboard.Where(s => s.ContractId.Equals(numVal));
                }
                else
                {
                    jobboard = jobboard.Where(s => s.ContractId.Equals(0));
                    ViewBag.Message = "Invalid Job#";
                }

            }

            switch (sortOrder)
            {
                case "contract_desc":
                    jobboard = jobboard.OrderByDescending(s => s.ContractId);
                    break;
                case "Sitename":
                    jobboard = jobboard.OrderBy(s => s.Rfq.Farm.FarmName);
                    break;
                case "sitename_desc":
                    jobboard = jobboard.OrderByDescending(s => s.Rfq.Farm.FarmName);
                    break;
                case "Datename":
                    jobboard = jobboard.OrderBy(s => s.Date);
                    break;
                case "datename_desc":
                    jobboard = jobboard.OrderByDescending(s => s.Date);
                    break;
                default: //Contract ascending
                    jobboard = jobboard.OrderBy(s => s.ContractId);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(jobboard.ToPagedList(pageNumber, pageSize));
        }
    }
}