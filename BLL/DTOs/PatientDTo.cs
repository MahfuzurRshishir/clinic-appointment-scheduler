using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PatientDTO
    {
        public int PatientId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(100)]
        public string EmergencyContact { get; set; }

        [StringLength(1000)]
        public string MedicalHistory { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(200)]
        
        public string Address { get; set; }
    }
}
