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
    [Authorize]
    public class TechInfoKitsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: TechInfoKits
        public ActionResult Index()
        {

            var techInfoKits = db.TechInfoKits.Include(t => t.Tech);
            return View(techInfoKits.ToList());
        }

        // GET: TechInfoKits/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoKit techInfoKit = db.TechInfoKits.Where(c => c.TechId == id).Single();
            if (techInfoKit == null)
            {
                return HttpNotFound();
            }
            return View(techInfoKit);
        }

        // GET: TechInfoKits/Details/6
        public ActionResult PartialKitdetails(int TechId)
        {
            if (TechId < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoKit techInfoKit = db.TechInfoKits.Where(c => c.TechId == TechId).Single();
            if (techInfoKit == null)
            {
                return HttpNotFound();
            }
            ViewBag.TechId = TechId;
            return PartialView(techInfoKit);
        }


        // GET: TechInfoKits/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoKit techInfoKit = db.TechInfoKits.Where(c => c.TechId == id).Single();
            if (techInfoKit == null)
            {
                return HttpNotFound();
            }
            ViewBag.TechId = id;
            return View(techInfoKit);
        }

        // POST: TechInfoKits/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechInfoKitId,HarnessManufacter,HarnessModel,HarnessSerial,HarnessDateManufacture,HarnessRecertification,LaynarManufacter,LaynarModel,LaynarSerial,LaynarDateManufacture,LaynarRecertification,CableGrab,Helment,Uniforms,Other,TechId")] TechInfoKit techInfoKit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(techInfoKit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Teches", new { id = techInfoKit.TechId });
            }
            ViewBag.Message = "Save error";
            return View(techInfoKit);
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
