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
    public class FieldOperationsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: FieldOperations
        public ActionResult Index()
        {
            var fieldOperations = db.FieldOperations.Include(f => f.PurchaseOrder).Include(f => f.Tech);
            return View(fieldOperations.ToList());
        }

        // GET: FieldOperations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOperations fieldOperations = db.FieldOperations.Find(id);
            if (fieldOperations == null)
            {
                return HttpNotFound();
            }
            return View(fieldOperations);
        }

        // GET: FieldOperations/Create
        public ActionResult Create(int? id)
        {


            ViewBag.PurchaseOrderId = new SelectList(db.Purchaseorders, "PurchaseOrderId", "PO");
            ViewBag.TechId = new SelectList(db.Teches.Where(c => c.Status == "BANCH"), "TechId", "FullName");
            return View();
        }

        // POST: FieldOperations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FieldOperationsId,TechApproval,PerDiemAdvance,TechApprovalADV,status,CertificatesStatus,TechId,PurchaseOrderId")] FieldOperations fieldOperations)
        {
            if (ModelState.IsValid)
            {
                db.FieldOperations.Add(fieldOperations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseOrderId = new SelectList(db.Purchaseorders, "PurchaseOrderId", "PO", fieldOperations.PurchaseOrderId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "FullName", fieldOperations.TechId);
            return View(fieldOperations);
        }

        // GET: FieldOperations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOperations fieldOperations = db.FieldOperations.Find(id);
            if (fieldOperations == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseOrderId = new SelectList(db.Purchaseorders, "PurchaseOrderId", "PO", fieldOperations.PurchaseOrderId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "FullName", fieldOperations.TechId);
            return View(fieldOperations);
        }

        // POST: FieldOperations/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FieldOperationsId,TechApproval,PerDiemAdvance,TechApprovalADV,status,CertificatesStatus,TechId,PurchaseOrderId")] FieldOperations fieldOperations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fieldOperations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PurchaseOrderId = new SelectList(db.Purchaseorders, "PurchaseOrderId", "PO", fieldOperations.PurchaseOrderId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "FullName", fieldOperations.TechId);
            return View(fieldOperations);
        }

        // GET: FieldOperations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOperations fieldOperations = db.FieldOperations.Find(id);
            if (fieldOperations == null)
            {
                return HttpNotFound();
            }
            return View(fieldOperations);
        }

        // POST: FieldOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FieldOperations fieldOperations = db.FieldOperations.Find(id);
            db.FieldOperations.Remove(fieldOperations);
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
