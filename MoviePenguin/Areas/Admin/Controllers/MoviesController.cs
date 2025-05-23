﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviePenguin.DAO;
using MoviePenguin.Models;

namespace MoviePenguin.Areas.Admin.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Admin/Movies
        //[Authorize(Roles = "Admin")]
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var DAO = new MovieDao();
            var model = DAO.ListM(page, pageSize);
            return View(model);
        }

        // GET: Admin/Movies/Details/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Admin/Movies/Create
        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name");
            return View();
        }

        // POST: Admin/Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,Name,Actor,Description,Directors,Year,CategoryID,Rate,CountryID,Viewed,CreateDate,Status")] Movie movie, HttpPostedFileBase  urlmovie, HttpPostedFileBase urlimage)
        {
            if (urlmovie != null && urlmovie.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(urlmovie.FileName);
                string movieLink = Server.MapPath( "~/VideoFileUpload/" + fileName);
                urlmovie.SaveAs(movieLink);
                movie.MovieLink = "VideoFileUpload/" + fileName;
            }

            if (urlimage != null && urlimage.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(urlimage.FileName);
                string imagelink = Server.MapPath("~/VideoFileUpload/" + fileName);
                urlimage.SaveAs(imagelink);
                movie.Image = "VideoFileUpload/" + fileName;
            }





            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", movie.CategoryID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", movie.CountryID);
            return View(movie);
        }

        // GET: Admin/Movies/Edit/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", movie.CategoryID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", movie.CountryID);
            return View(movie);
        }

        // POST: Admin/Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,Name,Image,Actor,Description,Directors,Year,Country,CategoryID,Rate,CountryID,Viewed,CreateDate,Status")] Movie movie,HttpPostedFileBase editmovie,HttpPostedFileBase editimg)
        {

            if (ModelState.IsValid)
            {
                
                if (movie != null)
                {               
                    if (editmovie != null && editmovie.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(editmovie.FileName);
                        string movieLink = Server.MapPath("~/VideoFileUpload" + fileName);
                        editmovie.SaveAs(movieLink);
                        movie.MovieLink = "VideoFileUpload" + fileName;
                    }
                }
                if (movie != null)
                {
                    if (editimg != null && editimg.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(editimg.FileName);
                        string image = Server.MapPath("~/VideoFileUpload/" + fileName);
                        editimg.SaveAs(image);
                        movie.Image = "VideoFileUpload/" + fileName;
                    }
                }

                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", movie.CategoryID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", movie.CountryID);
            return View(movie);
        }
        // GET: Admin/Movies/Delete/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Admin/Movies/Delete/5
        //[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
