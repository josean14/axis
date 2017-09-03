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

        public System.Data.Entity.DbSet<AXIS.Models.ScopeWork> ScopeWorks { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Contract> Contracts { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Purchaseorder> Purchaseorders { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Manufactere> Manufacteres { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Platform> Platforms { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Tech> Teches { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.TechInfoAxi> TechInfoAxis { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.TechInfoWork> TechInfoWorks { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.TechInfoKit> TechInfoKits { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.TechInfoCim> TechInfoCims { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.QuotesList> QuotesLists { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.FieldOperations> FieldOperations { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Flight> Flights { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.AssignmentOfTool> AssignmentOfTools { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Truck> Trucks { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.AssignmentOfToolsByJob> AssignmentOfToolsByJobs { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.AssignmentOfToolsByTruck> AssignmentOfToolsByTrucks { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.TruckDetail> TruckDetails { get; set; }

        public System.Data.Entity.DbSet<AXIS.Models.Shipping> Shippings { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().
        //          HasMany(p => p.Roles).
        //          WithMany(p => p.Users).
        //          Map(p => p.ToTable("userroles").
        //            MapLeftKey("UserId").
        //            MapRightKey("RoleId"));


        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
