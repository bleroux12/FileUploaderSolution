using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Core.DTO
{
    public class UserManagementChangePasswordViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]        
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
