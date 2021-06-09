using Model.EF;
using Model.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TourDetailDAO
    {
        BookingTourDbContext db = null;
        public TourDetailDAO()
        {
            db = new BookingTourDbContext();
        }
        public TourDetailComment getById(long id)
        {
            var model = from a in db.Tours
                        join b in db.Tour_Detail on a.id equals b.tour_id
                        join c in db.Cities on a.departure_place equals c.id
                        join d in db.TourCategories on a.category equals d.id
                        select new TourDetailComment
                        {
                            id = a.id,
                            back_tour_guide = b.back_tour_guide,
                            tour_guide = b.tour_guide,
                            category = a.category,
                            checkin_date = a.checkin_date,
                            checkout_date = a.checkout_date,
                            days_of_tour = a.days_of_tour,
                            departure_detail = b.departure_detail,
                            description = a.description,
                            hotel_detail = b.hotel_detail,
                            image = a.image,
                            name = a.name,
                            price = a.price,
                            rating = a.rating,
                            view_count = a.view_count,
                            rating_count = a.rating_count,
                            departure_place = c.id,
                            main_image = a.main_image,
                            remaining_slot = a.remaining_slot,
                            category_name = d.name
                        };
            return model.Where(x => x.id.Equals(id)).FirstOrDefault();
        }
        public Tour_Detail getViewDetail(long id)
        {
            return db.Tour_Detail.SingleOrDefault(x => x.tour_id.Equals(id));
        }
        public bool update(Tour_Detail entity)
        {
            try
            {
                var tourDetail = db.Tour_Detail.Find(entity.id);
                tourDetail.departure_detail = entity.departure_detail;
                tourDetail.hotel_detail = entity.hotel_detail;
                tourDetail.tour_guide = entity.tour_guide;
                tourDetail.back_tour_guide = entity.back_tour_guide;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public long Insert(Tour_Detail entity)
        {
            try
            {
                var model = db.Tour_Detail.Add(entity);
                db.SaveChanges();
                return model.id;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }
}
