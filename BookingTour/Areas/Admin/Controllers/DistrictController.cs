using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingTour.Areas.Admin.Controllers
{
    public class DistrictController : Controller
    {
        // GET: Admin/District
        public JsonResult getDistrictByProvinceID(long id)
        {
            var result = new DistrictDAO().getDistrictByProvinceID(id);
            return Json(new
            {
                list_district = result
            });
        }
    }
}