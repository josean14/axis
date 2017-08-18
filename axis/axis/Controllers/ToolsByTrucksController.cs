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
    public class ToolsByTrucksController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: ToolsByTrucks
        public ActionResult Index()
        {
            return View(db.AssignmentOfToolsByTrucks.ToList());
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
