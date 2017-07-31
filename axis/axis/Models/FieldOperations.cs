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
        YES = 1, NO = 0
    }

    public enum TechApprovalADV
    {

        PROCESSING = 0,
        YES = 1,
        NO = 2
    }

    public enum CertificatesStatus
    {
        YES = 1, NO = 0
    }

    public enum PerDiemAdvance
    {
        [Display(Name = "A = 7 DAYS")]
        A = 7,
        [Display(Name = "B = 14 DAYS")]
        B = 14,
        [Display(Name = "NOT AUTHORIZED")]
        NO = 0
    }

    [Table("FieldOperationsTechs")]
    public class FieldOperations
    {

        public virtual int FieldOperationsId { get; set; }

        [DisplayName("TECH APPROVAL")]
        
        public virtual string TechApproval { get; set; }

        [DisplayName("PER DIEM ADVANCE")]
        
        public virtual PerDiemAdvance? PerDiemAdvance { get; set; }

        [DisplayName("TECH APPROVAL ADV")]
        
        public virtual string TechApprovalADV { get; set; }

        [DisplayName("STATUS")]
        public virtual string status { get; set; }

        [DisplayName("CERTIFICATES STATUS")]
        public virtual string CertificatesStatus { get; set; }

        [DisplayName("REJECTION COMMENT")]
        public virtual string RejectionComment { get; set; }

        public virtual string ARejectionComment { get; set; }


        [DisplayName("TECH")]
        public virtual int TechId { get; set; }

        [DisplayName("PURCHASE ORDER")]
        public virtual int PurchaseOrderId { get; set; }


        public virtual Tech Tech { get; set; }


        public virtual Purchaseorder PurchaseOrder { get; set; }

        public virtual List<Flight> Fligh { get; set; }

      
    }
}