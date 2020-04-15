namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Province")]
    public partial class Province
    {
        public long id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int? zip_code { get; set; }
    }
}
