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
    public class EmailService
    {
        // Get all emails
        public static List<EmailDTO> Get()
        {
            var data = DataAccessFactory.EmailLogRepo().Read();
            return data.Select(e => MapToDTO(e)).ToList();
        }

        // Get email by ID
        public static EmailDTO Get(int id)
        {
            var email = DataAccessFactory.EmailLogRepo().Read(id);
            return email == null ? null : MapToDTO(email);
        }

        // Create email
        public static bool Create(EmailDTO dto)
        {
            var email = MapToEntity(dto);
            return DataAccessFactory.EmailLogRepo().Create(email);
        }

        // Update email
        public static bool Update(EmailDTO dto)
        {
            var email = MapToEntity(dto);
            return DataAccessFactory.EmailLogRepo().Update(email);
        }
        // Delete email
        public static bool Delete(int id)
        {
            return DataAccessFactory.EmailLogRepo().Delete(id);
        }

        // Get emails by user ID
        public static List<EmailDTO> GetByUserId(int userId)
        {
            var data = DataAccessFactory.CustomEmailLogRepo().GetLogsByUserId(userId);
            return data.Select(e => MapToDTO(e)).ToList();
        }

        // Map Email entity to EmailDTO
        private static EmailDTO MapToDTO(Email e)
        {
            return new EmailDTO
            {
                EmailLogId = e.EmailLogId,
                UserId = e.UserId,
                EmailAddress = e.EmailAddress,
                Subject = e.Subject,
                Body = e.Body,
                SentAt = e.SentAt,
                IsSuccess = e.IsSuccess,
                ErrorMessage = e.ErrorMessage,
            };
        }
        // Map EmailDTO to Email entity
        private static Email MapToEntity(EmailDTO dto)
        {
            return new Email
            {
                EmailLogId = dto.EmailLogId,
                UserId = dto.UserId,
                EmailAddress = dto.EmailAddress,
                Subject = dto.Subject,
                Body = dto.Body,
                SentAt = dto.SentAt,
                IsSuccess = dto.IsSuccess,
                ErrorMessage = dto.ErrorMessage,
            };
        }
    }
}
