using blogsoftware.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blogsoftware.Attributes;
using blogsoftware.Models;

namespace blogsoftware.Controllers
{
    [SessionAuth]
    public class PostController : Controller
    {
        private readonly AppContext _db;

        public PostController(AppContext db)
        {
            _db = db;
        }

        // GET: Post
        public ActionResult Index()
        {
            //TODO: Integrate with redis
            using (_db)
            {
                var user = _db.Users.First(x => x.Username == Session["Username"] as string);
                return user.Posts.Any() ? View("Index", user.Posts) : View("Empty");
            }
        }

        public ActionResult Item(Guid itemIndex)
        {
            using (_db)
            {
                var post =
                    _db.Users.First(x => x.Username == Session["Username"] as string)
                        .Posts.FirstOrDefault(x => x.PostID == itemIndex);

                return post != null ? View(post) : View("Error");
            }
        }

        [HttpGet]
        public ActionResult New()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public bool SaveToDatabase()
        {
            //If true redirect to item? Or do it as json so we dont need a page refresh?
            throw new NotImplementedException();
        }
    }
}