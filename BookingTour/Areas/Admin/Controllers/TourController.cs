using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Areas.Admin.Controllers
{
    public class TourController : Controller
    {
        // GET: Admin/Tour
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new TourDAO();
            var model = dao.getAll(page, pageSize, searchString);
            if (model.Count() < 1)
            {
                ModelState.AddModelError("NO_RECORD_FOUND", "Không tìm thấy bản ghi nào");
            }
            ViewBag.SearchString = searchString;
            ViewBag.TableName = "Thông tin tour";
            ViewBag.title = "Danh sách tour";
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var result = new TourDAO().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Insert()
        {
            ViewBag.title = "Thêm mới";
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Insert(Tour tour)
        {
            if (ModelState.IsValid)
            {
                var result = new TourDAO().Insert(tour);
                if (result > 0)
                {
                    ModelState.AddModelError("", "Thêm mới thành công !");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới thất bại !");
                }
            }
            ViewBag.title = "Thêm mới";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var tour = new TourDAO().getViewDetail(id);
            ViewBag.title = "Thêm mới";
            return View(tour);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Tour tour)
        {
            if (ModelState.IsValid)
            {
                var result = new TourDAO().update(tour);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public JsonResult changeStatus(long id)
        {
            var result = new TourDAO().changeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}