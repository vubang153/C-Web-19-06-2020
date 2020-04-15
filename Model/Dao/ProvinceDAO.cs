﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProvinceDAO
    {
        BookingTourDbContext db = null;
        public ProvinceDAO()
        {
            db = new BookingTourDbContext();
        }
        public List<Province> getAll()
        {
            return db.Provinces.ToList();
        }
    }
}
