using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IPatientRepo : IRepo<Patient, int, bool>
    {
        Patient GetPatientByUserId(int userId);
        List<Patient> SearchPatients(string searchTerm);
    }
}
