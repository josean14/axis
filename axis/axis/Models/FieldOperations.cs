using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public enum TechApproval
    {
        Yes = 1, NO = 0
    }

    public enum TechApprovalADV
    {
        Yes = 1, NO = 0
    }

    public enum CertificatesStatus
    {
        Yes = 1, NO = 0
    }


    [Table("FieldOperationsTechs")]
    public class FieldOperations
    {

        public virtual int FieldOperationsId { get; set; }

        [DisplayName("TECH APPROVAL")]
        [Required(ErrorMessage = "The tech approval is required.")]
        public virtual TechApproval? TechApproval { get; set; }

        [DisplayName("PER DIEM ADVANCE")]
        [Required(ErrorMessage = "The per diem advance is required.")]
        public virtual int PerDiemAdvance { get; set; }

        [DisplayName("TECH APPROVAL ADV")]
        [Required(ErrorMessage = "The tech approval is required.")]
        public virtual TechApprovalADV? TechApprovalADV { get; set; }

        [DisplayName("STATUS")]
        public virtual string status { get; set; }

        [DisplayName("CERTIFICATES STATUS")]
        public virtual CertificatesStatus? CertificatesStatus { get; set; }

        [DisplayName("TECH")]
        public virtual int TechId { get; set; }

        [DisplayName("PURCHASE ORDER")]
        public virtual int PurchaseOrderId { get; set; }


        public virtual Tech Tech { get; set; }


        public virtual Purchaseorder PurchaseOrder { get; set; }

        public virtual List<Flight> Fligh { get; set; }

    }
}