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

        [DisplayName("Firs name")]
        [Required(ErrorMessage = "The first name is required.")]
        public virtual string FirstName { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "The last name is required.")]
        public virtual string LastName { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "The title is required.")]
        public virtual string Title { get; set; }


        [Required(ErrorMessage = "The department is required.")]
        public virtual string Department { get; set; }


        [Required(ErrorMessage = "The phone number is required.")]
        [RegularExpression(@"^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$",
            ErrorMessage = "Invalid phone number.")]
        public virtual string WorkPhone { get; set; }


        [Required(ErrorMessage = "The email is required.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
            ErrorMessage = "Invalid email address.")]
        public virtual string Email { get; set; }

        public virtual string Street { get; set; }

        [Required(ErrorMessage = "The city is required.")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "The state is required.")]
        public virtual string State { get; set; }

        public virtual string ZipCode { get; set; }

        [Required(ErrorMessage = "The country is required.")]
        public virtual string Country { get; set; }
        public virtual ICollection<Farm> Farms { get; set; }


    }
}