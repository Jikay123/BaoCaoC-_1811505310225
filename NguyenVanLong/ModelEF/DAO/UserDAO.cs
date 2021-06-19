using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
//using PagedList;

namespace ModelEF.DAO
{
    public class UserDAO
    {
        private NguyenVanLongContext db = null;
        public UserDAO()
        {
            db = new NguyenVanLongContext();
        }
        public int login(string user, string pass)
        {
            var kq = db.UserAccounts.SingleOrDefault(x => x.UserName.Equals(user) && x.Password.Equals(pass) 
            && x.Status.Equals("activate"));
            if (kq == null)
            {
                return 0;
            }
            else
            {
                return 1;
          
            }
        }

        public string Insert(UserAccount entityUser)
        {
            db.UserAccounts.Add(entityUser);
            db.SaveChanges();
            return entityUser.UserName;
        }

        public bool Update(UserAccount entityUser)
        {
            try
            {
                var user = Find(entityUser.ID);
                user.UserName = entityUser.UserName;
                if (!string.IsNullOrEmpty(entityUser.Password))
                {
                    user.Password = entityUser.Password;
                }
                user.Status = entityUser.Status;
         
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Status(string ID)
        {
            try
            {
                var user = Find(ID);
                if (user.Status == "activate")
                {
                    user.Status = "blocked";
                }
                else
                {
                    user.Status = "activate";
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string ID)
        {
            try
            {
                UserAccount user = db.UserAccounts.Find(ID);
                if(user.Status == "activate")
                {
                    return false;
                }
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public UserAccount Find(string id)
        {
            return db.UserAccounts.Find(id);
        }

        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.OrderBy(x=>x.UserName).ToList();
        }

        public IEnumerable<UserAccount> ListWhereAll(string searchKey, int page, int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(searchKey))
            {
                model = model.Where(x => x.UserName.Contains(searchKey));
            }
            return model.OrderBy(x => x.UserName);
          
        }

        public string ChangeStatus(string ID)
        {
            var user = db.UserAccounts.Find(ID);
            if (user.Status == "activate")
            {
                user.Status = "blocked";
            }
            else
            {
                user.Status = "activate";
            }
            return user.Status;
        }


    }
}
