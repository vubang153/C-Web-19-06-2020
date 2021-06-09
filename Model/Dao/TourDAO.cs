using Model.EF;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System;

namespace Model.Dao
{
    public class TourDAO
    {
        BookingTourDbContext db = null;
        public TourDAO()
        {
            db = new BookingTourDbContext();
        }
        public IEnumerable<Tour> getAll(int page, int pageSize, string keyword, DateTime checkin_date, DateTime checkout_date, int price_limit, long category_id)
        {
            IQueryable<Tour> model = db.Tours;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.name.Contains(keyword));
            }
            if (price_limit != 0)
            {
                model = model.Where(x => x.price <= price_limit);
            }
            if (category_id != 0)
            {
                model = model.Where(x => x.category == category_id);
            }

            model = model.Where(x => x.checkin_date >= checkin_date
                                && x.checkout_date <= checkout_date)
                        .Where(x => x.status >= 1);
            return model.OrderByDescending(x => x.id).ToPagedList(page, pageSize);
        }
        public IEnumerable<Tour> getAll(int page, int pageSize, string keyword)
        {
            IQueryable<Tour> model = db.Tours;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.name.Contains(keyword));
            }
            return model.OrderByDescending(x => x.id).ToPagedList(page, pageSize);
        }
        public bool Delete(long id)
        {
            try
            {
                var tour = db.Tours.Find(id);
                db.Tours.Remove(tour);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public long Insert(Tour tour)
        {
            TimeSpan time = new TimeSpan();
            time = tour.checkout_date - tour.checkin_date;
            tour.status = 1;
            tour.days_of_tour = time.Days;
            var model = db.Tours.Add(tour);
            db.SaveChanges();
            return model.id;
        }
        public Tour getViewDetail(long id)
        {
            var tour = db.Tours.Find(id);
            return tour;
        }
        public bool update(Tour entity)
        {
            try
            {
                TimeSpan time = new TimeSpan();
                var tour = db.Tours.Find(entity.id);
                time = entity.checkout_date - entity.checkin_date;
                tour.days_of_tour = time.Days;
                tour.image = entity.image;
                tour.name = entity.name;
                tour.price = entity.price;
                tour.description = entity.description;
                tour.checkin_date = entity.checkin_date;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int changeStatus(long id)
        {
            try
            {
                var tour = db.Tours.Find(id);
                if (tour.status == 1)
                {
                    tour.status = 0;
                }
                else
                {
                    tour.status = 1;
                }
                db.SaveChanges();
                return tour.status;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }
        public List<Tour> getSuggestTourByCategoryId(long c_id)
        {
            var model = db.Tours.Where(x => x.category == c_id).OrderByDescending(x => x.id).Skip(1).Take(4).ToList();
            if (model.Count < 1)
            {
                model = db.Tours.Where(x => x.status == 1).OrderByDescending(x => x.id).Take(4).ToList();
            }
            return model;
        }
        public bool updateViewCount(long id)
        {
            try
            {
                var tour = db.Tours.Find(id);
                tour.view_count += 1;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
