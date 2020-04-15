using Model.Commons;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.DAO
{
    public class UserDAO
    {
        BookingTourDbContext db = null;
        public UserDAO()
        {
            db = new BookingTourDbContext();
        }
        // add new user
        public long Insert(User user)
        {
            user.permission = 1;
            db.Users.Add(user);
            db.SaveChanges();
            return user.id;
        }
        // authentication user
        public int authentication(string username, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.username == username);
            if (result == null)
            {
                return ACCOUNT.NOT_EXIST;
            }
            else
            {
                if (result.status == ACCOUNT.WAS_BANNED)
                {
                    return ACCOUNT.WAS_BANNED;
                }
                else
                {
                    if (result.password == password)
                    {
                        return ACCOUNT.LOGIN_SUCCESS;
                    }
                    else
                    {
                        return ACCOUNT.WRONG_PASSWORD;
                    }
                }
            }
        }
        // get ID
        public User getID(string username)
        {
            return db.Users.SingleOrDefault(x => x.username == username);
        }
        // Register an account
        // Get users list
        public IEnumerable<User> getUsers(int page, int pageSize, string keyword)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.username.Contains(keyword));
            }
            return model.OrderByDescending(x => x.permission).ToPagedList(page, pageSize);
        }

        // Update user
        public bool update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.id);
                user.address = entity.address;
                user.username = entity.username;
                user.password = entity.password;
                user.status = entity.status;
                /*user.email = entity.email;*/
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public User getViewDetail(long id)
        {
            var user = db.Users.Find(id);
            return user;
        }
        public bool Delete(long id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public int changeStatus(long id)
        {
            var user = db.Users.Find(id);
            if (user.status == 1)
            {
                user.status = 0;
            }
            else
            {
                user.status = 1;
            }
            db.SaveChanges();
            return user.status;
        }
        // Edit
        public bool Edit(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.id);
                if ((user.address == entity.address || entity.address == ""))
                    user.address = user.address;
                else
                    user.address = entity.address;
                //
                if ((user.username == entity.username || entity.username == ""))
                    user.username = user.username;
                else
                    user.username = entity.username;
                //
                if ((user.name == entity.name || entity.name == ""))
                    user.name = user.name;
                else
                    user.name = entity.name;
                //
                if ((user.password == entity.password || entity.password == ""))
                    user.password = user.password;
                else
                    user.password = entity.password;

                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
