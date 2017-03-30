using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{

    public enum TypePayRate
    {
        HUNAL, DIEM
    }

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
        [Required(ErrorMessage = "The last name is required.")]
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
        [Required(ErrorMessage = "The Country is required.")]
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

        [DisplayName("Local Airport")]
        [Required(ErrorMessage = "The Local Airport is required.")]
        public virtual string LocalAirport { get; set; }

        [DisplayName("SSN")]
        [Required(ErrorMessage = "The SSN is required.")]
        public virtual int SSN { get; set; }

        [DisplayName("Drive Licence")]
        [Required(ErrorMessage = "The Drive Licence is required.")]
        public virtual string DriveLicence { get; set; }

        [DisplayName("PayRate")]
        [Required(ErrorMessage = "The Pay Rate is required.")]
        public virtual double PayRate { get; set; }

        [DisplayName("Type Pay Rate")]
        [Required(ErrorMessage = "The type pay rate is required.")]
        public virtual TypePayRate? TypePayRate { get; set; }

        [DisplayName("Medical")]
        [Required(ErrorMessage = "The medical is required.")]
        public virtual string Medical { get; set; }

        [DisplayName("Passport")]
        [Required(ErrorMessage = "The passport is required.")]
        public virtual int Passport { get; set; }

        [DisplayName("Marital Status")]
        [Required(ErrorMessage = "The marital status is required.")]
        public virtual MaritalStatus? MaritalStatus { get; set; }

        [DisplayName("Children")]
        [Required(ErrorMessage = "The children is required.")]
        public virtual int Children { get; set; }

        [DisplayName("Education")]
        [Required(ErrorMessage = "The education is required.")]
        public virtual string Education { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public virtual List<TechInfoAxi> TechInfoAxi { get; set; }
        public virtual List<TechInfoWork> TechInfoWork { get; set; }
        public virtual List<TechInfoKit> TechInfoKit { get; set; }
   
    }
}