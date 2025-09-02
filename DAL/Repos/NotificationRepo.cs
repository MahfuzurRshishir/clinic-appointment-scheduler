using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class NotificationRepo : Repo, INotificationRepo
    {
        public bool Create(Notification obj)
        {
            try
            {
                db.Notifications.Add(obj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Notification> Read()
        {
            try
            {
                return db.Notifications.ToList();
            }
            catch
            {
                return new List<Notification>();
            }
        }

        public Notification Read(int id)
        {
            try
            {
                return db.Notifications.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Notification obj)
        {
            try
            {
                var existing = db.Notifications.Find(obj.NotificationId);
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
                var notification = db.Notifications.Find(id);
                if (notification == null) return false;
                db.Notifications.Remove(notification);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Notification> GetNotificationsByUserId(int userId)
        {
            try
            {
                return db.Notifications.Where(n => n.UserId == userId).ToList();
            }
            catch
            {
                return new List<Notification>();
            }
        }

        public List<Notification> GetUnreadNotificationsByUserId(int userId)
        {
            try
            {
                return db.Notifications.Where(n => n.UserId == userId && !n.IsRead).ToList();
            }
            catch
            {
                return new List<Notification>();
            }
        }
        public void MarkAllAsRead(int userId)
        {
            try
            {
                var notifications = db.Notifications.Where(n => n.UserId == userId && !n.IsRead).ToList();
                foreach (var notification in notifications)
                {
                    notification.IsRead = true;
                }
                db.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }
        public List<Notification> GetAllByUserId(int userId)
        {
            try
            {
                return db.Notifications.Where(n => n.UserId == userId).ToList();
            }
            catch
            {
                return new List<Notification>();
            }
        }
    }
}
