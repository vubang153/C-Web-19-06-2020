using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Areas.Admin.Controllers
{
    public class TourCommentController : BaseController
    {
        // GET: Admin/TourComment
        public ActionResult Index(string searchString, int page = 1, int pageSize = 12)
        {
            var model = new TourCommentDAO().getAll(page, pageSize, searchString);
            if (model.Count() < 1)
            {
                ModelState.AddModelError("NO_RECORD_FOUND", "Không tìm thấy bản ghi nào");
            }
            ViewBag.SearchString = searchString;
            ViewBag.TableName = "Bình luận Tour";
            ViewBag.title = "Danh sách bình luận";
            return View(model);
        }
        public JsonResult ChangeStatus(long id)
        {
            var result = new TourCommentDAO().changeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}