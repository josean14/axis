using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class Qoute
    {

        public virtual int QouteId { get; set; }
        public virtual string Description { get; set; }
        public virtual string Um { get; set; }
        public virtual string PricePerUnit { get; set; }
        public virtual int Quantity { get; set; }
        public virtual string Currency { get; set; }
        public virtual int RversionId { get; set; }

        public virtual Rversion Rversion { get; set; }

    }
}