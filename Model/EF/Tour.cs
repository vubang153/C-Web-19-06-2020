namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        public long id { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        public double price { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        public DateTime checkin_date { get; set; }

        public DateTime checkout_date { get; set; }

        public int? days_of_tour { get; set; }

        public double rating { get; set; }

        public int? rating_count { get; set; }

        [Required]
        [StringLength(100)]
        public string image { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_by { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_by { get; set; }

        public int status { get; set; }
    }
}
