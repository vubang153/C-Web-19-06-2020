namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public bool? gender { get; set; }

        public DateTime? DOB { get; set; }

        public int permission { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        public long? provinceID { get; set; }

        public long? districtID { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(50)]
        public string created_by { get; set; }

        public DateTime? modified_date { get; set; }

        [StringLength(50)]
        public string modified_by { get; set; }

        public int status { get; set; }
    }
}
