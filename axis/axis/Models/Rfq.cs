using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Rfq
    {
        [DisplayName("RFQ")]
        public virtual int RfqId { get; set; }

        [DisplayName("STATUS")]
        [Required(ErrorMessage = "The Status is required.")]
        public virtual string Status { get; set; }

        [DisplayName("PROJECT NAME")]
        public virtual string ProjectName { get; set; }

        [DisplayName("ID Farm")]
        public virtual int FarmId { get; set; }

        [DisplayName("SITE NAME")]
        public virtual Farm Farm { get; set; }

        [DisplayName("VER #")]
        public virtual List<Rversion> Rversions { get; set; }

    }
}