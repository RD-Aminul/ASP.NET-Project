using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Course_ASP_Project.DAL
{
    public static class Connection
    {
        public static string GetConncetionString()
        {
            string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            return conStr;
        }
    }
}