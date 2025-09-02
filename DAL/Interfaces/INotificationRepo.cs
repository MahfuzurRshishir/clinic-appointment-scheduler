using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface INotificationRepo : IRepo<Notification, int, bool>
    {
        List<Notification> GetUnreadNotificationsByUserId(int userId);
        void MarkAllAsRead(int userId);
        List<Notification> GetAllByUserId(int userId);
    }
}
