using Course_ASP_Project.DAL;
using Course_ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Course_ASP_Project
{
    public partial class StudentUserControl : System.Web.UI.UserControl
    {
        public string opType = "EF";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar.Visible = false;
                LoadDdlCourse();
                LoadDdlFaculty();
                LoadDdlTsp();
            }
            ShowImage();
        }

        private void ShowImage()
        {
            if (UploadStudentImg.HasFile)
            {
                string imageName = Path.GetFileName(UploadStudentImg.PostedFile.FileName);
                HiddenImageName.Value = imageName;
                string filePath = "~/Images/StudentImg/" + imageName;
                HiddenImageUrl.Value = filePath;
                UploadStudentImg.SaveAs(Server.MapPath(filePath));
                imgStudent.ImageUrl = filePath;
            };
        }

        private void LoadDdlCourse()
        {
            DataTable dt = StudentGateWay.GetCourses();

            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "Select" };
            dt.Rows.InsertAt(dr, 0);

            ddlCourse.DataSource = dt;
            ddlCourse.DataTextField = dt.Columns["CourseName"].ToString();
            ddlCourse.DataValueField = dt.Columns["CourseID"].ToString();
            ddlCourse.DataBind();
        }

        private void LoadDdlFaculty()
        {
            DataTable dt = StudentGateWay.GetFacultys();

            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "Select" };
            dt.Rows.InsertAt(dr, 0);

            ddlFaculty.DataSource = dt;
            ddlFaculty.DataTextField = dt.Columns["FacultyName"].ToString();
            ddlFaculty.DataValueField = dt.Columns["FacultyID"].ToString();
            ddlFaculty.DataBind();
        }
        private void LoadDdlTsp()
        {
            DataTable dt = StudentGateWay.GetTsps();

            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "Select" };
            dt.Rows.InsertAt(dr, 0);

            ddlTsp.DataSource = dt;
            ddlTsp.DataTextField = dt.Columns["TspName"].ToString();
            ddlTsp.DataValueField = dt.Columns["TspID"].ToString();
            ddlTsp.DataBind();
        }

        protected void imgCalender_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar.Visible)
            {
                Calendar.Visible = false;
            }
            else
            {
                Calendar.Visible = true;
            }
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            txtCalenderDate.Text = Calendar.SelectedDate.ToShortDateString();
            Calendar.Visible = false;
        }

        protected void btnSaveCourse_Click(object sender, EventArgs e)
        {
            Course obj = new Course();
            obj.CourseName = txtCourseName.Text;
            StudentGateWay.SaveCourse(obj.CourseName);
            lblMessage.Text = "Course Save Successfully";
            txtCourseName.Text = "";
            LoadDdlCourse();
        }

        protected void btnSaveFaculty_Click(object sender, EventArgs e)
        {
            Faculty obj = new Faculty();
            obj.FacultyName = txtFacultyName.Text;
            StudentGateWay.SaveFaculty(obj.FacultyName);
            lblMessage.Text = "Faculty Save Successfully";
            txtFacultyName.Text = "";
            LoadDdlFaculty();
        }

        protected void btnSaveTsp_Click(object sender, EventArgs e)
        {
            Tsp obj = new Tsp();
            obj.TspName = txtTspName.Text;
            StudentGateWay.SaveTsp(obj.TspName);
            lblMessage.Text = "Tsp Save Successfully";
            txtTspName.Text = "";
            LoadDdlTsp();
        }

        protected void btnSaveStudent_Click(object sender, EventArgs e)
        {
            StudentC obj = new StudentC();
            obj.FirstName = txtFirstName.Text;
            obj.LastName = txtLastName.Text;
            obj.DateOfBirth = Convert.ToDateTime(txtCalenderDate.Text);
            obj.Mobile = txtMobileNo.Text;
            obj.Email = txtEmail.Text;
            //obj.Gender = rbtnMale.GroupName;
            obj.ImageName = HiddenImageName.Value;
            obj.ImageUrl = HiddenImageUrl.Value;
            obj.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
            obj.FacultyID = Convert.ToInt32(ddlFaculty.SelectedValue);
            obj.TspID = Convert.ToInt32(ddlTsp.SelectedValue);
            if (opType == "ObjDS")
            {
                StudentGateWay.SaveStudent(obj.FirstName, obj.LastName, obj.DateOfBirth, obj.Mobile, obj.Email, obj.ImageName, obj.ImageUrl, obj.CourseID, obj.FacultyID, obj.TspID);
                lblMessage1.Text = "Student Save Successfully";
                Response.Redirect("ObjCrud");
            }
            else if (opType == "SQLDS")
            {
                Session["Student"] = obj;
                lblMessage1.Text = "Student Save Successfully";
                Response.Redirect("SqlCrud");
            }
            else if (opType == "EFDS")
            {
                Student obj1 = new Student();
                obj1.FirstName = txtFirstName.Text;
                obj1.LastName = txtLastName.Text;
                obj1.DateOfBirth = Convert.ToDateTime(txtCalenderDate.Text);
                obj1.Mobile = txtMobileNo.Text;
                obj1.Email = txtEmail.Text;
                obj1.ImageName = HiddenImageName.Value;
                obj1.ImageUrl = HiddenImageUrl.Value;
                obj1.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
                obj1.FacultyID = Convert.ToInt32(ddlFaculty.SelectedValue);
                obj1.TspID = Convert.ToInt32(ddlTsp.SelectedValue);
                StudentEFGateWay EfObj = new StudentEFGateWay();
                EfObj.InsertStudent(obj1);
                lblMessage1.Text = "Student Save Successfully";
                Response.Redirect("EntityCrud");
            }
        }
    }
}