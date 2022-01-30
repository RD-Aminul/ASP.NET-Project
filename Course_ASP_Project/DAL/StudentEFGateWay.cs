using Course_ASP_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course_ASP_Project.DAL
{
    public class StudentEFGateWay
    {
        CouAspDBEntities db = new CouAspDBEntities();
        public IQueryable<Student> GetStudentList()
        {
            return from stu in db.Students select stu;
        }
        public Student GetStudent(int id)
        {
            Student stu = db.Students.FirstOrDefault(s => s.StudentID == id);
            return stu;
        }
        public void InsertStudent(Student obj)
        {
            db.Students.Add(obj);
            db.SaveChanges();
        }
        public int UpdateStudent(Student upObj)
        {
            int count = 0;
            Student obj = GetStudent(upObj.StudentID);
            obj.FirstName = upObj.FirstName;
            obj.LastName = upObj.LastName;
            obj.DateOfBirth = upObj.DateOfBirth;
            obj.Mobile = upObj.Mobile;
            obj.Email = upObj.Email;
            obj.ImageName = upObj.ImageName;
            obj.ImageUrl = upObj.ImageUrl;
            obj.CourseID = upObj.CourseID;
            obj.FacultyID = upObj.FacultyID;
            obj.TspID = upObj.TspID;
            count = db.SaveChanges();
            return count;
        }
        public int DeleteStudent(int id)
        {
            int count = 0;
            Student deleteStudent = GetStudent(id);
            db.Students.Remove(deleteStudent);
            count = db.SaveChanges();
            return count;
        }

    }
}