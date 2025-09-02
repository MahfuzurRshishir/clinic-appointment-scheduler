using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public class AppointmentService
    {
        // Get all appointments
        public static List<AppointmentDTO> Get()
        {
            var data = DataAccessFactory.AppointmentRepo().Read();
            return data.Select(a => MapToDTO(a)).ToList();
        }

        // Get appointment by ID
        public static AppointmentDTO Get(int id)
        {
            var appointment = DataAccessFactory.AppointmentRepo().Read(id);
            return appointment == null ? null : MapToDTO(appointment);
        }

        // Create appointment
        public static bool Create(AppointmentDTO dto)
        {
            var appointment = MapToEntity(dto);
            return DataAccessFactory.AppointmentRepo().Create(appointment);
        }




        // Update appointment
        public static bool Update(AppointmentDTO dto)
        {
            var appointment = MapToEntity(dto);
            return DataAccessFactory.AppointmentRepo().Update(appointment);
        }
        // Delete appointment
        public static bool Delete(int id)
        {
            return DataAccessFactory.AppointmentRepo().Delete(id);
        }

        public static List<AppointmentDTO> GetByDoctorId(int doctorId)
        {
            var data = DataAccessFactory.CustomAppointmentRepo().GetAppointmentsByDoctorId(doctorId);
            return data.Select(MapToDTO).ToList();
        }

        public static List<AppointmentDTO> GetByPatientId(int patientId)
        {
            var data = DataAccessFactory.CustomAppointmentRepo().GetAppointmentsByPatientId(patientId);
            return data.Select(MapToDTO).ToList();
        }

        public static List<AppointmentDTO> Search(string status = null)
        {
            var data = DataAccessFactory.CustomAppointmentRepo().SearchAppointments(status);
            return data.Select(MapToDTO).ToList();
        }

        // Map Appointment entity to AppointmentDTO
        private static AppointmentDTO MapToDTO(Appointment a)
        {
            return new AppointmentDTO
            {
                AppointmentId = a.AppointmentId,
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status,
                Reason = a.Reason,
                Notes = a.Notes,
                CreatedAt = a.CreatedAt
            };
        }
        // Map AppointmentDTO to Appointment entity
        private static Appointment MapToEntity(AppointmentDTO dto)
        {
            return new Appointment
            {
                AppointmentId = dto.AppointmentId,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                Status = dto.Status,
                Reason = dto.Reason,
                Notes = dto.Notes,
                CreatedAt = dto.CreatedAt == default(DateTime) ? DateTime.Now : dto.CreatedAt
            };
        }
    }
}
