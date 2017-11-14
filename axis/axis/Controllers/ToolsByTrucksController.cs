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
    public class ToolsByTrucksController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: ToolsByTrucks
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TruckIdSortParm = String.IsNullOrEmpty(sortOrder) ? "truckId_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            ViewBag.ManufacturerSortParm = sortOrder == "Manufacturer" ? "manufacturer_desc" : "Manufacturer";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var ToolsbyTruck = from s in db.AssignmentOfToolsByTrucks.Where(c => c.Location == "JOB")
                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    ToolsbyTruck = ToolsbyTruck.Where(s => s.TruckId.Equals(numVal));
                }
                else
                {
                    ToolsbyTruck = ToolsbyTruck.Where(s => s.TruckId.Equals(0));
                    ViewBag.Message = "Invalid TruckId#";
                }

            }

            switch (sortOrder)
            {
                case "truckId_desc":
                    ToolsbyTruck = ToolsbyTruck.OrderByDescending(s => s.TruckId);
                    break;
                case "Category":
                    ToolsbyTruck = ToolsbyTruck.OrderBy(s => s.Category);
                    break;
                case "category_desc":
                    ToolsbyTruck = ToolsbyTruck.OrderByDescending(s => s.Category);
                    break;
                case "Manufacturer":
                    ToolsbyTruck = ToolsbyTruck.OrderBy(s => s.Manufacturer);
                    break;
                case "manufacturer_desc":
                    ToolsbyTruck = ToolsbyTruck.OrderByDescending(s => s.Manufacturer);
                    break;
                default: //Contract ascending
                    ToolsbyTruck = ToolsbyTruck.OrderBy(s => s.TruckId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(ToolsbyTruck.ToPagedList(pageNumber, pageSize));
        }

        // GET: ToolsByTrucks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentOfToolsByTruck assignmentOfToolsByTruck = db.AssignmentOfToolsByTrucks.Find(id);
            if (assignmentOfToolsByTruck == null)
            {
                return HttpNotFound();
            }
            return View(assignmentOfToolsByTruck);
        }

        // GET: ToolsByTrucks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToolsByTrucks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Manufacturer,Model,Serial1,Serial2,Status,CDMD,Additional1,Additional2,Location,Category,TruckId")] AssignmentOfToolsByTruck assignmentOfToolsByTruck)
        {
            if (ModelState.IsValid)
            {
                db.AssignmentOfToolsByTrucks.Add(assignmentOfToolsByTruck);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignmentOfToolsByTruck);
        }

        // GET: ToolsByTrucks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentOfToolsByTruck assignmentOfToolsByTruck = db.AssignmentOfToolsByTrucks.Find(id);
            if (assignmentOfToolsByTruck == null)
            {
                return HttpNotFound();
            }
            return View(assignmentOfToolsByTruck);
        }

        // POST: ToolsByTrucks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Manufacturer,Model,Serial1,Serial2,Status,CDMD,Additional1,Additional2,Location,Category,TruckId")] AssignmentOfToolsByTruck assignmentOfToolsByTruck)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignmentOfToolsByTruck).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignmentOfToolsByTruck);
        }

        // GET: ToolsByTrucks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentOfToolsByTruck assignmentOfToolsByTruck = db.AssignmentOfToolsByTrucks.Find(id);
            if (assignmentOfToolsByTruck == null)
            {
                return HttpNotFound();
            }
            return View(assignmentOfToolsByTruck);
        }

        // POST: ToolsByTrucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignmentOfToolsByTruck assignmentOfToolsByTruck = db.AssignmentOfToolsByTrucks.Find(id);
            db.AssignmentOfToolsByTrucks.Remove(assignmentOfToolsByTruck);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AToolsbyTruck(int? TruckId, int ContractId, string LicencePlate, int PurchaseOrderId)
        {
            ViewBag.LicencePlate = LicencePlate;
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            if (TruckId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assignmentOfToolsByTruck = db.AssignmentOfToolsByTrucks.Where(f => f.TruckId == TruckId);
            ViewBag.TrucktId = TruckId;
            if (assignmentOfToolsByTruck == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = ContractId;

            return View(assignmentOfToolsByTruck);

        }

        public ActionResult PartialList(int? Id, int ContractId, int PurchaseOrderId)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assignmentOfToolsByTruck = db.AssignmentOfToolsByTrucks.Where(f => f.TruckId == 0);
            ViewBag.TrucktId = Id;
            ViewBag.ContractId = ContractId;
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            if (assignmentOfToolsByTruck == null)
            {
                return HttpNotFound();
            }
            return PartialView(assignmentOfToolsByTruck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveListA(int TruckId, int ContractId, string[] values)
        {
            ViewBag.TruckId = TruckId;

            AssignmentOfToolsByTruck assignmentOfToolsByTruck;
            foreach (var item in values)
            {

                int id = Int32.Parse(item);
                assignmentOfToolsByTruck = db.AssignmentOfToolsByTrucks.Find(id);

                assignmentOfToolsByTruck.TruckId = TruckId;
                assignmentOfToolsByTruck.Location = "JOB";
                db.SaveChanges();

            }

            return new JsonResult() { Data = "Assigned successfully" };

        }

        // Liberar inventario de trucks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int Id)
        {
            AssignmentOfToolsByTruck assignmentOfToolsByTruck;
            assignmentOfToolsByTruck = db.AssignmentOfToolsByTrucks.Find(Id);
            assignmentOfToolsByTruck.TruckId = 0;
            assignmentOfToolsByTruck.Location = "WAREHOUSE";
            db.SaveChanges();
            return new JsonResult() { Data = 1 };

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
