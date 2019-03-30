using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_Layer.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Birth Year")]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="Passwords don't match")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
