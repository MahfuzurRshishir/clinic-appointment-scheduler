using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class FileRecordRepo : Repo, IFileRecordRepo
    {
        public bool Create(FileRecord obj)
        {
            try
            {
                db.FileRecords.Add(obj);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<FileRecord> Read()
        {
            try
            {
                return db.FileRecords.ToList();
            }
            catch
            {
                return new List<FileRecord>();
            }
        }

        public FileRecord Read(int id)
        {
            try
            {
                return db.FileRecords.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Update(FileRecord obj)
        {
            try
            {
                var existing = db.FileRecords.Find(obj.FileRecordId);
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
                var fileRecord = db.FileRecords.Find(id);
                if (fileRecord == null) return false;
                db.FileRecords.Remove(fileRecord);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<FileRecord> GetFilesByPatientId(int patientId)
        {
            try
            {
                return db.FileRecords.Where(f => f.PatientId == patientId).ToList();
            }
            catch
            {
                return new List<FileRecord>();
            }
        }
        public List<FileRecord> GetFilesByAppointmentId(int appointmentId)
        {
            try
            {
                return db.FileRecords.Where(f => f.AppointmentId == appointmentId).ToList();
            }
            catch
            {
                return new List<FileRecord>();
            }
        }
    }
}
