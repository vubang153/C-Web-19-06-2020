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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            Bookings = new HashSet<Booking>();
        }

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

        public long departure_place { get; set; }

        public double rating { get; set; }

        public int? rating_count { get; set; }

        public int? view_count { get; set; }

        [StringLength(100)]
        public string main_image { get; set; }

        [Required]
        [StringLength(100)]
        public string image { get; set; }

        public long category { get; set; }

        public int? remaining_slot { get; set; }

        public int? total_slot { get; set; }

        public int status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
