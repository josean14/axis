using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;
using PagedList;

namespace AXIS.Controllers
{
    [Authorize]
    public class TruckDetailsController : Controller
    {
        private AXISDB db = new AXISDB();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SiteSortParm = String.IsNullOrEmpty(sortOrder) ? "site_desc" : "";
            ViewBag.LicenseSortParm = sortOrder == "License" ? "lisence_desc" : "Lisence";
            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "description_desc" : "Description";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Trucks = from s in db.TruckDetails.Where(t => t.Status == "RENT")
                               select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Trucks = Trucks.Where(s => s.SiteLocation.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "site_desc":
                    Trucks = Trucks.OrderByDescending(s => s.SiteLocation);
                    break;
                case "License":
                    Trucks = Trucks.OrderBy(s => s.LicencePlate);
                    break;
                case "license_desc":
                    Trucks = Trucks.OrderByDescending(s => s.LicencePlate);
                    break;
                case "Description":
                    Trucks = Trucks.OrderBy(s => s.MakeModel);
                    break;
                case "description_desc":
                    Trucks = Trucks.OrderByDescending(s => s.MakeModel);
                    break;
                default: //Site Location ascending
                    Trucks = Trucks.OrderBy(s => s.SiteLocation);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Trucks.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult PartialList(int PurchaseOrderId, int ContractId)
        {

            var trucks = db.TruckDetails.Where(t => t.PurchaseOrderId == PurchaseOrderId);
            ViewBag.PurchaseOrderId = PurchaseOrderId;
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
            ViewBag.FullName = new SelectList(db.Teches.Where(c => c.Status == "IN FIELD"), "FullName", "FullName");
            return View(truckDetail);
        }

        // POST: TruckDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TruckId,LicencePlate,MakeModel,SiteLocation,VIN,DateRent,Year,GasDiesel,GasCard,InsuranceDocumentacion,ItemInterior1,ItemInterior2,ItemInterior3,ItemInterior4,ItemInterior5,EngineComparment1,EngineComparment2,EngineComparment3,EngineComparment4,ItemExterior1,ItemExterior2,ItemExterior3,ItemExterior4,ItemExterior5,ItemExterior6,ItemExterior7,ItemExterior8,ItemExterior9,ItemExterior10,ItemExterior11,ItemExterior12,ItemExterior13,ItemExterior14,ItemExterior15,ItemExterior16,AditionalComments,PurchaseOrderId,FullName")] TruckDetail truckDetail, int ContractId)
        {
            if (ModelState.IsValid)
            {
                truckDetail.Status = "RENT";
                db.Entry(truckDetail).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Edit","Trucks", new { id = truckDetail.PurchaseOrderId, ContractId = ContractId});
            }
            ViewBag.ContractId = ContractId;
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
