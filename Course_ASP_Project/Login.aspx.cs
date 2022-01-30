using Course_ASP_Project.DAL;
using Course_ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_ASP_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            int authenticated = 0;
            Users obj = new Users();
            obj.UserName = txtUserName.Text;
            obj.Password = txtPassword.Text;
            string encryptedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(obj.Password, "SHA1");
            UsersGateWay gateWay = new UsersGateWay();
            authenticated = gateWay.AuthenticateUser(obj.UserName, encryptedPass);

            if (authenticated == 1)
            {
                Session["User"] = obj.UserName;
                
                FormsAuthentication.RedirectFromLoginPage(obj.UserName, chkbox.Checked);
                Response.Redirect("Home");
            }
            else
            {
                lblMessage.Text = "Invalid Username or Password";
            }

        }
    }
}