using blogsoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace blogsoftware.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (true) //Service to authenticate
            {
                FormsAuthentication.SetAuthCookie(user.Username, true);
            }

            var username = user.Username;
            return View();
        }
    }
}