using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Quote
    {
        public virtual int QuoteId { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "The description is required.")]
        public virtual string Description { get; set; }

        [DisplayName("Um")]
        [Required(ErrorMessage = "The unit is required.")]
        public virtual string Um { get; set; }


        [DisplayName("Price per unit")]
        [Required(ErrorMessage = "The price is required.")]
        public virtual double PricePerUnit { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "The quantity is required.")]
        public virtual double Quantity { get; set; }

        [DefaultValue(0)]
        [DisplayName("Currency")]
        public virtual double Currency { get; set; }

        [DefaultValue(0)]
        [DisplayName("Cost per Unit")]
        public virtual double CostPerUnit { get; set; }

        public virtual int RversionId { get; set; }

        public virtual Rversion Rversion { get; set; }

    }
}