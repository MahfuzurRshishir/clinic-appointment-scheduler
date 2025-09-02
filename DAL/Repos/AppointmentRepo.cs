using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class AppointmentRepo : Repo, IAppointmentRepo
    {
        public bool Create(Appointment obj)
        {
            try
            {
                db.Appointments.Add(obj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Appointment> Read()
        {
            try
            {
                return db.Appointments.ToList();
            }
            catch
            {
                return new List<Appointment>();
            }
        }

        public Appointment Read(int id)
        {
            try
            {
                return db.Appointments.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Appointment obj)
        {
            try
            {
                var existing = db.Appointments.Find(obj.AppointmentId);
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
                var appointment = db.Appointments.Find(id);
                if (appointment == null) return false;
                db.Appointments.Remove(appointment);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Appointment> GetAppointmentsByDoctorId(int doctorId, DateTime? date = null)
        {
            try
            {
                var query = db.Appointments.Where(a => a.DoctorId == doctorId);
                if (date.HasValue)
                    query = query.Where(a => a.AppointmentDate.Date == date.Value.Date);
                return query.ToList();
            }
            catch
            {
                return new List<Appointment>();
            }
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId, DateTime? date = null)
        {
            try
            {
                var query = db.Appointments.Where(a => a.PatientId == patientId);
                if (date.HasValue)
                    query = query.Where(a => a.AppointmentDate.Date == date.Value.Date);
                return query.ToList();
            }
            catch
            {
                return new List<Appointment>();
            }
        }
        public List<Appointment> SearchAppointments(string status)
        {
            try
            {
                var query = db.Appointments.AsQueryable();
                if (!string.IsNullOrEmpty(status))
                    query = query.Where(a => a.Status == status);
                return query.ToList();
            }
            catch
            {
                return new List<Appointment>();
            }
        }
    }
}
