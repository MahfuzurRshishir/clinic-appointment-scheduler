using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IEmailLogRepo : IRepo<Email, int, bool>
    {
        List<Email> GetLogsByUserId(int userId);
    }
}
