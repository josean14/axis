using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{

    [Table("QuotesList")]
    public class QuotesList
    {

        public virtual int QuotesListId { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "The description is required.")]
        public virtual string Description { get; set; }

        [DisplayName("Um")]
        [Required(ErrorMessage = "The unit is required.")]
        public virtual string Um { get; set; }


        [DisplayName("Cost per unit")]
        [Required(ErrorMessage = "The cost is required.")]
        public virtual double Cost { get; set; }


        [DisplayName("Price per unit")]
        [Required(ErrorMessage = "The price is required.")]
        public virtual double Price { get; set; }

    }
}