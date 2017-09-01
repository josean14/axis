using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{

    [Table("truckdetails")]
    public class TruckDetail
    {


        [Key]
        public virtual int TruckId { get; set; }

        [DisplayName("LICENCE PLATE.")]
        public virtual string LicencePlate { get; set; }

        [DisplayName("MAKE MODEL.")]
        public virtual string MakeModel { get; set; }

        [DisplayName("SITE LOCATION.")]
        public virtual string SiteLocation { get; set; }

        [DisplayName("LAST 6 OF VIN.")]
        public virtual string VIN { get; set; }

        [DisplayName("DATE RENT.")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public virtual DateTime DateRent { get; set; }


        [DisplayName("YEAR.")]
        public virtual int Year { get; set; }

        [DisplayName("GAS/DIESEL.")]
        public virtual string GasDiesel { get; set; }

        [DisplayName("GAS CARD.")]
        public virtual string GasCard { get; set; }

        [DisplayName("INSURANCE DOCUMENTACION.")]
        public virtual string InsuranceDocumentacion { get; set; }

        [DisplayName("ITEM INTERIOR 1.")]
        public virtual string ItemInterior1 { get; set; }

        [DisplayName("ITEM INTERIOR 2.")]
        public virtual string ItemInterior2 { get; set; }

        [DisplayName("ITEM INTERIOR 3.")]
        public virtual string ItemInterior3 { get; set; }

        [DisplayName("ITEM INTERIOR 4.")]
        public virtual string ItemInterior4 { get; set; }

        [DisplayName("ITEM INTERIOR 5.")]
        public virtual string ItemInterior5 { get; set; }

        [DisplayName("ENGINE COMPARMENT 1.")]
        public virtual string EngineComparment1 { get; set; }

        [DisplayName("ENGINE COMPARMENT 2.")]
        public virtual string EngineComparment2 { get; set; }

        [DisplayName("ENGINE COMPARMENT 3.")]
        public virtual string EngineComparment3 { get; set; }

        [DisplayName("ENGINE COMPARMENT 4.")]
        public virtual string EngineComparment4 { get; set; }

        [DisplayName("ITEM EXTERIOR 1.")]
        public virtual string ItemExterior1 { get; set; }

        [DisplayName("ITEM EXTERIOR 2.")]
        public virtual string ItemExterior2 { get; set; }

        [DisplayName("ITEM EXTERIOR 3.")]
        public virtual string ItemExterior3 { get; set; }

        [DisplayName("ITEM EXTERIOR 4.")]
        public virtual string ItemExterior4 { get; set; }

        [DisplayName("ITEM EXTERIOR 5.")]
        public virtual string ItemExterior5 { get; set; }

        [DisplayName("ITEM EXTERIOR 6.")]
        public virtual string ItemExterior6 { get; set; }

        [DisplayName("ITEM EXTERIOR 7.")]
        public virtual string ItemExterior7 { get; set; }

        [DisplayName("ITEM EXTERIOR 8.")]
        public virtual string ItemExterior8 { get; set; }

        [DisplayName("ITEM EXTERIOR 9.")]
        public virtual string ItemExterior9 { get; set; }

        [DisplayName("ITEM EXTERIOR 10.")]
        public virtual string ItemExterior10 { get; set; }

        [DisplayName("ITEM EXTERIOR 11.")]
        public virtual string ItemExterior11 { get; set; }

        [DisplayName("ITEM EXTERIOR 12.")]
        public virtual string ItemExterior12 { get; set; }

        [DisplayName("ITEM EXTERIOR 13.")]
        public virtual string ItemExterior13 { get; set; }

        [DisplayName("ITEM EXTERIOR 14.")]
        public virtual string ItemExterior14 { get; set; }

        [DisplayName("ITEM EXTERIOR 15.")]
        public virtual string ItemExterior15 { get; set; }

        [DisplayName("ITEM EXTERIOR 16.")]
        public virtual string ItemExterior16 { get; set; }

        [DisplayName("ADITIONAL COMMENTS.")]
        public virtual string AditionalComments { get; set; }

        [DisplayName("PURCHASE ORDER.")]
        public virtual int PurchaseOrderId { get; set; }

        [DisplayName("STATUS.")]
        public virtual string Status { get; set; }

        public virtual Truck Truck { get; set; }

    }
}