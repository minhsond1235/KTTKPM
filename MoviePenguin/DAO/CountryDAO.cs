using MoviePenguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Threading.Tasks;

namespace MoviePenguin.DAO
{
    public class CountryDAO
    {
        MovieDBContext dbContext = null;
        public CountryDAO()
        {
            dbContext = new MovieDBContext();
        }
        public IEnumerable<Country> ListPg(int page, int pageSize)
        {
            return dbContext.Countries.OrderByDescending(x => x.CountryID).ToPagedList(page, pageSize);
        }
        public List<Country> ListAll()
        {
            return dbContext.Countries.Where(x => x.Status == true).ToList();
        }
        public Country ViewDetail(long id)
        {
            return dbContext.Countries.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = dbContext.Countries.Find(id);
                dbContext.Countries.Remove(user);
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
            var ad = dbContext.Countries.Find(id);
            ad.Status = !ad.Status;
            dbContext.SaveChanges();
            return (bool)ad.Status;
        }
    }
}