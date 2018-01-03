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
using AXIS.Mailers;

namespace AXIS.Controllers
{
    [Authorize]
    public class FlightsController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Flights
        public ActionResult Index(string msg)
        {
            var flights = db.Flights.Include(f => f.FieldOperarions);
            ViewBag.Msg = msg;
            return View(flights.ToList());
        }

        // PartialCreate
        public ActionResult PartialCreate(int PurchaseOrderId, int ContractId, int FieldOperationsId)
        {

            ViewBag.FieldOperationsId = FieldOperationsId;
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            ViewBag.ContractId = ContractId;
            return PartialView();
        }

        // POST: Flights/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightId,Description,DataFlight,CostFlight,Status,RejectionComment,FieldOperationsId")] Flight flight, HttpPostedFileBase DataFlight, int PurchaseOrderId, int ContractId)
        {
            if (ModelState.IsValid && DataFlight != null)
            {

                var dir = Server.MapPath("~/Documents/Flights/" + flight.FieldOperationsId);
                Directory.CreateDirectory(dir);

                string _FileName = System.IO.Path.GetFileName(DataFlight.FileName);

                string path = System.IO.Path.Combine(dir, _FileName);
                DataFlight.SaveAs(path);

                flight.Status = "PENDING APPROVAL";
                flight.DataFlight = _FileName;
                db.Flights.Add(flight);
                db.SaveChanges();
                ViewBag.ContractId = ContractId;


                return RedirectToAction("Details", "FieldOperations", new { id = flight.FieldOperationsId, ContractId = ContractId, PurchaseOrderId = PurchaseOrderId });
            }

            return RedirectToAction("Details", "FieldOperations", new { id = flight.FieldOperationsId, ContractId = ContractId, PurchaseOrderId = PurchaseOrderId });
            //return RedirectToAction("Index", "Flights",new { msg = "FAILED TO SAVE FLIGHT"});
        }


        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            db.SaveChanges();
            return new JsonResult() { Data = "Deleted successfully" };
        }


        public ActionResult PartialList(int PurchaseOrderId, int ContractId, int FieldOperationsId)
        {
            ViewBag.PurchaseOrderId = PurchaseOrderId;
            ViewBag.ContractId = ContractId;
            ViewBag.FieldOperationsId = FieldOperationsId;
            var flights = db.Flights.Where(c => c.FieldOperationsId == FieldOperationsId).Include(f => f.FieldOperarions);
            return PartialView(flights.ToList());
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
        public FileResult Download(int FieldOperationId, string ImageName)
        {
            return File("~/Documents/Flights/" + FieldOperationId + "/" + ImageName, System.Net.Mime.MediaTypeNames.Application.Octet, ImageName);
        }

        private IFONMailer _FONMailer = new FONMailer();
        public IFONMailer FONMailer
        {
            get { return _FONMailer; }
            set { _FONMailer = value; }
        }

        //Aprueba la compra del vuelo
        [HttpPost, ActionName("ApprovedF")]
        [ValidateAntiForgeryToken]
        public ActionResult ApprovedF(int id)
        {
            Flight flight = db.Flights.Find(id);

            flight.Status = "APPROVED";

            db.Entry(flight).State = EntityState.Modified;
            db.SaveChanges();

            string email = "";

            var users = db.Users.Include(r => r.UserRoles).Where(r => r.UserRoles.RoleId == "7");

            bool bd = false;

            foreach (var item in users)
            {

                if (bd)
                {
                    email = email + "," + item.Email;

                }
                else
                {
                    bd = true;
                    email = item.Email;
                }
            }
            //Prueba
            //email = "jagr14@gmail.com, eduardin23@hotmail.com";


            string emailCC = "";
            users = db.Users.Include(r => r.UserRoles).Where(r => r.UserRoles.RoleId == "3");

            bd = false;

            foreach (var item in users)
            {

                if (bd)
                {
                    emailCC = emailCC + "," + item.Email;

                }
                else
                {
                    bd = true;
                    emailCC = item.Email;
                }
            }
            //Prueba
            //emailCC = "jagr14@gmail.com, eduardin23@hotmail.com";

            try
            {
                FONMailer.FlightAPV(flight.FieldOperarions.Tech.FullName, flight.Status, email, emailCC, "", flight.FieldOperarions.PurchaseOrderId).Send();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                  ex.ToString());

            }

            return new JsonResult() { Data = "Assigned successfully" };
        }

        //Aprueba la compra del vuelo
        [HttpPost, ActionName("DeniedF")]
        [ValidateAntiForgeryToken]
        public ActionResult DeniedF(int id, string comment)
        {
            Flight flight = db.Flights.Find(id);

            flight.Status = "REJECTED";
            flight.RejectionComment = comment;
            db.Entry(flight).State = EntityState.Modified;
            db.SaveChanges();

            string email = "";

            var users = db.Users.Include(r => r.UserRoles).Where(r => r.UserRoles.RoleId == "7");

            bool bd = false;

            foreach (var item in users)
            {

                if (bd)
                {
                    email = email + "," + item.Email;

                }
                else
                {
                    bd = true;
                    email = item.Email;
                }
            }
            //Prueba
            //email = "jagr14@gmail.com, eduardin23@hotmail.com";


            string emailCC = "";
            users = db.Users.Include(r => r.UserRoles).Where(r => r.UserRoles.RoleId == "3");

            bd = false;

            foreach (var item in users)
            {

                if (bd)
                {
                    emailCC = emailCC + "," + item.Email;

                }
                else
                {
                    bd = true;
                    emailCC = item.Email;
                }
            }
            //Prueba
            //emailCC = "jagr14@gmail.com, eduardin23@hotmail.com";

            try
            {
                FONMailer.FlightAPV(flight.FieldOperarions.Tech.FullName, flight.Status, email, emailCC, comment, flight.FieldOperarions.PurchaseOrderId).Send();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                  ex.ToString());

            }

            return new JsonResult() { Data = "Assigned successfully" };
        }

    }
}
