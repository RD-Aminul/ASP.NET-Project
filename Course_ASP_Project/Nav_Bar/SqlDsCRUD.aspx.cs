using Course_ASP_Project.DAL;
using Course_ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_ASP_Project.Nav_Bar
{
    public partial class SqlDsCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentUserControl.opType = "SQLDS";
            if (Session["Student"] != null)
            {
                StudentC obj = (StudentC)Session["Student"];
                InsertStudentUsingSQLDS(obj);
            }
        }

        private void InsertStudentUsingSQLDS(StudentC obj)
        {
            SqlDataSource1.InsertParameters["FirstName"].DefaultValue = obj.FirstName;
            SqlDataSource1.InsertParameters["LastName"].DefaultValue = obj.LastName;
            SqlDataSource1.InsertParameters["DateOfBirth"].DefaultValue = obj.DateOfBirth.ToShortDateString();
            SqlDataSource1.InsertParameters["Mobile"].DefaultValue = obj.Mobile;
            SqlDataSource1.InsertParameters["Email"].DefaultValue = obj.Email;
            SqlDataSource1.InsertParameters["ImageName"].DefaultValue = obj.ImageName;
            SqlDataSource1.InsertParameters["ImageUrl"].DefaultValue = obj.ImageUrl;
            SqlDataSource1.InsertParameters["CourseID"].DefaultValue = obj.CourseID.ToString();
            SqlDataSource1.InsertParameters["FacultyID"].DefaultValue = obj.FacultyID.ToString();
            SqlDataSource1.InsertParameters["TspID"].DefaultValue = obj.TspID.ToString();
            SqlDataSource1.Insert();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int studentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            FileUpload up = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");
            string imgName = StudentGateWay.ImageName(studentId);
           
            string fileUrl = "~/Images/StudentImg/";
            string newImgName = "";
            if (up.HasFile)
            {
                DeleteExistingImage(imgName);
                newImgName = up.FileName;
                fileUrl += newImgName;
                up.SaveAs(Server.MapPath(fileUrl));
            }
            else
            {
                newImgName = imgName;
                fileUrl += newImgName;
            }
            DropDownList dllC = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList1");
            DropDownList dllf = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList3");
            DropDownList dllt = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropDownList5");
            int courseId = Convert.ToInt32(dllC.SelectedValue);
            int facultyId = Convert.ToInt32(dllf.SelectedValue);
            int tspId = Convert.ToInt32(dllt.SelectedValue);
            //TextBox txt = GridView1.Rows[e.RowIndex].FindControl("TextBox6") as TextBox;
            //txt.Text = newImgName;
            string FirstName = (GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text;
            string LastName = (GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text;
            string DateOfBirth = (GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox).Text;
            string Mobile = (GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox).Text;
            string Email = (GridView1.Rows[e.RowIndex].FindControl("TextBox5") as TextBox).Text;

            UpdateSql(newImgName, fileUrl, studentId, courseId, facultyId, tspId, FirstName, LastName, DateOfBirth, Mobile, Email);
        }

        private void UpdateSql(string newImgName, string fileUrl, int studentId, int courseId, int facultyId, int tspId, string firstName, string lastName, string dateOfBirth, string mobile, string email)
        {
            SqlDataSource1.UpdateCommand = "Update [Student] set FirstName='" + firstName + "', LastName='" + lastName + "', DateOfBirth='" + dateOfBirth + "', Mobile='" + mobile + "', Email='" + email + "', ImageName='" + newImgName + "', ImageUrl='" + fileUrl + "', CourseID='" + courseId + "', FacultyID='" + facultyId + "', TspID='" + tspId + "' where StudentID='" + studentId + "'";
            int affraw_update = SqlDataSource1.Update();
            SqlDataSource1.Dispose();
        }

        private void DeleteExistingImage(string imgName)
        {
            string path = Server.MapPath("~/Images/StudentImg/" + imgName);
            FileInfo fileObj = new FileInfo(path);
            if (fileObj.Exists)
            {
                fileObj.Delete();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int studentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string imgName = StudentGateWay.ImageName(studentId);
            DeleteExistingImage(imgName);
        }
    }
}