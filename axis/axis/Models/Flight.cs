using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Flight
    {

        public virtual int FlightId { get; set; }

        [DisplayName("DESCRIPTION")]
        [Required(ErrorMessage = "The description s required.")]
        public virtual string Description { get; set; }


        [DisplayName("DATA FLIGHT")]
        [Required(ErrorMessage = "The data flight s required.")]
        public virtual string DataFlight { get; set; }

        [DisplayName("COST FLIGHT")]
        [Required(ErrorMessage = "The cost flight s required.")]
        public virtual double CostFlight { get; set; }

        [DisplayName("STATUS")]
        public virtual string Status { get; set; }

        [DisplayName("REJECTION COMMENT")]
        public virtual string RejectionComment { get; set; }

        public virtual int FieldOperationsId { get; set; }


        public virtual FieldOperations FieldOperarions { get; set; }

    }
}