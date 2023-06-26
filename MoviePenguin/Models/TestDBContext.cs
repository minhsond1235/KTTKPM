using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MoviePenguin.Models
{
    public class TestDBContext : DbContext
    {
        public TestDBContext()
            : base("name=MovieDBContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public  DbSet<News> News { get; set; }
        public  DbSet<Slide> Slides { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slide>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
