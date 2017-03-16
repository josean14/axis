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
            var scopeworks = db.Rversions.Include(r => r.ScopeWork);
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
                Status = "Open",
                Date = DateTime.Now
            };
            Rfq rfq = db.Rfqs.Find(rfqid);
            ViewBag.ProjectName = projectname;
            ViewBag.RfqId = rfqid;
            ViewBag.FullName = rfq.Farm.Client.FullName;
            ViewBag.Street = rfq.Farm.StreetAddress;
            ViewBag.City = rfq.Farm.City;
            ViewBag.State = rfq.Farm.State;
            ViewBag.Country = rfq.Farm.Country;
            ViewBag.SiteFarm = rfq.Farm.FarmName;


            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work");
            return View(model);
        }

        // POST: Rversions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RversionId,NumberVersion,Date,TypeWork,ProjectDescription,TotalCost,Status,NotesAndInstructions,RfqId,ScopeWorkId,TermsandConditions")] Rversion rversion)
        {
            if (ModelState.IsValid)
            {
                rversion.Date = DateTime.Now;
                db.Rversions.Add(rversion);
                db.SaveChanges();
                return RedirectToAction("Create", "Quotes", new { rversionid = rversion.RversionId });
            }

            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "ProjectName", rversion.RfqId);
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", rversion.ScopeWorkId);
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
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", rversion.ScopeWorkId);
            return View(rversion);
        }

        // POST: Rversions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RversionId,NumberVersion,Date,TypeWork,ProjectDescription,TotalCost,Status,NotesAndInstructions,RfqId,ScopeWorkId,TermsandConditions")] Rversion rversion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rversion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "Status", rversion.RfqId);
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", rversion.ScopeWorkId);
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


        //Action result for ajax call
        [HttpPost]
        public ActionResult GetScopeWork(int typework)
        {
            switch (typework)
            {

                case 0:
                    var objservice = db.ScopeWorks.Where(m => m.TypeWork == "Services");
                    SelectList listservice = new SelectList(objservice, "ScopeWorkId", "Work", 0);
                    return Json(listservice);
                case 1:
                    var objconstruct = db.ScopeWorks.Where(m => m.TypeWork == "Construct");
                    SelectList listconstruct = new SelectList(objconstruct, "ScopeWorkId", "Work", 0);
                    return Json(listconstruct);
                default:
                    SelectList listdefault = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", 0);
                    return Json(listdefault);
            }

        }
    }
}
