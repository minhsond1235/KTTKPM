using MoviePenguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Threading.Tasks;
namespace MoviePenguin.DAO
{
    public class SlideDao
    {
        MovieDBContext db = null;
        public SlideDao()
        {
            db = new MovieDBContext();
        }
        public IEnumerable<Slide> ListPg(int page, int pageSize)
        {
            return db.Slides.OrderByDescending(x => x.SlideID).ToPagedList(page, pageSize);
        }
        public List<Slide> ListAllSlide(int top)
        {
            return db.Slides.Where(X => X.Status == true).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Slides.Find(id);
                db.Slides.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool ChangeStatus(int id)
        {
            var ad = db.Slides.Find(id);
            ad.Status = !ad.Status;
            db.SaveChanges();
            return (bool)ad.Status;
        }
    }
}