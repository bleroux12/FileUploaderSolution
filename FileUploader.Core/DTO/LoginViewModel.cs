using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password has to be at least 6 characters in length")]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
