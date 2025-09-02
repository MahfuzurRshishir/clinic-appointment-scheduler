using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, bool> UserRepo()
        {
            return new UserRepo();
        }
        public static IUserRepo CustomUserRepo()
        {
            return new UserRepo();
        }

        public static IRepo<Doctor, int, bool> DoctorRepo()
        {
            return new DoctorRepo();
        }
        public static IDoctorRepo CustomDoctorRepo()
        {
            return new DoctorRepo();
        }

        public static IRepo<Patient, int, bool> PatientRepo()
        {
            return new PatientRepo();
        }
        public static IPatientRepo CustomPatientRepo()
        {
            return new PatientRepo();
        }

        public static IRepo<Appointment, int, bool> AppointmentRepo()
        {
            return new AppointmentRepo();
        }

        public static IAppointmentRepo CustomAppointmentRepo()
        {
            return new AppointmentRepo();
        }

        public static IRepo<FileRecord, int, bool> FileRecordRepo()
        {
            return new FileRecordRepo();
        }
        public static IFileRecordRepo CustomFileRecordRepo()
        {
            return new FileRecordRepo();
        }

        public static IRepo<Notification, int, bool> NotificationRepo()
        {
            return new NotificationRepo();
        }
        public static INotificationRepo CustomNotificationRepo()
        {
            return new NotificationRepo();
        }

        public static IRepo<Email, int, bool> EmailLogRepo()
        {
            return new EmailRepo();
        }

        public static IEmailLogRepo CustomEmailLogRepo()
        {
            return new EmailRepo();
        }

    }
}
