using Course_ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Course_ASP_Project.DAL
{
    public class StudentGateWay
    {
        public static List<StudentC> GetStudentList()
        {
            List<StudentC> list = new List<StudentC>();
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT StudentID, FirstName, LastName, DateOfBirth, Mobile, Email, ImageName, ImageUrl, S.CourseID, C.CourseName, S.FacultyID, " +
                    "F.FacultyName, S.TspID, T.TspName FROM Student AS S " +
                    "JOIN Course AS C ON S.CourseID = C.CourseID " +
                    "JOIN Faculty AS F ON S.FacultyID = F.FacultyID " +
                    "JOIN Tsp AS T ON S.TspID = T.TspID";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StudentC obj = new StudentC();
                    obj.StudentID = Convert.ToInt32(rdr["StudentID"]);
                    obj.FirstName = rdr["FirstName"].ToString();
                    obj.LastName = rdr["LastName"].ToString();
                    obj.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"].ToString());
                    obj.Mobile = rdr["Mobile"].ToString();
                    obj.Email = rdr["Email"].ToString();
                    //obj.Gender = rdr["Gender"].ToString();
                    obj.ImageName = rdr["ImageName"].ToString();
                    obj.ImageUrl = rdr["ImageUrl"].ToString();
                    obj.CourseID = Convert.ToInt32(rdr["CourseID"]);
                    obj.FacultyID = Convert.ToInt32(rdr["FacultyID"]);
                    obj.TspID = Convert.ToInt32(rdr["TspID"]);
                    obj.CourseName = rdr["CourseName"].ToString();
                    obj.FacultyName = rdr["FacultyName"].ToString();
                    obj.TspName = rdr["TspName"].ToString();
                    list.Add(obj);
                }
                return list;
            }
        }
        public static void SaveStudent(string FirstName, string LastName, DateTime DateOfBirth, string Mobile, string Email, string ImageName, string ImageUrl, int CourseID, int FacultyID, int TspID)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Student (FirstName, LastName, DateOfBirth, Mobile, Email, ImageName, ImageUrl, CourseID, FacultyID, TspID) VALUES(@FirstName, @LastName, @DateOfBirth, @Mobile, @Email, @ImageName, @ImageUrl, @CourseID, @FacultyID, @TspID)";
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Parameters.AddWithValue("@Email", Email);
                //cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@ImageName", ImageName);
                cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                cmd.Parameters.AddWithValue("@FacultyID", FacultyID);
                cmd.Parameters.AddWithValue("@TspID", TspID);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateStudent(string FirstName, string LastName, DateTime DateOfBirth, string Mobile, string Email, string ImageName, string ImageUrl, int CourseID, int FacultyID, int TspID, int StudentID)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Student SET FirstName=@FirstName, LastName=@LastName, DateOfBirth=@DateOfBirth, Mobile=@Mobile, Email=@Email WHERE StudentID=@StudentID";
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Parameters.AddWithValue("@Email", Email);
                //cmd.Parameters.AddWithValue("@Gender", Gender);
                //cmd.Parameters.AddWithValue("@ImageName", ImageName);
                //cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                //cmd.Parameters.AddWithValue("@CourseID", CourseID);
                //cmd.Parameters.AddWithValue("@FacultyID", FacultyID);
                //cmd.Parameters.AddWithValue("@TspID", TspID);
                //cmd.Parameters.AddWithValue("@CourseName", CourseName);
                //cmd.Parameters.AddWithValue("@FacultyName", FacultyName);
                //cmd.Parameters.AddWithValue("@TspName", TspName);
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteStudent(int StudentID)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Student WHERE StudentID=@StudentID";
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static string ImageName(int StudentID)
        {
            string imageName = "";
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ImageName FROM Student WHERE StudentID=@StudentID";
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                con.Open();
                imageName = cmd.ExecuteScalar().ToString();
            }
            return imageName;
        }
        public static void UpdateImageById(string ImageName, string ImageUrl, int StudentID)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Student SET ImageName=@ImageName, ImageUrl=@ImageUrl WHERE StudentID=@StudentID";
                cmd.Parameters.AddWithValue("@ImageName", ImageName);
                cmd.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                cmd.Parameters.AddWithValue("@StudentID", StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static DataTable GetCourses()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Course";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                dt.Load(rdr, LoadOption.Upsert);
            }
            return dt;
        }
        public static DataTable GetFacultys()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Faculty";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                dt.Load(rdr, LoadOption.Upsert);
            }
            return dt;
        }
        public static DataTable GetTsps()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Tsp";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                dt.Load(rdr, LoadOption.Upsert);
            }
            return dt;
        }
        public static void SaveCourse(string CourseName)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Course (CourseName) VALUES(@CourseName)";
                cmd.Parameters.AddWithValue("@CourseName", CourseName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void SaveFaculty(string FacultyName)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Faculty (FacultyName) VALUES (@FacultyName)";
                cmd.Parameters.AddWithValue("@FacultyName", FacultyName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void SaveTsp(string TspName)
        {
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Tsp (TspName) VALUES (@TspName)";
                cmd.Parameters.AddWithValue("@TspName", TspName);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}