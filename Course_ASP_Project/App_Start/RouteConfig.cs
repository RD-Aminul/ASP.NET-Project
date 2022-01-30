using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Course_ASP_Project
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Temporary;
            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("Home", "home", "~/Home.aspx");
            routes.MapPageRoute("OBJCRUD", "ObjCrud", "~/Nav_Bar/ObjDsCRUD.aspx");
            routes.MapPageRoute("SQLCRUD", "SqlCrud", "~/Nav_Bar/SqlDsCRUD.aspx");
            routes.MapPageRoute("ENTITYCRUD", "EntityCrud", "~/Nav_Bar/EntityDsCRUD.aspx");
            routes.MapPageRoute("LogIn", "login", "~/Login.aspx");
            routes.MapPageRoute("Registration", "Register", "~/Reg/Registration.aspx");
            routes.MapPageRoute("ResetPassword", "ResetPass", "~/Reg/ResetPass.aspx");
            routes.MapPageRoute("ReportView", "Report", "~/Views/ReportView.aspx");
            

        }
    }
}
