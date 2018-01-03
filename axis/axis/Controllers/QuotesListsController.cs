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
    public class QuotesListsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: QuotesLists
        public ActionResult Index()
        {
            return View(db.QuotesLists.ToList());
        }

        // GET: QuotesLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotesList quotesList = db.QuotesLists.Find(id);
            if (quotesList == null)
            {
                return HttpNotFound();
            }
            return View(quotesList);
        }

        // GET: QuotesLists/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: QuotesLists/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuotesListId,Description,Um,Cost,Price")] QuotesList quotesList)
        {
            if (ModelState.IsValid)
            {
                db.QuotesLists.Add(quotesList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quotesList);
        }

        // GET: QuotesLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotesList quotesList = db.QuotesLists.Find(id);
            if (quotesList == null)
            {
                return HttpNotFound();
            }
            return View(quotesList);
        }

        // POST: QuotesLists/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuotesListId,Description,Um,Cost,Price")] QuotesList quotesList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quotesList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quotesList);
        }



        // POST: QuotesLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            QuotesList quotesList = db.QuotesLists.Find(id);
            db.QuotesLists.Remove(quotesList);
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

        [HttpPost]
        public ActionResult GetQuotes(string Description)
        {
            var quotes = db.QuotesLists.Where(c => c.Description == Description).Single();


            return Json(new { Um = quotes.Um, Cost = quotes.Cost, Price = quotes.Price });

        }


    }
}
