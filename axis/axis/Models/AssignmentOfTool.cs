using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{

    public enum SuppliedBy
    {
        [Display(Name = "OWNER")]
        CLIENT = 0,
        [Display(Name = "PURCHASE REQUEST TO")]
        PURCHASEREQUESTTO = 1,
        [Display(Name = "RENT")]
        RENT = 2,
        [Display(Name = "SELECT INVENTORY ASSET")]
        SELECTINVENTARY = 3
    }


    [Table("assignmentoftools")]
    public class AssignmentOfTool
    {
        [Key,ForeignKey("Purchaseorder")]
        public virtual int PurchaseOrderId { get; set; }

        [DisplayName("SUPPLIED BY")]
        public virtual SuppliedBy? SuppliedBy { get; set; }

        [DisplayName("ADITIONAL INFO.")]
        public virtual string AditionalInfo { get; set; }

        [DisplayName("ORDER NUMBER")]
        public virtual string OrderNumber { get; set; }

        [DefaultValue(0)]
        [DisplayName("COST")]
        public virtual double Cost { get; set; }

        [DisplayName("FILE")]
        public virtual string FileT { get; set; }

       public virtual Purchaseorder Purchaseorder { get; set; }
    }
}