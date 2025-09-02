using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public class NotificationService
    {
        // Get all notifications
        public static List<NotificationDTO> Get()
        {
            var data = DataAccessFactory.NotificationRepo().Read();
            return data.Select(n => MapToDTO(n)).ToList();
        }

        // Get notification by ID
        public static NotificationDTO Get(int id)
        {
            var notification = DataAccessFactory.NotificationRepo().Read(id);
            return notification == null ? null : MapToDTO(notification);
        }

        // Create notification
        public static bool Create(NotificationDTO dto)
        {
            var notification = MapToEntity(dto);
            return DataAccessFactory.NotificationRepo().Create(notification);
        }

        // Update notification
        public static bool Update(NotificationDTO dto)
        {
            var notification = MapToEntity(dto);
            return DataAccessFactory.NotificationRepo().Update(notification);
        }

        // Delete notification
        public static bool Delete(int id)
        {
            return DataAccessFactory.NotificationRepo().Delete(id);
        }

        // Get all notifications for a user
        public static List<NotificationDTO> GetAllByUserId(int userId)
        {
            var data = DataAccessFactory.CustomNotificationRepo().GetAllByUserId(userId);
            return data.Select(n => MapToDTO(n)).ToList();
        }
        // Get unread notifications for a user
        public static List<NotificationDTO> GetUnreadByUserId(int userId)
        {
            var data = DataAccessFactory.CustomNotificationRepo().GetUnreadNotificationsByUserId(userId);
            return data.Select(n => MapToDTO(n)).ToList();
        }

        // Mark all notifications as read for a user
        public static void MarkAllAsRead(int userId)
        {
            DataAccessFactory.CustomNotificationRepo().MarkAllAsRead(userId);
        }
        // Map Notification entity to NotificationDTO
        private static NotificationDTO MapToDTO(Notification n)
        {
            return new NotificationDTO
            {
                NotificationId = n.NotificationId,
                UserId = n.UserId,
                Message = n.Message,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt
            };
        }
        // Map NotificationDTO to Notification entity
        private static Notification MapToEntity(NotificationDTO dto)
        {
            return new Notification
            {
                NotificationId = dto.NotificationId,
                UserId = dto.UserId,
                Message = dto.Message,
                IsRead = dto.IsRead,
                CreatedAt = dto.CreatedAt == default(DateTime) ? DateTime.Now : dto.CreatedAt
            };
        }
    }
}
