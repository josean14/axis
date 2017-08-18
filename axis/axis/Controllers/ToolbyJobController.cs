using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;

namespace AXIS.Controllers
{
    public class ToolbyJobController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: ToolbyJob
        public ActionResult Index()
        {
            return View(db.AssignmentOfToolsByJobs.ToList());
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
