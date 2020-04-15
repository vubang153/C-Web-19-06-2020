using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingTour.Commons
{
    public static class Commons
    {
        // Hàm chuyển
        public static string convertString(int id, string string_1, string string_2)
        {
            if (id == 1)
            {
                return string_1;
            }
            else
            {
                return string_2;
            }
        }
       
    }
}