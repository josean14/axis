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
    public class FlightsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Flights
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.FieldOperarions);
            return View(flights.ToList());
        }

      

        // GET: Flights/Create
        public ActionResult Create(int PurchaseOrderId, int ContractId, int FieldOperationsId)
        {
            
            ViewBag.FieldOperationsId = FieldOperationsId;
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            ViewBag.ContractId = ContractId;
            return View();
        }

        // POST: Flights/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightId,Description,DataFlight,CostFlight,FieldOperationsId")] Flight flight, HttpPostedFileBase DataFlight, int PurchaseOrderId, int ContractId)
        {
            if (ModelState.IsValid && DataFlight != null)
            {

                var dir = Server.MapPath("~/Documents/Flights/" + flight.FieldOperationsId);
                Directory.CreateDirectory(dir);

                string _FileName = System.IO.Path.GetFileName(DataFlight.FileName);

                string path = System.IO.Path.Combine(dir, _FileName);
                DataFlight.SaveAs(path);


                flight.DataFlight = _FileName;
                db.Flights.Add(flight);
                db.SaveChanges();

                
                return RedirectToAction("Details","FieldOperations", new {id = flight.FieldOperationsId, ContractId = ViewBag.ContractId = ContractId });
            }

            ViewBag.FieldOperationsId = new SelectList(db.FieldOperations, "FieldOperationsId", "status", flight.FieldOperationsId);
            return View(flight);
        }

       

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PartialList(int PurchaseOrderId, int ContractId, int FieldOperationsId)
        {
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            ViewBag.ContractId = ContractId;
            ViewBag.FieldOperationsId = FieldOperationsId;
            var flights = db.Flights.Where(c => c.FieldOperationsId == FieldOperationsId).Include(f => f.FieldOperarions);
            return PartialView(flights.ToList());
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
