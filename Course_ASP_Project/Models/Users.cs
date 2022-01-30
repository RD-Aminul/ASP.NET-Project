using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Course_ASP_Project.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
    }
}