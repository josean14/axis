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
    public class TrucksController : Controller
    {
        private AXISDB db = new AXISDB();


       

        // GET: Trucks/Edit/5
        public ActionResult Edit(int? id, int ContractId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseOrderId = id;
            ViewBag.ContractId = ContractId;
            return View(truck);
        }

        // POST: Trucks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrderId,NumberTrucks,RentalAgency,Status")] Truck truck, int ContractId)
        {
            if (ModelState.IsValid)
            {
                

                db.Entry(truck).State = EntityState.Modified;

                if (truck.Status == "PENDING ASSIGNMENT" || truck.Status == "REJECTED")
                {
                    truck.Status = "PENDING APPROVAL";
                }
                db.SaveChanges();

                return RedirectToAction("Index", "Mobilization");


            }
           
            return View(truck);
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
