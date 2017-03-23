using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;
using System.IO;

namespace AXIS.Controllers
{
    public class PurchaseordersController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Purchaseorders
        public ActionResult PartialList(int contractid)
        {
            var purchaseorders = db.Purchaseorders.Include(p => p.Contract).Where(c => c.ContractId == contractid);
            return PartialView(purchaseorders.ToList());
        }

        // GET: Purchaseorders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchaseorder purchaseorder = db.Purchaseorders.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        // GET: Purchaseorders/Create
        public ActionResult PartialCreate(int contractId)
        {
            var model = new Purchaseorder
            {
                ContractId = contractId
            };

            ViewBag.ContractId = contractId;
            return PartialView();
        }

        // POST: Purchaseorders/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseOrderId,PO,Commentary,ContractId")] Purchaseorder purchaseorder, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {

                var dir = Server.MapPath("~/Documents/PO/" + purchaseorder.ContractId);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string _FileName = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(dir, _FileName);
                file.SaveAs(path);


                purchaseorder.Date = DateTime.Now;
                purchaseorder.File = _FileName;
                db.Purchaseorders.Add(purchaseorder);
                db.SaveChanges();
                return RedirectToAction("Details", "Contracts", new { id = purchaseorder.ContractId });
            }


            return RedirectToAction("Details", "Contracts", new { id = purchaseorder.ContractId });
        }

        // GET: Purchaseorders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchaseorder purchaseorder = db.Purchaseorders.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "OcClient", purchaseorder.ContractId);
            return View(purchaseorder);
        }

        // POST: Purchaseorders/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrderId,PO,Commentary,Date,File,ContractId")] Purchaseorder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractId = new SelectList(db.Contracts, "ContractId", "OcClient", purchaseorder.ContractId);
            return View(purchaseorder);
        }


        // POST: Purchaseorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int contractid)
        {
            Purchaseorder purchaseorder = db.Purchaseorders.Find(id);
            db.Purchaseorders.Remove(purchaseorder);
            db.SaveChanges();
            return RedirectToAction("Details", "Contracts", new { id = contractid });
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
