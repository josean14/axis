using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Client
    {
        public virtual int ClientId { get; set; }

        [DisplayName("FIRST NAME")]
        [Required(ErrorMessage = "The first name is required.")]
        public virtual string FirstName { get; set; }

        [DisplayName("LAST NAME")]
        [Required(ErrorMessage = "The last name is required.")]
        public virtual string LastName { get; set; }

        [DisplayName("TITLE")]
        [Required(ErrorMessage = "The title is required.")]
        public virtual string Title { get; set; }

        [DisplayName("DEPARMENT")]
        [Required(ErrorMessage = "The department is required.")]
        public virtual string Department { get; set; }

        [DisplayName("COMPANY")]
        [Required(ErrorMessage = "The Company is required.")]
        public virtual string Company { get; set; }

        [DisplayName("REGION")]
        [Required(ErrorMessage = "The Region is required.")]
        public virtual string Region { get; set; }

        [DisplayName("WORK PHONE")]
        [Required(ErrorMessage = "The phone number is required.")]
        [RegularExpression(@"^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$",
            ErrorMessage = "Invalid phone number.")]
        public virtual string WorkPhone { get; set; }

        [DisplayName("E-MAIL")]
        [Required(ErrorMessage = "The email is required.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Invalid email address.")]
        public virtual string Email { get; set; }

        [DisplayName("STREET ADDRESS")]
        public virtual string Street { get; set; }

        [DisplayName("CITY")]
        [Required(ErrorMessage = "The city is required.")]
        public virtual string City { get; set; }

        [DisplayName("STATE")]
        [Required(ErrorMessage = "The state is required.")]
        public virtual string State { get; set; }

        [DisplayName("ZIP CODE")]
        public virtual string ZipCode { get; set; }

        [DisplayName("COUNTRY")]
        [Required(ErrorMessage = "The country is required.")]
        public virtual string Country { get; set; }
        public virtual ICollection<Farm> Farms { get; set; }
        public virtual ICollection<Ccall> Ccalls { get; set; }

        public string FullName
        {get { return FirstName + " " + LastName; }

        }
    }
}