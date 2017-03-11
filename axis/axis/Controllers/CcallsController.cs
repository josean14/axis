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
    public class CcallsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Ccalls
        public ActionResult Index()
        {


            List<SelectListItem> propertyTypesSelectList = new SelectList(db.Clients, "ClientId", "FullName").ToList();
            propertyTypesSelectList.Insert(0, new SelectListItem() { Value = "0", Text = "Select Client" });

            ViewBag.ClientId = propertyTypesSelectList;
            return View();
        }

        public ActionResult PartialCallList(int id)
        {

            var ccalls = db.Ccalls.Include(c => c.Client).Where(f => f.ClientId == id);
            ViewBag.ClientId = id;
            return PartialView(ccalls.ToList());
        }


        // GET: Ccalls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ccall ccall = db.Ccalls.Find(id);
            if (ccall == null)
            {
                return HttpNotFound();
            }
            return View(ccall);
        }

        //Create que renderiza la vista parcial
        public ActionResult PartialCreate(int Id)
        {
            var model = new Ccall
            {
                ClientId = Id
            };

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartialCreate([Bind(Include = "CcallId,Title,Date,Note,UserName,ClientId")] Ccall ccall)
        {
            if (ModelState.IsValid)
            {
                db.Ccalls.Add(ccall);
                db.SaveChanges();
                return new JsonResult() { Data = 1 };
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", ccall.ClientId);
            return View(ccall);
        }


        // GET: Ccalls/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");

            return View();
        }

        // POST: Ccalls/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CcallId,Title,Date,Note,UserName,ClientId")] Ccall ccall)
        {
            if (ModelState.IsValid)
            {
                db.Ccalls.Add(ccall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", ccall.ClientId);
            return View(ccall);
        }

        // GET: Ccalls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ccall ccall = db.Ccalls.Find(id);
            if (ccall == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", ccall.ClientId);
            return View(ccall);
        }

        // POST: Ccalls/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CcallId,Title,Date,Note,UserName,ClientId")] Ccall ccall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ccall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", ccall.ClientId);
            return View(ccall);
        }

        // GET: Ccalls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ccall ccall = db.Ccalls.Find(id);
            if (ccall == null)
            {
                return HttpNotFound();
            }
            return View(ccall);
        }

        // POST: Ccalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ccall ccall = db.Ccalls.Find(id);
            db.Ccalls.Remove(ccall);
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
