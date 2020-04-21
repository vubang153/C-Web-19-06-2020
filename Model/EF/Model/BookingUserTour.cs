using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF.Model
{
    public class BookingUserTour
    {
        public long id { get; set; }

        public string username { set; get; }

        public DateTime? DOB { set; get; }
        public string name { set; get; }
        public DateTime checkin_date { set; get; }
        public DateTime checkout_date { set; get; }
        public DateTime booking_date { set; get; }
        public int status { set; get; }

    }
}
