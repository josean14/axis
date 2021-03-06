﻿using System;
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
    [MyAuthorize(Roles = "Administrator, FieldManager, AFManager, SalesManager, Salesman")]
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


            ViewBag.RfqId = rfq.RfqId;
            ViewBag.VersionDate = rversion.Date;
            ViewBag.NumberVersion = rversion.NumberVersion;
            ViewBag.SiteFarm = rfq.Farm.FarmName;
            ViewBag.FullName = rfq.Farm.Client.FullName;
            ViewBag.Street = rfq.Farm.StreetAddress;
            ViewBag.City = rfq.Farm.City;
            ViewBag.State = rfq.Farm.State;
            ViewBag.Country = rfq.Farm.Country;
            ViewBag.ProjectDescription = rversion.ProjectDescription;
            ViewBag.ProjectName = rfq.ProjectName;
            ViewBag.RversionId = rversion.RversionId;

            ViewBag.TypeWork = rversion.TypeWork;
            ViewBag.ScopeWork = rversion.ScopeWork.Work;

            ViewBag.Notes = rversion.NotesAndInstructions;
            ViewBag.Description = "";

            //ViewBag.Description = new SelectList(db.QuotesLists, "Description", "Description");

            return View();
        }

        // POST: Quotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteId,Description,PricePerUnit,NUnits,HourlyRate,Technicians,WeeklyHours,Weeks,Total,TypeR,RversionId")] Quote quote)
        {
            
            if (ModelState.IsValid)
            {
                db.Quotes.Add(quote);
                db.SaveChanges();
                return new JsonResult() { Data = quote.QuoteId };
            }
            ViewBag.Description = new SelectList(db.QuotesLists, "Description", "Description");
            ViewBag.RversionId = new SelectList(db.Rversions, "RversionId", "ScopeWork", quote.RversionId);
            return new JsonResult() { Data = quote.QuoteId };
        }


        // GET: Quotes/Edit/5
        public ActionResult PartialVersionEdit(int? rversionId, int rfqId)
        {
            if (rversionId == null)
            {
                return RedirectToAction("Details", "Rfqs", new { id = rfqId });
            }
            Rversion rversion = db.Rversions.Find(rversionId);
            Rfq rfq = db.Rfqs.Find(rfqId);


            ViewBag.VersionDate = rversion.Date;
            ViewBag.NumberVersion = rversion.NumberVersion;
            ViewBag.RfqId = rfqId;

            ViewBag.SiteFarm = rfq.Farm.FarmName;
            ViewBag.FullName = rfq.Farm.Client.FullName;
            ViewBag.Street = rfq.Farm.StreetAddress;
            ViewBag.City = rfq.Farm.City;
            ViewBag.State = rfq.Farm.State;
            ViewBag.Country = rfq.Farm.Country;
            ViewBag.ProjectDescription = rversion.ProjectDescription;
            ViewBag.ProjectName = rfq.ProjectName;
            ViewBag.RversionId = rversion.RversionId;

            ViewBag.TypeWork = rversion.TypeWork;
            ViewBag.Notes = rversion.NotesAndInstructions;
            ViewBag.ScopeWork = rversion.ScopeWork.Work;
            ViewBag.Typefarm = rfq.Farm.TypeFarm;
            ViewBag.Description = "";

            ViewBag.MIPricePerTech = rversion.MIPricePerTech;
            ViewBag.MITechnicians = rversion.MITechnicians;
            ViewBag.MITotal = rversion.MITotal;

            ViewBag.MOPricePerTech = rversion.MOPricePerTech;
            ViewBag.MOTechnicians = rversion.MOTechnicians;
            ViewBag.MOTotal = rversion.MOTotal;


            var quotes1 = db.Quotes.Where(q => q.RversionId == rversion.RversionId).Where(r => r.TypeR == 1).ToList();
            var quotes2 = db.Quotes.Where(q => q.RversionId == rversion.RversionId).Where(r => r.TypeR == 2).ToList();

            ViewBag.Quotes1 = quotes1;
            ViewBag.Quotes2 = quotes2;


            //ViewBag.Description = new SelectList(db.QuotesLists, "Description", "Description");


            ViewBag.Quotes = db.Quotes.Where(r => r.RversionId == rversionId).ToList();
            return PartialView();
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
