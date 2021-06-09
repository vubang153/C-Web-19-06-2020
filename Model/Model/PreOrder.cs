using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class PreOrder
    {
        public long user_id { get; set; }
        public long id { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        public DateTime checkin_date { get; set; }

        public DateTime checkout_date { get; set; }

        public int? days_of_tour { get; set; }

        public int? remaining_slot { get; set; }

        public string image { get; set; }
        public int payments { get; set; }
        public long total_payment { get; set; }

    }
}
