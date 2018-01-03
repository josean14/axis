using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;
using PagedList;
using AXIS.Mailers;

namespace AXIS.Controllers
{
    [Authorize]
    public class MobilizationController : Controller
    {
        private AXISDB db = new AXISDB();

        // GET: Mobilization

        [MyAuthorize(Roles = "Administrator, FieldManager, RSourceManager, AAManager")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ContractSortParm = String.IsNullOrEmpty(sortOrder) ? "contract_desc" : "";
            ViewBag.PonameSortParm = sortOrder == "Poname" ? "poname_desc" : "Poname";
            ViewBag.DatenameSortParm = sortOrder == "Datetname" ? "datename_desc" : "Datetname";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

      
            var Purchaseorders = from s in db.Purchaseorders.Include(c => c.Contract).Include(d => d.Contract.Rfq.Farm)
                                 select s;
      Purchaseorders = Purchaseorders.Where(a => a.Status == "OPEN");

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    Purchaseorders = Purchaseorders.Where(s => s.ContractId.Equals(numVal));
                    //rfqss = rfqss.Where(s => s.RfqId.Equals(numVal) && s.Farm.TypeFarm == TypeFarm.Solar);
                }
                else
                {
                    Purchaseorders = Purchaseorders.Where(s => s.PurchaseOrderId.Equals(0));
                    ViewBag.Message = "Invalid PO AXIS#";
                }

            }

            switch (sortOrder)
            {
                case "contract_desc":
                    Purchaseorders = Purchaseorders.OrderByDescending(s => s.ContractId);
                    break;
                case "Poname":
                    Purchaseorders = Purchaseorders.OrderBy(s => s.PurchaseOrderId);
                    break;
                case "poname_desc":
                    Purchaseorders = Purchaseorders.OrderByDescending(s => s.PurchaseOrderId);
                    break;
                case "Datename":
                    Purchaseorders = Purchaseorders.OrderBy(s => s.Date);
                    break;
                case "datename_desc":
                    Purchaseorders = Purchaseorders.OrderByDescending(s => s.Date);
                    break;
                default: //Contract ascending
                    Purchaseorders = Purchaseorders.OrderBy(s => s.ContractId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Purchaseorders.ToPagedList(pageNumber, pageSize));
        }

