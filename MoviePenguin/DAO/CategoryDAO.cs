using MoviePenguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Threading.Tasks;

namespace MoviePenguin.DAO
{
    public class CategoryDAO
    {
        MovieDBContext DBContext = null;
        public CategoryDAO()
        {
            DBContext = new MovieDBContext ();
        }
        public IEnumerable<Category> ListPg(int page, int pageSize)
        {
            return DBContext.Categories.OrderByDescending(x => x.CategoryID).ToPagedList(page, pageSize);
        }
        public List<Category> ListAll()
        {
            return DBContext.Categories.Where(x => x.Status == true).ToList();
        }
        public Category ViewDetail(long id)
        {
            return DBContext.Categories.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = DBContext.Categories.Find(id);
                DBContext.Categories.Remove(user);
                DBContext.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool ChangeStatus(int id)
        {
            var ad =   DBContext.Categories.Find(id);
            ad.Status = !ad.Status;
            DBContext.SaveChanges();
            return (bool)ad.Status;
        }
    }
}