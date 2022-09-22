using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class RegistrationViewModel
    {
        [Display(Name = "User Name")]
        [DataType(DataType.Text)]
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string UserName { get; set; }

        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Email { get; set; }

        [Display(Name = "Your Address")]
        [DataType(DataType.MultilineText)]
        [Required]
        [MaxLength(100)]
        [MinLength(7)]
        public string Address { get; set; }

        [Display(Name = "Age")]
        [DataType(DataType.Text)]
        [Required]
        public int Age { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [MaxLength(17)]
        [MinLength(5)]
        public string Phone { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        public string Password { set; get; }
    }
}
