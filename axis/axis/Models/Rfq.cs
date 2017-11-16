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
        [DisplayName("# RFQ")]
        public virtual int RfqId { get; set; }
        
        [Required(ErrorMessage = "The street address is required.")]
        public virtual string Status { get; set; }

        [DisplayName("Project Name")]
        public virtual string ProjectName { get; set; }

        [DisplayName("ID Farm")]
        public virtual int FarmId { get; set; }

        [DisplayName("Farm")]
        public virtual Farm Farm { get; set; }

        [DisplayName("# Ver")]
        public virtual List<Rversion> Rversions { get; set; }

    }
}