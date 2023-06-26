using MoviePenguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Threading.Tasks;

namespace MoviePenguin.DAO
{
    public class MovieDao
    {
        MovieDBContext dbContext = null;
        public MovieDao()
        {
            dbContext = new MovieDBContext();
        }
       
        public IEnumerable<Movie> ListM(int page, int pageSize )
        {
           var dbContext = new MovieDBContext();    
            return dbContext.Movies.OrderByDescending(x => x.MovieID).ToPagedList(page, pageSize);
        }
       
        public List<Movie> ListMovieNew(int top)
        {
            return dbContext.Movies.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
     
        public List<Movie> ListMovieTop(int top)
        {
            return dbContext.Movies.Where(x => x.Status == true).OrderByDescending(x => x.Rate).Take(top).ToList();
        }
        
        public List<Movie> ListMoviePo(int top)
        {
            return dbContext.Movies.Where(x => x.Status == true).OrderByDescending(x => x.Viewed & x.Rate).Take(top).ToList();
        }
       
        public List<Movie> ListMovieRelated(int movieid, int top)
        {
            var movie = dbContext.Movies.Find(movieid);
            return dbContext.Movies.Where(x => x.MovieID != movieid && x.CategoryID == movie.CategoryID).OrderByDescending(y => y.CreateDate).Take(top).ToList();
        }
     
        public List<Movie> ListMovieNew1(int top)
        {

            return dbContext.Movies.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
       
        public List<Movie> ListByCateId(long cateID)
        {

            return dbContext.Movies.Where(x => x.CategoryID == cateID).OrderByDescending(x => x.CreateDate).ToList();

        }
        public List<Movie> ListByCountryID(long countryID)
        {

            return dbContext.Movies.Where(x => x.CountryID == countryID).OrderByDescending(x => x.CreateDate).ToList();

        }

        public List<Movie> SearchByKey(string key)
        {
            return dbContext.Movies.SqlQuery("Select * from Movie where Name like '%" + key + "%'").ToList();
        }

        public Movie ViewDetail(int id)
        {
            return dbContext.Movies.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = dbContext.Movies.Find(id);
                dbContext.Movies.Remove(user);
                dbContext.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool ChangeStatus(int id)
        {
            var ad = dbContext.Movies.Find(id);
            ad.Status = !ad.Status;
            dbContext.SaveChanges();
            return (bool)ad.Status;
        }
    }
}