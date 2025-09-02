using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class EmailRepo : Repo, IEmailLogRepo
    {
        public bool Create(Email obj)
        {
            try
            {
                db.EmailLogs.Add(obj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Email> Read()
        {
            try
            {
                return db.EmailLogs.ToList();
            }
            catch
            {
                return new List<Email>();
            }
        }

        public Email Read(int id)
        {
            try
            {
                return db.EmailLogs.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Email obj)
        {
            try
            {
                var existing = db.EmailLogs.Find(obj.EmailLogId);
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
                var email = db.EmailLogs.Find(id);
                if (email == null) return false;
                db.EmailLogs.Remove(email);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Email> GetLogsByUserId(int userId)
        {
            try
            {
                return db.EmailLogs.Where(e => e.UserId == userId).ToList();
            }
            catch
            {
                return new List<Email>();
            }
        }

        public List<Email> GetFailedEmails()
        {
            try
            {
                return db.EmailLogs.Where(e => !e.IsSuccess).ToList();
            }
            catch
            {
                return new List<Email>();
            }
        }
    }
}
