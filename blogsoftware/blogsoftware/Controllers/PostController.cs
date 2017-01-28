using blogsoftware.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blogsoftware.Controllers
{
    public class PostController : Controller
    {
        AppContext db = new AppContext();
        // GET: Post
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        public string Item(Guid itemIndex)
        {

            return itemIndex.ToString();
        }


    }
}