using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Version
    {
        public virtual int VersionId { get; set; }


        [Required(ErrorMessage = "The project name is required.")]
        public virtual string NumberVersion { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string TypeWork { get; set; }
        public virtual string ScopeWork { get; set; }
        public virtual string ProjectDescription { get; set; }
        public virtual double TotalCost { get; set; }
        public virtual string Status { get; set; }
        public virtual double NotesAndInstructions { get; set; }
        public virtual int RfqId { get; set; }

        public virtual Rfq Rfq { get; set; }
        public virtual ICollection<Qoute> Qoutes { get; set; }

    }
}