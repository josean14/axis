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
    [MyAuthorize(Roles = "Administrator, FieldManager, AFManager, SalesManager, Salesman")]
    public class RversionsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Rversions
        public ActionResult Index()
        {
            var rversions = db.Rversions.Include(r => r.Rfq);
            var scopeworks = db.Rversions.Include(r => r.ScopeWork);
            return View(rversions.ToList());
        }

        // GET: Rversions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rversion rversion = db.Rversions.Find(id);
            if (rversion == null)
            {
                return HttpNotFound();
            }
            return View(rversion);
        }

        // GET: Rversions/Create
        public ActionResult Create(int rfqid, string projectname)
        {
            var model = new Rversion
            {
                RfqId = rfqid,
                NumberVersion = 1,
                Status = "Open",
                Date = DateTime.Now
            };
            Rfq rfq = db.Rfqs.Find(rfqid);
            ViewBag.ProjectName = projectname;
            ViewBag.RfqId = rfqid;
            ViewBag.FullName = rfq.Farm.Client.FullName;
            ViewBag.Street = rfq.Farm.StreetAddress;
            ViewBag.City = rfq.Farm.City;
            ViewBag.State = rfq.Farm.State;
            ViewBag.Country = rfq.Farm.Country;
            ViewBag.SiteFarm = rfq.Farm.FarmName;


            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work");
            return View(model);
        }

        // POST: Rversions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RversionId,NumberVersion,Date,TypeWork,ProjectDescription,TotalCost,Status,NotesAndInstructions,RfqId,ScopeWorkId,TermsandConditions")] Rversion rversion)
        {
            if (ModelState.IsValid)
            {
                rversion.Date = DateTime.Now;
                db.Rversions.Add(rversion);
                db.SaveChanges();
                return RedirectToAction("Create", "Quotes", new { rversionid = rversion.RversionId });
            }

            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "ProjectName", rversion.RfqId);
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", rversion.ScopeWorkId);
            return View(rversion);
        }

        // GET: Rversions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rversion rversion = db.Rversions.Find(id);
            if (rversion == null)
            {
                return HttpNotFound();
            }
            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "Status", rversion.RfqId);
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", rversion.ScopeWorkId);
            return View(rversion);
        }

        // POST: Rversions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RversionId,NumberVersion,Date,TypeWork,ProjectDescription,TotalCost,Status,NotesAndInstructions,RfqId,ScopeWorkId,TermsandConditions")] Rversion rversion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rversion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "Status", rversion.RfqId);
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", rversion.ScopeWorkId);
            return View(rversion);
        }



        // POST: Rversions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Rversion rversion = db.Rversions.Find(id);
            db.Rversions.Remove(rversion);
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


        //Action result for ajax call
        [HttpPost]
        public ActionResult GetScopeWork(int typework)
        {
            switch (typework)
            {

                case 0:
                    var objservice = db.ScopeWorks.Where(m => m.TypeWork == "Services");
                    SelectList listservice = new SelectList(objservice, "ScopeWorkId", "Work", 0);
                    return Json(listservice);
                case 1:
                    var objconstruct = db.ScopeWorks.Where(m => m.TypeWork == "Construct");
                    SelectList listconstruct = new SelectList(objconstruct, "ScopeWorkId", "Work", 0);
                    return Json(listconstruct);
                default:
                    SelectList listdefault = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", 0);
                    return Json(listdefault);
            }

        }

        [HttpPost]
        public ActionResult NewVersion(int? Id, int rfqId)
        {

            if (Id != null)
            {
                var sql = "SELECT Count(*) FROM axisdb.rversions where RfqId =" + rfqId;
                var total = db.Database.SqlQuery<int>(sql).First();
                Rversion rversion = db.Rversions.Find(Id);
                rversion.Date = DateTime.Now;
                rversion.NumberVersion = total + 1;
                db.Rversions.Add(rversion);
                db.SaveChanges();

                var listquote = db.Quotes.Where(r => r.RversionId == Id).ToList();
                foreach (var item in listquote)
                {

                    item.RversionId = rversion.RversionId;
                    db.Quotes.Add(item);
                    db.SaveChanges();
                }


                return RedirectToAction("PartialVersionEdit", "Quotes", new { rversionId = rversion.RversionId, rfqId = rfqId });
            }
            else
            {
                return new JsonResult() { Data = null };
            }

        }

        public ActionResult close(int? rfqid, int rversionid)
        {

            if (rfqid != null)
            {

                var rversion = db.Rversions.Find(rversionid);
                rversion.Status = "Close";
                db.Entry(rversion).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details", "Rfqs", new { id = rfqid });
            }

            return RedirectToAction("Index", "Rfqs");
        }

        ///Salvar datos de movilizacion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveM(int? Id, double MIPricePerTech,double MITechnicians, double MITotal, double MOPricePerTech, double MOTechnicians, double MOTotal)
        {


            if (Id != null)
            {

                var rversion = db.Rversions.Find(Id);

                rversion.MIPricePerTech = MIPricePerTech;
                rversion.MITechnicians = MITechnicians;
                rversion.MITotal = MITotal;
                rversion.MOPricePerTech = MOPricePerTech;
                rversion.MOTechnicians = MOTechnicians;
                rversion.MOTotal = MOTotal;

                db.Entry(rversion).State = EntityState.Modified;
                db.SaveChanges();

                return new JsonResult() { Data = 1 };
            }
            else
            {
                return new JsonResult() { Data = null };

            }

           // return RedirectToAction("Index", "Rfqs");
        }

    }
}
