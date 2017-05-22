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
        public ActionResult Details(int? id, int ContractId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOperations fieldOperations = db.FieldOperations.Find(id);
            if (fieldOperations == null || fieldOperations.status != "ASSIGNED")
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = ContractId;
            return View(fieldOperations);
        }

        // GET: FieldOperations/Create
        public ActionResult Create(int? id, int? ContractId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            ViewBag.ContractId = ContractId;
            ViewBag.PurchaseOrderId = id;
            
            ViewBag.TechId = new SelectList(db.Teches.Where(c => c.Status == "BANCH"), "TechId", "FullName");
            return View();
        }

        // POST: FieldOperations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FieldOperationsId,TechApproval,PerDiemAdvance,TechApprovalADV,status,CertificatesStatus,TechId,PurchaseOrderId")] FieldOperations fieldOperations, int ContractId)
        {
            if (ModelState.IsValid)
            {

                fieldOperations.status = "PENDING  APPROVAL";
                fieldOperations.CertificatesStatus = 0;
                fieldOperations.TechApprovalADV = 0;
                db.FieldOperations.Add(fieldOperations);
                db.SaveChanges();

                var tech = db.Teches.Find(fieldOperations.TechId);
                tech.Status = "PENDING  APPROVAL";
                db.Entry(tech).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Details", "Contracts", new { id = ContractId });
            }

            ViewBag.ContractId = ContractId;
            ViewBag.PurchaseOrderId = fieldOperations.PurchaseOrderId;

            ViewBag.TechId = new SelectList(db.Teches.Where(c => c.Status == "BANCH"), "TechId", "FullName");
            return View(fieldOperations);
        }

        // GET: FieldOperations/Edit/5
        public ActionResult Edit(int? id, int PurchaseOrderId, int ContractId)
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
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            ViewBag.ContractId = ContractId;

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
            return new JsonResult() { Data = "Deleted successfully" };
        }



        //Despliega la lista de Tecnicos asignados a la PO
        public ActionResult PartialList(int Id, int ContractId)
        {

            ViewBag.ContractId = ContractId;
            var fieldOperations = db.FieldOperations.Where(a => a.PurchaseOrderId == Id).Include(f => f.PurchaseOrder).Include(f => f.Tech);
            return PartialView(fieldOperations.ToList());
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
