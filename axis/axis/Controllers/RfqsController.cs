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
                case "Wind":
                    rfqss = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Wind);
                    break;
                //        var rfqsWind = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Wind);
                //        return View(rfqsWind.ToPagedList(pageNumber, pageSize));
                case "Solar":
                    rfqss = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Solar);
                    break;
                //        var rfqsSolar = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Solar);
                //        return View(rfqsSolar.ToPagedList(pageNumber, pageSize));
                case "Other":
                    rfqss = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Other);
                    break;
                //        var rfqsOther = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Other);
                //        return View(rfqsOther.ToPagedList(pageNumber, pageSize));
                default:
                    rfqss = db.Rfqs.Include(r => r.Farm).Where(r => r.Farm.TypeFarm == TypeFarm.Wind);
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



            int pageSize = 3;
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

                case "Wind":
                    ViewBag.FarmId = new SelectList(db.Farms.Where(f => f.TypeFarm == TypeFarm.Wind), "FarmId", "FarmName");
                    break;
                case "Solar":
                    ViewBag.FarmId = new SelectList(db.Farms.Where(f => f.TypeFarm == TypeFarm.Solar), "FarmId", "FarmName");
                    break;
                case "Other":
                    ViewBag.FarmId = new SelectList(db.Farms.Where(f => f.TypeFarm == TypeFarm.Other), "FarmId", "FarmName");
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

        // GET: Rfqs/Edit/5
        public ActionResult VersionDetails(int? RversionId, int? RfqId, string typefarm )
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

            var quotes = db.Quotes.Where(q => q.RversionId == rversion.RversionId).ToList();

            ViewBag.Quotes = quotes;

            return View(rfq);
        }

    }

}
