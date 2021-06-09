namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tour_Detail
    {
        public long id { get; set; }

        public long tour_id { get; set; }

        [Column(TypeName = "ntext")]
        public string departure_detail { get; set; }

        [StringLength(100)]
        public string hotel_detail { get; set; }

        [StringLength(100)]
        public string tour_guide { get; set; }

        [StringLength(100)]
        public string back_tour_guide { get; set; }
    }
}
