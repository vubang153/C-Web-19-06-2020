using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Commons
{
    public class CommonFunction : Controller
    {
        // Hàm lưu query vào session
        public void setMultipleSearchQuery(string destination_name, string checkin_date, string checkout_date, int price_limit = 0)
        {

            System.Web.HttpContext.Current.Session["LogID"] = 10;

            if (!String.IsNullOrEmpty(destination_name))
            {
                if (String.IsNullOrEmpty((string)Session["destination_name"]))
                {
                    Session.Add("destination_name", destination_name);
                }
                else
                {
                    Session["destination_name"] = destination_name;
                }
            }
            else
            {
                if (!(String.IsNullOrEmpty((string)Session["destination_name"])))
                {
                    Session.Remove("destination_name");
                }
            }
            //--------------------------------------------

            /*if (!String.IsNullOrEmpty(checkin_date))
            {
                if (Session["checkin_date"] == null)
                {
                    Session.Add("checkin_date", checkin_date);
                }
                else
                {
                    Session["checkin_date"] = checkin_date;
                }
            }
            else
            {
                if (Session["checkin_date"] != null)
                {
                    Session.Remove("checkin_date");
                }
            }
            //--------------------------------------------
            if (!String.IsNullOrEmpty(checkout_date))
            {
                if (Session["checkout_date"] == null)
                {
                    Session.Add("checkout_date", checkout_date);
                }
                else
                {
                    Session["checkout_date"] = checkout_date;
                }
            }
            else
            {
                if (Session["checkout_date"] != null)
                {
                    Session.Remove("checkout_date");
                }
            }
            //--------------------------------------------
            if (price_limit != 0)
            {
                if (Session["price_limit"] == null)
                {
                    Session.Add("price_limit", price_limit);
                }
                else
                {
                    Session["price_limit"] = price_limit;
                }
            }
            else
            {
                if (Session["price_limit"] != null)
                {
                    Session.Remove("price_limit");
                }
            }*/
        }
        // Hàm xoá queries trong session
        public void deleteMultipleSearchQuery()
        {
            Session.Remove("destination_name");
            Session.Remove("checkin_date");
            Session.Remove("checkout_date");
            Session.Remove("price_limit");
        }
    }
}