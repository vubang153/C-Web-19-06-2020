namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TourComment")]
    public partial class TourComment
    {
        public long id { get; set; }

        public long tour_id { get; set; }
        public int status { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string comment_content { get; set; }

    }
}
