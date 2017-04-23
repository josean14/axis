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
using System.IO;

namespace AXIS.Controllers
{
    [Authorize]
    public class TechesController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Teches
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";
            ViewBag.AirportSortParm = sortOrder == "Airport" ? "airport_desc" : "Airport";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Teches = from s in db.Teches
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Teches = Teches.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Teches = Teches.OrderByDescending(s => s.FirstName);
                    break;
                case "Country":
                    Teches = Teches.OrderBy(s => s.Country);
                    break;
                case "country_desc":
                    Teches = Teches.OrderByDescending(s => s.Country);
                    break;
                case "Airport":
                    Teches = Teches.OrderBy(s => s.LocalAirport);
                    break;
                case "airport_desc":
                    Teches = Teches.OrderByDescending(s => s.LocalAirport);
                    break;
                default: //Name ascending
                    Teches = Teches.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Teches.ToPagedList(pageNumber, pageSize));
        }



        // GET: Teches/Assets
        public ActionResult Assets(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";
            ViewBag.AirportSortParm = sortOrder == "Airport" ? "airport_desc" : "Airport";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Teches = from s in db.Teches
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Teches = Teches.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Teches = Teches.OrderByDescending(s => s.FirstName);
                    break;
                case "Country":
                    Teches = Teches.OrderBy(s => s.Country);
                    break;
                case "country_desc":
                    Teches = Teches.OrderByDescending(s => s.Country);
                    break;
                case "Airport":
                    Teches = Teches.OrderBy(s => s.LocalAirport);
                    break;
                case "airport_desc":
                    Teches = Teches.OrderByDescending(s => s.LocalAirport);
                    break;
                default: //Name ascending
                    Teches = Teches.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Teches.ToPagedList(pageNumber, pageSize));
        }

        // GET: Teches/WorkExp
        public ActionResult WorkExp(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";
            ViewBag.AirportSortParm = sortOrder == "Airport" ? "airport_desc" : "Airport";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var Teches = from s in db.Teches
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Teches = Teches.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Teches = Teches.OrderByDescending(s => s.FirstName);
                    break;
                case "Country":
                    Teches = Teches.OrderBy(s => s.Country);
                    break;
                case "country_desc":
                    Teches = Teches.OrderByDescending(s => s.Country);
                    break;
                case "Airport":
                    Teches = Teches.OrderBy(s => s.LocalAirport);
                    break;
                case "airport_desc":
                    Teches = Teches.OrderByDescending(s => s.LocalAirport);
                    break;
                default: //Name ascending
                    Teches = Teches.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Teches.ToPagedList(pageNumber, pageSize));
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

            ViewBag.Src = "~/Content/images/Users/" + tech.TechId + "/" + tech.Photo + "?width=100&height=90&mode=min";
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
        public ActionResult Create([Bind(Include = "TechId,Photo,FirstName,LastName,Language,StreetAdderess,CityAdderess,State,Zip,Country,Cell,Email,EmailCompany,LocalAirport,SSN,DriveLicence,PayRate,DayliPerDiem,Medical,Passport,MaritalStatus,Children,Education")] Tech tech)
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
        public ActionResult Edit([Bind(Include = "TechId,Photo,FirstName,LastName,Language,StreetAdderess,CityAdderess,State,Zip,Country,Cell,Email,EmailCompany,LocalAirport,SSN,DriveLicence,PayRate,DayliPerDiem,Medical,Passport,MaritalStatus,Children,Education")] Tech tech)
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

        public ActionResult Uploadimg(int? id)
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
            ViewBag.Src = "~/Content/images/Users/" + tech.TechId + "/" + tech.Photo + "?width=140&height=130&mode=min";


            return View(tech);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Uploadimg(HttpPostedFileBase Photo, int TechId)
        {

            string _FileName;
            string path;
            var dir = Server.MapPath("~/Content/images/Users/" + TechId);
            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", ".jpeg",".JPG"
            };
            var ext = "";
            Tech tech = db.Teches.Find(TechId);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }


            if (Photo != null)
            {
                ext = System.IO.Path.GetExtension(Photo.FileName);
            }


            if (allowedExtensions.Contains(ext))
            {

                _FileName = System.IO.Path.GetFileName(Photo.FileName);
                path = System.IO.Path.Combine(dir, _FileName);
                Photo.SaveAs(path);

                tech.Photo = _FileName;
                db.Entry(tech).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details", "Teches", new { id = TechId });
            }
            else
            {
                ViewBag.message = "Please choose only Image file";
                ViewBag.Src = "~/Content/images/Users/" + tech.TechId + "/" + tech.Photo + "?width=140&height=130&mode=min";
                return View(tech);
            }

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
