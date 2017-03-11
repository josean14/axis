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

        [DisplayName("First Name")]
        [Required(ErrorMessage = "The first name is required.")]
        public virtual string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "The last name is required.")]
        public virtual string LastName { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "The title is required.")]
        public virtual string Title { get; set; }

        [DisplayName("Department")]
        [Required(ErrorMessage = "The department is required.")]
        public virtual string Department { get; set; }

        [DisplayName("Company")]
        [Required(ErrorMessage = "The Company is required.")]
        public virtual string Company { get; set; }

        [DisplayName("Region")]
        [Required(ErrorMessage = "The Region is required.")]
        public virtual string Region { get; set; }

        [DisplayName("Work Phone")]
        [Required(ErrorMessage = "The phone number is required.")]
        [RegularExpression(@"^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$",
            ErrorMessage = "Invalid phone number.")]
        public virtual string WorkPhone { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "The email is required.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Invalid email address.")]
        public virtual string Email { get; set; }

        [DisplayName("Street Address")]
        public virtual string Street { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "The city is required.")]
        public virtual string City { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "The state is required.")]
        public virtual string State { get; set; }

        [DisplayName("Zip Code")]
        public virtual string ZipCode { get; set; }

        [DisplayName("Country")]
        [Required(ErrorMessage = "The country is required.")]
        public virtual string Country { get; set; }
        public virtual ICollection<Farm> Farms { get; set; }
        public virtual ICollection<Ccall> Ccalls { get; set; }

        public string FullName
        {get { return FirstName + " " + LastName; }

        }
    }
}