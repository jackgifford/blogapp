using blogsoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogsoftware.Controllers
{
    public class SeedController : Controller
    {
        // GET: Seed
        public ViewResult Index()
        {
            return View();
        }

        public void UserContext()
        {
            var userContext = new UserContext();
            var user = new User
            {
                Username = "test",
                PasswordHash = "test"
            };

            userContext.Users.Add(user);
            userContext.SaveChanges();

        }
    }
}