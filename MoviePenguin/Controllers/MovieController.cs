using MoviePenguin.DAO;
using MoviePenguin.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviePenguin.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        MovieDBContext DBContext = new MovieDBContext();
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Category()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);

        }
        [ChildActionOnly]

        public PartialViewResult Country()
        {
            var model = new CountryDAO().ListAll();
            return PartialView(model);

        }
        [ChildActionOnly]

        public PartialViewResult MenuBottom()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }

        public ActionResult Search()
        {

            return View();
        }

        public ActionResult CategoryPage(long id, int page = 1)
        {
            var movieDao = new MovieDao();
            var cate = new CategoryDAO().ViewDetail(id);
            ViewBag.cate = cate;
            ViewBag.ListMovieNew = movieDao.ListMovieNew(12);
            var model = movieDao.ListByCateId(id);
            return View(model.ToPagedList(page, 5));
        }
      
        public ActionResult CountryPage(long id, int page = 1)
        {
            var movieDao = new MovieDao();
            var country = new CountryDAO().ViewDetail(id);
            ViewBag.country = country;
            ViewBag.ListMovieNew = movieDao.ListMovieNew(12);
            var model = movieDao.ListByCountryID(id);
            return View(model.ToPagedList(page, 5));
        }
        public ActionResult MovieDetail(int id)
        {

            Movie movie = new MovieDao().ViewDetail(id);
            ViewBag.movie = movie;
            ViewBag.category = new CategoryDAO().ViewDetail(movie.CategoryID.Value);
            ViewBag.ListMovieRelated = new MovieDao().ListMovieRelated(id, 7);
            ViewBag.ListMovieNew1 = new MovieDao().ListMovieNew1(12);
            var upview = DBContext.Movies.Find(id);
            if (upview.Viewed == null)
            {
                upview.Viewed = 1;
                upview.Name = upview.Name;
                upview.Image = upview.Image;
                upview.Actor = upview.Actor;
                upview.Description = upview.Description;
                upview.Directors = upview.Directors;
                upview.Year = upview.Year;
                upview.Country = upview.Country;
                upview.MovieLink = upview.MovieLink;
                upview.CategoryID = upview.CategoryID;
                upview.Rate = upview.Rate;
                upview.CreateDate = upview.CreateDate;
                upview.Status = upview.Status;
                DBContext.Entry(upview).State = EntityState.Modified;
                DBContext.SaveChanges();
                return View(upview);
            }
            else
            {
                upview.Viewed = upview.Viewed + 1;
                upview.Name = upview.Name;
                upview.Image = upview.Image;
                upview.Actor = upview.Actor;
                upview.Description = upview.Description;
                upview.Directors = upview.Directors;
                upview.Year = upview.Year;
                upview.Country = upview.Country;
                upview.MovieLink = upview.MovieLink;
                upview.CategoryID = upview.CategoryID;
                upview.Rate = upview.Rate;
                upview.Status = upview.Status;
                DBContext.Entry(upview).State = EntityState.Modified;
                DBContext.SaveChanges();
                return View(upview);
            }

        }
    }
}