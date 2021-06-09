using Model.EF;
using Model.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using Model.Model;
using Model.Commons;

namespace Model.Dao
{
    public class BookingDAO
    {
        BookingTourDbContext db = null;
        public BookingDAO()
        {
            db = new BookingTourDbContext();
        }
        public ListOrder getAll(long user_id)
        {
            var listAll = db.Bookings.Where(x => x.user_id.Equals(user_id)).ToList();
            // list chờ xác nhận
            var list1 = listAll.Where(x => x.status.Equals(1)).ToList();
            // list đang thực hiện
            var list2 = listAll.Where(x => x.status.Equals(2)).ToList();
            // list đã hoàn thành
            var list3 = listAll.Where(x => x.status.Equals(3)).ToList();
            // List order đã huỷ
            var list4 = listAll.Where(x => x.status.Equals(4)).ToList();

            var model = new ListOrder();

            model.list4 = list4;
            model.listAll = listAll;
            model.list1 = list1;
            model.list2 = list2;
            model.list3 = list3;
            return model;

        }
        public IEnumerable<BookingUserTour> getAll(int page, int pageSize, string keyword, int type)
        {
            IQueryable<BookingUserTour> model = from b in db.Bookings
                                                join u in db.Users on b.user_id equals u.id
                                                join t in db.Tours on b.tour_id equals t.id
                                                select new BookingUserTour
                                                {
                                                    id = b.id,
                                                    username = u.username,
                                                    DOB = u.DOB,
                                                    name = t.name,
                                                    checkin_date = t.checkin_date,
                                                    checkout_date = t.checkout_date,
                                                    booking_date = b.booking_date,
                                                    status = b.status
                                                };
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.name.Contains(keyword) || x.username.Contains(keyword));
            }
            if (type != 4)
            {
                model = model.Where(x => x.status.Equals(type));
            }
            /*if (selectOption != 2)
            {
                model = model.Where(x => x.status.Equals(selectOption));
            }*/
            return model.OrderByDescending(x => x.id).ToPagedList(page, pageSize);
        }
        public bool Booking(PreOrder model)
        {
            var tour = new TourDAO().getViewDetail(model.id);
            if (tour != null)
            {

                try
                {
                    var bookingModel = this.setPreOrderToBooking(model);
                    db.Bookings.Add(bookingModel);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
            return true;
        }
        public Booking setPreOrderToBooking(PreOrder model)
        {
            var bookingModel = new Booking();
            bookingModel.payments = model.payments;
            bookingModel.status = 1;
            bookingModel.tour_id = model.id;
            bookingModel.booking_date = DateTime.Now;
            ///
            return bookingModel;
        }
        public int Insert(Booking model)
        {
            db.Bookings.Add(model);
            var result = db.SaveChanges();
            return result;
        }
        public bool ChangeState(long id, int value)
        {
            try
            {
                var model = db.Bookings.Find(id);
                model.status = value;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var model = db.Bookings.Find(id);
                db.Bookings.Remove(model);
                var result = db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public long getTotalPayments(long id)
        {
            var total_payments = db.Bookings.Find(id).total_payment;
            return total_payments;
        }
    }
}
