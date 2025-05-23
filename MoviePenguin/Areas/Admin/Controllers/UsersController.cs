using MoviePenguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePenguin.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private MovieDBContext db = new MovieDBContext();
        // GET: Admin/Users
        public ActionResult Index()
        {
            return View(); 
        }
    }
}