        [MyAuthorize(Roles = "Administrator, FieldManager")]
        public ActionResult Authorization(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ContractSortParm = String.IsNullOrEmpty(sortOrder) ? "contract_desc" : "";
            ViewBag.PonameSortParm = sortOrder == "Poname" ? "poname_desc" : "Poname";
            ViewBag.StatusnameSortParm = sortOrder == "Statusname" ? "statusname_desc" : "Statusname";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            //var Purchaseorders = from s in db.Purchaseorders.Include(c => c.Contract).Include(d => d.Contract.Rfq.Farm)
            //                     select s;
            var approvaltech = from s in db.FieldOperations.Include(c => c.PurchaseOrder).Include(d => d.Tech)
                               select s;

            approvaltech = approvaltech.Where(a => a.status != "REJECTED").Where(a=> a.status != "DEMOBILIZED").Where(b=> b.TechApprovalADV == "PROCESSING");
            //approvaltech = approvaltech.Where(a => a.status.Contains("PENDING APPROVAL"));

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    approvaltech = approvaltech.Where(s => s.PurchaseOrder.ContractId.Equals(numVal));

                }
                else
                {
                    approvaltech = approvaltech.Where(s => s.PurchaseOrderId.Equals(0));
                    ViewBag.Message = "Invalid JOB AXIS#";
                }

            }

            switch (sortOrder)
            {
                case "contract_desc":
                    approvaltech = approvaltech.OrderByDescending(s => s.PurchaseOrder.ContractId);
                    break;
                case "Poname":
                    approvaltech = approvaltech.OrderBy(s => s.PurchaseOrderId);
                    break;
                case "poname_desc":
                    approvaltech = approvaltech.OrderByDescending(s => s.PurchaseOrderId);
                    break;
                case "Statusname":
                    approvaltech = approvaltech.OrderBy(s => s.status);
                    break;
                case "statusname_desc":
                    approvaltech = approvaltech.OrderByDescending(s => s.status);
                    break;
                default: //Contract ascending
                    approvaltech = approvaltech.OrderBy(s => s.PurchaseOrder.ContractId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(approvaltech.ToPagedList(pageNumber, pageSize));
        }

        [MyAuthorize(Roles = "Administrator, FieldManager")]
        public ActionResult AuthorizationTrucks(string sortOrder, string currentFilter, string searchString, int? page) 
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ContractSortParm = String.IsNullOrEmpty(sortOrder) ? "contract_desc" : "";
            ViewBag.PonameSortParm = sortOrder == "Poname" ? "poname_desc" : "Poname";
            ViewBag.DatenameSortParm = sortOrder == "Datetname" ? "datename_desc" : "Datetname";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var Trucks = from s in db.Trucks.Include(b => b.Purchaseorder).Include(c => c.Purchaseorder.Contract).Include(d => d.Purchaseorder.Contract.Rfq.Farm)
                         select s;
               Trucks = Trucks.Where(a => a.Status == "PENDING APPROVAL");

            if (!String.IsNullOrEmpty(searchString))
            {
                int numVal;
                if (Int32.TryParse(searchString, out numVal))
                {
                    Trucks = Trucks.Where(s => s.Purchaseorder.Contract.ContractId.Equals(numVal));
                    //rfqss = rfqss.Where(s => s.RfqId.Equals(numVal) && s.Farm.TypeFarm == TypeFarm.Solar);
                }
                else
                {
                    Trucks = Trucks.Where(s => s.PurchaseOrderId.Equals(0));
                    ViewBag.Message = "Invalid PO AXIS#";
                }

            }

            switch (sortOrder)
            {
                case "contract_desc":
                    Trucks = Trucks.OrderByDescending(s => s.Purchaseorder.Contract.ContractId);
                    break;
                case "Poname":
                    Trucks = Trucks.OrderBy(s => s.PurchaseOrderId);
                    break;
                case "poname_desc":
                    Trucks = Trucks.OrderByDescending(s => s.PurchaseOrderId);
                    break;
                case "Datename":
                    Trucks = Trucks.OrderBy(s => s.Purchaseorder.Date);
                    break;
                case "datename_desc":
                    Trucks = Trucks.OrderByDescending(s => s.Purchaseorder.Date);
                    break;
                default: //Contract ascending
                    Trucks = Trucks.OrderBy(s => s.Purchaseorder.Contract.ContractId);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(Trucks.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EmployeMob(int? id)
        {
            ViewBag.Poid = id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchaseorder purchaseorder = db.Purchaseorders.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeMob([Bind(Include = "PurchaseOrderId,Tooling,SpecialtyItems,AirportDestination,DepartureDate,TravelPlans,AirportCargoAddress,AirportCargoContact,LodgingInArea,Notes,ContractId,Commentary")] Purchaseorder POrder)
        {
            if (ModelState.IsValid)
            {
                Purchaseorder purchaseorder = db.Purchaseorders.Find(POrder.PurchaseOrderId);
                purchaseorder.Tooling = POrder.Tooling;
                purchaseorder.SpecialtyItems = POrder.SpecialtyItems;
                purchaseorder.AirportDestination = POrder.AirportDestination;
                purchaseorder.DepartureDate = POrder.DepartureDate;
                purchaseorder.TravelPlans = POrder.TravelPlans;
                purchaseorder.AirportCargoAddress = POrder.AirportCargoAddress;
                purchaseorder.AirportCargoContact = POrder.AirportCargoContact;
                purchaseorder.LodgingInArea = POrder.LodgingInArea;
                purchaseorder.Notes = POrder.Notes;

                db.Entry(purchaseorder).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("EmployeMob", "Mobilization", new { id = POrder.PurchaseOrderId });
            }

            
            return View(POrder);
        }

        public ActionResult EmployeMobPDF(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchaseorder purchaseorder = db.Purchaseorders.Find(id);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            var allCustomer = db.Clients.ToList();

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "EmployeeMob2.rpt"));

            rd.SetDataSource(allCustomer);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Employee Mobilization.pdf");
        }

        //Funciones para Mailer
        private IFONMailer _FONMailer = new FONMailer();
        public IFONMailer FONMailer
        {
            get { return _FONMailer; }
            set { _FONMailer = value; }
        }

        // POST: Assigned
        [HttpPost, ActionName("Assigned")]
        [ValidateAntiForgeryToken]
        public ActionResult Assigned(int id)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            FieldOperations field = new FieldOperations();

            fo.status = "ASSIGNED";


            db.Entry(fo).State = EntityState.Modified;
            db.SaveChanges();

            Tech tech = db.Teches.Find(fo.TechId);
            tech.Status = "IN FIELD";
            tech.POAsigned = fo.PurchaseOrder.PurchaseOrderId;
            db.Entry(tech).State = EntityState.Modified;
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
                FONMailer.TECHAPRV(tech.FullName, fo.status, email, emailCC, "", fo.PurchaseOrderId).Send();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                  ex.ToString());

            }


            return new JsonResult() { Data = "Assigned successfully" };
        }


        [HttpPost, ActionName("Denied")]
        [ValidateAntiForgeryToken]
        public ActionResult Denied(int id, string comment)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            var techid = fo.TechId;

            fo.status = "REJECTED";
            fo.TechApprovalADV = "NO";
            fo.RejectionComment = comment;
            db.Entry(fo).State = EntityState.Modified;
            db.SaveChanges();

            Tech tech = db.Teches.Find(techid);
            tech.Status = "BANCH";
            tech.POAsigned = 0;
            db.Entry(tech).State = EntityState.Modified;
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

            //
            //string emailCC = "jagr14@gmail.com";
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
                FONMailer.TECHAPRV(tech.FullName, fo.status, email, emailCC, comment, fo.PurchaseOrderId).Send();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                  ex.ToString());

            }


            return new JsonResult() { Data = "Denied successfully" };
        }


        [HttpPost, ActionName("ApprovalADV")]
        [ValidateAntiForgeryToken]
        public ActionResult ApprovalADV(int id)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            var techid = fo.TechId;


            fo.TechApprovalADV = "YES";
            db.Entry(fo).State = EntityState.Modified;
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
            users = db.Users.Include(r => r.UserRoles).Where(r => r.UserRoles.RoleId == "4");

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
                FONMailer.TECHAPRVADV(fo.Tech.FullName, fo.TechApprovalADV, email, emailCC, "", fo.PurchaseOrderId).Send();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                  ex.ToString());

            }


            return new JsonResult() { Data = "Liberty successfully" };
        }

        [HttpPost, ActionName("UnapprovalADV")]
        [ValidateAntiForgeryToken]
        public ActionResult UnapprovalADV(int id, string comment)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            var techid = fo.TechId;

            fo.TechApprovalADV = "NO";
            fo.ARejectionComment = comment;
            db.Entry(fo).State = EntityState.Modified;
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
            users = db.Users.Include(r => r.UserRoles).Where(r => r.UserRoles.RoleId == "4");

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
                FONMailer.TECHAPRVADV(fo.Tech.FullName, fo.TechApprovalADV, email, emailCC, comment, fo.PurchaseOrderId).Send();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                  ex.ToString());

            }

            return new JsonResult() { Data = "Liberty successfully" };
        }


        /// <summary>

        // POST: Assigned
        [HttpPost, ActionName("ApprovalTruck")]
        [ValidateAntiForgeryToken]
        public ActionResult ApprovalTruck(int id)
        {
            
            Truck truck = db.Trucks.Find(id);

            truck.Status = "COMPLETED";

            db.Entry(truck).State = EntityState.Modified;
            db.SaveChanges();

            TruckDetail truckdetail = new TruckDetail();
            
                // Se agregan los registros de trucks
                        
            for (int i = 0; i < truck.NumberTrucks; i++)
            {
                truckdetail.PurchaseOrderId = truck.PurchaseOrderId;
                truckdetail.Status = "PENDING RENT";

                db.TruckDetails.Add(truckdetail);
                db.SaveChanges();


             }
            



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
            email = "jagr14@gmail.com, eduardin23@hotmail.com";


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
            emailCC = "jagr14@gmail.com, eduardin23@hotmail.com";

            try
            {
                FONMailer.TRUCKAPV(truck.Status, email, emailCC, "", truck.PurchaseOrderId).Send();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                  ex.ToString());

            }


            return new JsonResult() { Data = "Assigned successfully" };
        }


        [HttpPost, ActionName("RejectdTruck")]
        [ValidateAntiForgeryToken]
        public ActionResult RejectdTruck(int id, string comment)
        {
            Truck truck = db.Trucks.Find(id);

            truck.Status = "REJECTED";
            truck.RejectionComment = comment;

            db.Entry(truck).State = EntityState.Modified;
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
            email = "jagr14@gmail.com, eduardin23@hotmail.com";


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
            emailCC = "jagr14@gmail.com, eduardin23@hotmail.com";

            try
            {
                FONMailer.TRUCKAPV(truck.Status, email, emailCC, comment, truck.PurchaseOrderId).Send();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
                  ex.ToString());

            }


            return new JsonResult() { Data = "Assigned successfully" };
        }




        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        [HttpPost, ActionName("Liberty")]
        [ValidateAntiForgeryToken]
        public ActionResult Liberty(int id)
        {
            FieldOperations fo = db.FieldOperations.Find(id);

            var techid = fo.TechId;

            fo.status = "DEMOBILIZED";
            db.Entry(fo).State = EntityState.Modified;
            db.SaveChanges();

            Tech tech = db.Teches.Find(techid);
            tech.Status = "BANCH";
            tech.POAsigned = 0;
            db.Entry(tech).State = EntityState.Modified;
            db.SaveChanges();

            return new JsonResult() { Data = "Liberty successfully" };
        }

    }





}