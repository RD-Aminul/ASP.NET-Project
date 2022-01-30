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
    public partial class EntityDsCRUD : System.Web.UI.Page
    {
        StudentEFGateWay dbObj = new StudentEFGateWay();
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentUserControl.opType = "EFDS";
            if (!IsPostBack)
            {
                LoadGridView();
            }
        }

        private void LoadGridView()
        {
            List<Student> data = dbObj.GetStudentList().ToList();
            if (data.Count > 0)
            {
                GridView1.DataSource = data;
            }
            else
            {
                GridView1.DataSource = null;
            }
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadGridView();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            FileUpload up = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");
            string imgName = StudentGateWay.ImageName(id);
            
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
            Student obj = new Student();
            obj.FirstName = e.NewValues["FirstName"].ToString();
            obj.LastName = e.NewValues["LastName"].ToString();
            obj.DateOfBirth = Convert.ToDateTime(e.NewValues["DateOfBirth"].ToString());
            obj.Mobile = e.NewValues["Mobile"].ToString();
            obj.Email = e.NewValues["Email"].ToString();
            obj.ImageName = newImg;
            obj.ImageUrl = fileUrl;
            obj.StudentID = id;
            obj.CourseID = Convert.ToInt32(e.NewValues["CourseID"].ToString());
            obj.FacultyID = Convert.ToInt32(e.NewValues["FacultyID"].ToString());
            obj.TspID = Convert.ToInt32(e.NewValues["TspID"].ToString());
            dbObj.UpdateStudent(obj);
            GridView1.EditIndex = -1;
            LoadGridView();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string ImgName = StudentGateWay.ImageName(id);
            DeleteExistingImage(ImgName);
            dbObj.DeleteStudent(id);
            LoadGridView();

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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGridView();
        }
    }
}