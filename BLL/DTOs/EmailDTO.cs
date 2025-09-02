using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmailDTO
    {
        public int EmailLogId { get; set; }

        public int? UserId { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string EmailAddress { get; set; }

        [StringLength(200)]
        public string Subject { get; set; }

        [StringLength(2000)]
        public string Body { get; set; }

        public DateTime SentAt { get; set; }

        public bool IsSuccess { get; set; }

        [StringLength(1000)]
        public string ErrorMessage { get; set; }

        public bool IsRead { get; set; }
    }
}
