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

namespace AXIS.Controllers
{
    [Authorize]
    public class ContractsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Contracts
        public ActionResult Index()
        {
            var contracts = db.Contracts.Include(c => c.Rfq).Include(c => c.Rversion).OrderByDescending(c => c.Date);
            return View(contracts.ToList());
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
        public ActionResult Create(int rfqid, int rversionid)
        {
            var model = new Contract
            {
                RfqId = rfqid,
                RversionId = rversionid
            };

            ViewBag.RfqId = rfqid;
            ViewBag.RversionId = rversionid;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractId,OcClient,Date,RfqId,RversionId")] Contract contract, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {

                var dir = Server.MapPath("~/Documents/Contracts/" + contract.RfqId);
                Directory.CreateDirectory(dir);

                string _FileName = System.IO.Path.GetFileName(file.FileName);

                string path = System.IO.Path.Combine(dir, _FileName);
                file.SaveAs(path);

                contract.Date = DateTime.Now;
                contract.File = _FileName;
                db.Contracts.Add(contract);
                db.SaveChanges();

                var listverions = db.Rversions.Where(r => r.RfqId == contract.RfqId).ToList();
                foreach (var item in listverions)
                {
                    if (item.RversionId != contract.RversionId)
                    {
                        item.Status = "Close";
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        item.Status = "Contract";
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();

                        var rfq = db.Rfqs.Find(contract.RfqId);
                        rfq.Status = "Contract";
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
        public ActionResult Edit([Bind(Include = "ContractId,OcClient,Date,File,RfqId,RversionId")] Contract contract)
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
    }
}
