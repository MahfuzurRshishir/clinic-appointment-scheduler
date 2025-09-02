using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class ClinicContext: DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<FileRecord> FileRecords { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Email> EmailLogs { get; set; }
    }
}
