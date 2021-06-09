using BookingTour.Commons;
using Model.Dao;
using Model.EF;
using Model.EF.Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Controllers
{
    public class BookingController : RedirectController
    {
        // GET: Booking
        [HttpGet]
        public ActionResult Index(long id)
        {
            var model = new TourDetailDAO().getById(id);
            var userSession = (User)Session["user"];
            ViewBag.blance = new AccountBlanceDAO().getSingle(userSession.id);
            ViewBag.title = "Thanh toán";
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(PreOrder model)
        {
            Booking book = new Booking();
            book.tour_id = model.id;
            book.booking_date = DateTime.Now;
            book.payments = model.payments;
            if (model.payments == 0)
            {
                book.total_payment = (long)model.price;
            }
            else
            {
                book.total_payment = 0;
            }
            
            book.status = 1;
            book.user_id = ((User)Session["user"]).id;
            var result = new BookingDAO().Insert(book);
            var cash_result = new AccountBlanceDAO().Cash(book.user_id, book.total_payment);
            if (result > 0)
            {
                return RedirectToAction("Order", "User");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public PreOrder setTourToPreOrder(TourDetailComment tour, int payment)
        {
            var model = new PreOrder();
            model.id = tour.id;
            model.name = tour.name;
            model.image = tour.image;
            model.days_of_tour = tour.days_of_tour;
            model.checkin_date = tour.checkin_date;
            model.checkout_date = tour.checkout_date;
            model.payments = payment;
            model.price = tour.price;
            model.remaining_slot = tour.remaining_slot;
            return model;
        }
        public JsonResult addToCart(long id, int payments)
        {
            var tour = new TourDetailDAO().getById(id);
            var model = this.setTourToPreOrder(tour, payments);
            if (model != null)
            {
                Session.Add(Commons.Commons.SESSION_CART, model);
                return Json(new
                {
                    result = 1
                });
            }
            else
            {
                return Json(new
                {
                    result = 0
                });
            }

        }
        public ActionResult Checkout()
        {
            var model = (PreOrder)Session[Commons.Commons.SESSION_CART];

            var userSession = (User)Session["user"];

            var blance = (double)new AccountBlanceDAO().getSingle(userSession.id).blance;
            if (model.payments == 1)
            {
                blance = blance - model.price;
            }
            ViewBag.blance_account = blance;
            ViewBag.title = "Thanh toán";
            return View(model);
        }
        public ActionResult CancelOrder(long id)
        {
            var BookingDAO = new BookingDAO();
            var total_payments = BookingDAO.getTotalPayments(id);
            var result = BookingDAO.Delete(id);
            long id_user = ((User)Session["user"]).id;
            var refund_result = new AccountBlanceDAO().Refund(id_user, total_payments);
            return Json(new
            {
                result = result,
                refund_result = refund_result
            });
        }
    }
}