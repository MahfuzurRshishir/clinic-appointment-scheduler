using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IAppointmentRepo : IRepo<Appointment, int, bool>
    {
        List<Appointment> GetAppointmentsByDoctorId(int doctorId, DateTime? date = null);
        List<Appointment> GetAppointmentsByPatientId(int patientId, DateTime? date = null);
        List<Appointment> SearchAppointments(string status);
    }
}
