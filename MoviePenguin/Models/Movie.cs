namespace MoviePenguin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movie")]
    public partial class Movie
    {
        public int MovieID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Image { get; set; }

        [StringLength(100)]
        public string Actor { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string Directors { get; set; }

        [StringLength(100)]
        public string Year { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        public string MovieLink { get; set; }

        public int? CategoryID { get; set; }

        public int? Rate { get; set; }

        public int? CountryID { get; set; }

        public int? Viewed { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }

        public virtual Category Category { get; set; }

        public virtual Country Country1 { get; set; }
    }
}
