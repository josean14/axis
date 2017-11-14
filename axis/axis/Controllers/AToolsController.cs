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
    public class AToolsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: ATools
        public ActionResult Index()
        {
            var assignmentOfTools = db.AssignmentOfTools.Include(a => a.Purchaseorder);
            return View(assignmentOfTools.ToList());
        }

        // GET: ATools/Edit/5
        public ActionResult Edit(int? id, int ContractId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentOfTool assignmentOfTool = db.AssignmentOfTools.Find(id);
            if (assignmentOfTool == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseOrderId = id;
            ViewBag.ContractId = ContractId;
            return View(assignmentOfTool);
        }

        // POST: ATools/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrderId,SuppliedBy")] AssignmentOfTool assignmentOfTool, HttpPostedFileBase FileT, int ContractId, string AditionalInfo, string OrderNumber, double Cost)
        {
            if (ModelState.IsValid)
            {
                assignmentOfTool = db.AssignmentOfTools.Find(assignmentOfTool.PurchaseOrderId);
                assignmentOfTool.AditionalInfo = AditionalInfo;
                assignmentOfTool.OrderNumber = OrderNumber;
                assignmentOfTool.Cost = Cost;

                if (FileT != null)
                {
                    var dir = Server.MapPath("~/Documents/PO/" + assignmentOfTool.PurchaseOrderId + "/" + "Tools");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    string _FileName = System.IO.Path.GetFileName(FileT.FileName);

                    string path = System.IO.Path.Combine(dir, _FileName);
                    FileT.SaveAs(path);

                    assignmentOfTool.FileT = FileT.FileName;
                }


                db.Entry(assignmentOfTool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Mobilization");
            }

            return View(assignmentOfTool);
        }


        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJson([Bind(Include = "PurchaseOrderId,SuppliedBy")] AssignmentOfTool assignmentOfTool, int ContractId, string AditionalInfo)
        {
            if (ModelState.IsValid)
            {
                assignmentOfTool.AditionalInfo = AditionalInfo;


                db.Entry(assignmentOfTool).State = EntityState.Modified;
                db.SaveChanges();
                return new JsonResult() { Data = "1" };
            }

            return new JsonResult() { Data = "0" };
        }

        //



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult PartialToolsbyJob()
        {
            return PartialView();
        }
    }
}
