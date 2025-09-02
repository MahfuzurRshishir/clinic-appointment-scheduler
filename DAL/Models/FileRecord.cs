using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class FileRecord
    {
        [Key]
        public int FileRecordId { get; set; }

        [ForeignKey("Appointment")]
        public int? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
