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
    public class DoctorService
    {
        // Get all doctors
        public static List<DoctorDTO> Get()
        {
            var data = DataAccessFactory.DoctorRepo().Read();
            return data.Select(d => MapToDTO(d)).ToList();
        }

        // Get doctor by ID
        public static DoctorDTO Get(int id)
        {
            var doctor = DataAccessFactory.DoctorRepo().Read(id);
            return doctor == null ? null : MapToDTO(doctor);
        }

        public static DoctorDTO GetByUserId(int userId)
        {
            var doctor = DataAccessFactory.CustomDoctorRepo().GetDoctorByUserId(userId);
            return doctor == null ? null : MapToDTO(doctor);
        }

        public static List<DoctorDTO> Search(string term)
        {
            var data = DataAccessFactory.CustomDoctorRepo().SearchDoctors(term);
            return data.Select(MapToDTO).ToList();
        }

        // Create doctor
        public static bool Create(DoctorDTO dto)
        {
            var doctor = MapToEntity(dto);
            return DataAccessFactory.DoctorRepo().Create(doctor);
        }
        // Update doctor
        public static bool Update(DoctorDTO dto)
        {
            var doctor = MapToEntity(dto);
            return DataAccessFactory.DoctorRepo().Update(doctor);
        }

        // Delete doctor
        public static bool Delete(int id)
        {
            return DataAccessFactory.DoctorRepo().Delete(id);
        }
        // Map Doctor entity to DoctorDTO
        private static DoctorDTO MapToDTO(Doctor d)
        {
            return new DoctorDTO
            {
                DoctorId = d.DoctorId,
                UserId = d.UserId,
                Name = d.Name,
                Specialization = d.Specialization,
                Qualifications = d.Qualifications,
                ExperienceYears = d.ExperienceYears,
                ClinicRoom = d.ClinicRoom
            };
        }
        // Map DoctorDTO to Doctor entity
        private static Doctor MapToEntity(DoctorDTO dto)
        {
            return new Doctor
            {
                DoctorId = dto.DoctorId,
                UserId = dto.UserId,
                Name = dto.Name,
                Specialization = dto.Specialization,
                Qualifications = dto.Qualifications,
                ExperienceYears = dto.ExperienceYears,
                ClinicRoom = dto.ClinicRoom
            };
        }
    }
}
