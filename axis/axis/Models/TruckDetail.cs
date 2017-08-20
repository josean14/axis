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

        [DisplayName("PLATE NUMBER.")]
        public virtual string PlateNumber { get; set; }

        [DisplayName("CAR BRAND.")]
        public virtual string Brand { get; set; }

        [DisplayName("MODEL.")]
        public virtual string Model { get; set; }

        [DisplayName("COLOR.")]
        public virtual string Color { get; set; }

        [DisplayName("OHTER.")]
        public virtual string Other1 { get; set; }

        [DisplayName("PURCHASE ORDER.")]
        public virtual int PurchaseOrderId { get; set; }

        public virtual Truck Truck { get; set; }

    }
}