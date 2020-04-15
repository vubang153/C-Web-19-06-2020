namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourCategory")]
    public partial class TourCategory
    {
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }
    }
}
