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
        private AXISDB db3 = new AXISDB();

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
            var datos = db.Contracts.Include(c => c.Rversion).Include(d => d.Rversion.Rfq.Farm).Include(t=>t.User).Where(r => r.Rversion.Status == "Contract");
            var teches = db2.FieldOperations.Include(b => b.Tech).Include(g => g.PurchaseOrder);
            var pos = db3.Purchaseorders.Include(c => c.Contract);
            string markers = "[";
            string markers2 = "";
            string markers3 = "";
            int numVal;
            foreach (var item in datos)
            {

                numVal = item.Rversion.Rfq.FarmId;
                //var farm = db.Farms.Where(s => s.FarmId.Equals(numVal)).First();

                markers += "{";
                markers += string.Format("'Id': '{0}',", item.ContractId);

                var pos2 = pos.Where(n => n.ContractId == item.ContractId).Where(m => m.Status == "OPEN");
                foreach (var item3 in pos2)
                {
                    markers3 += "";
                    markers3 += string.Format(" {0}, ", item3.PO);
                }
                markers += string.Format("'POS': '{0}',", markers3);
                markers3 = "";

                markers += string.Format("'PlaceName': '{0}',", item.Rversion.Rfq.Farm.FarmName);
                markers += string.Format("'ProjectName': '{0}',", item.Rversion.Rfq.ProjectName);
                markers += string.Format("'ResouceManager': '{0}',", item.User.UserName);
                markers += string.Format("'TypeFarm': '{0}',", item.Rversion.Rfq.Farm.TypeFarm);
                markers += string.Format("'GeoLat': '{0}',", item.Rversion.Rfq.Farm.GeoLat);
                markers += string.Format("'GeoLong': '{0}',", item.Rversion.Rfq.Farm.GeoLong);
                markers += string.Format("'Rfq': '{0}',", item.RfqId);

                var teches2 = teches.Where(s => s.PurchaseOrder.ContractId == item.ContractId).Where(r => r.status == "ASSIGNED");
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
            var fieldOperations = db.FieldOperations.Where(a => a.PurchaseOrder.ContractId == ContractId).Where(g => g.status == "ASSIGNED").Include(f => f.PurchaseOrder).Include(f => f.Tech);
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

        // GET: JobChanges
        public ActionResult JobChanges(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ContractSortParm = String.IsNullOrEmpty(sortOrder) ? "contract_desc" : "";
            ViewBag.PonameSortParm = sortOrder == "Poname" ? "poname_desc" : "Poname";
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

            var Purchaseorders = from s in db.Purchaseorders.Include(c => c.Contract).Include(d => d.Contract.Rfq.Farm)
                                 select s;

            Purchaseorders = Purchaseorders.Where(a => a.Status == "OPEN");

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    Purchaseorders = Purchaseorders.Where(s => s.ContractId.Equals(numVal));
                    //rfqss = rfqss.Where(s => s.RfqId.Equals(numVal) && s.Farm.TypeFarm == TypeFarm.Solar);
                }
                else
                {
                    Purchaseorders = Purchaseorders.Where(s => s.PurchaseOrderId.Equals(0));
                    ViewBag.Message = "Invalid PO AXIS#";
                }

            }

            switch (sortOrder)
            {
                case "contract_desc":
                    Purchaseorders = Purchaseorders.OrderByDescending(s => s.ContractId);
                    break;
                case "Poname":
                    Purchaseorders = Purchaseorders.OrderBy(s => s.PurchaseOrderId);
                    break;
                case "poname_desc":
                    Purchaseorders = Purchaseorders.OrderByDescending(s => s.PurchaseOrderId);
                    break;
                case "Datename":
                    Purchaseorders = Purchaseorders.OrderBy(s => s.Date);
                    break;
                case "datename_desc":
                    Purchaseorders = Purchaseorders.OrderByDescending(s => s.Date);
                    break;
                default: //Contract ascending
                    Purchaseorders = Purchaseorders.OrderBy(s => s.ContractId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Purchaseorders.ToPagedList(pageNumber, pageSize));
        }

        // GET: ChangeTeches
        public ActionResult ChangeTeches(int? id, int? ContractId)
        {
            ViewBag.ContractId = ContractId;
            ViewBag.PurchaseOrderId = id;

            var technicians = from s in db.FieldOperations.Include(c => c.PurchaseOrder).Where(d => d.PurchaseOrderId == id)
                              select s;

            technicians = technicians.Where(a=> a.status == "ASSIGNED");

            return View(technicians.ToList());
        }

        // GET: UpdatePOS
        public ActionResult UpdatePOS(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ContractSortParm = String.IsNullOrEmpty(sortOrder) ? "contract_desc" : "";
            ViewBag.PonameSortParm = sortOrder == "Poname" ? "poname_desc" : "Poname";
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

            var Purchaseorders = from s in db.Purchaseorders.Include(c => c.Contract).Include(d => d.Contract.Rfq.Farm)
                                 select s;

            Purchaseorders = Purchaseorders.Where(a => a.Status == "OPEN");

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    Purchaseorders = Purchaseorders.Where(s => s.ContractId.Equals(numVal));
                    //rfqss = rfqss.Where(s => s.RfqId.Equals(numVal) && s.Farm.TypeFarm == TypeFarm.Solar);
                }
                else
                {
                    Purchaseorders = Purchaseorders.Where(s => s.PurchaseOrderId.Equals(0));
                    ViewBag.Message = "Invalid PO AXIS#";
                }

            }

            switch (sortOrder)
            {
                case "contract_desc":
                    Purchaseorders = Purchaseorders.OrderByDescending(s => s.ContractId);
                    break;
                case "Poname":
                    Purchaseorders = Purchaseorders.OrderBy(s => s.PurchaseOrderId);
                    break;
                case "poname_desc":
                    Purchaseorders = Purchaseorders.OrderByDescending(s => s.PurchaseOrderId);
                    break;
                case "Datename":
                    Purchaseorders = Purchaseorders.OrderBy(s => s.Date);
                    break;
                case "datename_desc":
                    Purchaseorders = Purchaseorders.OrderByDescending(s => s.Date);
                    break;
                default: //Contract ascending
                    Purchaseorders = Purchaseorders.OrderBy(s => s.ContractId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Purchaseorders.ToPagedList(pageNumber, pageSize));
        }


    }
}