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
    public class QuotesController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Quotes
        public ActionResult Index()
        {
            var quotes = db.Quotes.Include(q => q.Rversion);
            return View(quotes.ToList());
        }

        // GET: Quotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // GET: Quotes/Create
        public ActionResult Create(int rversionid)
        {
            Rversion rversion = db.Rversions.Find(rversionid);
            Rfq rfq = db.Rfqs.Find(rversion.RfqId);

            ViewData["ProjectDescription"] = rversion.ProjectDescription;
            ViewData["TypeWork"] = rversion.TypeWork;
            ViewData["NumberRfq"] = rversion.RfqId;
            ViewData["NumberVersion"] = rversion.NumberVersion;
            ViewData["ProjectName"] = rversion.Rfq.ProjectName;
            ViewData["RversionId"] = rversionid;
            return View();
        }

        // POST: Quotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteId,Description,Um,PricePerUnit,Quantity,Currency,RversionId")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Quotes.Add(quote);
                db.SaveChanges();
                return new JsonResult() { Data = quote.QuoteId };
            }

            ViewBag.RversionId = new SelectList(db.Rversions, "RversionId", "ScopeWork", quote.RversionId);
            return new JsonResult() { Data = quote.QuoteId };
        }

        // GET: Quotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            ViewBag.RversionId = new SelectList(db.Rversions, "RversionId", "ScopeWork", quote.RversionId);
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuoteId,Description,Um,PricePerUnit,Quantity,Currency,RversionId")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RversionId = new SelectList(db.Rversions, "RversionId", "ScopeWork", quote.RversionId);
            return View(quote);
        }

       

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quote quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
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
