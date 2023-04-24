using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MoviePenguin.Models
{
    public partial class MovieDBContext : DbContext
    {
        public MovieDBContext()
            : base("name=MovieDBContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slide>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
