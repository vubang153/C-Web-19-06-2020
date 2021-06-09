using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class AccountBlanceDAO
    {
        BookingTourDbContext db = null;
        public AccountBlanceDAO()
        {
            db = new BookingTourDbContext();
        }
        public Account_blance getSingle(long id)
        {
            return db.Account_blance.Find(id);
        }
        public bool Cash(long id, long value)
        {
            try
            {
                var model = db.Account_blance.Find(id);
                model.blance = model.blance - value;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Refund(long id, long value)
        {
            try
            {
                var model = db.Account_blance.Find(id);
                model.blance = model.blance + value;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        public Account_blance Insert(long user_id)
        {
            var model = new Account_blance();
            model.blance = 0;
            model.id = user_id;
            db.Account_blance.Add(model);
            db.SaveChanges();
            return model;
        }
    }
}
