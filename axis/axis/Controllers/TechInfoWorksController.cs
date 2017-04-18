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
    public class TechInfoWorksController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: TechInfoWorks
        public ActionResult Index(int id)
        {
            int techid = id;

            var techInfoWorks = from s in db.TechInfoWorks
                                select s;

            techInfoWorks = techInfoWorks.Include(t => t.Farm).Include(t => t.Scopework).Include(t => t.Tech);

            techInfoWorks = techInfoWorks.Where(s => s.TechId.Equals(techid));
            ViewBag.TechId = techid;

            return View(techInfoWorks.ToList());

            //var techInfoWorks = db.TechInfoWorks.Include(t => t.Farm).Include(t => t.Scopework).Include(t => t.Tech);
            //return View(techInfoWorks.ToList());
        }

        // GET: TechInfoWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoWork techInfoWork = db.TechInfoWorks.Find(id);
            if (techInfoWork == null)
            {
                return HttpNotFound();
            }
            return View(techInfoWork);
        }

        // GET: TechInfoWorks/Create
        public ActionResult Create()
        {
            ViewBag.FarmId = new SelectList(db.Farms, "FarmId", "FarmName");
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work");
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "FullName");
            ViewBag.ManufacturerName = new SelectList(db.Manufacteres, "ManufacturerName", "ManufacturerName");
            return View();
        }

        // POST: TechInfoWorks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechInfoWorkId,TypeOfService,ManufacturerName,PlatformName,Notes,FarmId,ScopeWorkId,TechId")] TechInfoWork techInfoWork)
        {
            if (ModelState.IsValid)
            {
                db.TechInfoWorks.Add(techInfoWork);
                db.SaveChanges();
                return RedirectToAction("WorkExp","Teches");
            }

            ViewBag.FarmId = new SelectList(db.Farms, "FarmId", "FarmName", techInfoWork.FarmId);
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", techInfoWork.ScopeWorkId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "FullName", techInfoWork.TechId);
            ViewBag.ManufacturerName = new SelectList(db.Manufacteres, "ManufacturerName", "ManufacturerName");
            return View(techInfoWork);
        }

        // GET: TechInfoWorks/Edit/5
        public ActionResult Edit(int? id, int idtech)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoWork techInfoWork = db.TechInfoWorks.Find(id);
            if (techInfoWork == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmId = new SelectList(db.Farms, "FarmId", "FarmName", techInfoWork.FarmId);
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", techInfoWork.ScopeWorkId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "FullName", techInfoWork.TechId);
            ViewBag.ManufacturerName = new SelectList(db.Manufacteres, "ManufacturerName", "ManufacturerName", techInfoWork.ManufacturerName);

            var objPlatform = db.Platforms.Where(c => c.ManufacturerName == techInfoWork.ManufacturerName);

            ViewBag.PlatformName = new SelectList(objPlatform, "PlatformName", "PlatformName", techInfoWork.PlatformName);

            return View(techInfoWork);
        }

        // POST: TechInfoWorks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechInfoWorkId,TypeOfService,ManufacturerName,PlatformName,Notes,FarmId,ScopeWorkId,TechId")] TechInfoWork techInfoWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(techInfoWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "TechInfoWorks", new { id = techInfoWork.TechId });
            }
            ViewBag.FarmId = new SelectList(db.Farms, "FarmId", "FarmName", techInfoWork.FarmId);
            ViewBag.ScopeWorkId = new SelectList(db.ScopeWorks, "ScopeWorkId", "Work", techInfoWork.ScopeWorkId);
            ViewBag.TechId = new SelectList(db.Teches, "TechId", "FullName", techInfoWork.TechId);

            ViewBag.ManufacturerName = new SelectList(db.Manufacteres, "ManufacturerName", "ManufacturerName", techInfoWork.ManufacturerName);

            var objPlatform = db.Platforms.Where(c => c.ManufacturerName == techInfoWork.ManufacturerName);

            ViewBag.PlatformName = new SelectList(objPlatform, "PlatformName", "PlatformName", techInfoWork.PlatformName);

            return View(techInfoWork);
        }

        // GET: TechInfoWorks/Delete/5
        public ActionResult Delete(int? id, int idtech)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoWork techInfoWork = db.TechInfoWorks.Find(id);
            if (techInfoWork == null)
            {
                return HttpNotFound();
            }
            return View(techInfoWork);
        }

        // POST: TechInfoWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechInfoWork techInfoWork = db.TechInfoWorks.Find(id);
            db.TechInfoWorks.Remove(techInfoWork);
            db.SaveChanges();
            return RedirectToAction("Index", "TechInfoWorks", new { id = techInfoWork.TechId });
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
        public ActionResult GetPlatform(string ManufacturerName)
        {
            var objconstruct = db.Platforms.Where(c => c.ManufacturerName == ManufacturerName);

            SelectList listdefault = new SelectList(objconstruct, "PlatformName", "PlatformName", 0);
            return Json(listdefault);

        }
    }
}
