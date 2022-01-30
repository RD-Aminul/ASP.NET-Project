using Course_ASP_Project.DAL;
using Course_ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_ASP_Project.Nav_Bar
{
    public partial class Nav : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                string userName = Session["User"].ToString();
                lblLoginUser.Text = "Hello, " + userName;
            }
        }
        protected void lbtnSignOut_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            FormsAuthentication.SignOut();
            Response.Redirect("login");
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("/");
            List<StudentC> students = StudentGateWay.GetStudentList();
            Session["Data"] = students;
            Response.Redirect("Report");
        }
    }
}