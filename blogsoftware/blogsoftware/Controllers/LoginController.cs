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
        private readonly AppContext _db;

        public LoginController(BCryptWrapper bCryptWrapper, AppContext db)
        {
            _bCryptWrapper = bCryptWrapper;
            _db = db;
        }

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["Logged in"] == null)
                return View();

            return RedirectToAction("Index", "Home"); //Redirect home if user is already logged in
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            using (_db)
            {
                var userFromDb = _db.Users.First(x => x.Username == user.Username);
                if (userFromDb != null)
                {
                    if (_bCryptWrapper.CheckPassword(userFromDb.PasswordHash, user.PasswordHash))
                    {
                        Session["Logged in"] = true;
                        Session["Username"] = user.Username;
                        return RedirectToAction("Index", "Home"); 
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateAccount()
        {
            if (Session["Username"] == null)
                return View();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult CreateAccount(User user)
        {
            using (_db)
            {

                if (!_db.Users.Any(x => x.Username == user.Username))
                {
                    var newUser = new User
                    {
                        Username = user.Username,
                        PasswordHash = _bCryptWrapper.GetHash(user.PasswordHash, _bCryptWrapper.GetSalt())
                    };
                    _db.Users.Add(newUser);
                    _db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }                
            }

            return View();
        }
    }
}