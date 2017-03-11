using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AXIS.Models
{
    public class AXISDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public AXISDB() : base("name=AXISDB")
        {
        }

        public System.Data.Entity.DbSet<AXIS.Models.Client> Clients { get; set; }
        public System.Data.Entity.DbSet<AXIS.Models.Farm> Farms { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Rfq> Rfqs { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Rversion> Rversions { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Quote> Quotes { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Ccall> Ccalls { get; set; }
    }
}
