using AXIS.Models;
using Mvc.Mailer;

namespace AXIS.Mailers
{
    public interface IFONMailer
    {
        MvcMailMessage Certificates(TechInfoAxi model, string FullName, string path, string email, string emailCC);
        MvcMailMessage TECHAPRV(string FullName, string status, string email, string emailCC,string comment, int PO);
        MvcMailMessage TECHAPRVADV(string FullName, string status, string email, string emailCC, string comment, int PO);
        MvcMailMessage FlightAPV(string FullName, string status, string email, string emailCC, string comment, int PO);
        MvcMailMessage TRUCKAPV(string status, string email, string emailCC, string comment, int PO);
    }
}