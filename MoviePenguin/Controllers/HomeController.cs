
using MoviePenguin.DAO;
using MoviePenguin.Models;
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
            TestDBContext test = new TestDBContext();
            var x = test.Countries.ToList();
            var MovieDao = new MovieDao();
            ViewBag.listMovieNew = MovieDao.ListMovieNew(6);
            ViewBag.listMovieTop = MovieDao.ListMovieTop(4);
            ViewBag.listMoviePo = MovieDao.ListMoviePo(4);
            ViewBag.Slides = new SlideDao().ListAllSlide(5);
            return View(MovieDao);
        }
        public ActionResult Search()
        {
            return View();
        }
    }
}