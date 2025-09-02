using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 


namespace BLL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Role { get; set; }
    }
}
