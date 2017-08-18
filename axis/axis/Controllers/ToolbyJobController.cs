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
        public ActionResult Create([Bind(Include = "Id,Manufacturer,Model,Serial1,Serial2,Status,CDMD,Additional1,Additional2,Location,Category,ContractId")] AssignmentOfToolsByJob assignmentOfToolsByJob)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult Edit([Bind(Include = "Id,Manufacturer,Model,Serial1,Serial2,Status,CDMD,Additional1,Additional2,Location,Category,ContractId")] AssignmentOfToolsByJob assignmentOfToolsByJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignmentOfToolsByJob).State = EntityState.Modified;
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
