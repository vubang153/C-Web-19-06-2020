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
        public ActionResult Index(string destination_name, string checkin_date, string checkout_date, int price_limit = 0, long category = 0, int page = 1, int pageSize = 12)
        {
            // Create search string session
            this.createMultiSearchSession();
            // Set query to session
            this.setMultipleSearchQuery(destination_name, checkin_date, checkout_date, price_limit, category);
            //
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
            var model = dao.getAll(page, pageSize, destination_name, checkInDate, checkOutDate, price_limit, category);
            if (model.Count() < 1)
            {
                ModelState.AddModelError("", "Không tìm thấy kết quả nào phù hợp !");
            }
            ViewBag.destination_name = destination_name;
            ViewBag.title = "Trang chủ";
            // Get TourCategory to select option
            return View(model);
        }
        // Set list tour category to select element in SearchBar.cshtml
        public ActionResult Category()
        {
            if (String.IsNullOrEmpty(Session["category_id"].ToString()))
            {
                ViewBag.category_id = 0;
            }
            else
            {
                ViewBag.category_id = Session["category_id"];
            }
            ///
            if (String.IsNullOrEmpty(Session["price_limit"].ToString()))
            {
                ViewBag.price_limit = 0;
            }
            else
            {
                ViewBag.price_limit = Session["price_limit"];
            }
            var list_category = new TourCategoryDAO().getAll();
            return PartialView("_SearchBar", list_category);
        }
        public ActionResult About()
        {
            return View();
        }
        //
        public void setMultipleSearchQuery(
            string destination_name,
            string checkin_date,
            string checkout_date,
            int price_limit = 0,
            long category_id = 0)
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
                    Session["destination_name"] = "";
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
                    Session["checkin_date"] = "";
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
                    Session["checkout_date"] = "";
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
                    Session["price_limit"] = "";
                }
            }
            if (category_id != 0)
            {
                if (Session["category_id"] == null)
                {
                    Session.Add("category_id", category_id);
                }
                else
                {
                    Session["category_id"] = category_id;
                }
            }
            else
            {
                if (Session["category_id"] != null)
                {
                    Session["category_id"] = "";
                }
            }

        }

        public void createMultiSearchSession()
        {
            Session.Add("destination_name", "");
            Session.Add("checkin_date", "");
            Session.Add("checkout_date", "");
            Session.Add("price_limit", "");
            Session.Add("category_id", "");
        }

    }
}