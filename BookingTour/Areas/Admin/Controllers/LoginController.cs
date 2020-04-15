using BookingTour.Areas.Admin.Controllers;
using BookingTour.Areas.Admin.Models;
using Model.Commons;
using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Areas.Admin
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            if (!String.IsNullOrEmpty((string)Session[SESSION.USER_SESSION]))
            {
                return RedirectToAction("Index", "Home");
            }

            HttpCookie reqCookies = Request.Cookies["userInfo"];
            var loginModel = new LoginModel();
            if (reqCookies != null)
            {
                loginModel.Username = reqCookies["username"].ToString();
                loginModel.Password = reqCookies["password"].ToString();
                loginModel.RememberMe = Convert.ToBoolean(reqCookies["rememberMe"]);
                return View(loginModel);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            int result = new UserDAO().authentication(model.Username, model.Password);
            if (result == ACCOUNT.LOGIN_SUCCESS)
            {
                if (model.RememberMe)
                {
                    HttpCookie userInfo = new HttpCookie("userInfo");
                    userInfo["username"] = model.Username;
                    userInfo["password"] = model.Password;
                    userInfo["rememberMe"] = model.RememberMe.ToString();
                    userInfo.Expires.Add(new TimeSpan(0, 1, 0));
                    Response.Cookies.Add(userInfo);
                }
                else
                {
                    HttpCookie reqCookies = Request.Cookies["userInfo"];
                    if (reqCookies != null)
                    {
                        reqCookies.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(reqCookies);
                    }
                }
                Session.Add(SESSION.USER_SESSION, model.Username);
                return RedirectToAction("Index", "Home");
            }
            if (result == ACCOUNT.WAS_BANNED)
            {
                ModelState.AddModelError("", "Tài khoản đã bị khoá ");
            }
            else if (result == ACCOUNT.NOT_EXIST || result == ACCOUNT.WRONG_PASSWORD)
            {
                ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Remove(SESSION.USER_SESSION);
            return RedirectToAction("Index", "Login");
        }

    }
}