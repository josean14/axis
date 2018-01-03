using AXIS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Controllers
{
    [Authorize]
    public class ToolsController : Controller
    {

        private AXISDB db = new AXISDB();
        // GET: Tools

        public ActionResult List() {

            return View();
        }

       //public ActionResult Edit(int? id, int ContractId)
       // {
       //     if (id == null)
       //     {
       //         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
       //     }
       //     var tool = db.AssignmentOfTools.Where(c => c.PurchaseOrderId == id);
       //     if (tool == null)
       //     {
       //         return HttpNotFound();
       //     }
       //     ViewBag.PurchaseOrderId = id;
       //     ViewBag.ContractId = ContractId;
       //     return PartialView(tool);
       // }

       // [HttpPost]
       // [ValidateAntiForgeryToken]
       // public ActionResult Edit([Bind(Include = "AssignmentOfToolsId,SuppliedBy,AditionalInfo,OrderNumber,Cost,PurchaseOrderId")] AssignmentOfTool tool, HttpPostedFileBase FileT, int PurchaseOrderId, int ContractId)
       // {
       //     if (ModelState.IsValid)
       //     {
       //         if (FileT != null)
       //         {
       //             var dir = Server.MapPath("~/Documents/PO/" + PurchaseOrderId + "/" + tool.AssignmentOfToolsId);
       //             if (!Directory.Exists(dir))
       //             {
       //                 Directory.CreateDirectory(dir);
       //             }

       //             string _FileName = System.IO.Path.GetFileName(FileT.FileName);

       //             string path = System.IO.Path.Combine(dir, _FileName);
       //             FileT.SaveAs(path);
       //         }
                
       //         db.Entry(tool).State = EntityState.Modified;
       //         db.SaveChanges();
       //         return RedirectToAction("Edit", new {id = PurchaseOrderId, ContractId = ContractId });
       //     }

       //     ViewBag.Msg = "ERROR ON SAVING";
       //     return RedirectToAction("Edit", new { id = PurchaseOrderId, ContractId = ContractId });
       // }
    }
}