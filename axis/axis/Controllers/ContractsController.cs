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
    [MyAuthorize(Roles = "Administrator, FieldManager, AFManager, SalesManager, Salesman")]
    public class ContractsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Contracts
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ContractSortParm = String.IsNullOrEmpty(sortOrder) ? "contract_desc" : "";
            ViewBag.FarmnameortParm = sortOrder == "Farmname" ? "farmname_desc" : "Farmname";
            ViewBag.ProjectnameSortParm = sortOrder == "Projectname" ? "projectname_desc" : "Projectname";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var contracts = from s in db.Contracts
                            select s;

            contracts = contracts.Include(c => c.Rfq).Include(c => c.Rversion);
            //var Contratos = db.Contracts.Include(c => c.Rfq).Include(c => c.Rversion).OrderByDescending(c => c.Date);
            //contracts = db.Contracts.Include(c => c.Rfq).Include(c => c.Rversion).OrderByDescending(c => c.Date);

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    contracts = contracts.Where(s => s.ContractId.Equals(numVal));
                    //rfqss = rfqss.Where(s => s.RfqId.Equals(numVal) && s.Farm.TypeFarm == TypeFarm.Solar);
                }
                else
                {
                    contracts = contracts.Where(s => s.ContractId.Equals(0));
                    ViewBag.Message = "Invalid Contract #";
                }

            }

            switch (sortOrder)
            {
                case "contract_desc":
                    contracts = contracts.OrderByDescending(s => s.ContractId);
                    break;
                case "Farmname":
                    contracts = contracts.OrderBy(s => s.Rfq.Farm.FarmName);
                    break;
                case "farmname_desc":
                    contracts = contracts.OrderByDescending(s => s.Rfq.Farm.FarmName);
                    break;
                case "Projectname":
                    contracts = contracts.OrderBy(s => s.Rfq.ProjectName);
                    break;
                case "projectname_desc":
                    contracts = contracts.OrderByDescending(s => s.Rfq.ProjectName);
                    break;
                default: //Contract ascending
                    contracts = contracts.OrderBy(s => s.ContractId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(contracts.ToPagedList(pageNumber, pageSize));

        }

        // GET: Contracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // GET: Contracts/Create
        public ActionResult Create(int rfqid, int rversionid, int version)
        {
            var model = new Contract
            {
                RfqId = rfqid,
                RversionId = rversionid
            };

            ViewBag.RfqId = rfqid;
            ViewBag.RversionId = rversionid;
            ViewBag.rversion = version;
            
            //Aqui se genera una lista con el usuario del ROL RM
            ViewBag.UserId = new SelectList(db.Users.Include(r => r.UserRoles).Where(r => r.UserRoles.RoleId == "7"), "Id", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractId,Comments,Date,StartDate,Status,EndDate,RfqId,RversionId,UserId")] Contract contract, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {

                var dir = Server.MapPath("~/Documents/Contracts/" + contract.RfqId);
                Directory.CreateDirectory(dir);

                string _FileName = System.IO.Path.GetFileName(file.FileName);

                string path = System.IO.Path.Combine(dir, _FileName);
                file.SaveAs(path);

                contract.Date = DateTime.Now;
                contract.Status = "OPEN";
                contract.File = _FileName;
                db.Contracts.Add(contract);
                db.SaveChanges();

                var listverions = db.Rversions.Where(r => r.RfqId == contract.RfqId).ToList();
                foreach (var item in listverions)
                {
                    if (item.RversionId != contract.RversionId)
                    {
                        item.Status = "Closed";
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        item.Status = "Contracted";
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();

                        var rfq = db.Rfqs.Find(contract.RfqId);
                        rfq.Status = "Contracted";
                        db.Entry(rfq).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }


                return RedirectToAction("Index", "Contracts");
            }


            return RedirectToAction("Index", "Contracts");
        }

        // GET: Contracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "Status", contract.RfqId);
            ViewBag.RversionId = new SelectList(db.Rversions, "RversionId", "ProjectDescription", contract.RversionId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractId,Comments,Date,StartDate,EndDate,File,RfqId,RversionId,UserId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RfqId = new SelectList(db.Rfqs, "RfqId", "Status", contract.RfqId);
            ViewBag.RversionId = new SelectList(db.Rversions, "RversionId", "ProjectDescription", contract.RversionId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
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

        //Open Files
        public FileResult Download(string ImageName, int Rfqid)
        {
            return File("~/Documents/Contracts/" + Rfqid + "/" + ImageName, System.Net.Mime.MediaTypeNames.Application.Octet, ImageName);
        }

    }
}
