﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;
using PagedList;
using Rotativa;

namespace AXIS.Controllers
{
    [MyAuthorize(Roles = "Administrator, FieldManager, AFManager, SalesManager, Salesman")]
    public class RfqsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Rfqs
        public ActionResult Index(string typefarm, string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.RfqSortParm = String.IsNullOrEmpty(sortOrder) ? "rfq_desc" : "";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "status_desc" : "Status";
            ViewBag.Typefarm = typefarm;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var rfqss = from s in db.Rfqs
                        select s;


            //Filtro por tipos de farm
            switch (typefarm)
            {
                case "WIND":
                    rfqss = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.WIND);
                    break;
                //        var rfqsWind = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Wind);
                //        return View(rfqsWind.ToPagedList(pageNumber, pageSize));
                case "SOLAR":
                    rfqss = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.SOLAR);
                    break;
                //        var rfqsSolar = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Solar);
                //        return View(rfqsSolar.ToPagedList(pageNumber, pageSize));
                case "OTHER":
                    rfqss = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.OTHER);
                    break;
                //        var rfqsOther = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Other);
                //        return View(rfqsOther.ToPagedList(pageNumber, pageSize));
                default:
                    rfqss = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.WIND);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    rfqss = rfqss.Where(s => s.RfqId.Equals(numVal));
                    //rfqss = rfqss.Where(s => s.RfqId.Equals(numVal) && s.Farm.TypeFarm == TypeFarm.Solar);
                }
                else
                {
                    rfqss = rfqss.Where(s => s.RfqId.Equals(0));
                    ViewBag.Message = "Invalid RFQ#";
                }

            }

            //Ordenamiento por RFQ# o Status
            switch (sortOrder)
            {
                case "rfq_desc":
                    rfqss = rfqss.OrderByDescending(s => s.RfqId);
                    break;
                case "Status":
                    rfqss = rfqss.OrderBy(s => s.Status);
                    break;
                case "status_desc":
                    rfqss = rfqss.OrderByDescending(s => s.Status);
                    break;
                default:
                    rfqss = rfqss.OrderBy(s => s.RfqId);
                    break;
            }



            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(rfqss.ToPagedList(pageNumber, pageSize));
        }

        // GET: Rfqs/Details/5
        public ActionResult Details(int? id, string typefarm)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rfq rfq = db.Rfqs.Find(id);
            if (rfq == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rversion = db.Rversions.Where(f => f.RfqId == id).ToList();
            ViewBag.Typefarm = typefarm;
            return View(rfq);
        }

        // GET: Rfqs/Create
        public ActionResult Create(string typefarm)
        {

            switch (typefarm)
            {

                case "WIND":
                    ViewBag.FarmId = new SelectList(db.Farms.Where(f => f.TypeFarm == TypeFarm.WIND), "FarmId", "FarmName");
                    ViewBag.ClientId = new SelectList(db.Clients,"ClientId","FullName");
                    
                    //Otra manera de hacer la lista
                    List<Client> ClientList = db.Clients.ToList();
                    ViewBag.ClientList = new SelectList(ClientList, "ClientId", "Fullname");
                    break;  
                case "SOLAR":
                    ViewBag.FarmId = new SelectList(db.Farms.Where(f => f.TypeFarm == TypeFarm.SOLAR), "FarmId", "FarmName");
                    break;
                case "OTHER":
                    ViewBag.FarmId = new SelectList(db.Farms.Where(f => f.TypeFarm == TypeFarm.OTHER), "FarmId", "FarmName");
                    break;
            }
            var model = new Rfq
            {
                Status = "Open"
            };

            return View(model);
        }

        // POST: Rfqs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RfqId,Status,ProjectName,FarmId")] Rfq rfq)
        {
            if (ModelState.IsValid)
            {
                db.Rfqs.Add(rfq);
                db.SaveChanges();


                return RedirectToAction("Create", "Rversions", new { rfqid = rfq.RfqId, projectname = rfq.ProjectName });
            }

            ViewBag.FarmId = new SelectList(db.Farms, "FarmId", "FarmName", rfq.FarmId);
            return View(rfq);
        }

        public JsonResult GetFarm(int ClientId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Farm> FarmList = db.Farms.Where(x => x.ClientId == ClientId).ToList();
            return Json(FarmList, JsonRequestBehavior.AllowGet);
        }


        // GET: Rfqs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rfq rfq = db.Rfqs.Find(id);
            if (rfq == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmId = new SelectList(db.Farms, "FarmId", "FarmName", rfq.FarmId);
            return View(rfq);
        }

        // POST: Rfqs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RfqId,Status,ProjectName,FarmId")] Rfq rfq)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rfq).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmId = new SelectList(db.Farms, "FarmId", "FarmName", rfq.FarmId);
            return View(rfq);
        }



        // POST: Rfqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rfq rfq = db.Rfqs.Find(id);
            db.Rfqs.Remove(rfq);
            db.SaveChanges();
            return new JsonResult() { Data = "RFQ Deleted successfully" };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // POST: Rfqs/Delete/5
        [HttpPost, ActionName("Closed")]
        [ValidateAntiForgeryToken]
        public ActionResult Closed(int id)
        {
            Rfq rfq = db.Rfqs.Find(id);
            rfq.Status = "Closed";
            db.Entry(rfq).State = EntityState.Modified;
            db.SaveChanges();

            var listverions = db.Rversions.Where(r => r.RfqId == id).ToList();
            foreach (var item in listverions)
            {
                item.Status = "Close";
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }

                return new JsonResult() { Data = "RFQ Closed" };
        }




        // GET: Rfqs/Edit/5
        public ActionResult VersionDetails(int? RversionId, int? RfqId, string typefarm)
        {
            if ((RversionId == null) & (RfqId == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rfq rfq = db.Rfqs.Find(RfqId);
            if (rfq == null)
            {
                return HttpNotFound();
            }
            Rversion rversion = db.Rversions.Find(RversionId);
            if (rfq == null)
            {
                return HttpNotFound();
            }
            ViewBag.Typefarm = typefarm;
            ViewBag.RversionId = rversion.RversionId;
            ViewBag.VersionDate = rversion.Date;
            ViewBag.NumberVersion = rversion.NumberVersion;
            ViewBag.TypeWork = rversion.TypeWork;
            ViewBag.Status = rversion.Status;
            ViewBag.ScopeWork = rversion.ScopeWork.Work;
            ViewBag.MIPricePerTech = rversion.MIPricePerTech;
            ViewBag.MITechnicians = rversion.MITechnicians;
            ViewBag.MITotal = rversion.MITotal;
            ViewBag.MOPricePerTech = rversion.MOPricePerTech;
            ViewBag.MOTechnicians = rversion.MOTechnicians;
            ViewBag.MOTotal = rversion.MOTotal;
            
            ViewBag.Notes = rversion.NotesAndInstructions;
            ViewBag.ProjectDescription = rversion.ProjectDescription;
            ViewBag.ProjectName = rfq.ProjectName;
            ViewBag.SiteFarm = rfq.Farm.FarmName;
            ViewBag.FullName = rfq.Farm.Client.FullName;
            ViewBag.Street = rfq.Farm.StreetAddress;
            ViewBag.City = rfq.Farm.City;
            ViewBag.State = rfq.Farm.State;
            ViewBag.Country = rfq.Farm.Country;
            ViewBag.TermsandConditions = rversion.TermsandConditions;

            var quotes1 = db.Quotes.Where(q => q.RversionId == rversion.RversionId).Where(r => r.TypeR == 1).ToList();
            var quotes2 = db.Quotes.Where(q => q.RversionId == rversion.RversionId).Where(r => r.TypeR == 2).ToList();

            ViewBag.Quotes1 = quotes1;
            ViewBag.Quotes2 = quotes2;
            return View(rfq);
        }

        public ActionResult RfqViewer(int? RversionId, int? RfqId, string typefarm)
        {
            if ((RversionId == null) & (RfqId == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rfq rfq = db.Rfqs.Find(RfqId);
            if (rfq == null)
            {
                return HttpNotFound();
            }
            Rversion rversion = db.Rversions.Find(RversionId);
            if (rfq == null)
            {
                return HttpNotFound();
            }
            ViewBag.Typefarm = typefarm;
            ViewBag.RversionId = rversion.RversionId;
            ViewBag.VersionDate = rversion.Date;
            ViewBag.NumberVersion = rversion.NumberVersion;
            ViewBag.TypeWork = rversion.TypeWork;
            ViewBag.Status = rversion.Status;
            ViewBag.ScopeWork = rversion.ScopeWork.Work;
            ViewBag.MIPricePerTech = rversion.MIPricePerTech;
            ViewBag.MITechnicians = rversion.MITechnicians;
            ViewBag.MITotal = rversion.MITotal;
            ViewBag.MOPricePerTech = rversion.MOPricePerTech;
            ViewBag.MOTechnicians = rversion.MOTechnicians;
            ViewBag.MOTotal = rversion.MOTotal;

            ViewBag.Notes = rversion.NotesAndInstructions;
            ViewBag.ProjectDescription = rversion.ProjectDescription;
            ViewBag.ProjectName = rfq.ProjectName;
            ViewBag.SiteFarm = rfq.Farm.FarmName;
            ViewBag.FullName = rfq.Farm.Client.FullName;
            ViewBag.Street = rfq.Farm.StreetAddress;
            ViewBag.City = rfq.Farm.City;
            ViewBag.State = rfq.Farm.State;
            ViewBag.Country = rfq.Farm.Country;
            ViewBag.TermsandConditions = rversion.TermsandConditions;

            var quotes1 = db.Quotes.Where(q => q.RversionId == rversion.RversionId).Where(r => r.TypeR == 1).ToList();
            var quotes2 = db.Quotes.Where(q => q.RversionId == rversion.RversionId).Where(r => r.TypeR == 2).ToList();

            ViewBag.Quotes1 = quotes1;
            ViewBag.Quotes2 = quotes2;

            return View(rfq);
        }

        public ActionResult PrintRfqViewer(int? RversionId, int? RfqId, string typefarm)
        {
            if ((RversionId == null) & (RfqId == null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rfq rfq = db.Rfqs.Find(RfqId);
            if (rfq == null)
            {
                return HttpNotFound();
            }
            Rversion rversion = db.Rversions.Find(RversionId);
            if (rfq == null)
            {
                return HttpNotFound();
            }
            ViewBag.Typefarm = typefarm;
            ViewBag.RversionId = rversion.RversionId;
            ViewBag.VersionDate = rversion.Date;
            ViewBag.NumberVersion = rversion.NumberVersion;
            ViewBag.TypeWork = rversion.TypeWork;
            ViewBag.Status = rversion.Status;
            ViewBag.ScopeWork = rversion.ScopeWork.Work;
            ViewBag.MIPricePerTech = rversion.MIPricePerTech;
            ViewBag.MITechnicians = rversion.MITechnicians;
            ViewBag.MITotal = rversion.MITotal;
            ViewBag.MOPricePerTech = rversion.MOPricePerTech;
            ViewBag.MOTechnicians = rversion.MOTechnicians;
            ViewBag.MOTotal = rversion.MOTotal;

            ViewBag.Notes = rversion.NotesAndInstructions;
            ViewBag.ProjectDescription = rversion.ProjectDescription;
            ViewBag.ProjectName = rfq.ProjectName;
            ViewBag.SiteFarm = rfq.Farm.FarmName;
            ViewBag.FullName = rfq.Farm.Client.FullName;
            ViewBag.Street = rfq.Farm.StreetAddress;
            ViewBag.City = rfq.Farm.City;
            ViewBag.State = rfq.Farm.State;
            ViewBag.Country = rfq.Farm.Country;
            ViewBag.TermsandConditions = rversion.TermsandConditions;

            var quotes1 = db.Quotes.Where(q => q.RversionId == rversion.RversionId).Where(r => r.TypeR == 1).ToList();
            var quotes2 = db.Quotes.Where(q => q.RversionId == rversion.RversionId).Where(r => r.TypeR == 2).ToList();

            ViewBag.Quotes1 = quotes1;
            ViewBag.Quotes2 = quotes2;
            return new Rotativa.ViewAsPdf("RfqViewer", rfq) { FileName = "RFQ " + RfqId + " Ver "+ ViewBag.NumberVersion +  ".pdf" };
        }
    }

}
