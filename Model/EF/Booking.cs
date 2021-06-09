namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public long id { get; set; }

        public long tour_id { get; set; }

        public long user_id { get; set; }

        public DateTime booking_date { get; set; }

        public int payments { get; set; }

        public long total_payment { get; set; }

        public int status { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
