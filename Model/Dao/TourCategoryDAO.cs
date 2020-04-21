using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TourCategoryDAO
    {
        BookingTourDbContext db = null;
        public TourCategoryDAO()
        {
            db = new BookingTourDbContext();
        }
        public List<TourCategory> getAll()
        {
            return db.TourCategories.ToList();
        }

    }
}
