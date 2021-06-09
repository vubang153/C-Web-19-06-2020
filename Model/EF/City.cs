namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        public long id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(50)]
        public string zip_code { get; set; }

        public int status { get; set; }
    }
}
