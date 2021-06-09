using Model.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model.EF;

namespace BookingTour.Controllers
{
    public class RedirectController : Controller
    {
        // GET: Redirect
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (User)Session["user"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
            /*else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Home", action = "Index", Area = "Admin" }));
            }*/
            base.OnActionExecuting(filterContext);
        }

    }
}