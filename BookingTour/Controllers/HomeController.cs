using BookingTour.Commons;
using Model;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(string destination_name, string checkin_date, string checkout_date, int price_limit = 0, int page = 1, int pageSize = 12)
        {
            // Set query to session
            this.setMultipleSearchQuery(destination_name, checkin_date, checkout_date, price_limit);
            DateTime checkInDate = new DateTime();
            DateTime checkOutDate = new DateTime();
            if (!String.IsNullOrEmpty(checkin_date))
            {
                checkInDate = Convert.ToDateTime(checkin_date);
            }
            if (!String.IsNullOrEmpty(checkout_date))
            {
                checkOutDate = Convert.ToDateTime(checkout_date);
            }
            else
            {
                checkOutDate = Convert.ToDateTime("30/12/2030");
            }


            // -------------------------------
            var dao = new TourDAO();
            var model = dao.getAll(page, pageSize, destination_name, checkInDate, checkOutDate, price_limit);
            if (model.Count() < 1)
            {
                ModelState.AddModelError("", "Không tìm thấy kết quả nào phù hợp !");
            }
            ViewBag.destination_name = destination_name;
            ViewBag.title = "Trang chủ";
            return View(model);
        }
        public ActionResult About()
        {
            return View();
        }
        //
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

            if (!String.IsNullOrEmpty(checkin_date))
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
            }
        }


    }
}