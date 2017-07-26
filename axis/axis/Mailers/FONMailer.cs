using AXIS.Models;
using Mvc.Mailer;
using System;
using System.Net.Mail;

namespace AXIS.Mailers
{
    public class FONMailer : MailerBase, IFONMailer
    {
        public FONMailer()
        {
            MasterName = "_Layout";
        }

        public virtual MvcMailMessage Certificates(TechInfoAxi model, string FullName, string path, string email, string emailCC)
        {
            ViewBag.FullName = FullName;
            var mailMessage = new MvcMailMessage
            {
                Subject = "Sending certificates",
                ViewName = "Sending certificates"
            };
            var attachmentPath = "";
            var file = "";

            if (model.Osha10 != null)
            {
                file = path + model.Osha10;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.FirstAidCPR != null)
            {
                file = path + model.FirstAidCPR;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.TowerRescue != null)
            {
                file = path + model.TowerRescue;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.ConfinedSpace != null)
            {
                file = path + model.ConfinedSpace;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.Nfra70E != null)
            {
                file = path + model.Nfra70E;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.Loto != null)
            {
                file = path + model.Loto;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.Ergonomics != null)
            {
                file = path + model.Ergonomics;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.Hazcom != null)
            {
                file = path + model.Hazcom;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.CraneSafety != null)
            {
                file = path + model.CraneSafety;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.RiggingSignalMan != null)
            {
                file = path + model.RiggingSignalMan;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.FireExtinguisher != null)
            {
                file = path + model.FireExtinguisher;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.I9File != null)
            {
                file = path + model.I9File;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.W2File != null)
            {
                file = path + model.W2File;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.W4File != null)
            {
                file = path + model.W4File;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.ApplicanceOfferFile != null)
            {
                file = path + model.ApplicanceOfferFile;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }
            }

            if (model.AxisLaborCodeFile != null)
            {
                file = path + model.AxisLaborCodeFile;
                attachmentPath = System.Web.HttpContext.Current.Server.MapPath(file);
                if (System.IO.File.Exists(attachmentPath))
                {
                    mailMessage.Attachments.Add(new Attachment(attachmentPath));
                }

            }





            mailMessage.To.Add(email);
            mailMessage.CC.Add(emailCC);
            PopulateBody(mailMessage, "Certificates", null);


            SmtpClient mailClient = new SmtpClient();

            mailClient.Timeout = 10;
            return mailMessage;


        }

        public virtual MvcMailMessage TECHAPRV(string FullName, string status, string email, string emailCC, string comment, int PO)
        {
            //ViewBag.Data = someObject;

            ViewBag.FullName = FullName;
            var mailMessage = new MvcMailMessage();

            switch (status)
            {
                case "ASSIGNED":
                    mailMessage.Subject = "The technician has been approved";
                    ViewBag.Msg = "The technician "+ FullName +" has been approved for PO "+ PO ;
                    break;

                case "DENIED":
                    mailMessage.Subject = "The technician has been denied";
                    ViewBag.Msg = "The technician " + FullName + " has been denied for PO " + PO;
                    break;

            }

            
            ViewBag.Comment = comment;

            mailMessage.To.Add(email);
            mailMessage.CC.Add(emailCC);
            PopulateBody(mailMessage, "TECHAPRV", null);


            SmtpClient mailClient = new SmtpClient();

            mailClient.Timeout = 10;
            return mailMessage;


        }

        public virtual MvcMailMessage TECHAPRVADV(string FullName, string status, string email, string emailCC, string comment, int PO)
        {
            //ViewBag.Data = someObject;
            ViewBag.FullName = FullName;
            var mailMessage = new MvcMailMessage();

            switch (status)
            {
                case "YES":
                    mailMessage.Subject = "The technician has been approved";
                    ViewBag.Msg = "The technician " + FullName + " has been approved for PO " + PO;
                    break;

                case "NO":
                    mailMessage.Subject = "The technician has been denied";
                    ViewBag.Msg = "The technician " + FullName + " has been denied for PO " + PO;
                    break;

            }


            ViewBag.Comment = comment;

            mailMessage.To.Add(email);
            mailMessage.CC.Add(emailCC);
            PopulateBody(mailMessage, "TECHAPRVADV", null);


            SmtpClient mailClient = new SmtpClient();

            mailClient.Timeout = 10;
            return mailMessage;


        }

     

  

       
    }
}