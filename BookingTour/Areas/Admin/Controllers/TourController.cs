using Model.Dao;
using Model.EF;
using Model.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Areas.Admin.Controllers
{
    public class TourController : BaseController
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
        public ActionResult OLD_Insert()
        {
            ViewBag.title = "Thêm mới";

            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OLD_Insert(Tour tour)
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
        public ActionResult OLD_Edit(long id)
        {
            var tour = new TourDAO().getViewDetail(id);
            ViewBag.title = "Thêm mới";
            return View(tour);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OLD_Edit(Tour tour)
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
        [HttpGet]
        public ActionResult Insert()
        {
            ViewBag.list_city = new CityDAO().getAll();
            ViewBag.list_category = new TourCategoryDAO().getAll();
            ViewBag.title = "Thêm mới";
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Insert(Tour tourModel, Tour_Detail tourDetailModel)
        {
            var firstResult = new TourDAO().Insert(tourModel);
            tourDetailModel.tour_id = firstResult;
            var secondResult = new TourDetailDAO().Insert(tourDetailModel);
            ////////////////////////////////
            return RedirectToAction("Index");
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(TourDetailComment tourModel)
        {
            var tourDAO = new TourDAO();
            var tourDetailDAO = new TourDetailDAO();
            ////////////////////////////////////////
            var tour = tourDAO.getViewDetail(tourModel.id);
            var tourDetail = tourDetailDAO.getViewDetail(tourModel.id);
            //////////////////////////////////
            ///set tourModel to 2 object
            tour.id = tourModel.id;
            tour.name = tourModel.name;
            tour.category = tourModel.category;
            tour.price = tourModel.price;
            tour.departure_place = tourModel.departure_place;
            tour.description = tourModel.description;
            tourDetail.departure_detail = tourModel.departure_detail;
            tour.checkin_date = tourModel.checkin_date;
            tour.checkout_date = tourModel.checkout_date;
            tour.image = tourModel.image;
            tour.main_image = tourModel.main_image;
            tourDetail.hotel_detail = tourModel.hotel_detail;
            tourDetail.tour_guide = tourModel.tour_guide;
            tourDetail.back_tour_guide = tourModel.back_tour_guide;
            ////////////////////////////////
            var firstResult = tourDAO.update(tour);
            var secondResult = tourDetailDAO.update(tourDetail);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var model = new TourDetailDAO().getById(id);
            ViewBag.list_city = new CityDAO().getAll();
            ViewBag.list_category = new TourCategoryDAO().getAll();
            ViewBag.title = "Sửa - " + model.name;
            return View(model);
        }
    }
}