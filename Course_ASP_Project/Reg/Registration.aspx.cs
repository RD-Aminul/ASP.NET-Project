using Course_ASP_Project.DAL;
using Course_ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_ASP_Project.Reg
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Users obj = new Users();
                obj.UserName = txtUserName.Text;
                obj.Email = txtEmail.Text;
                bool isChecked = rbtnMale.Checked;
                bool isChecked1 = rbtnFemale.Checked;
                if (isChecked)
                {
                    obj.Gender = "M";
                }
                else if (isChecked1)
                {
                    obj.Gender = "F";
                }
                else
                {
                    obj.Gender = "O";
                }
                obj.Password = txtPassword.Text;
                string encryptedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(obj.Password, "SHA1");
                UsersGateWay gateobj = new UsersGateWay();
                int returnCode = gateobj.SaveUser(obj.UserName, obj.Email, obj.Gender, encryptedPass);
                if (returnCode == -1)
                {
                    lblMessage.Text = "Username already exists";
                }
                else
                {
                    Response.Redirect("../login");
                }
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 4)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 4)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}