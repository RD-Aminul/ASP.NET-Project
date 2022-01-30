using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Course_ASP_Project.DAL
{
    public class UsersGateWay
    {
        public int SaveUser(string userName, string email, string gender, string password )
        {
            int returnCode = 0;
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter username = new SqlParameter("@UserName", userName);
                SqlParameter mail = new SqlParameter("@Email", email);
                SqlParameter gen = new SqlParameter("@Gender", gender);
                SqlParameter pass = new SqlParameter("@Password", password);
                cmd.Parameters.Add(username);
                cmd.Parameters.Add(mail);
                cmd.Parameters.Add(gen);
                cmd.Parameters.Add(pass);
                con.Open();
                returnCode = (int)cmd.ExecuteScalar();
            }
            return returnCode;
        }
        public int AuthenticateUser(string userName, string password)
        {
            int authenticated = 0;
            using (SqlConnection con = new SqlConnection(Connection.GetConncetionString()))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter username = new SqlParameter("@UserName", userName);
                SqlParameter pass = new SqlParameter("@Password", password);
                cmd.Parameters.Add(username);
                cmd.Parameters.Add(pass);
                con.Open();
                authenticated = (int)cmd.ExecuteScalar();
            }
            return authenticated;

        }
    }
}