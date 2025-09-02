using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FileRecordDTO
    {
        public int FileRecordId { get; set; }

        public int? AppointmentId { get; set; }

        public int? PatientId { get; set; }

        [Required, StringLength(200)]
        public string FileName { get; set; }

        [Required, StringLength(500)]
        public string FilePath { get; set; }

        [StringLength(50)]
        public string FileType { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}
