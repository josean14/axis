using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AXIS.Models
{
    [Table("shippings")]
    public class Shipping
    {
        [Key, ForeignKey("Purchaseorder")]
        public virtual int PurchaseOrderId { get; set; }

        [AllowHtml]
        [DisplayName("PACKING LIST.")]
        public virtual string PackingList { get; set; }

        [DisplayName("AIRWAY BILL.")]
        public virtual string AirwayBill { get; set; }

        [DisplayName("COST.")]
        [DefaultValue(0)]
        [Required(ErrorMessage = "The cost is required.")]
        public virtual double Cost { get; set; }

        [DisplayName("COMMENT.")]
        public virtual string Comment { get; set; }

        public virtual Purchaseorder Purchaseorder { get; set; }
    }
}