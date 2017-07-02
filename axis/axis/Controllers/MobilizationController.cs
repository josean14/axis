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
    public class MobilizationController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Mobilization
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
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
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Purchaseorders.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Authorization(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ContractSortParm = String.IsNullOrEmpty(sortOrder) ? "contract_desc" : "";
            ViewBag.PonameSortParm = sortOrder == "Poname" ? "poname_desc" : "Poname";
            ViewBag.StatusnameSortParm = sortOrder == "Statusname" ? "statusname_desc" : "Statusname";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //var Purchaseorders = from s in db.Purchaseorders.Include(c => c.Contract).Include(d => d.Contract.Rfq.Farm)
            //                     select s;
            var approvaltech = from s in db.FieldOperations.Include(c => c.PurchaseOrder).Include(d => d.Tech)
                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    approvaltech = approvaltech.Where(s => s.PurchaseOrder.ContractId.Equals(numVal));

                }
                else
                {
                    approvaltech = approvaltech.Where(s => s.PurchaseOrderId.Equals(0));
                    ViewBag.Message = "Invalid JOB AXIS#";
                }

            }

            switch (sortOrder)
            {
                case "contract_desc":
                    approvaltech = approvaltech.OrderByDescending(s => s.PurchaseOrder.ContractId);
                    break;
                case "Poname":
                    approvaltech = approvaltech.OrderBy(s => s.PurchaseOrderId);
                    break;
                case "poname_desc":
                    approvaltech = approvaltech.OrderByDescending(s => s.PurchaseOrderId);
                    break;
                case "Statusname":
                    approvaltech = approvaltech.OrderBy(s => s.status);
                    break;
                case "statusname_desc":
                    approvaltech = approvaltech.OrderByDescending(s => s.status);
                    break;
                default: //Contract ascending
                    approvaltech = approvaltech.OrderBy(s => s.PurchaseOrder.ContractId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(approvaltech.ToPagedList(pageNumber, pageSize));
        }


        // POST: Assigned
        [HttpPost, ActionName("Assigned")]
        [ValidateAntiForgeryToken]
        public ActionResult Assigned(int id)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            FieldOperations field = new FieldOperations();

            var a = 3;

            fo.status = "ASSIGNED";


            db.Entry(fo).State = EntityState.Modified;
            db.SaveChanges();

            Tech tech = db.Teches.Find(fo.TechId);
            tech.Status = "IN FIELD";
            tech.POAsigned = fo.PurchaseOrder.PO;
            db.Entry(tech).State = EntityState.Modified;
            db.SaveChanges();

            return new JsonResult() { Data = "Assigned successfully" };
        }


        [HttpPost, ActionName("Denied")]
        [ValidateAntiForgeryToken]
        public ActionResult Denied(int id)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            var techid = fo.TechId;

            fo.status = "DENIED";
            fo.TechApprovalADV = "NO";
            db.Entry(fo).State = EntityState.Modified;
            db.SaveChanges();

            Tech tech = db.Teches.Find(techid);
            tech.Status = "BANCH";
            tech.POAsigned = " ";
            db.Entry(tech).State = EntityState.Modified;
            db.SaveChanges();

            return new JsonResult() { Data = "Denied successfully" };
        }

        [HttpPost, ActionName("Liberty")]
        [ValidateAntiForgeryToken]
        public ActionResult Liberty(int id)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            var techid = fo.TechId;

            fo.status = "CLOSED";
            db.Entry(fo).State = EntityState.Modified;
            db.SaveChanges();

            Tech tech = db.Teches.Find(techid);
            tech.Status = "BANCH";
            tech.POAsigned = " ";
            db.Entry(tech).State = EntityState.Modified;
            db.SaveChanges();

            return new JsonResult() { Data = "Liberty successfully" };
        }


        [HttpPost, ActionName("ApprovalADV")]
        [ValidateAntiForgeryToken]
        public ActionResult ApprovalADV(int id)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            var techid = fo.TechId;

            fo.TechApprovalADV = "YES";
            db.Entry(fo).State = EntityState.Modified;
            db.SaveChanges();

            return new JsonResult() { Data = "Liberty successfully" };
        }

        [HttpPost, ActionName("UnapprovalADV")]
        [ValidateAntiForgeryToken]
        public ActionResult UnapprovalADV(int id)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            var techid = fo.TechId;

            fo.TechApprovalADV = "NO";
            db.Entry(fo).State = EntityState.Modified;
            db.SaveChanges();

            return new JsonResult() { Data = "Liberty successfully" };
        }

    }

}