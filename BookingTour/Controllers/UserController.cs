using BookingTour.Models;
using Model.Dao;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public JsonResult Login(LoginModel loginModel)
        {
            var result = new UserDAO().authentication(loginModel.Username, loginModel.Password);
            if (result > 0 && loginModel.rememberMe == true)
            {
                this.addCookie(loginModel);
            }
            return Json(new
            {
                result = result
            });
        }
        public ActionResult loginWithCookie(LoginModel loginModel)
        {
            var result = new UserDAO().authentication(loginModel.Username, loginModel.Password);

            var user = new UserDAO().getID(loginModel.Username);
            this.addSessionAfterRegister(user);
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            if (Request.Cookies["userInfo"] != null)
            {
                Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register(User user)
        {
            var result = new UserDAO().Insert(user);
            var account_blance = new AccountBlanceDAO().Insert(result);
            if (result > 0)
            {
                this.addSessionAfterRegister(user);
            }
            return RedirectToAction("Index", "Home");
        }
        public JsonResult AddSession(string username)
        {
            var user = new UserDAO().getID(username);
            System.Web.HttpContext.Current.Session.Add("user", user);
            return Json(new
            {
            });
        }
        public void addSessionAfterRegister(User user)
        {
            Session.Add("user", user);
        }
        public void addCookie(LoginModel model)
        {
            HttpCookie userInfo = new HttpCookie("userInfo");
            userInfo["username"] = model.Username;
            userInfo["password"] = model.Password;
            userInfo["rememberMe"] = model.rememberMe.ToString();
            userInfo.Expires.Add(new TimeSpan(0, 1, 0));
            Response.Cookies.Add(userInfo);
        }
        public new ActionResult Profile()
        {
            ViewBag.title = "Thông tin tài khoản";
            var userSession = (User)Session["user"];
            var model = new UserDAO().getViewDetail(userSession.id);
            return View(model);
        }
        public ActionResult Order()
        {
            if (Session["user"] != null)
            {
                ViewBag.title = "Danh sách order";
                var user_id = ((User)Session["user"]).id;
                var model = new BookingDAO().getAll(user_id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}