using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogsoftware.Attributes
{
    public class SessionAuthAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["Logged in"] == null || (bool)HttpContext.Current.Session["Logged in"] == false)
                return false;
            
            return true;
        }
    }
}