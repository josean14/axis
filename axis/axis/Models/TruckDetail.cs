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
        public virtual DateTime? DateRent { get; set; }


        [DisplayName("YEAR.")]
        public virtual int Year { get; set; }

        [DisplayName("GAS/DIESEL.")]
        public virtual string GasDiesel { get; set; }

        [DisplayName("GAS CARD.")]
        public virtual string GasCard { get; set; }

        [DisplayName("INSURANCE DOCUMENTACION.")]
        public virtual string InsuranceDocumentacion { get; set; }

        [DisplayName("SEAT BELTS WORK AND FREE OF DEMAGE")]
        public virtual string ItemInterior1 { get; set; }

        [DisplayName("NO WARNING LIGHTS ARE ON")]
        public virtual string ItemInterior2 { get; set; }

        [DisplayName("OIL LAVEL IS SUFFICIENTLY HIGH")]
        public virtual string ItemInterior3 { get; set; }

        [DisplayName("RADIATOR FLUID LEVELS ARE SUFFICIENT")]
        public virtual string ItemInterior4 { get; set; }

        [DisplayName("EMERGENCY ROADSIDE SUPPLIES ARE PROPERLY STOCKED")]
        public virtual string ItemInterior5 { get; set; }

        [DisplayName("ENGINE OIL LEVEL")]
        public virtual string EngineComparment1 { get; set; }

        [DisplayName("COOLANT LEVEL (ANTI-FREEZE)")]
        public virtual string EngineComparment2 { get; set; }

        [DisplayName("BRAKE FLUID LEVEL")]
        public virtual string EngineComparment3 { get; set; }

        [DisplayName("TRANSMISSION FLUID LEVEL")]
        public virtual string EngineComparment4 { get; set; }

        [DisplayName("WINDOWS/WINDSHIELD NOT CRAKED")]
        public virtual string ItemExterior1 { get; set; }

        [DisplayName("FUNCTIONAL WINDSHIELD WIPERS")]
        public virtual string ItemExterior2 { get; set; }

        [DisplayName("HEADLIGHTS (HIGH/LOW BEAM)")]
        public virtual string ItemExterior3 { get; set; }

        [DisplayName("TAIL LIGHT / BRAKE LIGHTS")]
        public virtual string ItemExterior4 { get; set; }

        [DisplayName("EMERGENCY BRAKE IN GOOD WORKING ORDER")]
        public virtual string ItemExterior5 { get; set; }

        [DisplayName("POWER BRAKES ARE IN GOOD WORKING ORDER")]
        public virtual string ItemExterior6 { get; set; }

        [DisplayName("HORN")]
        public virtual string ItemExterior7 { get; set; }

        [DisplayName("TIRE IN GOOD SHAPE (NO BALD TIRES / PROPERLY INFLATED")]
        public virtual string ItemExterior8 { get; set; }

        [DisplayName("NO AIR LEAKS IN TIRES")]
        public virtual string ItemExterior9 { get; set; }

        [DisplayName("NO OIL / GREASE LEAKS (UNDER THE VEHICLE)")]
        public virtual string ItemExterior10 { get; set; }

        [DisplayName("NO FUEL LEAKS OR ODOR OF GASOLINE DETECTED")]
        public virtual string ItemExterior11 { get; set; }

        [DisplayName("EXHAUST SYSTEM IS IN GOOD WORKING ORDER")]
        public virtual string ItemExterior12 { get; set; }

        [DisplayName("TURN SIGNALS")]
        public virtual string ItemExterior13 { get; set; }

        [DisplayName("VEHICLE IS FREE OF EXCESSIVE DEMAGE")]
        public virtual string ItemExterior14 { get; set; }

        [DisplayName("VEHICLE CONDITION IS SATISFACTORY")]
        public virtual string ItemExterior15 { get; set; }

        [DisplayName("DEFECTS REPORTED")]
        public virtual string ItemExterior16 { get; set; }

        [DisplayName("ADDITIONAL COMMENTS.")]
        public virtual string AditionalComments { get; set; }

        [DisplayName("PURCHASE ORDER.")]
        public virtual int PurchaseOrderId { get; set; }

        [DisplayName("STATUS.")]
        public virtual string Status { get; set; }

        [DisplayName("TECHID")]
        public virtual string TechId { get; set; }

        public virtual Truck Truck { get; set; }

    }
}