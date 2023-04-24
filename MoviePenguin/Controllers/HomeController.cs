
using MoviePenguin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MoviePenguin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var MovieDao = new MovieDao();
            ViewBag.listMovieNew = MovieDao.ListMovieNew(6);
            ViewBag.listMovieTop = MovieDao.ListMovieTop(6);
            ViewBag.listMoviePo = MovieDao.ListMoviePo(6);
            ViewBag.Slides = new SlideDao().ListAllSlide(5);
            return View(MovieDao);
        }
        public ActionResult Search()
        {
            return View();
        }
    }
}