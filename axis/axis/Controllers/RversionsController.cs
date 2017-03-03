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
    public class RversionsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Rversions
        public ActionResult Index()
        {
            var rversions = db.Rversions.Include(r => r.Rfq);
            return View(rversions.ToList());
        }

        // GET: Rversions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rversion rversion = db.Rversions.Find(id);
            if (rversion == null)
            {
                return HttpNotFound();
            }
            return View(rversion);
        }

        // GET: Rversions/Create
        public ActionResult Create(int rfqid, string projectname)
        {
            var model = new Rversion
            {
                RfqId = rfqid,
                NumberVersion = 1,
                Status = "Open"
            };

            ViewBag.ProjectName = projectname;
            ViewBag.RfqId = rfqid;
            return View(model);
        }

        // POST: Rversions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RversionId,NumberVersion,Date,TypeWork,ScopeWork,ProjectDescription,TotalCost,Status,NotesAndInstructions,RfqId")] Rversion rversion)
        {
            if (ModelState.IsValid)
            {
                db.Rversions.Add(rversion);
                db.SaveChanges();
                return RedirectToAction("Create", "Quotes", new { rversionid = rversion.RversionId });
            }

            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "ProjectName", rversion.RfqId);
            return View(rversion);
        }

        // GET: Rversions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rversion rversion = db.Rversions.Find(id);
            if (rversion == null)
            {
                return HttpNotFound();
            }
            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "Status", rversion.RfqId);
            return View(rversion);
        }

        // POST: Rversions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RversionId,NumberVersion,Date,TypeWork,ScopeWork,ProjectDescription,TotalCost,Status,NotesAndInstructions,RfqId")] Rversion rversion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rversion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "Status", rversion.RfqId);
            return View(rversion);
        }

      

        // POST: Rversions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Rversion rversion = db.Rversions.Find(id);
            db.Rversions.Remove(rversion);
            db.SaveChanges();
            return new JsonResult() { Data = "Deleted successfully" };
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
