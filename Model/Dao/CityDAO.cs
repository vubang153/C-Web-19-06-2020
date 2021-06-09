using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CityDAO
    {
        BookingTourDbContext db = null;
        public CityDAO()
        {
            db = new BookingTourDbContext();
        }
        public List<City> getAll()
        {
            return db.Cities.ToList();
        }
    }
}
