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

        [DisplayName("Commentary")]
        [Required(ErrorMessage = "The commentary is required.")]
        public virtual string Commentary { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public virtual DateTime Date { get; set; }

        [DisplayName("File")]
        public virtual string File { get; set; }

        [DisplayName("Supervisor")]
        public virtual string UserName { get; set; }

        [DisplayName("Status")]
        public virtual string Status { get; set; }

        public virtual int ContractId { get; set; }

        public virtual Contract Contract { get; set; }

        public virtual List<FieldOperations> FieldOperations { get; set; }
    }
}