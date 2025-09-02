using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUserRepo : IRepo<User, int, bool>
    {
        User GetUserByEmail(string email);
        List<User> GetUsersByRole(string role);
    }
}
