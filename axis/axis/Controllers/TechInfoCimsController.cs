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
    public class TechInfoCimsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: TechInfoCims
        public ActionResult Index()
        {
            var techInfoCims = db.TechInfoCims.Include(t => t.Tech);
            return View(techInfoCims.ToList());
        }

        // GET: TechInfoCims/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoCim techInfoCim = db.TechInfoCims.Where(c => c.TechId == id).Single();
            if (techInfoCim == null)
            {
                return HttpNotFound();
            }
            return View(techInfoCim);
        }

       
        // GET: TechInfoCims/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoCim techInfoCim = db.TechInfoCims.Where(c => c.TechId == id).Single();
            if (techInfoCim == null)
            {
                return HttpNotFound();
            }
            ViewBag.TechId = id;
            return View(techInfoCim);
        }

        // POST: TechInfoCims/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechInfoCimId,Computer,Phone,Camera,Other,TechId")] TechInfoCim techInfoCim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(techInfoCim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Teches", new { id = techInfoCim.TechId });
            }
            ViewBag.Message = "Save error";
            return View(techInfoCim);
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
