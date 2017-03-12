using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class ScopeWork
    {

        public virtual int ScopeWorkId { get; set; }

        [DisplayName("Type Work")]
        public virtual string TypeWork { get; set; }

        [DisplayName("Scope Work")]
        public virtual string Work { get; set; }

        public virtual List<Rversion> Rversions { get; set; }
    }
}