using AXIS.Models;
using Mvc.Mailer;

namespace AXIS.Mailers
{
    public interface IFONMailer
    {
        MvcMailMessage Certificates(TechInfoAxi model, string FullName, string path, string email, string emailCC);
        MvcMailMessage TECHAPRV();
        MvcMailMessage TECHAPRVADV();
    }
}