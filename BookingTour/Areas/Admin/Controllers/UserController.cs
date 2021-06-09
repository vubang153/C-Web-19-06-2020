using Model.Dao;
using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDAO();
            var districtDao = new DistrictDAO();
            var provinceDao = new ProvinceDAO();
            var model = dao.getUsers(page, pageSize, searchString);
            if (model.Count() < 1)
            {
                ModelState.AddModelError("NO_RECORD_FOUND", "Không tìm thấy bản ghi nào");
            }
            ViewBag.SearchString = searchString;
            ViewBag.TableName = "Tài khoản";
            ViewBag.provinceList = provinceDao.getAll();
            ViewBag.title = "Quản lý user";


            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index");
        }
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDAO().changeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        public JsonResult getViewDetail(long id)
        {
            var user = new UserDAO().getViewDetail(id);
            return Json(new {
                user = user
            });
        }
        public ActionResult Edit(User user)
        {
            var result = new UserDAO().Edit(user);
            return RedirectToAction("Index");
        }
        public ActionResult Insert(User user)
        {
            user.status = 1;
            user.permission = 1;
            var result = new UserDAO().Insert(user);
            if (result > 0)
                ModelState.AddModelError("", "Thêm mới thành công");
            else
                ModelState.AddModelError("", "Thêm mới thất bại");
            return RedirectToAction("Index");
        }
    }
}