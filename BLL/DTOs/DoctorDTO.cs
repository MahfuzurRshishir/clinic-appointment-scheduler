using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Specialization { get; set; }

        [StringLength(200)]
        public string Qualifications { get; set; }

        [Range(0, 100)]
        public int? ExperienceYears { get; set; }

        [StringLength(50)]
        public string ClinicRoom { get; set; }
    }
}
