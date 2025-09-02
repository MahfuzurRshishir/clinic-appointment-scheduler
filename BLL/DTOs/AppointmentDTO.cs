using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
