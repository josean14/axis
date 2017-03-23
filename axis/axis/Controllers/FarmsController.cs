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
    public class FarmsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Farms
        public ActionResult Index()
        {
            var farms = db.Farms.Include(f => f.Client);
            return View(farms.ToList());
        }

        // GET: Farms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farm farm = db.Farms.Find(id);
            if (farm == null)
            {
                return HttpNotFound();
            }
            return View(farm);
        }

        // GET: Farms/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");
            return View();
        }

        // POST: Farms/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmId,TypeFarm,FarmName,StreetAddress,City,State,ZipCode,Country,Manufacture,Platform,Convertor,NumberTowers,NumberMws,Gearbox,ClientId")] Farm farm)
        {
            if (ModelState.IsValid)
            {
                db.Farms.Add(farm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", farm.ClientId);
            return View(farm);
        }

        // GET: Farms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farm farm = db.Farms.Find(id);
            if (farm == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", farm.ClientId);
            return View(farm);
        }

        // POST: Farms/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmId,TypeFarm,FarmName,StreetAddress,City,State,ZipCode,Country,Manufacture,Platform,Convertor,NumberTowers,NumberMws,Gearbox,ClientId,Panel")] Farm farm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", farm.ClientId);
            return View(farm);
        }

       

        // POST: Farms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Farm farm = db.Farms.Find(id);
            db.Farms.Remove(farm);
            db.SaveChanges();
            return new JsonResult() { Data = 1 };
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
