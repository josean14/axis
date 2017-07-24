using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;
using AXIS.Mailers;

namespace AXIS.Controllers
{
    public class FieldOperationsController : Controller
    {
        private AXISDB db = new AXISDB();



        // GET: FieldOperations/Details/5
        public ActionResult Details(int? id, int ContractId, int PurchaseOrderId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldOperations fieldOperations = db.FieldOperations.Find(id);
            if (fieldOperations == null || fieldOperations.status != "ASSIGNED")
            {
                return HttpNotFound();
            }
            ViewBag.ContractId = ContractId;
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            return View(fieldOperations);
        }

        // GET: FieldOperations/Create
        public ActionResult Create(int? id, int? ContractId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            ViewBag.ContractId = ContractId;
            ViewBag.PurchaseOrderId = id;

            ViewBag.TechId = new SelectList(db.Teches.Where(c => c.Status == "BANCH"), "TechId", "FullName");
            return View();
        }

        // POST: FieldOperations/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FieldOperationsId,TechApproval,PerDiemAdvance,TechApprovalADV,status,CertificatesStatus,RejectionComment,ARejectionComment,TechId,PurchaseOrderId")] FieldOperations fieldOperations, int ContractId)
        {
            if (ModelState.IsValid)
            {

                fieldOperations.status = "PENDING APPROVAL";
                fieldOperations.CertificatesStatus = "NO SENDING";
                fieldOperations.TechApprovalADV = "PROCESSING";
                db.FieldOperations.Add(fieldOperations);
                db.SaveChanges();

                var tech = db.Teches.Find(fieldOperations.TechId);
                tech.Status = "PENDING APPROVAL";
                db.Entry(tech).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Create", "FieldOperations", new { id = fieldOperations.PurchaseOrderId, ContractId = ContractId });
            }

            ViewBag.ContractId = ContractId;
            ViewBag.PurchaseOrderId = fieldOperations.PurchaseOrderId;

            ViewBag.TechId = new SelectList(db.Teches.Where(c => c.Status == "BANCH"), "TechId", "FullName");
            return View(fieldOperations);
        }



        // POST: FieldOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FieldOperations fieldOperations = db.FieldOperations.Find(id);
            db.FieldOperations.Remove(fieldOperations);
            db.SaveChanges();
            return new JsonResult() { Data = "Deleted successfully" };
        }



        //Despliega la lista de Tecnicos asignados a la PO
        public ActionResult PartialList(int Id, int ContractId)
        {

            ViewBag.ContractId = ContractId;
            ViewBag.PurchaseOrderId = Id;
            var fieldOperations = db.FieldOperations.Where(a => a.PurchaseOrderId == Id).Include(f => f.PurchaseOrder).Include(f => f.Tech);
            return PartialView(fieldOperations.ToList());
        }

        //Funciones para Mailer
        private IFONMailer _FONMailer = new FONMailer();
        public IFONMailer FONMailer
        {
            get { return _FONMailer; }
            set { _FONMailer = value; }
        }

        public ActionResult SendCertificates(int FieldOperationsId, int ContractId, int TechId, string FullName, int PurchaseOrderId)
        {

            TechInfoAxi model = db.TechInfoAxis.Where(c => c.TechId == TechId).Single();

            Contract contract = db.Contracts.Find(ContractId);

            //foreach(var item in Model)

            //El correo de email debe ser el contacto del Farm (email)
            string email = contract.Rfq.Farm.Email;
            //string email = "jagr14@gmail.com";

            //El correo de CC debe ser la persona que esta efecutando la acción

            var users = db.Users.Include(r => r.UserRoles).Where(r => r.UserRoles.RoleId == "1");
            string emailCC = "";
            bool bd = false;

            foreach (var item in users) {
                
                if (bd)
                {
                    emailCC = emailCC + "," + item.Email;

                }
                else {
                    bd = true;
                    emailCC = item.Email;
                }
                   

            }
            
            //string emailCC = "iprice@axisrg.com";
            //string emailCC = "jagr14@gmail.com";

            string path = "~/Documents/Teches/" + TechId + "/";

            try
            {
                FONMailer.Certificates(model, FullName, path, email, emailCC).Send();

                var FO = db.FieldOperations.Find(FieldOperationsId);
                FO.CertificatesStatus = "SENDING";
                db.Entry(FO).State = EntityState.Modified;
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                  ex.ToString());

            }


            return RedirectToAction("Create", "FieldOperations", new { id = PurchaseOrderId, ContractId = ContractId });
            // return RedirectToAction("Index");
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
        public FileResult Download(int FieldOperationsId, string ImageName)
        {
            return File("~/Documents/Flights/" + FieldOperationsId + "/" + ImageName, System.Net.Mime.MediaTypeNames.Application.Octet, ImageName);
        }
    }
}
