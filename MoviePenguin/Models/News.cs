namespace MoviePenguin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public int NewsID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public string MoreDescription { get; set; }

        public DateTime? Createdate { get; set; }

        public bool? Status { get; set; }
    }
}
