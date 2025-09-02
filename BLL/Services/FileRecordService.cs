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
    public class FileRecordService
    {
        // Get all file records
        public static List<FileRecordDTO> Get()
        {
            var data = DataAccessFactory.FileRecordRepo().Read();
            return data.Select(f => MapToDTO(f)).ToList();
        }

        // Get file record by ID
        public static FileRecordDTO Get(int id)
        {
            var file = DataAccessFactory.FileRecordRepo().Read(id);
            return file == null ? null : MapToDTO(file);
        }

        // Create file record
        public static bool Create(FileRecordDTO dto)
        {
            var file = MapToEntity(dto);
            return DataAccessFactory.FileRecordRepo().Create(file);
        }

        // Update file record
        public static bool Update(FileRecordDTO dto)
        {
            var file = MapToEntity(dto);
            return DataAccessFactory.FileRecordRepo().Update(file);
        }
        // Delete file record
        public static bool Delete(int id)
        {
            return DataAccessFactory.FileRecordRepo().Delete(id);
        }

        // Get file records by patient ID
        public static List<FileRecordDTO> GetByPatientId(int patientId)
        {
            var data = DataAccessFactory.CustomFileRecordRepo().GetFilesByPatientId(patientId);
            return data.Select(f => MapToDTO(f)).ToList();
        }

        // Get file records by appointment ID
        public static List<FileRecordDTO> GetByAppointmentId(int appointmentId)
        {
            var data = DataAccessFactory.CustomFileRecordRepo().GetFilesByAppointmentId(appointmentId);
            return data.Select(f => MapToDTO(f)).ToList();
        }
        // Map FileRecord entity to FileRecordDTO
        private static FileRecordDTO MapToDTO(FileRecord f)
        {
            return new FileRecordDTO
            {
                FileRecordId = f.FileRecordId,
                AppointmentId = f.AppointmentId,
                PatientId = f.PatientId,
                FileName = f.FileName,
                FilePath = f.FilePath,
                FileType = f.FileType,
                UploadedAt = f.UploadedAt
            };
        }
        // Map FileRecordDTO to FileRecord entity
        private static FileRecord MapToEntity(FileRecordDTO dto)
        {
            return new FileRecord
            {
                FileRecordId = dto.FileRecordId,
                AppointmentId = dto.AppointmentId,
                PatientId = dto.PatientId,
                FileName = dto.FileName,
                FilePath = dto.FilePath,
                FileType = dto.FileType,
                UploadedAt = dto.UploadedAt
            };
        }
    }
}
