using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IUserRepo
    {
        public bool Create(User obj)
        {
            try
            {
                db.Users.Add(obj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<User> Read()
        {
            try
            {
                return db.Users.ToList();
            }
            catch
            {
                return new List<User>();
            }
        }

        public User Read(int id)
        {
            try
            {
                return db.Users.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Update(User obj)
        {
            try
            {
                var existing = db.Users.Find(obj.UserId);
                if (existing == null) return false;
                db.Entry(existing).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                if (user == null) return false;
                db.Users.Remove(user);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return db.Users.FirstOrDefault(u => u.Email == email);
            }
            catch
            {
                return null;
            }
        }

        public List<User> GetUsersByRole(string role)
        {
            try
            {
                return db.Users.Where(u => u.Role == role).ToList();
            }
            catch
            {
                return new List<User>();
            }
        }
    }
}
