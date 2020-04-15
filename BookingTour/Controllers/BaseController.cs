using BookingTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookingTour.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LoginModel loginModel = new LoginModel();
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                loginModel.Username = reqCookies["username"].ToString();
                loginModel.Password = reqCookies["password"].ToString();
                loginModel.rememberMe = Convert.ToBoolean(reqCookies["rememberMe"]);
                if (Session["user"] == null)
                {
                    new UserController().AddSession(loginModel.Username);
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}