using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;
using CrystalDecisions.CrystalReports.Engine;
using PagedList;

namespace AXIS.Controllers
{
    [MyAuthorize(Roles = "Administrator, FieldManager, AFManager, SalesManager, Salesman")]
    public class FarmsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Farms
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SiteSortParm = String.IsNullOrEmpty(sortOrder) ? "site_desc" : "";
            ViewBag.TypeSortParm = sortOrder == "TypeFarm" ? "typefarm_desc" : "TypeFarm";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var farms = from s in db.Farms
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                farms = farms.Where(s => s.FarmName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "site_desc":
                    farms = farms.OrderByDescending(s => s.FarmName);
                    break;
                case "TypeFarm":
                    farms = farms.OrderBy(s => s.TypeFarm);
                    break;
                case "typefarm_desc":
                    farms = farms.OrderByDescending(s => s.TypeFarm);
                    break;
                default: //Name ascending
                    farms = farms.OrderBy(s => s.FarmName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(farms.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Create([Bind(Include = "FarmId,TypeFarm,FarmName,StreetAddress,City,State,ZipCode,Country,Manufacture,Platform,Convertor,NumberTowers,NumberMws,Gearbox,ClientId,GeoLong, GeoLat,Email")] Farm farm)
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
        public ActionResult Edit([Bind(Include = "FarmId,TypeFarm,FarmName,StreetAddress,City,State,ZipCode,Country,Manufacture,Platform,Convertor,NumberTowers,NumberMws,Gearbox,ClientId,Panel,GeoLong,GeoLat,Email")] Farm farm)
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

        public ActionResult IndexPDF()
        {
            var allsites1 = db.Farms.Include(a => a.Client).ToList();
            var allsites = db.Farms.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "Site Index.rpt"));

            if (allsites1.Count == 0)
            {
                //No hay datos
                return HttpNotFound();
            }

            rd.SetDataSource(allsites1);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Farm Index.pdf");
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
