using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    [Table("trucks")]
    public class Truck
    {

        [Key, ForeignKey("Purchaseorder")]
        public virtual int PurchaseOrderId { get; set; }

        [DisplayName("NUMBER TRUCKS.")]
        [DefaultValue(0)]
        public virtual int NumberTrucks { get; set; }

        [DisplayName("RENTAL AGENCY.")]
        public virtual string RentalAgency { get; set; }

        [DisplayName("STATUS.")]
        public virtual string Status { get; set; }
        
        [DisplayName("REJECTION COMMENT.")]
        public virtual string RejectionComment { get; set; }

        public virtual Purchaseorder Purchaseorder { get; set; }

        public virtual ICollection<TruckDetail> TruckDetails { get; set; }
    }
}