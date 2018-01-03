using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{



    public enum MaritalStatus
    {
        Married,
        Widowed,
        Separated,
        Divorced,
        Single
    }


    [Table("Teches")]
    public class Tech
    {
        public virtual int TechId { get; set; }

        [DisplayName("Photo")]
        public virtual string Photo { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "The first name is required.")]
        public virtual string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "The last name is required.")]
        public virtual string LastName { get; set; }

        [DisplayName("Language")]

        public virtual string Language { get; set; }

        [DisplayName("Street Address")]
        [Required(ErrorMessage = "The street address is required.")]
        public virtual string StreetAdderess { get; set; }

        [DisplayName("City Adderess")]
        [Required(ErrorMessage = "The city adderess is required.")]
        public virtual string CityAdderess { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "The state adderess is required.")]
        public virtual string State { get; set; }

        [DisplayName("ZIP")]
        [Required(ErrorMessage = "The ZIP is required.")]
        public virtual string Zip { get; set; }

        [DisplayName("Country")]

        public virtual string Country { get; set; }

        [DisplayName("Cell")]
        [Required(ErrorMessage = "The cell is required.")]
        [RegularExpression(@"^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$",
            ErrorMessage = "Invalid phone number.")]
        public virtual string Cell { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "The email is required.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Invalid email address.")]
        public virtual string Email { get; set; }

        [DisplayName("E-mail Company")]

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Invalid email address.")]
        public virtual string EmailCompany { get; set; }


        [DisplayName("Local Airport")]

        public virtual string LocalAirport { get; set; }

        [DisplayName("SSN")]
        [Required(ErrorMessage = "The SSN is required.")]
        public virtual int SSN { get; set; }

        [DisplayName("Drive Licence")]

        public virtual string DriveLicence { get; set; }

        [DisplayName("PayRate")]

        public virtual double PayRate { get; set; }

        [DisplayName("Daily Per Diem Rate")]

        public virtual double DayliPerDiem { get; set; }

        [DisplayName("Medical")]

        public virtual string Medical { get; set; }

        [DisplayName("Passport")]

        public virtual int Passport { get; set; }

        [DisplayName("Marital Status")]

        public virtual MaritalStatus? MaritalStatus { get; set; }

        [DisplayName("Children")]
        [Required(ErrorMessage = "The children is required.")]
        public virtual int Children { get; set; }

        [DisplayName("Education")]

        public virtual string Education { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        [DisplayName("Status")]
        public virtual string Status { get; set; }

        [DisplayName("PO Asigned")]
        public virtual int POAsigned { get; set; }

        public virtual List<TechInfoAxi> TechInfoAxi { get; set; }
        public virtual List<TechInfoWork> TechInfoWork { get; set; }
        public virtual List<TechInfoKit> TechInfoKit { get; set; }
        

    }
}