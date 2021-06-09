using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF.Model
{
    public class TourDetailComment
    {
        public long id { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        public string description { get; set; }

        public DateTime checkin_date { get; set; }

        public DateTime checkout_date { get; set; }

        public int? days_of_tour { get; set; }

        public double rating { get; set; }

        public int? rating_count { get; set; }

        public string image { get; set; }

        public long category { get; set; }

        public string departure_detail { get; set; }

        public string hotel_detail { get; set; }

        public string tour_guide { get; set; }

        public string back_tour_guide { get; set; }
        public int? view_count { set; get; }
        public long departure_place { set; get; }
        public string main_image { get; set; }
        public int? remaining_slot { get; set; }
        public string category_name { get; set; }
    }
}
