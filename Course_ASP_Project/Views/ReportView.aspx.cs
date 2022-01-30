using Course_ASP_Project.Models;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_ASP_Project.Views
{
    public partial class ReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Data"] != null)
            {
                var list = Session["Data"] as List<StudentC>;
                StudentReport reportObj = new StudentReport();
                reportObj.SetDataSource(list);
                CrystalReportViewer1.ReportSource = reportObj;
                //reportObj.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "User Info");
            }
        }
    }
}