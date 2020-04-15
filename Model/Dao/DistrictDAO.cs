using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DistrictDAO
    {
        BookingTourDbContext db = null;
        public DistrictDAO()
        {
            db = new BookingTourDbContext();
        }
        public List<District> getDistrictByProvinceID(long id)
        {
            return db.Districts.Where(x => x.province_id == id).ToList();
        }
    }
}
