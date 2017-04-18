using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AXIS.Models
{

    public enum Cattechkit
    {
        HARNESS, LAN_YARD, CABLE_GRAB, OTHER
    }

    [Table("TechInfoKits")]
    public class TechInfoKit
    {
        public virtual int TechInfoKitId { get; set; }

        [DisplayName("Manufacter")]
        public virtual string HarnessManufacter { get; set; }

        [DisplayName("Model")]
        public virtual string HarnessModel { get; set; }

        [DisplayName("Serial")]
        public virtual string HarnessSerial { get; set; }

        [DisplayName("Date Manufacture")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public virtual DateTime HarnessDateManufacture { get; set; }

        [DisplayName("Recertification")]
        public virtual string HarnessRecertification { get; set; }



        [DisplayName("Manufacter")]
        public virtual string LaynarManufacter { get; set; }

        [DisplayName("Model")]
        public virtual string LaynarModel { get; set; }

        [DisplayName("Serial")]
        public virtual string LaynarSerial { get; set; }

        [DisplayName("Date Manufacture")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public virtual DateTime LaynarDateManufacture { get; set; }

        [DisplayName("Recertification")]
        public virtual string LaynarRecertification { get; set; }

        [DisplayName("Cable Grab")]
        public virtual string CableGrab { get; set; }

        [DisplayName("Helment")]
        public virtual string Helment { get; set; }

        [DisplayName("Uniforms")]
        public virtual string Uniforms { get; set; }

        [DisplayName("Other")]
        public virtual string Other { get; set; }

        [DisplayName("Tech")]
        [Required(ErrorMessage = "The tech is required.")]
        public virtual int TechId { get; set; }


        public virtual Tech Tech { get; set; }

    }
}