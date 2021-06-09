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
        public static string convertString(int id, string s1, string s2, string s3, string s4)
        {
            if (id == 1)
            {
                return s1;
            }
            else if (id == 2)
            {
                return s2;
            }
            else if (id == 3)
            {
                return s3;
            }
            else
            {
                return s4;
            }
        }
        public static string SESSION_CART = "SESSION_CART";
        public static int CASH_ON = 1;
        public static int ACCOUNT_PAYMENT = 2;
    }
}