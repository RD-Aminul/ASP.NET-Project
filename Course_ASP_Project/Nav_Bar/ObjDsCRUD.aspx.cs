using Course_ASP_Project;
using Course_ASP_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_ASP_Project.Nav_Bar
{
    public partial class ObjDsCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentUserControl.opType = "ObjDS";
        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DataTable dt = StudentGateWay.GetCourses();
        //        DataTable dt1 = StudentGateWay.GetFacultys();
        //        DataTable dt2 = StudentGateWay.GetTsps();
        //        if (dt.Rows.Count > 0)
        //        {
        //            DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList1");
        //            ddl.DataSource = dt;
        //            ddl.DataTextField = dt.Columns["CourseName"].ToString();
        //            ddl.DataValueField = dt.Columns["CourseID"].ToString();
        //            ddl.DataBind();
        //        }
        //        else if (dt1.Rows.Count > 0)
        //        {
        //            DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList2");
        //        }
        //        else if (dt2.Rows.Count > 0)
        //        {
        //            DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList3");
        //        }
        //    }
        //}

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int studentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            FileUpload up = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");
            string imgName = StudentGateWay.ImageName(studentId);
           
            string fileUrl = "~/Images/StudentImg/";
            string newImg = "";
            if (up.HasFile)
            {
                DeleteExistingImage(imgName);
                newImg = up.FileName;
                fileUrl += newImg;
                up.SaveAs(Server.MapPath(fileUrl));
            }
            else
            {
                newImg = imgName;
                fileUrl += newImg;
            }
            StudentGateWay.UpdateImageById(newImg, fileUrl, studentId);
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