using Model.EF;
using Model.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class BookingDAO
    {
        BookingTourDbContext db = null;
        public BookingDAO()
        {
            db = new BookingTourDbContext();
        }
        public IEnumerable<BookingUserTour> getAll(int page, int pageSize, string keyword, int selectOption)
        {
            IQueryable<BookingUserTour> model = (from b in db.Bookings
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
                                                 });
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.name.Contains(keyword));
            }
            if (selectOption != 2)
            {
                model = model.Where(x => x.status.Equals(selectOption));
            }
            return model.OrderByDescending(x => x.id).ToPagedList(page, pageSize);
        }

    }
}
