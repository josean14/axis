using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;
using System.IO;
using PagedList;

namespace AXIS.Controllers
{
    [Authorize]
    public class PurchaseordersController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Purchaseorders/Index
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

            var Purchaseorders = from s in db.Purchaseorders
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    Purchaseorders = Purchaseorders.Where(s => s.PurchaseOrderId.Equals(numVal));
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
        // GET: Purchaseorders
        public ActionResult PartialList(int contractid)
        {
            var purchaseorders = db.Purchaseorders.Include(p => p.Contract).Where(c => c.ContractId == contractid);
            ViewBag.ContractId = contractid;
            return PartialView(purchaseorders.ToList());
        }

        // GET: Purchaseorders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchaseorder purchaseorder = db.Purchaseorders.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        // GET: Purchaseorders/Create
        public ActionResult PartialCreate(int contractId)
        {
            var model = new Purchaseorder
            {
                ContractId = contractId
            };

            ViewBag.ContractId = contractId;
            return PartialView();
        }

        // POST: Purchaseorders/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseOrderId,PO,Commentary,ContractId")] Purchaseorder purchaseorder, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {

                var dir = Server.MapPath("~/Documents/PO/" + purchaseorder.ContractId);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string _FileName = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(dir, _FileName);
                file.SaveAs(path);

                purchaseorder.Status = "OPEN";
                purchaseorder.Date = DateTime.Now;
                purchaseorder.File = _FileName;
                db.Purchaseorders.Add(purchaseorder);


                AssignmentOfTool ATool = new AssignmentOfTool();

                Truck Truck = new Truck();

                ATool.PurchaseOrderId = purchaseorder.PurchaseOrderId;
                Truck.PurchaseOrderId = purchaseorder.PurchaseOrderId;
                Truck.Status = "PENDING ASSIGNMENT";

                db.AssignmentOfTools.Add(ATool);
                db.Trucks.Add(Truck);

                db.SaveChanges();

                

                return RedirectToAction("Details", "Contracts", new { id = purchaseorder.ContractId });
            }


            return RedirectToAction("Details", "Contracts", new { id = purchaseorder.ContractId });
        }

        // GET: Purchaseorders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchaseorder purchaseorder = db.Purchaseorders.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "OcClient", purchaseorder.ContractId);
            return View(purchaseorder);
        }

        // POST: Purchaseorders/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrderId,PO,Commentary,Date,File,ContractId")] Purchaseorder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "OcClient", purchaseorder.ContractId);
            return View(purchaseorder);
        }


        // POST: Purchaseorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int contractid)
        {
            Purchaseorder purchaseorder = db.Purchaseorders.Find(id);
            db.Purchaseorders.Remove(purchaseorder);
            db.SaveChanges();
            return RedirectToAction("Details", "Contracts", new { id = contractid });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Open Files
        public FileResult Download(string ImageName, int POid)
        {
            return File("~/Documents/PO/" + POid + "/" + ImageName, System.Net.Mime.MediaTypeNames.Application.Octet, ImageName);
        }
    }
}
