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
    public class UserService
    {
        // Get all users
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserRepo().Read();
            return data.Select(u => MapToDTO(u)).ToList();
        }

        // Get user by ID
        public static UserDTO Get(int id)
        {
            var user = DataAccessFactory.UserRepo().Read(id);
            return user == null ? null : MapToDTO(user);
        }

        // Create user
        public static bool Create(UserDTO dto)
        {
            var user = MapToEntity(dto);
            return DataAccessFactory.UserRepo().Create(user);
        }
        // Update users  all info

        public static bool Update(UserDTO dto)
        {
            var user = MapToEntity(dto);
            return DataAccessFactory.UserRepo().Update(user);
        }

        // Delete user
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserRepo().Delete(id);
        }
        // Map User entity to UserDTO
        private static UserDTO MapToDTO(User u)
        {
            return new UserDTO
            {
                UserId = u.UserId,
                Email = u.Email,
                Password = u.Password, 
                Role = u.Role
            };
        }

        // Map UserDTO to User entity
        private static User MapToEntity(UserDTO dto)
        {
            return new User
            {
                UserId = dto.UserId,
                Email = dto.Email,
                Password = dto.Password, 
                Role = dto.Role
            };
        }
    }
}
