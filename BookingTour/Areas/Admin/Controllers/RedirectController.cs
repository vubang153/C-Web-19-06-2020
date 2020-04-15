using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Areas.Admin.Controllers
{
    public class RedirectController : Controller
    {
        // GET: Admin/Redirect
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Not_Found()
        {
            return View();
        }
    }
}