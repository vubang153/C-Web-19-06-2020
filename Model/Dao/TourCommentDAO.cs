using Model.EF;
using Model.EF.Model;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System;

namespace Model.Dao
{
    public class TourCommentDAO
    {
        BookingTourDbContext db = null;
        public TourCommentDAO()
        {
            db = new BookingTourDbContext();
        }
        public IEnumerable<TourCommentTour> getAll(int page, int pageSize, string keyword)
        {
            IQueryable<TourCommentTour> model = from a in db.TourComments
                                                join b in db.Tours on a.tour_id equals b.id
                                                select new TourCommentTour
                                                {
                                                    id = a.id,
                                                    comment_content = a.comment_content,
                                                    tour_name = b.name,
                                                    tour_id = a.tour_id,
                                                    status = a.status
                                                };
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.tour_name.Contains(keyword) || x.comment_content.Contains(keyword));
            }
            return model.OrderByDescending(x => x.id).ToPagedList(page, pageSize);
        }
        public TourComment getById(long id)
        {
            return db.TourComments.Find(id);
        }
        public List<TourComment> getByTourId(long tourId)
        {
            return db.TourComments.Where(x => x.tour_id == tourId).ToList();
        }
        public int changeStatus(long id)
        {
            try
            {
                var tour = db.TourComments.Find(id);
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
    }
}
