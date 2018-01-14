using AXIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AXIS.Reports
{
    public partial class EmployeeMob1 : System.Web.UI.Page
    {
        AXISDB db1 = new AXISDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            EmployeeMob3 crystalReport = new EmployeeMob3();
            var DB = db1.Purchaseorders.ToList();
            crystalReport.SetDataSource(DB);

            CrystalReportViewer1.ReportSource = crystalReport;
            CrystalReportViewer1.RefreshReport();
        }
    }
}