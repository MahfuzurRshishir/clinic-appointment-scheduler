using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class PatientRepo : Repo, IPatientRepo
    {
        public bool Create(Patient obj)
        {
            try
            {
                db.Patients.Add(obj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                // Log exception or handle as needed
                return false;
            }
        }

        public List<Patient> Read()
        {
            try
            {
                return db.Patients.ToList();
            }
            catch
            {
                return new List<Patient>();
            }
        }

        public Patient Read(int id)
        {
            try
            {
                return db.Patients.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Update(Patient obj)
        {
            try
            {
                var existing = db.Patients.Find(obj.PatientId);
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
                var patient = db.Patients.Find(id);
                if (patient == null) return false;
                db.Patients.Remove(patient);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public Patient GetPatientByUserId(int userId)
        {
            try
            {
                return db.Patients.FirstOrDefault(p => p.UserId == userId);
            }
            catch
            {
                return null;
            }
        }

        public List<Patient> SearchPatients(string searchTerm)
        {
            try
            {
                return db.Patients
                    .Where(p => p.Name.Contains(searchTerm) ||
                                p.Address.Contains(searchTerm) ||
                                p.EmergencyContact.Contains(searchTerm))
                    .ToList();
            }
            catch
            {
                return new List<Patient>();
            }
        }
    }
}
