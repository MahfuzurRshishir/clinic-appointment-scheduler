using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class DoctorRepo : Repo, IDoctorRepo
    {
        public bool Create(Doctor obj)
        {
            try
            {
                db.Doctors.Add(obj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Doctor> Read()
        {
            try
            {
                return db.Doctors.ToList();
            }
            catch
            {
                return new List<Doctor>();
            }
        }

        public Doctor Read(int id)
        {
            try
            {
                return db.Doctors.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Doctor obj)
        {
            try
            {
                var existing = db.Doctors.Find(obj.DoctorId);
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
                var doctor = db.Doctors.Find(id);
                if (doctor == null) return false;
                db.Doctors.Remove(doctor);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public Doctor GetDoctorByUserId(int userId)
        {
            try
            {
                return db.Doctors.FirstOrDefault(d => d.UserId == userId);
            }
            catch
            {
                return null;
            }
        }

        public List<Doctor> GetDoctorsBySpecialization(string specialization)
        {
            try
            {
                return db.Doctors.Where(d => d.Specialization == specialization).ToList();
            }
            catch
            {
                return new List<Doctor>();
            }
        }

        public List<Doctor> SearchDoctors(string searchTerm)
        {
            try
            {
                return db.Doctors
                    .Where(d => d.Name.Contains(searchTerm) ||
                                d.Specialization.Contains(searchTerm) ||
                                d.Qualifications.Contains(searchTerm))
                    .ToList();
            }
            catch
            {
                return new List<Doctor>();
            }
        }
    }
}
