using blogsoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using blogsoftware.Context;
using blogsoftware.Security;

namespace blogsoftware.Controllers
{
    public class LoginController : Controller
    {
        private readonly BCryptWrapper _bCryptWrapper;
        public readonly AppContext _db;

        public LoginController(BCryptWrapper bCryptWrapper, AppContext db)
        {
            _bCryptWrapper = bCryptWrapper;
            _db = db;
        }

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            using (var db = new Context.AppContext())
            {
                
            }

            if (true) //Service to authenticate
            {
                FormsAuthentication.SetAuthCookie(user.Username, true);
            }

            var username = user.Username;
            return View();
        }

        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public bool CreateAccount(User user)
        {
            using (_db)
            {

                if (!_db.Users.Any(x => x.Username == user.Username))
                {
                    var newUser = new User()
                    {
                        Username = user.Username,
                        PasswordHash = _bCryptWrapper.GetHash(user.PasswordHash, _bCryptWrapper.GetSalt())
                    };
                    _db.Users.Add(newUser);
                    _db.SaveChanges();
                    return true;
                }

                

            }

            return false;
        }
    }
}