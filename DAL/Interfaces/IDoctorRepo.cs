using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IDoctorRepo : IRepo<Doctor, int, bool>
    {
        Doctor GetDoctorByUserId(int userId);
        List<Doctor> GetDoctorsBySpecialization(string specialization);
        List<Doctor> SearchDoctors(string searchTerm);
    }
}
