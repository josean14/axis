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
    public class ToolbyJobController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: ToolbyJob
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //var ToolsbyJob = db.AssignmentOfToolsByJobs.Where(c => c.Location == "JOB");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ContractSortParm = String.IsNullOrEmpty(sortOrder) ? "contract_desc" : "";
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

            var ToolsbyJob = from s in db.AssignmentOfToolsByJobs.Where(c => c.Location == "JOB")
                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    ToolsbyJob = ToolsbyJob.Where(s => s.ContractId.Equals(numVal));
                }
                else
                {
                    ToolsbyJob = ToolsbyJob.Where(s => s.ContractId.Equals(0));
                    ViewBag.Message = "Invalid Job#";
                }

            }

            switch (sortOrder)
            {
                case "contract_desc":
                    ToolsbyJob = ToolsbyJob.OrderByDescending(s => s.ContractId);
                    break;
                case "Category":
                    ToolsbyJob = ToolsbyJob.OrderBy(s => s.Category);
                    break;
                case "category_desc":
                    ToolsbyJob = ToolsbyJob.OrderByDescending(s => s.Category);
                    break;
                case "Manufacturer":
                    ToolsbyJob = ToolsbyJob.OrderBy(s => s.Manufacturer);
                    break;
                case "manufacturer_desc":
                    ToolsbyJob = ToolsbyJob.OrderByDescending(s => s.Manufacturer);
                    break;
                default: //Contract ascending
                    ToolsbyJob = ToolsbyJob.OrderBy(s => s.ContractId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(ToolsbyJob.ToPagedList(pageNumber, pageSize));


            //return View(db.AssignmentOfToolsByJobs.ToList());
        }

        // GET: ToolbyJob/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentOfToolsByJob assignmentOfToolsByJob = db.AssignmentOfToolsByJobs.Find(id);
            if (assignmentOfToolsByJob == null)
            {
                return HttpNotFound();
            }
            return View(assignmentOfToolsByJob);
        }

        // GET: ToolbyJob/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToolbyJob/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Manufacturer,Model,Serial1,Serial2,Status,CDMD,Additional1,Additional2,Category")] AssignmentOfToolsByJob assignmentOfToolsByJob)
        {
            if (ModelState.IsValid)
            {

                assignmentOfToolsByJob.ContractId = 0;
                assignmentOfToolsByJob.Location = "WAREHOUSE";
                assignmentOfToolsByJob.CheckJob = false;
                db.AssignmentOfToolsByJobs.Add(assignmentOfToolsByJob);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignmentOfToolsByJob);
        }

        // GET: ToolbyJob/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentOfToolsByJob assignmentOfToolsByJob = db.AssignmentOfToolsByJobs.Find(id);
            if (assignmentOfToolsByJob == null)
            {
                return HttpNotFound();
            }
            return View(assignmentOfToolsByJob);
        }

        // POST: ToolbyJob/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Manufacturer,Model,Serial1,Serial2,Status,CDMD,Additional1,Additional2,Location,Category,ContractId,CheckJob")] AssignmentOfToolsByJob assignmentOfToolsByJob)
        {
            if (ModelState.IsValid)
            {
                AssignmentOfToolsByJob assignmentOfToolsByJobB;
                assignmentOfToolsByJobB = db.AssignmentOfToolsByJobs.Find(assignmentOfToolsByJob.Id);

                assignmentOfToolsByJobB.Manufacturer = assignmentOfToolsByJob.Manufacturer;
                assignmentOfToolsByJobB.Model = assignmentOfToolsByJob.Model;
                assignmentOfToolsByJobB.Serial1 = assignmentOfToolsByJob.Serial1;
                assignmentOfToolsByJobB.Serial2 = assignmentOfToolsByJob.Serial2;
                assignmentOfToolsByJobB.Status = assignmentOfToolsByJob.Status;
                assignmentOfToolsByJobB.CDMD = assignmentOfToolsByJob.CDMD;
                assignmentOfToolsByJobB.Additional1 = assignmentOfToolsByJob.Additional1;
                assignmentOfToolsByJobB.Additional2 = assignmentOfToolsByJob.Additional2;
                assignmentOfToolsByJobB.Location = assignmentOfToolsByJob.Location;
                assignmentOfToolsByJobB.Category = assignmentOfToolsByJob.Category;
                assignmentOfToolsByJobB.ContractId = assignmentOfToolsByJob.ContractId;



                //db.Entry(assignmentOfToolsByJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignmentOfToolsByJob);
        }

        // GET: ToolbyJob/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentOfToolsByJob assignmentOfToolsByJob = db.AssignmentOfToolsByJobs.Find(id);
            if (assignmentOfToolsByJob == null)
            {
                return HttpNotFound();
            }
            return View(assignmentOfToolsByJob);
        }

        // POST: ToolbyJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignmentOfToolsByJob assignmentOfToolsByJob = db.AssignmentOfToolsByJobs.Find(id);
            db.AssignmentOfToolsByJobs.Remove(assignmentOfToolsByJob);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PartialListContract(int? ContractId, int PurchaseOrderId)
        {

            if (ContractId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            ViewBag.ContractId = ContractId;
            var assignmentOfToolsByJob = db.AssignmentOfToolsByJobs.Where(f => f.ContractId == ContractId);

            if (assignmentOfToolsByJob == null)
            {
                return HttpNotFound();
            }
            return PartialView(assignmentOfToolsByJob);

        }

        public ActionResult PartialList(int? Id, int PurchaseOrderId)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var assignmentOfToolsByJob = db.AssignmentOfToolsByJobs.Where(f => f.ContractId == 0);
            ViewBag.ContractId = Id;
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            if (assignmentOfToolsByJob == null)
            {
                return HttpNotFound();
            }
            return PartialView(assignmentOfToolsByJob);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveListA(int ContractId, string[] values)
        {
            ViewBag.ContractId = ContractId;

            AssignmentOfToolsByJob assignmentOfToolsByJob;
            foreach (var item in values)
            {

                int id = Int32.Parse(item);
                assignmentOfToolsByJob = db.AssignmentOfToolsByJobs.Find(id);

                assignmentOfToolsByJob.ContractId = ContractId;
                assignmentOfToolsByJob.Location = "JOB";

                db.SaveChanges();

            }

            return new JsonResult() { Data = "Assigned successfully" };

        }

        // Liberar inventario de trucks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int Id)
        {
            AssignmentOfToolsByJob assignmentOfToolsByJob;
            assignmentOfToolsByJob = db.AssignmentOfToolsByJobs.Find(Id);
            assignmentOfToolsByJob.ContractId = 0;
            assignmentOfToolsByJob.Location = "WAREHOUSE";
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
