using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;
using System.IO;
using PagedList;

namespace AXIS.Controllers
{
    [Authorize]
    public class TechInfoAxisController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: TechInfoAxis/Index
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
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Teches.ToPagedList(pageNumber, pageSize));
        }


        // GET: TechInfoAxis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoAxi techInfoAxi = db.TechInfoAxis.Find(id);
            if (techInfoAxi == null)
            {
                return HttpNotFound();
            }
            return View(techInfoAxi);
        }

     
        // GET: TechInfoAxis/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechInfoAxi techInfoAxi = db.TechInfoAxis.Where(c => c.TechId == id).Single();
            if (techInfoAxi == null)
            {
                return HttpNotFound();
            }
            techInfoAxi.TechId = id;
            return View(techInfoAxi);
        }

        // POST: TechInfoAxis/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechInfoAxiId,ExperienceDate,HasI9,HasW2,HasW4,HasApplicanceOffer,HasAxisLaborCode,TechnicalLevel,TechId")] TechInfoAxi techInfoAxi, HttpPostedFileBase I9File,
            HttpPostedFileBase W2File, HttpPostedFileBase W4File,
            HttpPostedFileBase ApplicanceOfferFile, HttpPostedFileBase AxisLaborCodeFile,
            HttpPostedFileBase Osha10, HttpPostedFileBase FirstAidCPR,
            HttpPostedFileBase TowerRescue, HttpPostedFileBase ConfinedSpace,
            HttpPostedFileBase Nfra70E, HttpPostedFileBase Loto,
            HttpPostedFileBase Ergonomics, HttpPostedFileBase Hazcom,
            HttpPostedFileBase CraneSafety, HttpPostedFileBase RiggingSignalMan,
            HttpPostedFileBase FireExtinguisher
            )
            
        {
            string _FileName;
            string path;

            if (ModelState.IsValid)
            {

                var techInfoAxi2 = db.TechInfoAxis.Find(techInfoAxi.TechInfoAxiId);
                techInfoAxi2.ExperienceDate = techInfoAxi.ExperienceDate;
                techInfoAxi2.TechnicalLevel = techInfoAxi.TechnicalLevel;
                techInfoAxi2.HasI9 = techInfoAxi.HasI9;
                techInfoAxi2.HasW2 = techInfoAxi.HasW2;
                techInfoAxi2.HasW4 = techInfoAxi.HasW4;
                techInfoAxi2.HasApplicanceOffer = techInfoAxi.HasApplicanceOffer;
                techInfoAxi2.HasAxisLaborCode = techInfoAxi.HasAxisLaborCode;

                var dir = Server.MapPath("~/Documents/Teches/" + techInfoAxi.TechId);

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                if (Osha10 != null)
                {
                    _FileName = System.IO.Path.GetFileName(Osha10.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    Osha10.SaveAs(path);
                    techInfoAxi2.Osha10 = _FileName;
                }

                if (FirstAidCPR != null)
                {
                    _FileName = System.IO.Path.GetFileName(FirstAidCPR.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    FirstAidCPR.SaveAs(path);
                    techInfoAxi2.FirstAidCPR = _FileName;
                }

                if (TowerRescue != null)
                {
                    _FileName = System.IO.Path.GetFileName(TowerRescue.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    TowerRescue.SaveAs(path);
                    techInfoAxi2.TowerRescue = _FileName;
                }

                if (ConfinedSpace != null)
                {
                    _FileName = System.IO.Path.GetFileName(ConfinedSpace.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    ConfinedSpace.SaveAs(path);
                    techInfoAxi2.ConfinedSpace = _FileName;
                }

                if (Nfra70E != null)
                {
                    _FileName = System.IO.Path.GetFileName(Nfra70E.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    Nfra70E.SaveAs(path);
                    techInfoAxi2.Nfra70E = _FileName;
                }

                if (Loto != null)
                {
                    _FileName = System.IO.Path.GetFileName(Loto.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    Loto.SaveAs(path);
                    techInfoAxi2.Loto = _FileName;
                }

                if (Ergonomics != null)
                {
                    _FileName = System.IO.Path.GetFileName(Ergonomics.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    Ergonomics.SaveAs(path);
                    techInfoAxi2.Ergonomics = _FileName;
                }

                if (Hazcom != null)
                {
                    _FileName = System.IO.Path.GetFileName(Hazcom.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    Hazcom.SaveAs(path);
                    techInfoAxi2.Hazcom = _FileName;
                }

                if (CraneSafety != null)
                {
                    _FileName = System.IO.Path.GetFileName(CraneSafety.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    CraneSafety.SaveAs(path);
                    techInfoAxi2.CraneSafety = _FileName;
                }

                if (RiggingSignalMan != null)
                {
                    _FileName = System.IO.Path.GetFileName(RiggingSignalMan.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    RiggingSignalMan.SaveAs(path);
                    techInfoAxi2.RiggingSignalMan = _FileName;
                }

                if (FireExtinguisher != null)
                {
                    _FileName = System.IO.Path.GetFileName(FireExtinguisher.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    FireExtinguisher.SaveAs(path);
                    techInfoAxi2.FireExtinguisher = _FileName;
                }

                if (I9File != null && techInfoAxi.HasI9)
                {
                    _FileName = System.IO.Path.GetFileName(I9File.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    I9File.SaveAs(path);
                    techInfoAxi2.I9File = _FileName;
                }

                if (W2File != null && techInfoAxi.HasW2)
                {
                    _FileName = System.IO.Path.GetFileName(W2File.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    W2File.SaveAs(path);
                    techInfoAxi2.W2File = _FileName;
                }


                if (W4File != null && techInfoAxi.HasW4)
                {
                    _FileName = System.IO.Path.GetFileName(W4File.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    W4File.SaveAs(path);
                    techInfoAxi2.W4File = _FileName;
                }

                if (ApplicanceOfferFile != null && techInfoAxi.HasApplicanceOffer)
                {
                    _FileName = System.IO.Path.GetFileName(ApplicanceOfferFile.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    ApplicanceOfferFile.SaveAs(path);
                    techInfoAxi2.ApplicanceOfferFile = _FileName;
                }

                if (AxisLaborCodeFile != null && techInfoAxi.HasAxisLaborCode)
                {
                    _FileName = System.IO.Path.GetFileName(AxisLaborCodeFile.FileName);
                    path = System.IO.Path.Combine(dir, _FileName);
                    AxisLaborCodeFile.SaveAs(path);
                    techInfoAxi2.AxisLaborCodeFile = _FileName;
                }


                db.Entry(techInfoAxi2).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "TechInfoAxis");
            }
            ViewBag.Message = "Save error";
            return View(techInfoAxi);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Open Files
        public FileResult Download(string ImageName, int TechId)
        {
            return File("~/Documents/Teches/" + TechId + "/" + ImageName, System.Net.Mime.MediaTypeNames.Application.Octet, ImageName);
        }
    }
}
