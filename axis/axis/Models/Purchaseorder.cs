using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Purchaseorder
    {

        public virtual int PurchaseOrderId { get; set; }

        [DisplayName("PO")]
        public virtual string PO { get; set; }

        [DisplayName("COMMENTARY.")]
        [Required(ErrorMessage = "The commentary is required.")]
        public virtual string Commentary { get; set; }

        [DisplayName("DATE.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public virtual DateTime Date { get; set; }

        [DisplayName("FILE.")]
        public virtual string File { get; set; }

        [DisplayName("SUPERVISOR.")]
        public virtual string UserName { get; set; }

        [DisplayName("STATUS.")]
        public virtual string Status { get; set; }

        [DisplayName("TOOLING.")]
        public virtual string Tooling { get; set; }

        [DisplayName("SPECIALTY ITEMS.")]
        public virtual string SpecialtyItems { get; set; }

        [DisplayName("AIRPORT DESTINATION.")]
        public virtual string AirportDestination { get; set; }

        [DisplayName("DEPARTURE DATE.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public virtual DateTime? DepartureDate { get; set; }

        [DisplayName("TRAVEL PLANS.")]
        public virtual string TravelPlans { get; set; }

        [DisplayName("AIRPORT CARGO ADDRESS.")]
        public virtual string AirportCargoAddress { get; set; }

        [DisplayName("AIRPORT CARGO CONTACT.")]
        public virtual string AirportCargoContact { get; set; }

        [DisplayName("LODGING IN AREA.")]
        public virtual string LodgingInArea { get; set; }

        [DisplayName("NOTES.")]
        public virtual string Notes { get; set; }

        public virtual int ContractId { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual List<FieldOperations> FieldOperations { get; set; }

        public virtual AssignmentOfTool AssignmentOfTool { get; set; }

        public virtual Truck Truck { get; set; }

        public virtual Shipping Shipping { get; set; }

    }
}