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
    public class PatientService
    {
        // Get all patients
        public static List<PatientDTO> Get()
        {
            var data = DataAccessFactory.PatientRepo().Read();
            return data.Select(p => MapToDTO(p)).ToList();
        }

        // Get patient by ID
        public static PatientDTO Get(int id)
        {
            var patient = DataAccessFactory.PatientRepo().Read(id);
            return patient == null ? null : MapToDTO(patient);
        }

        // Create patient
        public static bool Create(PatientDTO dto)
        {
            var patient = MapToEntity(dto);
            return DataAccessFactory.PatientRepo().Create(patient);
        }

        // Update patient
        public static bool Update(PatientDTO dto)
        {
            var patient = MapToEntity(dto);
            return DataAccessFactory.PatientRepo().Update(patient);
        }
        // Delete patient
        public static bool Delete(int id)
        {
            return DataAccessFactory.PatientRepo().Delete(id);
        }

        public static PatientDTO GetByUserId(int userId)
        {
            var patient = DataAccessFactory.CustomPatientRepo().GetPatientByUserId(userId);
            return patient == null ? null : MapToDTO(patient);
        }

        public static List<PatientDTO> Search(string term)
        {
            var data = DataAccessFactory.CustomPatientRepo().SearchPatients(term);
            return data.Select(MapToDTO).ToList();
        }


        // Map Patient entity to PatientDTO
        private static PatientDTO MapToDTO(Patient p)
        {
            return new PatientDTO
            {
                PatientId = p.PatientId,
                UserId = p.UserId,
                Name = p.Name,
                Gender = p.Gender,
                EmergencyContact = p.EmergencyContact,
                MedicalHistory = p.MedicalHistory,
                DateOfBirth = p.DateOfBirth,
                Address = p.Address
            };
        }
        // Map PatientDTO to Patient entity
        private static Patient MapToEntity(PatientDTO dto)
        {
            return new Patient
            {
                PatientId = dto.PatientId,
                UserId = dto.UserId,
                Name = dto.Name,
                Gender = dto.Gender,
                EmergencyContact = dto.EmergencyContact,
                MedicalHistory = dto.MedicalHistory,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address
            };
        }

    }
}
