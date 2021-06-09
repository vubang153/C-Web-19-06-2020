using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Areas.Admin.Controllers
{
    public class BookingController : BaseController
    {
        // GET: Admin/Booking
        public ActionResult Index(string searchString, int type = 4, int page = 1, int pageSize = 5)
        {
            var dao = new BookingDAO();
            var model = dao.getAll(page, pageSize, searchString, type);
            if (model.Count() < 1)
            {
                ModelState.AddModelError("", "Không tìm thấy tour nào");
            }
            //
            ViewBag.tableName = "Danh sách Booking";
            ViewBag.title = "Danh sách Booking";
            return View(model);
        }
        public ActionResult ChangeState(long id, int value)
        {
            var result = new BookingDAO().ChangeState(id, value);
            return Json(new
            {
                result = result
            });;
        }
    }
}