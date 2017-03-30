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
    public class TechesController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Teches
        public ActionResult Index()
        {
            return View(db.Teches.ToList());
        }

        // GET: Teches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tech tech = db.Teches.Find(id);
            if (tech == null)
            {
                return HttpNotFound();
            }
            return View(tech);
        }

        // GET: Teches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teches/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechId,Photo,FirstName,LastName,Language,StreetAdderess,CityAdderess,State,Zip,Country,Cell,Email,LocalAirport,SSN,DriveLicence,PayRate,TypePayRate,Medical,Passport,MaritalStatus,Children,Education")] Tech tech)
        {
            if (ModelState.IsValid)
            {
                db.Teches.Add(tech);
                db.SaveChanges();

                //Tech Info
                var techInfoAxi = new TechInfoAxi();

                techInfoAxi.TechId = tech.TechId;
                techInfoAxi.ExperienceDate = DateTime.Now;

                db.TechInfoAxis.Add(techInfoAxi);
                db.SaveChanges();

                //Kit
                var techInfoKit = new TechInfoKit();
                techInfoKit.TechId = tech.TechId;
                techInfoKit.HarnessDateManufacture = DateTime.Now;
                techInfoKit.LaynarDateManufacture = DateTime.Now;

                db.TechInfoKits.Add(techInfoKit);
                db.SaveChanges();

                //Cim
                var techInfoCim = new TechInfoCim();
                techInfoCim.TechId = tech.TechId;


                db.TechInfoCims.Add(techInfoCim);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(tech);
        }

        // GET: Teches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tech tech = db.Teches.Find(id);
            if (tech == null)
            {
                return HttpNotFound();
            }
            return View(tech);
        }

        // POST: Teches/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechId,Photo,FirstName,LastName,Language,StreetAdderess,CityAdderess,State,Zip,Country,Cell,Email,LocalAirport,SSN,DriveLicence,PayRate,TypePayRate,Medical,Passport,MaritalStatus,Children,Education")] Tech tech)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tech).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tech);
        }

        // GET: Teches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tech tech = db.Teches.Find(id);
            if (tech == null)
            {
                return HttpNotFound();
            }
            return View(tech);
        }

        // POST: Teches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tech tech = db.Teches.Find(id);
            db.Teches.Remove(tech);
            db.SaveChanges();
            return RedirectToAction("Index");
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
