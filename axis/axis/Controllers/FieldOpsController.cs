using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AXIS.Models;

namespace AXIS.Controllers
{
    [Authorize]
    public class FieldOpsController : Controller
    {
        private AXISDB db = new AXISDB();
        
        // GET: FieldOps
        public ActionResult Index()
        {
            return View();
        }

        // GET: MAP
        public ActionResult JobBoard()
        {
            //var rversions = db.Rversions.Where(c => c.Status == "Contract").Include(Rfq);
            //var datos = db.Rfqs.Include(c => c.Farm).Where(r => r.Status == "Contract");
            var datos = db.Contracts.Include(c => c.Rversion).Include(d => d.Rversion.Rfq.Farm).Where(r => r.Rversion.Status == "Contract");
            string markers = "[";
            int numVal;
            foreach (var item in datos)
            {

                numVal = item.Rversion.Rfq.FarmId;
                //var farm = db.Farms.Where(s => s.FarmId.Equals(numVal)).First();

                markers += "{";
                markers += string.Format("'Id': '{0}',", item.ContractId);
                markers += string.Format("'PlaceName': '{0}',", item.Rversion.Rfq.Farm.FarmName);
                markers += string.Format("'TypeFarm': '{0}',", item.Rversion.Rfq.Farm.TypeFarm);
                markers += string.Format("'GeoLat': '{0}',", item.Rversion.Rfq.Farm.GeoLat);
                markers += string.Format("'GeoLong': '{0}',", item.Rversion.Rfq.Farm.GeoLong);
                markers += string.Format("'Rfq': '{0}'", item.RfqId);
                markers += "},";
            }
            markers += "]";

            ViewBag.Markers = markers;

            return View();
        }
    }
}