using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IFileRecordRepo : IRepo<FileRecord, int, bool>
    {
        List<FileRecord> GetFilesByPatientId(int patientId);
        List<FileRecord> GetFilesByAppointmentId(int appointmentId);
    }
}
