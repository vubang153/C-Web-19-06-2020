using Model.Commons;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        public ActionResult Index(long id)
        {
            var tourDAO = new TourDAO();
            tourDAO.updateViewCount(id);
            ////////////////
            var model = new TourDetailDAO().getById(id);
            ///////////////
            if (model.main_image == null)
            {
                model.main_image = "/Data/images/images/no-img.png";
            }
            ViewBag.title = model.name;
            ViewBag.list_suggest = new TourDAO().getSuggestTourByCategoryId(model.category);
            ViewBag.list_comment = new TourCommentDAO().getByTourId(id);
            return View(model);
        }
        public ActionResult Book(long id)
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Home", "Index");
            }
            else
            {
                return View();
            }
        }
        public JsonResult SessionChecking()
        {
            if (Session["user"] != null)
            {
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
    }
}