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
        public virtual int RfqId { get; set; }


        [Required(ErrorMessage = "The street address is required.")]
        public virtual string Status { get; set; }

        [DisplayName("Project name")]
        [Required(ErrorMessage = "The project name is required.")]
        public virtual string ProjectName { get; set; }
        public virtual int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
        public virtual List<Version> Versions { get; set; }

    }
}