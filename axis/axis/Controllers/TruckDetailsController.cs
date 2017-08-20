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
    public class TruckDetailsController : Controller
    {
        private AXISDB db = new AXISDB();

        public ActionResult PartialList(int PurchaseOrderId, int ContractId)
        {

            var trucks = db.TruckDetails.Where(t => t.PurchaseOrderId == PurchaseOrderId);
            
            ViewBag.ContractId = ContractId;
            return PartialView(trucks.ToList());
        }

        // GET: TruckDetails/Edit/5
        public ActionResult Edit(int? id, int ContractId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckDetail truckDetail = db.TruckDetails.Find(id);
            if (truckDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = ContractId;
            return View(truckDetail);
        }

        // POST: TruckDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TruckId,PlateNumber,Brand,Model,Color,Other1,PurchaseOrderId")] TruckDetail truckDetail, int ContractId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truckDetail).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Edit","Trucks", new { id = truckDetail.PurchaseOrderId, ContractId = ContractId});
            }

            return View(truckDetail);
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
